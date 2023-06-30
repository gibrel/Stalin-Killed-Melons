using StalinKilledMelons.Managers;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe responsável pelo painel de carregamento do jogo.
    /// </summary>
    public class LoadingUI : MonoBehaviour
    {
        [SerializeField] private float timeToWait = 1f; // Tempo de espera antes de carregar um novo nível.
        [SerializeField] private Image loadingFillImage;
        private LevelManager levelManager; // Gerenciador de níveis do jogo
        private bool startedTransition = false;

        private void Awake()
        {
            levelManager = GameObject.FindGameObjectWithTag(Constants.LevelLoaderTag).GetComponent<LevelManager>();
        }

        public void Update()
        {
            if (!startedTransition) StartCoroutine(MakeTransition());
        }

        /// <summary>
        /// Carrega o menu inicial e gerencia o andamento da barra de carregamento.
        /// </summary>
        private IEnumerator MakeTransition()
        {
            startedTransition = true;

            yield return new WaitForSeconds(timeToWait);

            levelManager.LoadLevel(Constants.MainMenuScene);

            while (!levelManager.LoadComplete)
            {
                loadingFillImage.fillAmount = levelManager.LoadProgress;
                yield return null;
            }

            loadingFillImage.fillAmount = 1f;
            yield return null;
        }

    }
}
