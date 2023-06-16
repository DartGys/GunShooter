using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFollow : MonoBehaviour
{
    private Transform _target;
    private bool followFlag = true;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (followFlag)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, 0.065f);
        }
        transform.LookAt(_target.transform);
    }

    public void FollowFlag(bool flag) => followFlag = flag;
}
