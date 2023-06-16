using UnityEngine;

namespace StalinKilledMelons.Gameplay.Animation
{
    /// <summary>
    /// Controla as anima��es do personagem, como movimentos, ataques, habilidades especiais e transi��es suaves entre diferentes estados de anima��o.
    /// </summary>
    public class AnimationController : MonoBehaviour
    {
        private Animator animator; // Refer�ncia ao componente Animator do personagem

        private static readonly int SpeedParameter = Animator.StringToHash("Speed"); // O par�metro do Animator que controla a velocidade de movimento
        private static readonly int AttackTrigger = Animator.StringToHash("Attack"); // O trigger do Animator para acionar a anima��o de ataque
        private static readonly int SpecialAbilityTrigger = Animator.StringToHash("SpecialAbility"); // O trigger do Animator para acionar a anima��o de habilidade especial

        private void Awake()
        {
            // Obt�m a refer�ncia ao componente Animator do personagem
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Define a velocidade de movimento do personagem.
        /// </summary>
        /// <param name="speed">A velocidade de movimento.</param>
        public void SetMovementSpeed(float speed)
        {
            animator.SetFloat(SpeedParameter, speed);
        }

        /// <summary>
        /// Executa a anima��o de ataque.
        /// </summary>
        public void PlayAttackAnimation()
        {
            animator.SetTrigger(AttackTrigger);
        }

        /// <summary>
        /// Executa a anima��o de habilidade especial.
        /// </summary>
        public void PlaySpecialAbilityAnimation()
        {
            animator.SetTrigger(SpecialAbilityTrigger);
        }
    }
}
