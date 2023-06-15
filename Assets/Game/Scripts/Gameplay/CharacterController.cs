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

        protected virtual void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
        }

        protected abstract void HandleInput();
    }
}
