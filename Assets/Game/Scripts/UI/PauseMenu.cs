using UnityEngine;

namespace StalinKilledMelons.UI
{
    /// <summary>
    /// Classe responsável pelo menu de pausa do jogo.
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuUI; // Referência ao objeto que representa a interface do menu de pausa

        /// <summary>
        /// Exibe o menu de pausa.
        /// </summary>
        public void ShowPauseMenu()
        {
            pauseMenuUI.SetActive(true);
        }

        /// <summary>
        /// Oculta o menu de pausa.
        /// </summary>
        public void HidePauseMenu()
        {
            pauseMenuUI.SetActive(false);
        }
    }
}
