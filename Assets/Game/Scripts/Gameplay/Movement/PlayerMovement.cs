using StalinKilledMelons.Managers;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Movement
{
    /// <summary>
    /// Classe responsável pelo movimento do jogador.
    /// </summary>
    [RequireComponent(typeof(Navigation))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f; // Velocidade de movimento do jogador
        private Navigation navigation; // Componente de navegação
        private InputManager inputManager; // Gerenciador de entrada do jogador

        private void Awake()
        {
            navigation = GetComponent<Navigation>();
            inputManager = FindObjectOfType<InputManager>();
        }

        private void Update()
        {
            HandleInput();
        }

        /// <summary>
        /// Lida com a entrada do jogador para mover o personagem.
        /// </summary>
        private void HandleInput()
        {
            float moveX = inputManager.GetHorizontalAxis();
            float moveZ = inputManager.GetVerticalAxis();

            Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized * moveSpeed;
            navigation.SetTarget(movement);
        }
    }
}
