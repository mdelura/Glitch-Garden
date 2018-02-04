using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    public enum Status
    {
        Success,
        Failure
    }


    Text _starsText;

    // Use this for initialization
    void Start()
    {
        _starsText = GetComponent<Text>();
        UpdateDisplay();
    }

    private int _stars = 100;

    public void AddStars(int amount)
    {
        _stars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if (amount <= _stars)
        {
            _stars -= amount;
            UpdateDisplay();
            return Status.Success;
        }

        return Status.Failure;
    }



    private void UpdateDisplay() => _starsText.text = _stars.ToString();

    // Update is called once per frame
    void Update()
    {

    }
}
