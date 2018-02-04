using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravestoneDefender : Defender
{

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<Attacker>()?.IsAttacking ?? false)
        {
            _animator.SetTrigger(AnimParam.UnderAttackTrigger);
        }
    }

    class AnimParam
    {
        public const string UnderAttackTrigger = "Under Attack Trigger";
    }
}
