using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia o fluxo do jogo, como iniciar o jogo e sair do jogo.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private LevelManager levelManager; // Referência para o LevelManager, responsável por controlar os níveis do jogo.

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>(); // Encontra o LevelManager na cena e atribui à variável levelManager.
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
            levelManager.QuitGame(); // Chama o método QuitGame() do LevelManager para encerrar o jogo.
            Debug.Log("Jogo encerrado!");
        }
    }
}
