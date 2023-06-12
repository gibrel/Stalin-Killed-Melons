using UnityEngine;

namespace StalinKilledMelons.UI
{
    public class UIManager : MonoBehaviour
    {
        // Refer�ncias aos objetos de UI
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private MainMenu mainMenu;
        [SerializeField] private ConfigMenu configMenu;

        // M�todos para controlar a exibi��o dos menus
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

        // M�todos para configura��es
        public void SetVolume(float volume)
        {
            configMenu.SetVolume(volume);
        }

        // Outros m�todos e funcionalidades da UI

        // ...
    }
}
