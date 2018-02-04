using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingAttacker : Attacker
{
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<GravestoneDefender>())
            animator.SetTrigger(AnimatorParamJumping.JumpTrigger);
        else
        {
            base.OnTriggerEnter2D(collider);
        }
    }

    class AnimatorParamJumping
    {
        public const string JumpTrigger = "Jump Trigger";
    }
}
