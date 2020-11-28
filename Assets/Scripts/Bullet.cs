using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timeToDeactivate;

    public void StartDeactivation()
    {
        StartCoroutine(DeactivateAfterSetTime());
    }

    private IEnumerator DeactivateAfterSetTime()
    {
        yield return new WaitForSeconds(timeToDeactivate);
        gameObject.SetActive(false);
    }
}
