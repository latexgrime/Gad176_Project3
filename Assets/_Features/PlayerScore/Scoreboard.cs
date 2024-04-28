using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SAE.GAD176.Project3.KalyambaMhango.Score.Board
{
    public class Scoreboard : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        private int playerScore = 0;

        void Start()
        {
            if (scoreText == null)
            {
                Debug.LogError("Score text not assigned to ScoreManager!");
            }

            UpdateScoreDisplay();
        }

        public void IncrementScore(int points)
        {
            playerScore += points;
            UpdateScoreDisplay();
        }

        void UpdateScoreDisplay()
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + playerScore;
            }
        }

        public int GetScore()
        {
            return playerScore;
        }
    }
}

