using UnityEngine;

namespace StalinKilledMelons.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuUI;

        public void ShowPauseMenu()
        {
            pauseMenuUI.SetActive(true);
        }

        public void HidePauseMenu()
        {
            pauseMenuUI.SetActive(false);
        }
    }
}
