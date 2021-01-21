using UnityEngine;

public class TakeCareOfExplosion : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject,0.5f);
    }
}
