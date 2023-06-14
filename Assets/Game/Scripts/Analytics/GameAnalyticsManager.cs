using StalinKilledMelons.Managers;
using UnityEngine;

namespace StalinKilledMelons.Analytics
{
    /// <summary>
    /// Classe responsável por gerenciar a integração com uma plataforma de análise de jogos.
    /// </summary>
    public class GameAnalyticsManager : MonoBehaviour
    {
        private static GameAnalyticsManager instance; // Instância única do GameAnalyticsManager

        /// <summary>
        /// Obtém a instância única do GameAnalyticsManager.
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
                        Debug.LogError("GameAnalyticsManager não encontrado na cena. Certifique-se de adicionar o GameAnalyticsManager à cena.");
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
        /// Registra o evento de início do jogo.
        /// </summary>
        public void LogGameStart()
        {
            // Implemente a lógica para registrar o evento de início do jogo na plataforma de análise de jogos.

            // Registrar o tempo de início do jogo nas preferências do jogador
            PlayerPreferences.Instance.GameStartTime = System.DateTime.UtcNow;
        }

        /// <summary>
        /// Registra o evento de fim do jogo.
        /// </summary>
        public void LogGameEnd()
        {
            // Implemente a lógica para registrar o evento de fim do jogo na plataforma de análise de jogos.

            // Calcular o tempo total de jogo e registrar nas preferências do jogador
            System.DateTime gameStartTime = PlayerPreferences.Instance.GameStartTime;
            System.TimeSpan playTime = System.DateTime.UtcNow - gameStartTime;
            LogPlayTime((float)playTime.TotalSeconds);
        }

        /// <summary>
        /// Registra o evento de morte de um inimigo.
        /// </summary>
        public void LogEnemyDeath()
        {
            // Implemente a lógica para registrar o evento de morte de um inimigo na plataforma de análise de jogos.

            // Incrementar o contador de inimigos mortos nas preferências do jogador
            PlayerPreferences.Instance.EnemiesKilled++;
        }

        /// <summary>
        /// Registra o tempo de jogo.
        /// </summary>
        /// <param name="playTime">O tempo de jogo em segundos.</param>
        public void LogPlayTime(float playTime)
        {
            // Implemente a lógica para registrar o tempo de jogo na plataforma de análise de jogos.

            // Atualizar o tempo de jogo nas preferências do jogador
            PlayerPreferences.Instance.TotalPlayTime += playTime;
        }
    }
}
