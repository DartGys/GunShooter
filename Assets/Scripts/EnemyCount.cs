using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyCount
{
    public static List<Transform> Enemies = new List<Transform>();

    public static void addEnemy(Transform enemy)
    {
        Enemies.Add(enemy);
    }
}
