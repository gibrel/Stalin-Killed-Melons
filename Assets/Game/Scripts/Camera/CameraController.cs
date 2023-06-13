using UnityEngine;

namespace StalinKilledMelons.Camera
{
    /// <summary>
    /// Classe responsável por controlar a posição da câmera em relação a um objeto alvo.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        private enum Orientation
        {
            X, Y, Z
        }

        [SerializeField] private GameObject targetObject; // Objeto alvo que a câmera seguirá
        [SerializeField][Range(0, 20)] private float smoothTime = 5; // Tempo suavização do movimento da câmera
        [SerializeField] private float cameraHeight = 10; // Altura da câmera em relação ao objeto alvo
        [SerializeField] private Orientation orientation = Orientation.X; // Orientação da câmera em relação ao objeto alvo

        private Vector3 velocity; // Velocidade de suavização do movimento da câmera

        private void Awake()
        {
            targetObject = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            Vector3 finalPosition = Vector3.SmoothDamp(transform.position, targetObject.transform.position, ref velocity, smoothTime * Time.deltaTime);

            switch (orientation)
            {
                case Orientation.X:
                    finalPosition.x = -cameraHeight;
                    break;
                case Orientation.Y:
                    finalPosition.y = -cameraHeight;
                    break;
                default:
                    finalPosition.z = -cameraHeight;
                    break;
            }

            transform.position = finalPosition;
        }
    }
}
