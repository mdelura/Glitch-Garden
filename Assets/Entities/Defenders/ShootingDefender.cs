using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDefender : Defender
{
    public GameObject gun;
    public GameObject projectile;

    private GameObject _projectileParent;

    private void Start()
    {
        _projectileParent = Util.FindOrSpawn("Projectiles");
    }


    private void Shoot()
    {
        var newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = _projectileParent.transform;
    }
}
