using StalinKilledMelons.Audio;
using UnityEngine;
using UnityEngine.Audio;

namespace StalinKilledMelons.General
{
    /// <summary>
    /// Armazena os ativos de áudio do jogo, como clipes de música e efeitos sonoros, bem como a configuração do mixer de áudio.
    /// </summary>
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets _instance;

        [Header("Música")]
        public MusicAudioClip[] musicAudioClips; // Array de clipes de áudio para as músicas do jogo.

        [Header("Efeitos Sonoros")]
        public SoundAudioClip[] soundAudioClips; // Array de clipes de áudio para os efeitos sonoros do jogo.

        public AudioMixer audioMixer; // Mixer de áudio utilizado para controlar o volume e outras configurações de áudio.

        /// <summary>
        /// Retorna uma instância única da classe GameAssets.
        /// </summary>
        public static GameAssets Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Classe que associa um enum de som a um AudioClip.
        /// </summary>
        [System.Serializable]
        public class SoundAudioClip
        {
            public Sound sound; // Enumeração que representa um som específico.
            public AudioClip audioClip; // O clip de áudio correspondente ao som.
        }

        /// <summary>
        /// Classe que associa um enum de música a um AudioClip.
        /// </summary>
        [System.Serializable]
        public class MusicAudioClip
        {
            public Music music; // Enumeração que representa uma música específica.
            public AudioClip audioClip; // O clip de áudio correspondente à música.
        }
    }
}
