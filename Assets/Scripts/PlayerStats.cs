using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public event Action<float> HealthBarChanged;
    private float _health;

    void Start()
    {
        _health = 100f;
    }


    private void HealthCalculate()
    {
        HealthBarChanged?.Invoke(_health / 100);
    }

    public void PlayerHit(float damage)
    {
        Debug.Log("Health: " + _health);
        if (_health - damage > 0)
        {
            _health -= damage;
        }

        HealthCalculate();
    }

}
