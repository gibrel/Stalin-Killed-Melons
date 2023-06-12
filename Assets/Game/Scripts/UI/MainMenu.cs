using StalinKilledMelons.General;
using UnityEngine;

namespace StalinKilledMelons.UI
{
    public class MainMenu : MonoBehaviour
    {
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

    }

}