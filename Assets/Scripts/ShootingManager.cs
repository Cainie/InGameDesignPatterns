using System;
using System.Collections;
using ObjectPool;
using UnityEngine;
using Weapons;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce = 20f;

    public event Action<WeaponType> ReloadEvent;

    private Rigidbody2D _rigidbody2D;
    private ObjectPooler _objectPooler;
    private Weapon _weapon;
    private BulletType _bulletType;
    private bool _emptyMagazine;
    private bool _stabilizing;
    private bool _reloading;

    public void ChangeWeapon(Weapon newWeapon)
    {
        _weapon = newWeapon;
        _bulletType = newWeapon.bulletType;
    }

    private void Start()
    {
        _objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
        if (!_emptyMagazine)
        {
            Shoot();
        } else
        {
            if (!_reloading)
            {
                StartCoroutine(WaitForReload());
            }
        }
    }

    private void Shoot()
    {
        if (!_stabilizing)
        {
            ShootBullet();
            _weapon.currentNumberOfBullets -= 1;
            if (_weapon.currentNumberOfBullets == 0)
            {
                _emptyMagazine = true;
            }
            StartCoroutine(WaitForWeaponStability());
        }
    }

    private IEnumerator WaitForReload()
    {
        _reloading = true;
        yield return new WaitForSeconds(_weapon.reloadTime);
        ReloadEvent?.Invoke(_weapon.weaponType);
        _emptyMagazine = false;
        _reloading = false;
    }
    
    private IEnumerator WaitForWeaponStability()
    {
        _stabilizing = true;
        yield return new WaitForSeconds(_weapon.nextBulletWaitTime);
        _stabilizing = false;
    }

    private void ShootBullet()
    {
        var bullet = _objectPooler.GetFromPool(_bulletType.ToString(), firePoint.transform.position, firePoint.rotation);
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector2.zero;
        bulletRigidbody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().StartDeactivation();
    }
}
