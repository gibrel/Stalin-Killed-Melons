using UnityEngine;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Controla as animações e transições suaves para elementos da interface do usuário.
    /// </summary>
    public class UIAnimationController : MonoBehaviour
    {
        private Animator animator; // Referência ao componente Animator do elemento da interface do usuário

        private static readonly int ShowTrigger = Animator.StringToHash(Constants.ShowTrigger); // O trigger do Animator para exibir o elemento
        private static readonly int HideTrigger = Animator.StringToHash(Constants.HideTrigger); // O trigger do Animator para ocultar o elemento

        private void Awake()
        {
            // Obtém a referência ao componente Animator do elemento da interface do usuário
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Exibe o elemento da interface do usuário.
        /// </summary>
        public void Show()
        {
            animator.SetTrigger(ShowTrigger);
        }

        /// <summary>
        /// Oculta o elemento da interface do usuário.
        /// </summary>
        public void Hide()
        {
            animator.SetTrigger(HideTrigger);
        }
    }
}
