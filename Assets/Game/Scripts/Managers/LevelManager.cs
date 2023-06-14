using StalinKilledMelons.Gameplay.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia os n�veis do jogo e suas transi��es.
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        private const string PLAYER_PREFERENCES = "PlayerPreferences";
        [SerializeField] private float timeToWait = 1f; // Tempo de espera antes de carregar um novo n�vel ou encerrar o jogo.
        [SerializeField] private Animator[] transitions; // Array de animators para as transi��es entre os n�veis.
        [SerializeField] private PauseMenu pauseMenu; // Refer�ncia ao menu de pausa.

        private PlayerPreferences playerPreferences; // Refer�ncia para o PlayerPreferences, respons�vel por armazenar as prefer�ncias do jogador.

        private void Awake()
        {
            playerPreferences = GameObject.FindGameObjectWithTag(PLAYER_PREFERENCES).GetComponent<PlayerPreferences>(); // Encontra o PlayerPreferences na cena e atribui � vari�vel playerPreferences.
        }

        private void SavePreferences()
        {
            playerPreferences.SavePlayerPreferences(); // Salva as prefer�ncias do jogador.
        }

        /// <summary>
        /// Carrega um n�vel espec�fico com base no nome fornecido.
        /// </summary>
        /// <param name="levelName">Nome do n�vel a ser carregado.</param>
        public void LoadLevel(string levelName)
        {
            SavePreferences();
            StartCoroutine(LoadLevelAsync(levelName));
        }

        /// <summary>
        /// Recarrega o n�vel atual.
        /// </summary>
        public void ReloadLevel()
        {
            SavePreferences();
            StartCoroutine(LoadLevelAsync(SceneManager.GetActiveScene().name));
        }

        /// <summary>
        /// Carrega o pr�ximo n�vel na sequ�ncia.
        /// </summary>
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
                Debug.LogWarning("Nenhum pr�ximo n�vel dispon�vel.");
            }
        }

        /// <summary>
        /// Carrega o n�vel anterior na sequ�ncia.
        /// </summary>
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
                Debug.LogWarning("Nenhum n�vel anterior dispon�vel.");
            }
        }

        /// <summary>
        /// Encerra o jogo.
        /// </summary>
        public void QuitGame()
        {
            SavePreferences();
#if !UNITY_EDITOR
            StartCoroutine(QuitApplication());
#endif
        }

        /// <summary>
        /// Pausa o jogo.
        /// </summary>
        public void PauseGame()
        {
            pauseMenu.ShowPauseMenu();
            Time.timeScale = 0f;
            Debug.Log("Jogo pausado!");
        }

        /// <summary>
        /// Retoma o jogo.
        /// </summary>
        public void ResumeGame()
        {
            pauseMenu.HidePauseMenu();
            Time.timeScale = 1f;
            Debug.Log("Jogo retomado!");
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
