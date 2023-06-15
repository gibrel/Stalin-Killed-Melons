using UnityEngine;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe responsável pelo gerenciamento da interface do usuário (UI).
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        // Referências aos objetos de UI
        [SerializeField] private PauseMenu pauseMenu; // Referência ao menu de pausa
        [SerializeField] private MainMenu mainMenu; // Referência ao menu principal
        [SerializeField] private ConfigMenu configMenu; // Referência ao menu de configurações
        [SerializeField] private AchievementPanel achievementPanel; // Referência ao painel de conquistas

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
        /// Define o volume de áudio.
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
            // Implemente a lógica para exibir o menu de ajuda
        }

        /// <summary>
        /// Oculta o menu de ajuda.
        /// </summary>
        public void HideHelpMenu()
        {
            // Implemente a lógica para ocultar o menu de ajuda
        }

        /// <summary>
        /// Reinicia o jogo.
        /// </summary>
        public void RestartGame()
        {
            // Implemente a lógica para reiniciar o jogo
        }

        /// <summary>
        /// Abre o menu de pausa e exibe as opções de configurações.
        /// </summary>
        public void OpenPauseMenuWithSettings()
        {
            ShowPauseMenu();
            configMenu.ShowConfigMenu();
        }

        /// <summary>
        /// Salva as configurações do jogo.
        /// </summary>
        public void SaveGameSettings()
        {
            // Implemente a lógica para salvar as configurações do jogo
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
