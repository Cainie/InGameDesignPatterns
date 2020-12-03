using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void FixedUpdate()
    {
        var newPosition = new Vector3();
        newPosition.x = player.transform.position.x;
        newPosition.y = player.transform.position.y;
        newPosition.z = -10;
        transform.position = newPosition;
    }
}
