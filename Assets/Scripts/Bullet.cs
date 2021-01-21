using System.Collections;
using UnityEngine;

public enum BulletType
{
    MachineGunBullet,
    BazookaBullet
}

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timeToDeactivate;
    [SerializeField] private GameObject explosionSprite;

    public void StartDeactivation()
    {
        StartCoroutine(DeactivateAfterSetTime());
    }

    public void LeaveExplosion()
    {
        Instantiate(explosionSprite,transform.position,Quaternion.identity);
    }

    private IEnumerator DeactivateAfterSetTime()
    {
        yield return new WaitForSeconds(timeToDeactivate);
        gameObject.SetActive(false);
    }
}
