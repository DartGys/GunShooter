using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 offset;
    [SerializeField] float Y, Z;

    void Start()
    {
        offset = new Vector3(0, Y, Z);
    }

    void LateUpdate()
    {
        transform.position = _player.position + offset;
    }
}
