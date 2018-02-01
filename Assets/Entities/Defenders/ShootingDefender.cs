using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDefender : Defender
{
    public GameObject gun;

    public GameObject projectile;

    private void Shoot()
    {
        var newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = GameObject.Find("Projectiles").transform;

    }
}
