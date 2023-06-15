using StalinKilledMelons.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe responsável por configurar e exibir os elementos individuais de conquista.
    /// </summary>
    public class AchievementUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage; // Imagem do ícone da conquista
        [SerializeField] private Text titleText; // Texto do título da conquista
        [SerializeField] private Text descriptionText; // Texto da descrição da conquista
        [SerializeField] private Text progressText; // Texto do progresso da conquista
        [SerializeField] private Image progressBar; // Barra de progresso da conquista

        private Achievement achievement; // Referência para a conquista associada

        /// <summary>
        /// Configura o elemento de conquista com os dados da conquista fornecida.
        /// </summary>
        /// <param name="achievement">A conquista a ser configurada.</param>
        public void Setup(Achievement achievement)
        {
            this.achievement = achievement;

            iconImage.sprite = achievement.icon; // Define o sprite do ícone da conquista
            titleText.text = achievement.title; // Define o texto do título da conquista
            descriptionText.text = achievement.description; // Define o texto da descrição da conquista

            UpdateProgress();
        }

        /// <summary>
        /// Atualiza o progresso exibido na conquista.
        /// </summary>
        public void UpdateProgress()
        {
            int currentProgress = AchievementManager.Instance.GetAchievementProgress(achievement.ID);
            int targetProgress = achievement.targetProgress;

            progressText.text = string.Format("{0}/{1}", currentProgress, targetProgress); // Exibe o progresso atual e o progresso alvo

            float progressPercentage = Mathf.Clamp01((float)currentProgress / targetProgress); // Calcula a porcentagem de progresso (limitada entre 0 e 1)
            progressBar.fillAmount = progressPercentage; // Atualiza a barra de progresso
        }
    }
}
