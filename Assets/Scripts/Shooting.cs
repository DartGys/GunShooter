using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Pistol _pistol;
    private Guns _guns;

    public void Start()
    {
        _guns = _pistol;
    }

    public void FixedUpdate()
    {
        if (fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
        {
            Vector3 target = new Vector3(fixedJoystick.Horizontal, 0, fixedJoystick.Vertical);
            transform.rotation = Quaternion.LookRotation(target);
            _guns.Shoot(() => Shoot(target));
        }
    }

    private void Shoot(Vector3 target)
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        var newBullet = Instantiate(_bullet, spawnPos, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(target.normalized * 25, ForceMode.Impulse);
    }
}
