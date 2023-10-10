using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public string[] enemyNames;
    public GameObject[] enemyTypes;

    public List <GameObject> enemies;
    public string killCondition = "Two";
    private void Start()
    {
        //spawnEnemies();
        SpawnAtRandom();
      
        
        
        GameObject first = Instantiate(enemyTypes[0], spawnPoints[0].position, spawnPoints[0].rotation);
        first.name = enemyNames[0];

        int lastEnemy = enemyTypes.Length - 1;
        GameObject last = Instantiate(enemyTypes[lastEnemy], spawnPoints[lastEnemy].position, spawnPoints[lastEnemy].rotation);
        last.name = enemyNames[lastEnemy];

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            SpawnAtRandom();
        if (Input.GetKeyDown(KeyCode.K))
            KillEnemy(enemies[0]);
        if (Input.GetKeyDown(KeyCode.P))
            KillSpecificEnemy(killCondition);
    }

    /// <summary>
    /// Spawns an enemy at every spawn point
    /// </summary>

    void spawnEnemies()
    {
        
        
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int rnd = Random.Range(0, enemyTypes.Length);
            GameObject first = Instantiate(enemyTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }
    /// <summary>
    /// Spawns a random enemy to random spawn point
    /// </summary>

    void SpawnAtRandom()
    {

        int rndenemy = Random.Range(0, enemyTypes.Length);
        int rndspawn = Random.Range(0, enemyTypes.Length);
        GameObject enemy = Instantiate(enemyTypes[rndenemy], spawnPoints[rndspawn].position, spawnPoints[rndspawn].rotation);
        enemies.Add(enemy);
        ShowEnemyCount();
        
    }
    /// <summary>
    /// Shows the amout of enemies in the stage 
    /// </summary>
    void ShowEnemyCount()
    {
        print("Number of enemies: " + enemies.Count);
    }

    /// <summary>
    /// Kills a sprcific enemy 
    /// </summary>
    /// <param name="_enemy">The enemy we want to kill</param>

    void KillEnemy(GameObject _enemy)
    {
        if (enemies.Count == 0)
            return;
        Destroy(_enemy);
        enemies.Remove(_enemy);
        ShowEnemyCount();
    }

    /// <summary>
    /// Kills all enemies
    /// </summary>

    void KillAllEnemies()
    {
        if (enemies.Count == 0)
            return;
        for(int i = enemies.Count - 1; i >= 0; i--)
        {
            KillEnemy(enemies[i]);
        }
        
    }

    /// <summary>
    /// Kills specific enemy
    /// </summary>
    /// <param name="_conditon">The condioton of the enemy we want to kill</param>

    void KillSpecificEnemy(string _conditon)
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].name.Contains(_conditon))
                KillEnemy(enemies[i]);
        }
    }
    void Example()
    {
        int numberRepetitions = 2000;
        for (int i = 0; i <= numberRepetitions; i++)
        {
            print(i);
        }
        //Create a loop within a loop for a wall
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        for (int i = 1; i < 10; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                Instantiate(wall, new Vector3(i, 0, 0), transform.rotation);
            }

        }
    }





}
