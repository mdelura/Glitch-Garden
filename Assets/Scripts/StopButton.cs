using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopButton : MonoBehaviour
{
    private void OnMouseDown() => SceneManager.LoadScene("00_1_Start");
}
