using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject enemyPrefab;

    float spawnTimer = 0;

    [SerializeField]
    float timeBetweenEnemySpawns = 2f; // hur ofta fiender "spawnar"

    void Update() 
    {
       spawnTimer += Time.deltaTime; // avgör när nästa fiende ska genereras

       if (spawnTimer > timeBetweenEnemySpawns)
       {
        Instantiate(enemyPrefab); // spawnar fienden
        spawnTimer = 0;           // startar om spawnTimer
       } 
    }
}
