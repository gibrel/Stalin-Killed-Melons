using StalinKilledMelons.Managers;

namespace StalinKilledMelons.Gameplay.Skills
{
    /// <summary>
    /// Habilidade que permite bloquear ataques.
    /// </summary>
    public class BlockSkill : BaseSkill
    {
        private InputManager inputManager;
        private CharacterController characterController;

        private void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
            characterController = GetComponent<CharacterController>();
        }

        /// <summary>
        /// Ativa a habilidade de bloquear.
        /// </summary>
        public override void Activate()
        {
            characterController.StartBlock();
        }

        /// <summary>
        /// Desativa a habilidade de bloquear.
        /// </summary>
        public override void Deactivate()
        {
            characterController.StopBlock();
        }

        private void Update()
        {
            if (inputManager.GetBlockInput())
            {
                Activate();
            }
            else
            {
                Deactivate();
            }
        }
    }
}
