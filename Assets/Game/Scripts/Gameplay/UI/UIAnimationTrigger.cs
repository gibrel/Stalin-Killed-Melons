using UnityEngine;
using UnityEngine.Events;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Dispara animações de elementos da interface do usuário com base em eventos ou ações específicas.
    /// </summary>
    public class UIAnimationTrigger : MonoBehaviour
    {
        [SerializeField] private Animator animator; // Referência ao componente Animator do elemento da interface do usuário
        [SerializeField] private string triggerName; // O nome do trigger do Animator a ser acionado

        public UnityEvent OnAnimationTriggered { get; set; }

        /// <summary>
        /// Dispara a animação.
        /// </summary>
        public void TriggerAnimation()
        {
            animator.SetTrigger(triggerName);
            OnAnimationTriggered?.Invoke();
        }
    }
}
