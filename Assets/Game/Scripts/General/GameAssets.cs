using StalinKilledMelons.Audio;
using UnityEngine;
using UnityEngine.Audio;

namespace StalinKilledMelons.General
{
    /// <summary>
    /// Armazena os ativos de �udio do jogo, como clipes de m�sica e efeitos sonoros, bem como a configura��o do mixer de �udio.
    /// </summary>
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets _instance;

        [Header("M�sica")]
        public MusicAudioClip[] musicAudioClips; // Array de clipes de �udio para as m�sicas do jogo.

        [Header("Efeitos Sonoros")]
        public SoundAudioClip[] soundAudioClips; // Array de clipes de �udio para os efeitos sonoros do jogo.

        public AudioMixer audioMixer; // Mixer de �udio utilizado para controlar o volume e outras configura��es de �udio.

        /// <summary>
        /// Retorna uma inst�ncia �nica da classe GameAssets.
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
            public Sound sound; // Enumera��o que representa um som espec�fico.
            public AudioClip audioClip; // O clip de �udio correspondente ao som.
        }

        /// <summary>
        /// Classe que associa um enum de m�sica a um AudioClip.
        /// </summary>
        [System.Serializable]
        public class MusicAudioClip
        {
            public Music music; // Enumera��o que representa uma m�sica espec�fica.
            public AudioClip audioClip; // O clip de �udio correspondente � m�sica.
        }
    }
}
