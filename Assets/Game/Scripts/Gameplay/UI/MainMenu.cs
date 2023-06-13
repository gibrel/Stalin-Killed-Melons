using StalinKilledMelons.Managers;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe responsável pelo menu principal do jogo.
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuUI; // Referência ao objeto que representa a interface do menu principal
        private LevelManager levelManager; // Gerenciador de níveis do jogo

        private void Awake()
        {
            levelManager = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelManager>();
        }

        /// <summary>
        /// Inicia o jogo, carregando o próximo nível.
        /// </summary>
        public void PlayGame()
        {
            levelManager.LoadNextLevel();
        }

        /// <summary>
        /// Sai do jogo.
        /// </summary>
        public void QuitGame()
        {
            levelManager.QuitGame();
        }

        /// <summary>
        /// Exibe o menu principal.
        /// </summary>
        public void ShowMainMenu()
        {
            mainMenuUI.SetActive(true);
        }

        /// <summary>
        /// Oculta o menu principal.
        /// </summary>
        public void HideMainMenu()
        {
            mainMenuUI.SetActive(false);
        }

    }
}
