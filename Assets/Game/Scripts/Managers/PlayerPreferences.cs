using StalinKilledMelons.Assets;
using System;
using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Armazena e gerencia as prefer�ncias do jogador.
    /// </summary>
    public class PlayerPreferences : MonoBehaviour
    {
        private static PlayerPreferences instance; // Inst�ncia �nica do PlayerPreferences

        /// <summary>
        /// Obt�m a inst�ncia �nica do PlayerPreferences.
        /// </summary>
        public static PlayerPreferences Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<PlayerPreferences>();
                    if (instance == null)
                    {
                        Debug.LogError("PlayerPreferences n�o encontrado na cena. Certifique-se de adicionar o PlayerPreferences � cena.");
                    }
                }
                return instance;
            }
        }

        private float volume; // Volume do jogo.
        private int spawnFreq; // Frequ�ncia de spawn.
        private int gameTime; // Tempo de jogo.
        private string gameStartTime; // Tempo de in�cio do jogo.
        private int enemiesKilled; // Inimigos eliminados.
        private float totalPlayTime; // Tempo total de jogo.

        /// <summary>
        /// Volume do jogo.
        /// </summary>
        public float Volume { get => volume; set { if (value is >= 0f and <= 1f) { volume = value; SavePlayerPreferences(); } } }

        /// <summary>
        /// Frequ�ncia de spawn.
        /// </summary>
        public int SpawnFreq { get => spawnFreq; set { if (value is >= 3 and <= 10) { spawnFreq = value; SavePlayerPreferences(); } } }

        /// <summary>
        /// Tempo de jogo.
        /// </summary>
        public int GameTime { get => gameTime; set { if (value is >= 1 and <= 3) { gameTime = value; SavePlayerPreferences(); } } }

        /// <summary>
        /// Tempo de in�cio do jogo.
        /// </summary>
        public DateTime GameStartTime { get => DateTime.Parse(gameStartTime); set { gameStartTime = value.ToString(); SavePlayerPreferences(); } }

        /// <summary>
        /// Inimigos eliminados.
        /// </summary>
        public int EnemiesKilled { get => enemiesKilled; set { enemiesKilled = value; SavePlayerPreferences(); } }

        /// <summary>
        /// Tempo total de jogo.
        /// </summary>
        public float TotalPlayTime { get => totalPlayTime; set { totalPlayTime = value; SavePlayerPreferences(); } }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            LoadPlayerPreferences(); // Carrega as prefer�ncias do jogador.
        }

        /// <summary>
        /// Salva as prefer�ncias do jogador.
        /// </summary>
        public void SavePlayerPreferences()
        {
            GameAssets.Instance.audioMixer.GetFloat(Constants.SoundVolumeKey, out float volume);
            volume = Mathf.InverseLerp(-80f, 20f, volume);

            PlayerPrefs.SetFloat(Constants.SoundVolumeKey, volume);
            PlayerPrefs.SetInt(Constants.SpawnFrequencyKey, spawnFreq);
            PlayerPrefs.SetInt(Constants.GameTimeKey, gameTime);
            PlayerPrefs.SetString(Constants.GameStartTimeKey, gameStartTime);
            PlayerPrefs.SetInt(Constants.EnemiesKilledKey, enemiesKilled);
            PlayerPrefs.SetFloat(Constants.TotalPlayTimeKey, totalPlayTime);
        }

        private void LoadPlayerPreferences()
        {
            volume = PlayerPrefs.GetFloat(Constants.SoundVolumeKey);
            spawnFreq = PlayerPrefs.GetInt(Constants.SpawnFrequencyKey);
            gameTime = PlayerPrefs.GetInt(Constants.GameTimeKey);
            gameStartTime = PlayerPrefs.GetString(Constants.GameStartTimeKey);
            enemiesKilled = PlayerPrefs.GetInt(Constants.EnemiesKilledKey);
            totalPlayTime = PlayerPrefs.GetFloat(Constants.TotalPlayTimeKey);

            GameAssets.Instance.audioMixer.SetFloat(Constants.VolumeAudioMixer, Mathf.Lerp(-80f, 20f, volume));
        }

        /// <summary>
        /// Obt�m a chave de controle personalizada para o nome do controle especificado.
        /// Se n�o houver uma chave personalizada, retorna a chave padr�o.
        /// </summary>
        public string GetControlKey(string controlName)
        {
            string customControlKey = PlayerPrefs.GetString(controlName);
            if (!string.IsNullOrEmpty(customControlKey))
                return customControlKey;
            else
                return Constants.DefaultControlKeys[controlName];
        }
    }
}
