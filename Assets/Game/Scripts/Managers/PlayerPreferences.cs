using StalinKilledMelons.Assets;
using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Armazena e gerencia as preferências do jogador.
    /// </summary>
    public class PlayerPreferences : MonoBehaviour
    {
        private float volume; // Volume do jogo.
        private int spawnFreq; // Frequência de spawn.
        private int gameTime; // Tempo de jogo.

        /// <summary>
        /// Volume do jogo.
        /// </summary>
        public float Volume { get => volume; set { if (value is >= 0f and <= 1f) { volume = value; SavePlayerPreferences(); } } }

        /// <summary>
        /// Frequência de spawn.
        /// </summary>
        public int SpawnFreq { get => spawnFreq; set { if (value is >= 3 and <= 10) { spawnFreq = value; SavePlayerPreferences(); } } }

        /// <summary>
        /// Tempo de jogo.
        /// </summary>
        public int GameTime { get => gameTime; set { if (value is >= 1 and <= 3) { gameTime = value; SavePlayerPreferences(); } } }

        private void Awake()
        {
            LoadPlayerPreferences(); // Carrega as preferências do jogador.
        }

        /// <summary>
        /// Salva as preferências do jogador.
        /// </summary>
        public void SavePlayerPreferences()
        {
            GameAssets.Instance.audioMixer.GetFloat(Constants.SoundVolumeKey, out float volume);
            volume = Mathf.InverseLerp(-80f, 20f, volume);

            PlayerPrefs.SetFloat(Constants.SoundVolumeKey, volume);
            PlayerPrefs.SetInt(Constants.SpawnFrequencyKey, spawnFreq);
            PlayerPrefs.SetInt(Constants.GameTimeKey, gameTime);
        }

        private void LoadPlayerPreferences()
        {
            volume = PlayerPrefs.GetFloat(Constants.SoundVolumeKey);
            spawnFreq = PlayerPrefs.GetInt(Constants.SpawnFrequencyKey);
            gameTime = PlayerPrefs.GetInt(Constants.GameTimeKey);

            GameAssets.Instance.audioMixer.SetFloat(Constants.VolumeAudioMixer, Mathf.Lerp(-80f, 20f, volume));
        }
    }
}
