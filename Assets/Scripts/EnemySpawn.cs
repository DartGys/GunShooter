using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            var newEnemy = Instantiate(_enemy, new Vector3(Random.Range(-49, 49), 1.5f, Random.Range(-49, 49)), Quaternion.identity);
            EnemyCount.addEnemy(newEnemy.transform);
            yield return new WaitForSeconds(5f);
        }
    }
}
