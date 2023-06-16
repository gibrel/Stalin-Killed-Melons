using UnityEngine;

namespace StalinKilledMelons.Gameplay.Animation
{
    /// <summary>
    /// Controla as animações do personagem, como movimentos, ataques, habilidades especiais e transições suaves entre diferentes estados de animação.
    /// </summary>
    public class AnimationController : MonoBehaviour
    {
        private Animator animator; // Referência ao componente Animator do personagem

        private static readonly int SpeedParameter = Animator.StringToHash("Speed"); // O parâmetro do Animator que controla a velocidade de movimento
        private static readonly int AttackTrigger = Animator.StringToHash("Attack"); // O trigger do Animator para acionar a animação de ataque
        private static readonly int SpecialAbilityTrigger = Animator.StringToHash("SpecialAbility"); // O trigger do Animator para acionar a animação de habilidade especial

        private void Awake()
        {
            // Obtém a referência ao componente Animator do personagem
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
        /// Executa a animação de ataque.
        /// </summary>
        public void PlayAttackAnimation()
        {
            animator.SetTrigger(AttackTrigger);
        }

        /// <summary>
        /// Executa a animação de habilidade especial.
        /// </summary>
        public void PlaySpecialAbilityAnimation()
        {
            animator.SetTrigger(SpecialAbilityTrigger);
        }
    }
}
