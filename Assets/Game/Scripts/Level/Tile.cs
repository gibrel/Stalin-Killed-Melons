using UnityEngine;

namespace StalinKilledMelons.Level
{
    /// <summary>
    /// Classe que representa um tile do mapa.
    /// </summary>
    public class Tile : MonoBehaviour
    {
        [SerializeField] private LevelTheme theme; // Tema do tile
        [SerializeField] private Material[] materials; // Materiais para cada tema

        /// <summary>
        /// Define o tema do tile.
        /// </summary>
        /// <param name="theme">O tema do tile.</param>
        public void SetTheme(LevelTheme theme)
        {
            this.theme = theme;
            UpdateAppearance();
        }

        /// <summary>
        /// Atualiza a apar�ncia do tile com base no tema.
        /// </summary>
        private void UpdateAppearance()
        {
            // Verifica se o tema est� dentro do intervalo de materiais dispon�veis
            if ((int)theme >= 0 && (int)theme < materials.Length)
            {
                Renderer renderer = GetComponent<Renderer>();

                // Aplica o material correspondente ao tema
                renderer.material = materials[(int)theme];
            }
            else
            {
                Debug.LogWarning("Tema inv�lido para o tile: " + theme);
            }
        }
    }
}
