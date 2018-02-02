using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    public GameObject[] attackerPrefabs;

    [Tooltip("Maximum number of simultaneous attackers.")]
    public int maxAttackers = 3;

    float _spawnXPos = 12;

    private Dictionary<GameObject, float> _lastSpawnTimes;


    // Use this for initialization
    void Start()
    {
        _lastSpawnTimes = attackerPrefabs
            .ToDictionary(a => a, a => Random.Range(-1f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var attacker in attackerPrefabs)
        {
            if (IsTimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }
    }

    void Spawn(GameObject attacker)
    {
        _lastSpawnTimes[attacker] = Time.realtimeSinceStartup;

        var newAttacker = Instantiate(attacker, new Vector3(_spawnXPos, Random.Range(1, 6)), Quaternion.identity);
        newAttacker.transform.parent = transform;
    }

    bool IsTimeToSpawn(GameObject attacker)
    {
        var spawnRate = attacker.GetComponent<Attacker>().seenEverySeconds;
        return Time.realtimeSinceStartup - _lastSpawnTimes[attacker] >= spawnRate;
    }
}
