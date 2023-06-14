using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia o estado de jogo quando o jogador perde.
    /// </summary>
    public class GameOverManager : MonoBehaviour
    {
        private LevelManager levelManager; // Refer�ncia para o LevelManager, respons�vel por controlar os n�veis do jogo.

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>(); // Encontra o LevelManager na cena e atribui � vari�vel levelManager.
        }

        /// <summary>
        /// Exibe a tela de game over.
        /// </summary>
        public void ShowGameOverScreen()
        {
            // Implemente aqui a l�gica para exibir a tela de game over
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
