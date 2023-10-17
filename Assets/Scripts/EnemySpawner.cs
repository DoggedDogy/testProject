using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyNumber;

    void Start()
    {
        for (int i =0; i < enemyNumber;  i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-26, 26), Random.Range(-19, 13), 0), Quaternion.identity);
        }
    }

}
