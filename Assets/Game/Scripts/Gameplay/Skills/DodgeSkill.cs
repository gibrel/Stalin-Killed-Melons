using StalinKilledMelons.Managers;

namespace StalinKilledMelons.Gameplay.Skills
{
    /// <summary>
    /// Habilidade que permite esquivar de ataques.
    /// </summary>
    public class DodgeSkill : BaseSkill
    {
        private InputManager inputManager;
        private CharacterController characterController;

        private void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
            characterController = GetComponent<CharacterController>();
        }

        /// <summary>
        /// Ativa a habilidade de esquivar.
        /// </summary>
        public override void Activate()
        {
            characterController.StartDodge();
        }

        /// <summary>
        /// Desativa a habilidade de esquivar.
        /// </summary>
        public override void Deactivate()
        {
            characterController.StopDodge();
        }

        private void Update()
        {
            if (inputManager.GetDodgeInput())
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
