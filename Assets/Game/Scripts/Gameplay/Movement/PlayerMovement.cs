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

        private void Awake()
        {
            navigation = GetComponent<Navigation>();
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
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized * moveSpeed;
            navigation.SetTarget(movement);
        }
    }
}
