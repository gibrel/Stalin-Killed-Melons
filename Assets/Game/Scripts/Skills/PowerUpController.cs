using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.PowerUps
{
    /// <summary>
    /// Controla o comportamento e efeitos dos power-ups no jogo.
    /// </summary>
    public class PowerUpController : MonoBehaviour
    {
        [SerializeField] private List<PowerUp> powerUps; // Lista de power-ups distintos
        [SerializeField] private float powerUpSpawnTime = 10f; // Tempo entre o surgimento de power-ups

        private bool isPowerUpActive = false; // Indica se um power-up est� ativo no momento

        private void Start()
        {
            InvokeRepeating(nameof(SpawnPowerUp), powerUpSpawnTime, powerUpSpawnTime); // Inicia a repeti��o do surgimento de power-ups
        }

        /// <summary>
        /// Surgimento de um power-up no jogo.
        /// </summary>
        private void SpawnPowerUp()
        {
            if (!isPowerUpActive)
            {
                // Escolhe um power-up aleat�rio da lista
                PowerUp randomPowerUp = powerUps[Random.Range(0, powerUps.Count)];

                // L�gica para instanciar um power-up no jogo
                // Por exemplo, voc� pode criar um objeto PowerUp na cena e ativ�-lo

                // Armazena o power-up selecionado para uso posterior
                ActivatePowerUp(randomPowerUp);
            }
        }

        /// <summary>
        /// Ativa o efeito do power-up.
        /// </summary>
        /// <param name="powerUp">O power-up a ser ativado.</param>
        private void ActivatePowerUp(PowerUp powerUp)
        {
            if (isPowerUpActive)
                return;

            // L�gica para ativar o efeito do power-up no jogador
            // Por exemplo, aumentar a velocidade do jogador por um determinado per�odo de tempo

            // Desativa o power-up ap�s o tempo especificado
            Invoke(nameof(DeactivatePowerUp), powerUp.duration);
        }

        /// <summary>
        /// Desativa o efeito do power-up.
        /// </summary>
        private void DeactivatePowerUp()
        {
            // L�gica para desativar o efeito do power-up no jogador
            // Por exemplo, restaurar a velocidade original do jogador

            isPowerUpActive = false;
        }
    }

    /// <summary>
    /// Classe que representa um power-up do jogo.
    /// </summary>
    [System.Serializable]
    public class PowerUp
    {
        public PowerUpType type; // Tipo do power-up
        public float duration; // Dura��o do efeito do power-up

        // Adicione aqui quaisquer outros par�metros espec�ficos do power-up
    }

    /// <summary>
    /// Enum que representa os tipos de power-ups dispon�veis no jogo.
    /// </summary>
    public enum PowerUpType
    {
        SpeedBoost,          // Aumento de velocidade
        Shield,              // Escudo
        DamageBoost,         // Aumento de dano
        HealthPack,          // Pacote de sa�de
        AmmoRefill,          // Recarga de muni��o
        Invisibility,        // Invisibilidade
        HealthRegeneration,  // Regenera��o de sa�de
        TimeSlowdown,        // Desacelera��o do tempo
        FireRateBoost,       // Aumento da taxa de disparo
        ScoreMultiplier      // Multiplicador de pontua��o
    }
}
