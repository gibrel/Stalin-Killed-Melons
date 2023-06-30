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
        [SerializeField] private float timeToWait = 1f; // Tempo de espera antes de carregar um novo nível ou encerrar o jogo.
        [SerializeField] private Animator[] transitions; // Array de animators para as transições entre os níveis.
        [SerializeField] private PauseMenu pauseMenu; // Referência ao menu de pausa.

        private PlayerPreferences playerPreferences; // Referência para o PlayerPreferences, responsável por armazenar as preferências do jogador.
        private float loadProgress = 0f;
        private bool loadComplete = false;

        public float LoadProgress { get => loadProgress; }
        public bool LoadComplete { get => loadComplete; }

        private void Awake()
        {
            playerPreferences = GameObject.FindGameObjectWithTag(Constants.PlayerPreferencesTag).GetComponent<PlayerPreferences>(); // Encontra o PlayerPreferences na cena e atribui à variável playerPreferences.
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
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

            while (!operation.isDone)
            {
                loadProgress = operation.progress;
                Debug.Log($"Carregando cena... {(int)(loadProgress * 100)}%");

                if (loadProgress >= 0.9f && !loadComplete)
                {
                    loadComplete = true;
                    GetRandomTransition().SetTrigger(Constants.StartTrigger);
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        private IEnumerator QuitApplication()
        {
            GetRandomTransition().SetTrigger(Constants.StartTrigger);

            yield return new WaitForSeconds(timeToWait);

            Application.Quit();
        }

        private Animator GetRandomTransition()
        {
            return transitions[Random.Range(0, transitions.Length)];
        }
    }
}
