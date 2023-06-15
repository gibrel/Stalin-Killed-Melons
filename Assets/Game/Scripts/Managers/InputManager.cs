using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia a entrada do jogador e permite controles personalizados.
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        private PlayerPreferences playerPreferences; // Referência ao script PlayerPreferences

        private void Awake()
        {
            playerPreferences = FindObjectOfType<PlayerPreferences>();
        }

        /// <summary>
        /// Obtém o valor do eixo horizontal do jogador.
        /// </summary>
        public float GetHorizontalAxis()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.HorizontalAxisControl);
            return Input.GetAxis(controlKey);
        }

        /// <summary>
        /// Obtém o valor do eixo vertical do jogador.
        /// </summary>
        public float GetVerticalAxis()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.VerticalAxisControl);
            return Input.GetAxis(controlKey);
        }

        /// <summary>
        /// Obtém a entrada de tiro do jogador (mouse).
        /// </summary>
        public bool GetShootInput()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.ShootControl);
            return Input.GetButton(controlKey);
        }

        /// <summary>
        /// Obtém a posição do mouse.
        /// </summary>
        public Vector2 GetMousePosition()
        {
            return Input.mousePosition;
        }

        /// <summary>
        /// Obtém a entrada para correr do jogador.
        /// </summary>
        public bool GetRunInput()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.RunControl);
            return Input.GetButton(controlKey);
        }

        /// <summary>
        /// Obtém a entrada para esquivar do jogador.
        /// </summary>
        public bool GetDodgeInput()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.DodgeControl);
            return Input.GetButton(controlKey);
        }

        /// <summary>
        /// Obtém a entrada para bloquear do jogador.
        /// </summary>
        public bool GetBlockInput()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.BlockControl);
            return Input.GetButton(controlKey);
        }

        /// <summary>
        /// Obtém a entrada para ativar a habilidade 1 do jogador.
        /// </summary>
        public bool GetAbility1Input()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.Ability1Control);
            return Input.GetButton(controlKey);
        }

        /// <summary>
        /// Obtém a entrada para ativar a habilidade 2 do jogador.
        /// </summary>
        public bool GetAbility2Input()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.Ability2Control);
            return Input.GetButton(controlKey);
        }

        /// <summary>
        /// Obtém a entrada para ativar a habilidade 3 do jogador.
        /// </summary>
        public bool GetAbility3Input()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.Ability3Control);
            return Input.GetButton(controlKey);
        }

        /// <summary>
        /// Obtém a entrada para ativar a habilidade 4 do jogador.
        /// </summary>
        public bool GetAbility4Input()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.Ability4Control);
            return Input.GetButton(controlKey);
        }

        /// <summary>
        /// Obtém a entrada para ativar a habilidade 5 do jogador.
        /// </summary>
        public bool GetAbility5Input()
        {
            string controlKey = playerPreferences.GetControlKey(Constants.Ability5Control);
            return Input.GetButton(controlKey);
        }
    }
}
