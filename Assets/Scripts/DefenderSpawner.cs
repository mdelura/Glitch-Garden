using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private GameObject _defendersParent;

    private StarDisplay _starDisplay;

    private void Start()
    {
        _defendersParent = Util.FindOrSpawn("Defenders");
        _starDisplay = FindObjectOfType<StarDisplay>();
    }

    private void OnMouseDown()
    {
        if (Button.SelectedDefender &&
            _starDisplay.UseStars(Button.SelectedDefender.GetComponent<Defender>().cost) == StarDisplay.Status.Success)
        {
            var newDefender = Instantiate(Button.SelectedDefender, GetSpawnPosition(), Quaternion.identity);
            newDefender.transform.parent = _defendersParent.transform;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        var mousePositionInWorldPoints = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(
            Mathf.Round(mousePositionInWorldPoints.x),
            Mathf.Round(mousePositionInWorldPoints.y));
    }
}
