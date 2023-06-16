using UnityEngine;

namespace StalinKilledMelons.Gameplay.Enviroment
{
    /// <summary>
    /// Classe respons�vel pelo gerenciamento de clima no jogo.
    /// </summary>
    public class WeatherManager : MonoBehaviour
    {
        [SerializeField] private WeatherState[] weatherStates; // Estados clim�ticos dispon�veis
        [SerializeField] private float transitionDuration = 1f; // Dura��o da transi��o entre os estados clim�ticos

        private WeatherState currentWeatherState; // Estado clim�tico atual
        private WeatherState targetWeatherState; // Estado clim�tico alvo para a transi��o
        private float transitionTimer; // Cron�metro para controlar a transi��o

        private void Start()
        {
            // Define o estado clim�tico inicial
            if (weatherStates.Length > 0)
            {
                currentWeatherState = weatherStates[0];
                currentWeatherState.StartWeatherState();
            }
        }

        private void Update()
        {
            // Verifica se h� um estado clim�tico alvo para a transi��o
            if (targetWeatherState != null)
            {
                // Atualiza a transi��o clim�tica
                transitionTimer += Time.deltaTime;

                // Calcula a porcentagem de progresso da transi��o
                float transitionProgress = Mathf.Clamp01(transitionTimer / transitionDuration);

                // Interpola os valores clim�ticos entre o estado atual e o estado alvo
                currentWeatherState.LerpWeatherState(targetWeatherState, transitionProgress);

                // Verifica se a transi��o terminou
                if (transitionTimer >= transitionDuration)
                {
                    // Completa a transi��o clim�tica
                    currentWeatherState.CompleteWeatherState();
                    targetWeatherState.StartWeatherState();

                    // Define o novo estado clim�tico atual
                    currentWeatherState = targetWeatherState;

                    // Reseta os valores da transi��o
                    transitionTimer = 0f;
                    targetWeatherState = null;
                }
            }
        }

        /// <summary>
        /// Inicia a transi��o para um novo estado clim�tico.
        /// </summary>
        /// <param name="weatherStateIndex">O �ndice do estado clim�tico na lista de estados dispon�veis.</param>
        public void StartWeatherTransition(int weatherStateIndex)
        {
            if (weatherStateIndex >= 0 && weatherStateIndex < weatherStates.Length)
            {
                // Obt�m o estado clim�tico alvo
                WeatherState newWeatherState = weatherStates[weatherStateIndex];

                // Verifica se o estado clim�tico alvo � diferente do estado atual
                if (newWeatherState != currentWeatherState)
                {
                    // Define o estado clim�tico alvo e reseta o cron�metro de transi��o
                    targetWeatherState = newWeatherState;
                    transitionTimer = 0f;
                }
            }
        }
    }

    /// <summary>
    /// Classe base para os diferentes estados clim�ticos.
    /// </summary>
    public class WeatherState : MonoBehaviour
    {
        public WeatherType Type { get; private set; } // O tipo de clima
        public Color SkyColor { get; private set; } // A cor do c�u
        public Color FogColor { get; private set; } // A cor do nevoeiro
        public float FogDensity { get; private set; } // A densidade do nevoeiro

        public WeatherState(WeatherType type, Color skyColor, Color fogColor, float fogDensity)
        {
            Type = type;
            SkyColor = skyColor;
            FogColor = fogColor;
            FogDensity = fogDensity;
        }

        /// <summary>
        /// Inicia o estado clim�tico.
        /// </summary>
        public void StartWeatherState()
        {
            // Implemente a l�gica de inicializa��o espec�fica para o estado clim�tico
            switch (Type)
            {
                case WeatherType.None:
                    // Implemente a l�gica para o estado "None"
                    break;
                case WeatherType.Ensolarado:
                    // Implemente a l�gica para o estado "Ensolarado"
                    break;
                case WeatherType.Nublado:
                    // Implemente a l�gica para o estado "Nublado"
                    break;
                case WeatherType.Chuvoso:
                    // Implemente a l�gica para o estado "Chuvoso"
                    break;
                case WeatherType.Nevado:
                    // Implemente a l�gica para o estado "Nevado"
                    break;
                case WeatherType.Ventania:
                    // Implemente a l�gica para o estado "Ventania"
                    break;
                case WeatherType.Tempestuoso:
                    // Implemente a l�gica para o estado "Tempestuoso"
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Interpola os valores clim�ticos entre o estado atual e o estado alvo.
        /// </summary>
        /// <param name="targetState">O estado clim�tico alvo.</param>
        /// <param name="transitionProgress">O progresso da transi��o entre 0 e 1.</param>
        public void LerpWeatherState(WeatherState targetState, float transitionProgress)
        {
            // Implemente a l�gica de interpola��o dos valores clim�ticos
            switch (Type)
            {
                case WeatherType.None:
                    // Implemente a l�gica para o estado "None"
                    break;
                case WeatherType.Ensolarado:
                    // Implemente a l�gica para o estado "Ensolarado"
                    break;
                case WeatherType.Nublado:
                    // Implemente a l�gica para o estado "Nublado"
                    break;
                case WeatherType.Chuvoso:
                    // Implemente a l�gica para o estado "Chuvoso"
                    break;
                case WeatherType.Nevado:
                    // Implemente a l�gica para o estado "Nevado"
                    break;
                case WeatherType.Ventania:
                    // Implemente a l�gica para o estado "Ventania"
                    break;
                case WeatherType.Tempestuoso:
                    // Implemente a l�gica para o estado "Tempestuoso"
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Conclui o estado clim�tico.
        /// </summary>
        public void CompleteWeatherState()
        {
            // Implemente a l�gica de conclus�o espec�fica para o estado clim�tico
            switch (Type)
            {
                case WeatherType.None:
                    // Implemente a l�gica para o estado "None"
                    break;
                case WeatherType.Ensolarado:
                    // Implemente a l�gica para o estado "Ensolarado"
                    break;
                case WeatherType.Nublado:
                    // Implemente a l�gica para o estado "Nublado"
                    break;
                case WeatherType.Chuvoso:
                    // Implemente a l�gica para o estado "Chuvoso"
                    break;
                case WeatherType.Nevado:
                    // Implemente a l�gica para o estado "Nevado"
                    break;
                case WeatherType.Ventania:
                    // Implemente a l�gica para o estado "Ventania"
                    break;
                case WeatherType.Tempestuoso:
                    // Implemente a l�gica para o estado "Tempestuoso"
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Estados clim�ticos poss�veis em un n�vel.
    /// </summary>
    public enum WeatherType
    {
        None,
        Ensolarado,
        Nublado,
        Chuvoso,
        Nevado,
        Ventania,
        Tempestuoso
    }

}
