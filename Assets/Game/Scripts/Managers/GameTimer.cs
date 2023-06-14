using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia o tempo de jogo.
    /// </summary>
    public class GameTimer : MonoBehaviour
    {
        private PlayerPreferences playerPreferences; // Referência para o PlayerPreferences, responsável por armazenar as preferências do jogador.
        private float gameTime; // Duração total do jogo em segundos.

        /// <summary>
        /// Duração total do jogo em segundos.
        /// </summary>
        public float GameTime => gameTime;

        /// <summary>
        /// Tempo restante de jogo em segundos.
        /// </summary>
        public float RemainingGameTime => gameTime - Time.time;

        /// <summary>
        /// Indica se o tempo de jogo acabou.
        /// </summary>
        public bool HasTimeRunOut => RemainingGameTime <= 0;

        private void Awake()
        {
            playerPreferences = GameObject.FindGameObjectWithTag(Constants.PlayerPreferencesTag).GetComponent<PlayerPreferences>(); // Encontra o PlayerPreferences na cena e atribui à variável playerPreferences.
        }

        private void Start()
        {
            gameTime = playerPreferences.GameTime * 60f; // Obtém a duração do jogo a partir das preferências do jogador e converte de minutos para segundos.

            if (gameTime is not >= Constants.MinLevelDuration or not <= Constants.MaxLevelDuration) // Verifica se a duração do jogo está dentro do intervalo esperado
            {
                Debug.LogError("Não foi possível carregar a duração do jogo como esperado.");
                gameTime = Constants.MinLevelDuration; // Define o valor padrão de 1 minuto.
            }
        }
    }
}
