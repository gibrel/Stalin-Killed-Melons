using UnityEngine;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Controla as anima��es e transi��es suaves para elementos da interface do usu�rio.
    /// </summary>
    public class UIAnimationController : MonoBehaviour
    {
        private Animator animator; // Refer�ncia ao componente Animator do elemento da interface do usu�rio

        private static readonly int ShowTrigger = Animator.StringToHash(Constants.ShowTrigger); // O trigger do Animator para exibir o elemento
        private static readonly int HideTrigger = Animator.StringToHash(Constants.HideTrigger); // O trigger do Animator para ocultar o elemento

        private void Awake()
        {
            // Obt�m a refer�ncia ao componente Animator do elemento da interface do usu�rio
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Exibe o elemento da interface do usu�rio.
        /// </summary>
        public void Show()
        {
            animator.SetTrigger(ShowTrigger);
        }

        /// <summary>
        /// Oculta o elemento da interface do usu�rio.
        /// </summary>
        public void Hide()
        {
            animator.SetTrigger(HideTrigger);
        }
    }
}
