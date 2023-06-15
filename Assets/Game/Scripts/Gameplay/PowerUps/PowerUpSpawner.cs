using UnityEngine;

namespace StalinKilledMelons.Gameplay.PowerUps
{
    /// <summary>
    /// Controla o surgimento de power-ups no jogo.
    /// </summary>
    public class PowerUpSpawner : MonoBehaviour
    {
        [SerializeField] private PowerUpController powerUpController; // Referência ao controlador de power-ups
        [SerializeField] private float spawnInterval = 15f; // Intervalo de tempo entre os surgimentos
        [SerializeField] private Transform[] spawnPoints; // Pontos de surgimento dos power-ups

        private void Start()
        {
            InvokeRepeating(nameof(SpawnPowerUp), spawnInterval, spawnInterval);
        }

        private void SpawnPowerUp()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];

            GameObject powerUpObject = ObjectPool.Instance.GetObjectFromPool();
            powerUpObject.transform.position = spawnPoint.position;
            powerUpObject.transform.rotation = spawnPoint.rotation;

            PowerUp powerUpComponent = powerUpObject.GetComponent<PowerUp>();
            powerUpController.ActivatePowerUp(powerUpComponent);
        }
    }
}
