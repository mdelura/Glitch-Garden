using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attacker : Damageable
{
    public float seenEverySeconds;

    protected Animator animator;

    private float _currentSpeed;
    private GameObject _currentTarget;

    private bool _isAttacking;
    public bool IsAttacking
    {
        get
        {
            return _isAttacking;
        }
        set
        {
            if (_isAttacking != value)
            {
                _isAttacking = value;
                OnIsAttackingChanged(value);
            }
        }
    }

    protected virtual void OnIsAttackingChanged(bool value)
    {
        animator.SetBool(AnimatorParam.IsAttacking, value);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Defender>())
        {
            Attack(collider.gameObject);
        }
    }

    public void Attack(GameObject target)
    {
        _currentTarget = target;
        _currentTarget.GetComponent<IDamageable>().Destroyed += () => OnTargetDestroyed();
        IsAttacking = true;
    }

    private void OnTargetDestroyed()
    {
        IsAttacking = false;
    }

    public void SetSpeed(float speed) => _currentSpeed = speed;

    public void StrikeCurrentTarget(float damage)
    {
        _currentTarget?.GetComponent<IDamageable>()?.Damage(damage);
    }

    protected class AnimatorParam
    {
        public const string IsAttacking = "Is Attacking";
    }
}
