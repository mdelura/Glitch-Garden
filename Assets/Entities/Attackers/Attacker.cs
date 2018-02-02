using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attacker : Damageable
{
    public float seenEverySeconds;

    private float _currentSpeed;



    private GameObject _currentTarget;

    public event Action TargetDestroyed;

    private void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
    }

    public void Attack(GameObject target)
    {
        _currentTarget = target;
        _currentTarget.GetComponent<IDamageable>().Destroyed += () => TargetDestroyed?.Invoke();
    }

    public void SetSpeed(float speed) => _currentSpeed = speed;

    public void StrikeCurrentTarget(float damage)
    {
        _currentTarget?.GetComponent<IDamageable>()?.Damage(damage);
    }
}
