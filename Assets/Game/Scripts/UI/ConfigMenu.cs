using StalinKilledMelons.Audio;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace StalinKilledMelons.UI
{
    public class ConfigMenu : MonoBehaviour
    {
        [SerializeField] private float timeToWait = 0.5f;
        public AudioMixer audioMixer;

        private void Start()
        {
            StartCoroutine(LateStart());
        }

        private IEnumerator LateStart()
        {

            yield return new WaitForSeconds(timeToWait);

            SoundManager.PlayMusic(SoundManager.Music.MenuMusic);
        }

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("volume", volume);
        }
    }

}