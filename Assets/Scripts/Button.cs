using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private GameObject _buttons;

    public GameObject associatedDefender;

    private Text _costText;

    public static GameObject SelectedDefender { get; private set; }

    private void Start()
    {
        _buttons = GameObject.Find("Buttons");
        GetComponentInChildren<Text>().text = associatedDefender.GetComponent<Defender>().cost.ToString();
    }

    private void OnMouseDown()
    {
        Debug.Log($"Button {name} clicked.");

        SelectedDefender = associatedDefender;

        foreach (var spriteRenderer in _buttons.GetComponentsInChildren<SpriteRenderer>())
        {
            float alpha = spriteRenderer.gameObject == gameObject ? 1 : 0.3f;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
        } 
    }
}
