using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Weapons
{
    public class WeaponsManager : SerializedMonoBehaviour
    {
        [SerializeField] Dictionary<WeaponType, Weapon> _weapons;
        [SerializeField] private ShootingManager _shootingManager;

        private void OnEnable()
        {
            _shootingManager.ReloadEvent += ReloadEventWeapon;
        }

        private void Awake()
        {
            _shootingManager.ChangeWeapon(_weapons[WeaponType.MachineGun]);
        }

        private void OnDisable()
        {
            _shootingManager.ReloadEvent -= ReloadEventWeapon;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _shootingManager.ChangeWeapon(_weapons[WeaponType.MachineGun]);
            } 
        
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _shootingManager.ChangeWeapon(_weapons[WeaponType.Bazooka]);
            }
        }

        private void ReloadEventWeapon(WeaponType weaponToReload)
        {
            var weapon = _weapons[weaponToReload];
            weapon.currentNumberOfBullets = weapon.numberOfBullets;
        }
    }
}
