using UnityEngine;

namespace StalinKilledMelons.Movement
{
    [RequireComponent(typeof(Navigation))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        private Navigation naviagtion;

        private void Awake()
        {
            naviagtion = GetComponent<Navigation>();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            float moveX = 0f;
            float moveZ = 0f;

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
            naviagtion.SetTarget(movement);
        }
    }
}
