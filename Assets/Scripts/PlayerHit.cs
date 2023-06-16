using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    bool attackFlag = true;

    private PlayerStats _playerStats;
    private EnemyFollow _enemyFollow;

    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        _playerStats = player.GetComponent<PlayerStats>();

        _enemyFollow = gameObject.GetComponent<EnemyFollow>();
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Player" && attackFlag)
        {
            var damage = Random.Range(5f, 25f);
            _playerStats.PlayerHit(damage);
            Debug.Log("Damage: " + damage);
            attackFlag = false;
            _enemyFollow.FollowFlag(attackFlag);
            StartCoroutine("AttackCoolDown");
        }
    }

    IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(1.5f);
        attackFlag = true;
        _enemyFollow.FollowFlag(attackFlag);
    }
}
