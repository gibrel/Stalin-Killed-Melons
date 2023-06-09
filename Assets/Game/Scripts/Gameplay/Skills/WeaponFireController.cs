using StalinKilledMelons.Gameplay.Combat;
using StalinKilledMelons.Managers;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Skills
{
    /// <summary>
    /// Classe responsável pelo controle de disparo de armas como uma habilidade.
    /// </summary>
    public class WeaponFireController : BaseSkill
    {
        [SerializeField] private FirearmController[] firearms;
        private InputManager inputManager;
        private CharacterController characterController;

        private void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
            characterController = GetComponent<CharacterController>();
        }

        /// <summary>
        /// Ativa a habilidade de disparo.
        /// </summary>
        public override void Activate()
        {
            characterController.SetShooting(true);
            foreach (FirearmController gun in firearms)
            {
                gun.Shoot();
            }
        }

        /// <summary>
        /// Desativa a habilidade de disparo.
        /// </summary>
        public override void Deactivate()
        {
            characterController.SetShooting(false);
        }

        private void Update()
        {
            if (inputManager.GetShootInput())
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
