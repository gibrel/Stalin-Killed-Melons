using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.PowerUps
{
    /// <summary>
    /// Controla o comportamento e efeitos dos power-ups no jogo.
    /// </summary>
    public class PowerUpController : MonoBehaviour
    {
        [SerializeField] private List<PowerUp> powerUps; // Lista de power-ups distintos
        [SerializeField] private float powerUpDuration = 10f; // Dura��o padr�o do efeito do power-up

        private bool isPowerUpActive = false; // Indica se um power-up est� ativo no momento

        /// <summary>
        /// Ativa o efeito do power-up.
        /// </summary>
        /// <param name="powerUp">O power-up a ser ativado.</param>
        public void ActivatePowerUp(PowerUp powerUp)
        {
            if (isPowerUpActive)
                return;

            isPowerUpActive = true;

            // L�gica para ativar o efeito do power-up no jogador
            // Por exemplo, aumentar a velocidade do jogador por um determinado per�odo de tempo

            // Desativa o power-up ap�s a dura��o especificada ou com base na dura��o do power-up fornecido
            float duration = powerUp != null ? powerUp.duration : powerUpDuration;
            Invoke(nameof(DeactivatePowerUp), duration);
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
