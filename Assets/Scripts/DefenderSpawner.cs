using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private GameObject _defendersParent;


    private void Start()
    {
        _defendersParent = Util.FindOrSpawn("Defenders");
    }

    private void OnMouseDown()
    {
        print(GetSpawnPosition());
        var pos = GetSpawnPosition();

        print($"X: {Mathf.Round(pos.x)}, Y: {Mathf.Round(pos.y)}");
        if (Button.SelectedDefender)
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
