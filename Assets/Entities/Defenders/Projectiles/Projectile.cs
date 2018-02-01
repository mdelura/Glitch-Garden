using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var colliderAttacker = collider.GetComponent<Attacker>();
        if (colliderAttacker)
        {
            colliderAttacker.Damage(damage);
            Destroy(gameObject);
        }
    }
}
