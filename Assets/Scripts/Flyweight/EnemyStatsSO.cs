using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(menuName = "EnemyStats")]
    public class EnemyStatsSO : ScriptableObject
    {
        public float _movementSpeed;
        public int _maxHP;
        public int _points;
        public Color _enemyColor;
        private GameObject _player;

        public void SetPlayer(GameObject player)
        {
            _player = player;
        }

        public GameObject GetPlayer()
        {
            return _player;
        }
    }
}
