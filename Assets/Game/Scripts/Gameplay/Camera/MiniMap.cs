using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.Camera
{
    /// <summary>
    /// Classe responsável por criar um mini mapa no jogo.
    /// </summary>
    public class MiniMap : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera miniMapCamera; // Câmera usada para renderizar o mini mapa
        [SerializeField] private RawImage miniMapImage; // Imagem usada para exibir o mini mapa na UI
        [SerializeField] private Transform player; // Transform do jogador

        private void Start()
        {
            // Configura o tamanho e a posição da câmera do mini mapa
            miniMapCamera.orthographicSize = 100; // Defina o tamanho desejado para o mini mapa
            miniMapCamera.transform.position = new Vector3(player.position.x, miniMapCamera.transform.position.y, player.position.z);
        }

        private void LateUpdate()
        {
            // Atualiza a posição da câmera do mini mapa para acompanhar o jogador
            miniMapCamera.transform.position = new Vector3(player.position.x, miniMapCamera.transform.position.y, player.position.z);

            // Atualiza a textura do mini mapa
            RenderTexture activeRenderTexture = RenderTexture.active;
            RenderTexture.active = miniMapCamera.targetTexture;
            miniMapCamera.Render();
            Texture2D miniMapTexture = new Texture2D(miniMapCamera.targetTexture.width, miniMapCamera.targetTexture.height);
            miniMapTexture.ReadPixels(new Rect(0, 0, miniMapCamera.targetTexture.width, miniMapCamera.targetTexture.height), 0, 0);
            miniMapTexture.Apply();
            RenderTexture.active = activeRenderTexture;

            // Atualiza a imagem do mini mapa na UI
            miniMapImage.texture = miniMapTexture;
        }
    }
}