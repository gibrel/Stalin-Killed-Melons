using UnityEngine;

namespace StalinKilledMelons.UI
{
    public class UIManager : MonoBehaviour
    {
        // Referências aos objetos de UI
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private MainMenu mainMenu;
        [SerializeField] private ConfigMenu configMenu;

        // Métodos para controlar a exibição dos menus
        public void ShowPauseMenu()
        {
            pauseMenu.ShowPauseMenu();
        }

        public void HidePauseMenu()
        {
            pauseMenu.HidePauseMenu();
        }

        public void ShowMainMenu()
        {
            mainMenu.ShowMainMenu();
        }

        public void HideMainMenu()
        {
            mainMenu.HideMainMenu();
        }

        // Métodos para configurações
        public void SetVolume(float volume)
        {
            configMenu.SetVolume(volume);
        }

        // Outros métodos e funcionalidades da UI

        // ...
    }
}
