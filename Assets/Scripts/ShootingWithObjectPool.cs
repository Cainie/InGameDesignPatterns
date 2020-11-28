using System.Collections.Generic;
using UnityEngine;

public class ShootingWithObjectPool : MonoBehaviour
{
    
    [SerializeField] private int objectPoolCount;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce = 20f;
    
    
    private Rigidbody2D _rigidbody2D;
    private List<GameObject> _bulletsPool;
    

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        for (var i = 0; i < objectPoolCount; i++)
        {
            var instantiatedBulletPrefab = Instantiate(bulletPrefab);
            _bulletsPool.Add(instantiatedBulletPrefab);
        }
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
        Debug.Log("Shoot");
    }
}
