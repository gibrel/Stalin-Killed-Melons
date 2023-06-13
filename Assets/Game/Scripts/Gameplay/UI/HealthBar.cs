using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe respons�vel pela barra de vida na interface do usu�rio.
    /// </summary>
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider; // Refer�ncia ao componente Slider que representa a barra de vida
        [SerializeField] private Gradient gradient; // Gradiente de cores para a barra de vida
        [SerializeField] private Image fill; // Imagem que representa o preenchimento da barra de vida

        /// <summary>
        /// Define o valor atual da vida na barra de vida.
        /// </summary>
        /// <param name="health">O valor atual da vida.</param>
        public void SetHealth(float health)
        {
            slider.value = health;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }

        /// <summary>
        /// Define o valor m�ximo da vida na barra de vida.
        /// </summary>
        /// <param name="maxHealth">O valor m�ximo da vida.</param>
        public void SetMaxHealth(float maxHealth)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;

            fill.color = gradient.Evaluate(1f);
        }
    }
}
