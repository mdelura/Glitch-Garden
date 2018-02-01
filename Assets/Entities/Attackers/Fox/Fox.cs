using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    private Animator _animator;
    private Attacker _attacker;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _attacker = GetComponent<Attacker>();
        _attacker.TargetDestroyed += _attacker_TargetDestroyed;
    }

    private void _attacker_TargetDestroyed()
    {
        _animator.SetBool(AnimatorParam.IsAttacking, false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<GravestoneDefender>())
            _animator.SetTrigger(AnimatorParam.JumpTrigger);
        else if (collider.gameObject.GetComponent<Defender>())
        {
            _animator.SetBool(AnimatorParam.IsAttacking, true);
            _attacker.Attack(collider.gameObject);
        }
    }

    class AnimatorParam
    {
        public const string IsAttacking = "Is Attacking";
        public const string JumpTrigger = "Jump Trigger";
    }
}
