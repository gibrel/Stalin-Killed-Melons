using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia o tempo de jogo.
    /// </summary>
    public class GameTimer : MonoBehaviour
    {
        private PlayerPreferences playerPreferences; // Refer�ncia para o PlayerPreferences, respons�vel por armazenar as prefer�ncias do jogador.
        private float gameTime; // Dura��o total do jogo em segundos.

        /// <summary>
        /// Dura��o total do jogo em segundos.
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
            playerPreferences = GameObject.FindGameObjectWithTag(Constants.PlayerPreferencesTag).GetComponent<PlayerPreferences>(); // Encontra o PlayerPreferences na cena e atribui � vari�vel playerPreferences.
        }

        private void Start()
        {
            gameTime = playerPreferences.GameTime * 60f; // Obt�m a dura��o do jogo a partir das prefer�ncias do jogador e converte de minutos para segundos.

            if (gameTime is not >= Constants.MinLevelDuration or not <= Constants.MaxLevelDuration) // Verifica se a dura��o do jogo est� dentro do intervalo esperado
            {
                Debug.LogError("N�o foi poss�vel carregar a dura��o do jogo como esperado.");
                gameTime = Constants.MinLevelDuration; // Define o valor padr�o de 1 minuto.
            }
        }
    }
}
