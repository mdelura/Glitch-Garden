using System.Linq;
using UnityEngine;

public class ShootingDefender : Defender
{
    const float startShootingXPos = 9;

    public GameObject gun;
    public GameObject projectile;

    private GameObject _projectileParent;

    private GameObject _attackerSpawner;
    private int _lane;


    private Animator _animator;

    private void Start()
    {
        _projectileParent = Util.FindOrSpawn("Projectiles");
        _animator = GetComponent<Animator>();

        _attackerSpawner = GameObject.Find("AttackerSpawner");
        _lane = GetLane(transform.position);
    }

    private int GetLane(Vector3 position) => Mathf.RoundToInt(position.y);

    private void Update()
    {
        _animator.SetBool(AnimatorParam.IsAttacking, IsAttackerAheadInLane());
    }

    private bool IsAttackerAheadInLane()
    {
        return _attackerSpawner.transform
            .Cast<Transform>()
            .Any(t => GetLane(t.position) == _lane &&
                t.position.x > transform.position.x &&
                t.position.x <= startShootingXPos);
    }

    private void Shoot()
    {
        var newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = _projectileParent.transform;
    }
}
