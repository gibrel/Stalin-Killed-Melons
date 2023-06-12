using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Skills
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private List<PowerUp> powerUps; // Lista de power-ups distintos
        [SerializeField] private float speedBoostDuration = 5f; // Dura��o do aumento de velocidade do jogador
        [SerializeField] private float powerUpSpawnTime = 10f; // Tempo entre o surgimento de power-ups

        private bool isPowerUpActive = false; // Indica se um power-up est� ativo no momento

        private void Start()
        {
            InvokeRepeating("SpawnPowerUp", powerUpSpawnTime, powerUpSpawnTime); // Inicia a repeti��o do surgimento de power-ups
        }

        private void SpawnPowerUp()
        {
            if (!isPowerUpActive)
            {
                // Escolhe um power-up aleat�rio da lista
                PowerUp randomPowerUp = powerUps[Random.Range(0, powerUps.Count)];

                // L�gica para instanciar um power-up no jogo
                // Por exemplo, voc� pode criar um objeto PowerUp na cena e ativ�-lo

                isPowerUpActive = true;
            }
        }

        public void ActivatePowerUp()
        {
            if (isPowerUpActive)
            {
                // L�gica para ativar o efeito do power-up no jogador
                // Por exemplo, aumentar a velocidade do jogador por um determinado per�odo de tempo

                // Desativa o power-up ap�s o tempo especificado
                Invoke("DeactivatePowerUp", speedBoostDuration);
            }
        }

        private void DeactivatePowerUp()
        {
            // L�gica para desativar o efeito do power-up no jogador
            // Por exemplo, restaurar a velocidade original do jogador

            isPowerUpActive = false;
        }
    }

    [System.Serializable]
    public class PowerUp
    {
        public string name; // Nome do power-up
        public float duration; // Dura��o do efeito do power-up

        // Adicione aqui quaisquer outros par�metros espec�ficos do power-up
    }
}