using UnityEngine;
using UnityEngine.Events;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Dispara anima��es de elementos da interface do usu�rio com base em eventos ou a��es espec�ficas.
    /// </summary>
    public class UIAnimationTrigger : MonoBehaviour
    {
        [SerializeField] private Animator animator; // Refer�ncia ao componente Animator do elemento da interface do usu�rio
        [SerializeField] private string triggerName; // O nome do trigger do Animator a ser acionado

        public UnityEvent OnAnimationTriggered { get; set; }

        /// <summary>
        /// Dispara a anima��o.
        /// </summary>
        public void TriggerAnimation()
        {
            animator.SetTrigger(triggerName);
            OnAnimationTriggered?.Invoke();
        }
    }
}
