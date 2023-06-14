using StalinKilledMelons.Managers;
using UnityEngine;

namespace StalinKilledMelons.Analytics
{
    /// <summary>
    /// Classe respons�vel por gerenciar a integra��o com uma plataforma de an�lise de jogos.
    /// </summary>
    public class GameAnalyticsManager : MonoBehaviour
    {
        private static GameAnalyticsManager instance; // Inst�ncia �nica do GameAnalyticsManager

        /// <summary>
        /// Obt�m a inst�ncia �nica do GameAnalyticsManager.
        /// </summary>
        public static GameAnalyticsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameAnalyticsManager>();
                    if (instance == null)
                    {
                        Debug.LogError("GameAnalyticsManager n�o encontrado na cena. Certifique-se de adicionar o GameAnalyticsManager � cena.");
                    }
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Registra o evento de in�cio do jogo.
        /// </summary>
        public void LogGameStart()
        {
            // Implemente a l�gica para registrar o evento de in�cio do jogo na plataforma de an�lise de jogos.

            // Registrar o tempo de in�cio do jogo nas prefer�ncias do jogador
            PlayerPreferences.Instance.GameStartTime = System.DateTime.UtcNow;
        }

        /// <summary>
        /// Registra o evento de fim do jogo.
        /// </summary>
        public void LogGameEnd()
        {
            // Implemente a l�gica para registrar o evento de fim do jogo na plataforma de an�lise de jogos.

            // Calcular o tempo total de jogo e registrar nas prefer�ncias do jogador
            System.DateTime gameStartTime = PlayerPreferences.Instance.GameStartTime;
            System.TimeSpan playTime = System.DateTime.UtcNow - gameStartTime;
            LogPlayTime((float)playTime.TotalSeconds);
        }

        /// <summary>
        /// Registra o evento de morte de um inimigo.
        /// </summary>
        public void LogEnemyDeath()
        {
            // Implemente a l�gica para registrar o evento de morte de um inimigo na plataforma de an�lise de jogos.

            // Incrementar o contador de inimigos mortos nas prefer�ncias do jogador
            PlayerPreferences.Instance.EnemiesKilled++;
        }

        /// <summary>
        /// Registra o tempo de jogo.
        /// </summary>
        /// <param name="playTime">O tempo de jogo em segundos.</param>
        public void LogPlayTime(float playTime)
        {
            // Implemente a l�gica para registrar o tempo de jogo na plataforma de an�lise de jogos.

            // Atualizar o tempo de jogo nas prefer�ncias do jogador
            PlayerPreferences.Instance.TotalPlayTime += playTime;
        }
    }
}
