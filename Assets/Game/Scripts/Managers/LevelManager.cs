using StalinKilledMelons.Gameplay.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia os níveis do jogo e suas transições.
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        private const string PLAYER_PREFERENCES = "PlayerPreferences";
        [SerializeField] private float timeToWait = 1f; // Tempo de espera antes de carregar um novo nível ou encerrar o jogo.
        [SerializeField] private Animator[] transitions; // Array de animators para as transições entre os níveis.
        [SerializeField] private PauseMenu pauseMenu; // Referência ao menu de pausa.

        private PlayerPreferences playerPreferences; // Referência para o PlayerPreferences, responsável por armazenar as preferências do jogador.

        private void Awake()
        {
            playerPreferences = GameObject.FindGameObjectWithTag(PLAYER_PREFERENCES).GetComponent<PlayerPreferences>(); // Encontra o PlayerPreferences na cena e atribui à variável playerPreferences.
        }

        private void SavePreferences()
        {
            playerPreferences.SavePlayerPreferences(); // Salva as preferências do jogador.
        }

        /// <summary>
        /// Carrega um nível específico com base no nome fornecido.
        /// </summary>
        /// <param name="levelName">Nome do nível a ser carregado.</param>
        public void LoadLevel(string levelName)
        {
            SavePreferences();
            StartCoroutine(LoadLevelAsync(levelName));
        }

        /// <summary>
        /// Recarrega o nível atual.
        /// </summary>
        public void ReloadLevel()
        {
            SavePreferences();
            StartCoroutine(LoadLevelAsync(SceneManager.GetActiveScene().name));
        }

        /// <summary>
        /// Carrega o próximo nível na sequência.
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
                Debug.LogWarning("Nenhum próximo nível disponível.");
            }
        }

        /// <summary>
        /// Carrega o nível anterior na sequência.
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
                Debug.LogWarning("Nenhum nível anterior disponível.");
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
