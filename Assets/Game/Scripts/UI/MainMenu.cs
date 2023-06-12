using StalinKilledMelons.General;
using UnityEngine;

namespace StalinKilledMelons.UI
{
    public class MainMenu : MonoBehaviour
    {

        [SerializeField] private GameObject mainMenuUI;
        private LevelManager levelManager;

        private void Awake()
        {
            levelManager = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelManager>();
        }

        public void PlayGame()
        {
            levelManager.LoadNextLevel();
        }

        public void QuitGame()
        {
            levelManager.QuitGame();
        }

        public void ShowMainMenu()
        {
            mainMenuUI.SetActive(true);
        }

        public void HideMainMenu()
        {
            mainMenuUI.SetActive(false);
        }

    }

}