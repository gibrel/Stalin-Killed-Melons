using UnityEngine;

namespace StalinKilledMelons.Gameplay.Enviroment
{
    /// <summary>
    /// Classe responsável pelo gerenciamento de clima no jogo.
    /// </summary>
    public class WeatherManager : MonoBehaviour
    {
        [SerializeField] private WeatherState[] weatherStates; // Estados climáticos disponíveis
        [SerializeField] private float transitionDuration = 1f; // Duração da transição entre os estados climáticos

        private WeatherState currentWeatherState; // Estado climático atual
        private WeatherState targetWeatherState; // Estado climático alvo para a transição
        private float transitionTimer; // Cronômetro para controlar a transição

        private void Start()
        {
            // Define o estado climático inicial
            if (weatherStates.Length > 0)
            {
                currentWeatherState = weatherStates[0];
                currentWeatherState.StartWeatherState();
            }
        }

        private void Update()
        {
            // Verifica se há um estado climático alvo para a transição
            if (targetWeatherState != null)
            {
                // Atualiza a transição climática
                transitionTimer += Time.deltaTime;

                // Calcula a porcentagem de progresso da transição
                float transitionProgress = Mathf.Clamp01(transitionTimer / transitionDuration);

                // Interpola os valores climáticos entre o estado atual e o estado alvo
                currentWeatherState.LerpWeatherState(targetWeatherState, transitionProgress);

                // Verifica se a transição terminou
                if (transitionTimer >= transitionDuration)
                {
                    // Completa a transição climática
                    currentWeatherState.CompleteWeatherState();
                    targetWeatherState.StartWeatherState();

                    // Define o novo estado climático atual
                    currentWeatherState = targetWeatherState;

                    // Reseta os valores da transição
                    transitionTimer = 0f;
                    targetWeatherState = null;
                }
            }
        }

        /// <summary>
        /// Inicia a transição para um novo estado climático.
        /// </summary>
        /// <param name="weatherStateIndex">O índice do estado climático na lista de estados disponíveis.</param>
        public void StartWeatherTransition(int weatherStateIndex)
        {
            if (weatherStateIndex >= 0 && weatherStateIndex < weatherStates.Length)
            {
                // Obtém o estado climático alvo
                WeatherState newWeatherState = weatherStates[weatherStateIndex];

                // Verifica se o estado climático alvo é diferente do estado atual
                if (newWeatherState != currentWeatherState)
                {
                    // Define o estado climático alvo e reseta o cronômetro de transição
                    targetWeatherState = newWeatherState;
                    transitionTimer = 0f;
                }
            }
        }
    }

    /// <summary>
    /// Classe base para os diferentes estados climáticos.
    /// </summary>
    public class WeatherState : MonoBehaviour
    {
        public WeatherType Type { get; private set; } // O tipo de clima
        public Color SkyColor { get; private set; } // A cor do céu
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
        /// Inicia o estado climático.
        /// </summary>
        public void StartWeatherState()
        {
            // Implemente a lógica de inicialização específica para o estado climático
            switch (Type)
            {
                case WeatherType.None:
                    // Implemente a lógica para o estado "None"
                    break;
                case WeatherType.Ensolarado:
                    // Implemente a lógica para o estado "Ensolarado"
                    break;
                case WeatherType.Nublado:
                    // Implemente a lógica para o estado "Nublado"
                    break;
                case WeatherType.Chuvoso:
                    // Implemente a lógica para o estado "Chuvoso"
                    break;
                case WeatherType.Nevado:
                    // Implemente a lógica para o estado "Nevado"
                    break;
                case WeatherType.Ventania:
                    // Implemente a lógica para o estado "Ventania"
                    break;
                case WeatherType.Tempestuoso:
                    // Implemente a lógica para o estado "Tempestuoso"
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Interpola os valores climáticos entre o estado atual e o estado alvo.
        /// </summary>
        /// <param name="targetState">O estado climático alvo.</param>
        /// <param name="transitionProgress">O progresso da transição entre 0 e 1.</param>
        public void LerpWeatherState(WeatherState targetState, float transitionProgress)
        {
            // Implemente a lógica de interpolação dos valores climáticos
            switch (Type)
            {
                case WeatherType.None:
                    // Implemente a lógica para o estado "None"
                    break;
                case WeatherType.Ensolarado:
                    // Implemente a lógica para o estado "Ensolarado"
                    break;
                case WeatherType.Nublado:
                    // Implemente a lógica para o estado "Nublado"
                    break;
                case WeatherType.Chuvoso:
                    // Implemente a lógica para o estado "Chuvoso"
                    break;
                case WeatherType.Nevado:
                    // Implemente a lógica para o estado "Nevado"
                    break;
                case WeatherType.Ventania:
                    // Implemente a lógica para o estado "Ventania"
                    break;
                case WeatherType.Tempestuoso:
                    // Implemente a lógica para o estado "Tempestuoso"
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Conclui o estado climático.
        /// </summary>
        public void CompleteWeatherState()
        {
            // Implemente a lógica de conclusão específica para o estado climático
            switch (Type)
            {
                case WeatherType.None:
                    // Implemente a lógica para o estado "None"
                    break;
                case WeatherType.Ensolarado:
                    // Implemente a lógica para o estado "Ensolarado"
                    break;
                case WeatherType.Nublado:
                    // Implemente a lógica para o estado "Nublado"
                    break;
                case WeatherType.Chuvoso:
                    // Implemente a lógica para o estado "Chuvoso"
                    break;
                case WeatherType.Nevado:
                    // Implemente a lógica para o estado "Nevado"
                    break;
                case WeatherType.Ventania:
                    // Implemente a lógica para o estado "Ventania"
                    break;
                case WeatherType.Tempestuoso:
                    // Implemente a lógica para o estado "Tempestuoso"
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Estados climáticos possíveis em un nível.
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
