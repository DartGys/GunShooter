using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyFollow : MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _navMeshAgent;
    private bool followFlag = true;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (followFlag)
        {
            //transform.position = Vector3.MoveTowards(transform.position, _target.position, 0.12f);
            _navMeshAgent.destination = _target.position;
        }
        transform.LookAt(_target.transform);
    }

    public void FollowFlag(bool flag) => followFlag = flag;
}
