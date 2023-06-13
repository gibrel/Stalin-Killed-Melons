using UnityEngine;

namespace StalinKilledMelons.Movement
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
            float moveX = 0f;
            float moveZ = 0f;

            // Verifica as teclas pressionadas para determinar o movimento
            if (Input.GetKey(KeyCode.W))
            {
                moveZ = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveZ = -1f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveX = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveX = 1f;
            }

            Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized * moveSpeed;
            navigation.SetTarget(movement);
        }
    }
}
