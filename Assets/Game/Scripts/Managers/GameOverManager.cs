using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia o estado de jogo quando o jogador perde.
    /// </summary>
    public class GameOverManager : MonoBehaviour
    {
        private LevelManager levelManager; // Referência para o LevelManager, responsável por controlar os níveis do jogo.

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>(); // Encontra o LevelManager na cena e atribui à variável levelManager.
        }

        /// <summary>
        /// Exibe a tela de game over.
        /// </summary>
        public void ShowGameOverScreen()
        {
            // Implemente aqui a lógica para exibir a tela de game over
        }

        /// <summary>
        /// Reinicia o jogo.
        /// </summary>
        public void RestartGame()
        {
            levelManager.ReloadLevel();
        }

        /// <summary>
        /// Retorna ao menu principal.
        /// </summary>
        public void ReturnToMainMenu()
        {
            levelManager.LoadLevel(Constants.MainMenuScene);
        }
    }
}
