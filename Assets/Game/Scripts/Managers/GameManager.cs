using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia o fluxo do jogo, como iniciar o jogo e sair do jogo.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private LevelManager levelManager; // Refer�ncia para o LevelManager, respons�vel por controlar os n�veis do jogo.

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>(); // Encontra o LevelManager na cena e atribui � vari�vel levelManager.
        }

        /// <summary>
        /// Inicia o jogo.
        /// </summary>
        public void StartGame()
        {
            // Inicie o jogo aqui
            Debug.Log("Jogo iniciado!");
        }

        /// <summary>
        /// Sai do jogo.
        /// </summary>
        public void QuitGame()
        {
            levelManager.QuitGame(); // Chama o m�todo QuitGame() do LevelManager para encerrar o jogo.
            Debug.Log("Jogo encerrado!");
        }
    }
}
