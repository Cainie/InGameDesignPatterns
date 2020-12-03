using System;
using UnityEngine;

namespace Flyweight
{
    public class Enemy : MonoBehaviour
    {
        private int _currentHp;
        private EnemyStatsSO _enemyStatsSo;
        private Rigidbody2D _rigidbody2D;
        private bool isStatsReady;

        public void SetEnemyStats(EnemyStatsSO enemyStatsSo)
        {
           _enemyStatsSo = enemyStatsSo;
            _currentHp = enemyStatsSo._maxHP;
            isStatsReady = true;
            SetColor();
        }

        private void SetColor()
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.color = _enemyStatsSo._enemyColor;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.tag.Equals("bullet")) return;
            other.gameObject.SetActive(false);
            LoseHp();
        }

        private void LoseHp()
        {
            _currentHp--;
            if (_currentHp <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (!isStatsReady) return;
            var direction = (_enemyStatsSo.GetPlayer().transform.position - transform.position).normalized;
            _rigidbody2D.MovePosition(transform.position + direction * (_enemyStatsSo._movementSpeed * Time.fixedDeltaTime));

        }

    }
}
