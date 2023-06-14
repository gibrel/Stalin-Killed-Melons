using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia a pontuação do jogador.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        private float totalPlayerPoints = 0; // Pontuação total do jogador.
        private float highScore = 0; // Pontuação mais alta alcançada.

        /// <summary>
        /// Pontuação total do jogador.
        /// </summary>
        public float TotalPlayerPoints { get { return totalPlayerPoints; } }

        /// <summary>
        /// Pontuação mais alta alcançada.
        /// </summary>
        public float HighScore { get { return highScore; } }

        private void Start()
        {
            // Carrega a pontuação mais alta salva anteriormente.
            highScore = PlayerPrefs.GetFloat(Constants.HighScoreKey, 0f);
        }

        /// <summary>
        /// Adiciona pontos à pontuação total do jogador. Atualiza a pontuação mais alta se necessário.
        /// </summary>
        /// <param name="points">Pontos a serem adicionados.</param>
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

        /// <summary>
        /// Salva a pontuação mais alta para uso futuro.
        /// </summary>
        private void SaveHighScore()
        {
            PlayerPrefs.SetFloat(Constants.HighScoreKey, highScore);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Reseta a pontuação total do jogador.
        /// </summary>
        public void ResetScore()
        {
            totalPlayerPoints = 0;
        }
    }
}
