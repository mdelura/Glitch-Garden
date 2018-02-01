using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    public float health = 100;


    public event Action Destroyed;

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
