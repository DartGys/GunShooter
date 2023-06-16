using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public float Damage { get; set; }
    public int Magazine { get; set; }
    protected int CurMagazine { get; set; }
    public float Reload { get; set; }
    private float BulletInterval { get; set; }

    private bool bulletIntervalFlag = true;

    public Guns(float damage, int magazine, float reload, float bulletInterval)
    {
        this.Damage = damage;
        this.Magazine = magazine;
        this.CurMagazine = magazine;
        this.Reload = reload;
        this.BulletInterval = bulletInterval;
    }

    public IEnumerator ReloadTime()
    {
        Debug.Log("Reload");
        yield return new WaitForSeconds(Reload);
        CurMagazine = Magazine;
    }

    public IEnumerator BulletIntervalTime()
    {
        bulletIntervalFlag = false;
        Debug.Log("BulletIntervalTime");
        yield return new WaitForSeconds(BulletInterval);
        bulletIntervalFlag = true;

    }

    public void Shoot(Action Shooting)
    {
        Debug.Log($"ammo: {CurMagazine}");
        if (CurMagazine > 0 && bulletIntervalFlag == true)
        {
            Debug.Log("Shoot");
            Shooting();
            CurMagazine--;
            StartCoroutine("BulletIntervalTime");
        }
        else if (CurMagazine <= 0)
        {
            StartCoroutine("ReloadTime");
        }
    }
}


