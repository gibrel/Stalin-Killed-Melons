using StalinKilledMelons.Managers;

namespace StalinKilledMelons.Gameplay.Skills
{
    /// <summary>
    /// Habilidade que permite correr.
    /// </summary>
    public class RunSkill : BaseSkill
    {
        private InputManager inputManager;
        private CharacterController characterController;

        private void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
            characterController = GetComponent<CharacterController>();
        }

        /// <summary>
        /// Ativa a habilidade de correr.
        /// </summary>
        public override void Activate()
        {
            characterController.SetRunning(true);
        }

        /// <summary>
        /// Desativa a habilidade de correr.
        /// </summary>
        public override void Deactivate()
        {
            characterController.SetRunning(false);
        }

        private void Update()
        {
            if (inputManager.GetRunInput())
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
