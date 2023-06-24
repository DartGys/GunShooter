using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("BulletLifeTime");
    }

    IEnumerator BulletLifeTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
