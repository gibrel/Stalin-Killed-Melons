using System.Collections;
using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia efeitos visuais no jogo, como explos�es, part�culas, tela tremendo, flash de dano, entre outros.
    /// </summary>
    public class EffectsManager : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPrefab; // Prefab da explos�o
        [SerializeField] private GameObject damageFlashPrefab; // Prefab do flash de dano
        [SerializeField] private float shakeDuration = 0.5f; // Dura��o do tremor da tela
        [SerializeField] private float shakeMagnitude = 0.1f; // Magnitude do tremor da tela

        private Camera mainCamera; // Refer�ncia � c�mera principal
        private bool isShaking; // Flag para verificar se a tela est� tremendo

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        /// <summary>
        /// Reproduz uma explos�o no mundo na posi��o especificada.
        /// </summary>
        /// <param name="position">Posi��o da explos�o.</param>
        public void PlayExplosion(Vector3 position)
        {
            Instantiate(explosionPrefab, position, Quaternion.identity);
        }

        /// <summary>
        /// Reproduz um flash de dano na tela.
        /// </summary>
        public void PlayDamageFlash()
        {
            Instantiate(damageFlashPrefab, Vector3.zero, Quaternion.identity);
        }

        /// <summary>
        /// Faz a tela tremer por um determinado per�odo de tempo.
        /// </summary>
        public void ShakeScreen()
        {
            if (!isShaking)
            {
                isShaking = true;
                StartCoroutine(ShakeScreenCoroutine());
            }
        }

        private IEnumerator ShakeScreenCoroutine()
        {
            Vector3 originalPosition = mainCamera.transform.localPosition;
            float elapsedTime = 0f;

            while (elapsedTime < shakeDuration)
            {
                float x = Random.Range(-1f, 1f) * shakeMagnitude;
                float y = Random.Range(-1f, 1f) * shakeMagnitude;

                mainCamera.transform.localPosition = originalPosition + new Vector3(x, y, 0f);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            mainCamera.transform.localPosition = originalPosition;
            isShaking = false;
        }
    }
}
