using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    public GameObject[] attackerPrefabs;

    [Tooltip("Maximum number of simultaneous attackers.")]
    public int maxAttackers = 3;

    [Range(0, 1f)]
    public float increaseSpawnRateAfter = 0.75f;

    float _spawnXPos = 12;

    private Dictionary<GameObject, float> _lastSpawnTimes;
    private GameTimer _gameTimer;

    // Use this for initialization
    void Start()
    {
        _lastSpawnTimes = attackerPrefabs
            .ToDictionary(a => a, a => Random.Range(-1f, 0));
        _gameTimer = FindObjectOfType<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var attacker in attackerPrefabs)
        {
            if (IsTimeToSpawn(attacker) && 
                !IsLevelFinished())
            {
                Spawn(attacker);
            }
        }
    }

    private bool IsLevelFinished() => _gameTimer.TimeLeft <= 0;

    void Spawn(GameObject attacker)
    {
        _lastSpawnTimes[attacker] = Time.timeSinceLevelLoad;

        var newAttacker = Instantiate(attacker, new Vector3(_spawnXPos, Random.Range(1, 6)), Quaternion.identity);
        newAttacker.transform.parent = transform;
    }


    bool IsTimeToSpawn(GameObject attacker)
    {
        var spawnRate = attacker.GetComponent<Attacker>().seenEverySeconds / (SpawnRateIncreased() ? 2 : 1);
        return Time.timeSinceLevelLoad - _lastSpawnTimes[attacker] >= spawnRate;
    }

    bool SpawnRateIncreased() => Time.timeSinceLevelLoad / _gameTimer.levelLenghtInSecs >= increaseSpawnRateAfter;
}
