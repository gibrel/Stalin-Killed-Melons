using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StalinKilledMelons.General
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private float timeToWait = 1f;
        [SerializeField] private Animator[] transitions;

        private PlayerPreferences playerPreferences;

        private void Awake()
        {
            playerPreferences = GameObject.FindGameObjectWithTag("PlayerPreferences").GetComponent<PlayerPreferences>();
        }

        private void SavePreferences()
        {
            playerPreferences.SavePlayerPreferences();
        }

        public void LoadLevel(string levelName)
        {
            SavePreferences();
            StartCoroutine(LoadLevelAsync(levelName));
        }

        public void ReloadLevel()
        {
            SavePreferences();
            StartCoroutine(LoadLevelAsync(SceneManager.GetActiveScene().name));
        }

        public void LoadNextLevel()
        {
            SavePreferences();
            int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextBuildIndex < SceneManager.sceneCountInBuildSettings)
            {
                StartCoroutine(LoadLevelAsync(nextBuildIndex));
            }
            else
            {
                Debug.LogWarning("No next level available.");
            }
        }

        public void LoadPreviousLevel()
        {
            SavePreferences();
            int previousBuildIndex = SceneManager.GetActiveScene().buildIndex - 1;
            if (previousBuildIndex >= 0)
            {
                StartCoroutine(LoadLevelAsync(previousBuildIndex));
            }
            else
            {
                Debug.LogWarning("No previous level available.");
            }
        }

        public void QuitGame()
        {
            SavePreferences();
#if !UNITY_EDITOR
            StartCoroutine(QuitApplication());
#endif
        }

        private IEnumerator LoadLevelAsync(string levelName)
        {
            GetRandomTransition().SetTrigger("Start");

            yield return new WaitForSeconds(timeToWait);

            AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
            while (!operation.isDone)
            {
                yield return null;
            }
        }

        private IEnumerator LoadLevelAsync(int buildIndex)
        {
            GetRandomTransition().SetTrigger("Start");

            yield return new WaitForSeconds(timeToWait);

            AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndex);
            while (!operation.isDone)
            {
                yield return null;
            }
        }

        private IEnumerator QuitApplication()
        {
            GetRandomTransition().SetTrigger("Start");

            yield return new WaitForSeconds(timeToWait);

            Application.Quit();
        }

        private Animator GetRandomTransition()
        {
            return transitions[Random.Range(0, transitions.Length)];
        }
    }
}
