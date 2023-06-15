using UnityEngine;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe respons�vel pelo gerenciamento da interface do usu�rio (UI).
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        // Refer�ncias aos objetos de UI
        [SerializeField] private PauseMenu pauseMenu; // Refer�ncia ao menu de pausa
        [SerializeField] private MainMenu mainMenu; // Refer�ncia ao menu principal
        [SerializeField] private ConfigMenu configMenu; // Refer�ncia ao menu de configura��es
        [SerializeField] private AchievementPanel achievementPanel; // Refer�ncia ao painel de conquistas

        /// <summary>
        /// Exibe o menu de pausa.
        /// </summary>
        public void ShowPauseMenu()
        {
            pauseMenu.ShowPauseMenu();
        }

        /// <summary>
        /// Oculta o menu de pausa.
        /// </summary>
        public void HidePauseMenu()
        {
            pauseMenu.HidePauseMenu();
        }

        /// <summary>
        /// Exibe o menu principal.
        /// </summary>
        public void ShowMainMenu()
        {
            mainMenu.ShowMainMenu();
        }

        /// <summary>
        /// Oculta o menu principal.
        /// </summary>
        public void HideMainMenu()
        {
            mainMenu.HideMainMenu();
        }

        /// <summary>
        /// Define o volume de �udio.
        /// </summary>
        /// <param name="volume">O valor do volume.</param>
        public void SetVolume(float volume)
        {
            configMenu.SetVolume(volume);
        }
        /// <summary>
        /// Exibe o menu de ajuda.
        /// </summary>
        public void ShowHelpMenu()
        {
            // Implemente a l�gica para exibir o menu de ajuda
        }

        /// <summary>
        /// Oculta o menu de ajuda.
        /// </summary>
        public void HideHelpMenu()
        {
            // Implemente a l�gica para ocultar o menu de ajuda
        }

        /// <summary>
        /// Reinicia o jogo.
        /// </summary>
        public void RestartGame()
        {
            // Implemente a l�gica para reiniciar o jogo
        }

        /// <summary>
        /// Abre o menu de pausa e exibe as op��es de configura��es.
        /// </summary>
        public void OpenPauseMenuWithSettings()
        {
            ShowPauseMenu();
            configMenu.ShowConfigMenu();
        }

        /// <summary>
        /// Salva as configura��es do jogo.
        /// </summary>
        public void SaveGameSettings()
        {
            // Implemente a l�gica para salvar as configura��es do jogo
        }

        /// <summary>
        /// Mostra as conquistas obtidas no painel de conquistas.
        /// </summary>
        public void ShowAchievements()
        {
            achievementPanel.ShowAchievements();
        }

        /// <summary>
        /// Oculta o painel de conquistas.
        /// </summary>
        public void HideAchievements()
        {
            achievementPanel.HideAchievements();
        }

    }
}
