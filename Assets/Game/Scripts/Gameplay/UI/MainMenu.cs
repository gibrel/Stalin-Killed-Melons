using StalinKilledMelons.Managers;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe respons�vel pelo menu principal do jogo.
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuUI; // Refer�ncia ao objeto que representa a interface do menu principal
        private LevelManager levelManager; // Gerenciador de n�veis do jogo

        private void Awake()
        {
            levelManager = GameObject.FindGameObjectWithTag(Constants.LevelLoaderTag).GetComponent<LevelManager>();
        }

        /// <summary>
        /// Inicia o jogo, carregando o primeiro n�vel.
        /// </summary>
        public void PlayGame()
        {
            levelManager.LoadLevel(Constants.GameLevelScene);
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
