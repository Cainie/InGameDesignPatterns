using Flyweight;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreSystem : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI scoreText;
    
        private int _score;

        private void OnEnable()
        {
            Enemy.enemyKill += RefreshScoreAfterKillingEnemy;
        }

        private void OnDisable()
        {
            Enemy.enemyKill -= RefreshScoreAfterKillingEnemy;
        }

        private void RefreshScoreAfterKillingEnemy(int pointsToAdd)
        {
            _score += pointsToAdd;
            scoreText.text = $"Score: {_score}!";
        }
    }
}
