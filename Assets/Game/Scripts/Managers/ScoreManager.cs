using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia a pontua��o do jogador.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        private float totalPlayerPoints = 0; // Pontua��o total do jogador.
        private float highScore = 0; // Pontua��o mais alta alcan�ada.

        /// <summary>
        /// Pontua��o total do jogador.
        /// </summary>
        public float TotalPlayerPoints { get { return totalPlayerPoints; } }

        /// <summary>
        /// Pontua��o mais alta alcan�ada.
        /// </summary>
        public float HighScore { get { return highScore; } }

        private void Start()
        {
            // Carrega a pontua��o mais alta salva anteriormente.
            highScore = PlayerPrefs.GetFloat(Constants.HighScoreKey, 0f);
        }

        /// <summary>
        /// Adiciona pontos � pontua��o total do jogador. Atualiza a pontua��o mais alta se necess�rio.
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
        /// Salva a pontua��o mais alta para uso futuro.
        /// </summary>
        private void SaveHighScore()
        {
            PlayerPrefs.SetFloat(Constants.HighScoreKey, highScore);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Reseta a pontua��o total do jogador.
        /// </summary>
        public void ResetScore()
        {
            totalPlayerPoints = 0;
        }
    }
}
