using System;

namespace Weapons
{
    public enum WeaponType
    {
        MachineGun,
        Bazooka
    }
    
    [Serializable]
    public class Weapon
    {
        public WeaponType weaponType;
        public BulletType bulletType;
        public float nextBulletWaitTime;
        public int reloadTime;
        public int numberOfBullets;
        public int currentNumberOfBullets;
    }
}
