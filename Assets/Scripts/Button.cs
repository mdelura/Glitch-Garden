using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Button : MonoBehaviour
{
    private GameObject _buttons;

    private void Start()
    {
        _buttons = GameObject.Find("Buttons");
    }


    private void OnMouseDown()
    {
        Debug.Log($"Button {name} clicked.");

        foreach (var spriteRenderer in _buttons.GetComponentsInChildren<SpriteRenderer>())
        {
            
            float alpha = spriteRenderer.gameObject == gameObject ? 1 : 0.3f;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
        } 
    }
}
