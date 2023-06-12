using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Skills
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private List<PowerUp> powerUps; // Lista de power-ups distintos
        [SerializeField] private float speedBoostDuration = 5f; // Duração do aumento de velocidade do jogador
        [SerializeField] private float powerUpSpawnTime = 10f; // Tempo entre o surgimento de power-ups

        private bool isPowerUpActive = false; // Indica se um power-up está ativo no momento

        private void Start()
        {
            InvokeRepeating("SpawnPowerUp", powerUpSpawnTime, powerUpSpawnTime); // Inicia a repetição do surgimento de power-ups
        }

        private void SpawnPowerUp()
        {
            if (!isPowerUpActive)
            {
                // Escolhe um power-up aleatório da lista
                PowerUp randomPowerUp = powerUps[Random.Range(0, powerUps.Count)];

                // Lógica para instanciar um power-up no jogo
                // Por exemplo, você pode criar um objeto PowerUp na cena e ativá-lo

                isPowerUpActive = true;
            }
        }

        public void ActivatePowerUp()
        {
            if (isPowerUpActive)
            {
                // Lógica para ativar o efeito do power-up no jogador
                // Por exemplo, aumentar a velocidade do jogador por um determinado período de tempo

                // Desativa o power-up após o tempo especificado
                Invoke("DeactivatePowerUp", speedBoostDuration);
            }
        }

        private void DeactivatePowerUp()
        {
            // Lógica para desativar o efeito do power-up no jogador
            // Por exemplo, restaurar a velocidade original do jogador

            isPowerUpActive = false;
        }
    }

    [System.Serializable]
    public class PowerUp
    {
        public string name; // Nome do power-up
        public float duration; // Duração do efeito do power-up

        // Adicione aqui quaisquer outros parâmetros específicos do power-up
    }
}