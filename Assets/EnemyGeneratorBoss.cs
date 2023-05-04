using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorBoss : MonoBehaviour
{
     [SerializeField]
    GameObject enemyPrefab;

    float spawnTimer = 0;

    [SerializeField]
    float timeBetweenEnemySpawns = 0.1f; // när "BossScenen" är igång så spawnar fiender snabbare genom denna separata "Spawner"

    void Update() // samma som vanliga EnemyGenerator fast snabbare
    {
       spawnTimer += Time.deltaTime;

       if (spawnTimer > timeBetweenEnemySpawns) // får fiender att "spawna"
       {
        Instantiate(enemyPrefab);
        spawnTimer = 0;
       } 
    }
}
