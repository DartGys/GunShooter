using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("Hit");
        if (EnemyCount.Enemies.Contains(obj.transform))
        {
            EnemyCount.Enemies.Remove(obj.transform);
            Destroy(obj.gameObject);
            Destroy(gameObject);
        }
    }
}
