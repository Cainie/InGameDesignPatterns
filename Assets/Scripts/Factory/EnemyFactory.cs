using System.Collections;
using Flyweight;
using UnityEngine;

namespace Factory
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyStatsSO enemyStatsSo;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int numberOfEnemies;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private GameObject player;
        [SerializeField] private float waitTimeTillNewEnemySpawn;

        private void Start()
        {
            enemyStatsSo.SetPlayer(player);
            StartCoroutine(SpawnEnemies());
        
        }

        private IEnumerator SpawnEnemies()
        {
            for (var i = 0; i < numberOfEnemies; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(waitTimeTillNewEnemySpawn);
            }
        }

        private void SpawnEnemy()
        {
            var spawnedEnemy = Instantiate(enemyPrefab, spawnPosition);
            var enemyData = spawnedEnemy.GetComponent<Enemy>();
            enemyData.SetEnemyStats(enemyStatsSo);
        }
    }
}
