using StalinKilledMelons.Gameplay.Audio;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Gerencia o menu de configura��es do jogo.
    /// </summary>
    public class ConfigMenu : MonoBehaviour
    {
        [SerializeField] private float timeToWait = 0.5f;
        public AudioMixer audioMixer;
        [SerializeField] private GameObject configMenuUI;

        private void Start()
        {
            StartCoroutine(LateStart());
        }

        /// <summary>
        /// Rotina de inicializa��o tardia que aguarda um tempo espec�fico antes de executar.
        /// </summary>
        private IEnumerator LateStart()
        {
            yield return new WaitForSeconds(timeToWait);
            SoundManager.PlayMusic(Music.MenuMusic);
        }

        /// <summary>
        /// Define o volume do �udio geral do jogo.
        /// </summary>
        /// <param name="volume">O valor do volume a ser definido.</param>
        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("volume", volume);
        }

        /// <summary>
        /// Exibe o menu de configura��es.
        /// </summary>
        public void ShowConfigMenu()
        {
            configMenuUI.SetActive(true);
        }

        /// <summary>
        /// Oculta o menu de configura��es.
        /// </summary>
        public void HideConfigMenu()
        {
            configMenuUI.SetActive(false);
        }
    }
}
