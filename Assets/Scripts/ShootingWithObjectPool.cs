using System;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWithObjectPool : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce = 20f;
    
    
    private Rigidbody2D _rigidbody2D;
    private List<GameObject> _bulletsPool;
    private ObjectPooler _objectPooler;

    private void Awake()
    {
        _objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = _objectPooler.GetFromPool("bullet", firePoint.transform.position, firePoint.rotation);
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().StartDeactivation();
    }
}
