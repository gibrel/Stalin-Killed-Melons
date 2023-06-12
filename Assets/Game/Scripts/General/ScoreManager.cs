using UnityEngine;

namespace StalinKilledMelons.General
{
    public class ScoreManager : MonoBehaviour
    {
        private float totalPlayerPoints = 0;
        private float highScore = 0;

        public float TotalPlayerPoints { get { return totalPlayerPoints; } }
        public float HighScore { get { return highScore; } }

        private void Start()
        {
            // Carregue a pontuação mais alta salva anteriormente
            highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        }

        public void AddPoints(float points)
        {
            totalPlayerPoints += points;

            if (totalPlayerPoints < 0)
            {
                totalPlayerPoints = 0;
            }

            if (totalPlayerPoints > highScore)
            {
                highScore = totalPlayerPoints;
                SaveHighScore();
            }
        }

        private void SaveHighScore()
        {
            // Salve a pontuação mais alta para uso futuro
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }

        public void ResetScore()
        {
            totalPlayerPoints = 0;
        }
    }
}
