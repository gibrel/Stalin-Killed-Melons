using StalinKilledMelons.Managers;
using UnityEngine;

namespace StalinKilledMelons.Gameplay
{
    /// <summary>
    /// Classe abstrata responsável por controlar um personagem.
    /// </summary>
    public abstract class CharacterController : MonoBehaviour
    {
        protected InputManager inputManager; // Gerenciador de entrada do personagem
        protected bool isShooting;
        protected bool isRunning;
        protected bool isDodging;
        protected bool isBlocking;

        protected virtual void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
        }

        protected abstract void HandleInput();

        public void SetShooting(bool shooting)
        {
            isShooting = shooting;
        }

        public void SetRunning(bool running)
        {
            isRunning = running;
        }

        public void StartDodge()
        {
            isDodging = true;
        }

        public void StopDodge()
        {
            isDodging = false;
        }

        public void StartBlock()
        {
            isBlocking = true;
        }

        public void StopBlock()
        {
            isBlocking = false;
        }
    }
}
