using StalinKilledMelons.Gameplay.Movement;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Players
{
    /// <summary>
    /// Classe respons�vel pelo controle do jogador.
    /// </summary>
    [RequireComponent(typeof(Navigation))]
    public class PlayerController : CharacterController
    {
        [SerializeField] private float moveSpeed = 5f; // Velocidade de movimento do jogador
        private Navigation navigation; // Componente de navega��o

        protected override void Awake()
        {
            base.Awake();
            navigation = GetComponent<Navigation>();
        }

        protected override void Update()
        {
            HandleInput();
        }

        /// <summary>
        /// Lida com a entrada do jogador para mover o personagem.
        /// </summary>
        protected override void HandleInput()
        {
            float moveX = inputManager.GetHorizontalAxis();
            float moveZ = inputManager.GetVerticalAxis();

            Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized * moveSpeed;
            navigation.SetTarget(movement);

            // Outras a��es do jogador
            if (inputManager.GetShootInput())
            {
                SetShooting(true);
            }
            else
            {
                SetShooting(false);
            }

            if (inputManager.GetRunInput())
            {
                SetRunning(true);
            }
            else
            {
                SetRunning(false);
            }

            if (inputManager.GetDodgeInput())
            {
                StartDodge();
            }

            if (inputManager.GetBlockInput())
            {
                StartBlock();
            }
            else
            {
                StopBlock();
            }
        }
    }
}
