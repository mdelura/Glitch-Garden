using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : Damageable
{
    public int cost = 100;

    private StarDisplay _starDisplay;



    private void Start()
    {
        _starDisplay = FindObjectOfType<StarDisplay>();
    }

    private void AddStars(int amount) => _starDisplay.AddStars(amount);

    protected class AnimatorParam
    {
        public const string IsAttacking = "Is Attacking";
    }
}
