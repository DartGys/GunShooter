using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    [SerializeField] private FixedJoystick fireJoystick;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Pistol _pistol;
    [SerializeField] private GameObject _line;

    private Guns _guns;

    public void Start()
    {
        _guns = _pistol;
    }

    public void FixedUpdate()
    {
        if (fireJoystick.Horizontal != 0 || fireJoystick.Vertical != 0)
        {
            _line.SetActive(true);
            Vector3 target = new Vector3(fireJoystick.Horizontal, 0, fireJoystick.Vertical);
            transform.rotation = Quaternion.LookRotation(target);
            _guns.Shoot(() => Shoot(target));
        }
        else
        {
            _line.SetActive(false);
        }
    }

    private void Shoot(Vector3 target)
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        var newBullet = Instantiate(_bullet, spawnPos, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(target.normalized * 25, ForceMode.Impulse);
    }
}
