using UnityEngine;

namespace StalinKilledMelons.Audio
{
    /// <summary>
    /// Controla os sons associados aos botões.
    /// </summary>
    public class ButtonSounds : MonoBehaviour
    {
        /// <summary>
        /// Reproduz o som de clique de botão.
        /// </summary>
        public void ButtonClick()
        {
            SoundManager.PlaySound(Sound.ButtonClick);
        }

        /// <summary>
        /// Reproduz o som de hover de botão.
        /// </summary>
        public void ButtonHover()
        {
            SoundManager.PlaySound(Sound.ButtonHover);
        }

        /// <summary>
        /// Reproduz o som de troca de botão.
        /// </summary>
        public void ButtonSwitch()
        {
            SoundManager.PlaySound(Sound.ButtonSwitch);
        }
    }
}
