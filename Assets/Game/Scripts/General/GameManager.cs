using UnityEngine;

namespace StalinKilledMelons.General
{
    public class GameManager : MonoBehaviour
    {
        private LevelManager levelManager;

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>();
        }

        public void StartGame()
        {
            // Inicie o jogo aqui
            Debug.Log("Game started!");
        }

        public void QuitGame()
        {
            levelManager.QuitGame();
            Debug.Log("Game quit!");
        }
    }
}
