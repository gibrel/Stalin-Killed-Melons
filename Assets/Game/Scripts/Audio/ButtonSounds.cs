using UnityEngine;

namespace StalinKilledMelons.Audio
{
    /// <summary>
    /// Controla os sons associados aos bot�es.
    /// </summary>
    public class ButtonSounds : MonoBehaviour
    {
        /// <summary>
        /// Reproduz o som de clique de bot�o.
        /// </summary>
        public void ButtonClick()
        {
            SoundManager.PlaySound(Sound.ButtonClick);
        }

        /// <summary>
        /// Reproduz o som de hover de bot�o.
        /// </summary>
        public void ButtonHover()
        {
            SoundManager.PlaySound(Sound.ButtonHover);
        }

        /// <summary>
        /// Reproduz o som de troca de bot�o.
        /// </summary>
        public void ButtonSwitch()
        {
            SoundManager.PlaySound(Sound.ButtonSwitch);
        }
    }
}
