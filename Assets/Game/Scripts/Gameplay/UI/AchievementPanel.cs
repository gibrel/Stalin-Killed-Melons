using StalinKilledMelons.Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Painel de conquistas para exibir as conquistas obtidas na interface do usuário.
    /// </summary>
    public class AchievementPanel : MonoBehaviour
    {
        [SerializeField] private GameObject achievementPrefab; // Prefab do elemento de conquista
        [SerializeField] private Transform contentTransform; // Transform que contém os elementos de conquista
        [SerializeField] private Text titleText; // Texto do título do painel de conquistas

        private List<Managers.Achievement> achievements; // Lista de conquistas

        /// <summary>
        /// Inicialização do painel de conquistas.
        /// </summary>
        private void Start()
        {
            InitializeAchievements();
            UpdateAchievements();
        }

        /// <summary>
        /// Inicializa as conquistas.
        /// </summary>
        private void InitializeAchievements()
        {
            achievements = new List<Achievement>(AchievementManager.Instance.GetAllAchievements().Values);
        }

        /// <summary>
        /// Atualiza as conquistas exibidas no painel.
        /// </summary>
        public void UpdateAchievements()
        {
            ClearAchievements();

            foreach (Achievement achievement in achievements)
            {
                GameObject achievementObject = Instantiate(achievementPrefab, contentTransform);
                AchievementUI achievementUI = achievementObject.GetComponent<AchievementUI>();
                achievementUI.Setup(achievement);
            }
        }

        /// <summary>
        /// Limpa as conquistas exibidas no painel.
        /// </summary>
        private void ClearAchievements()
        {
            foreach (Transform child in contentTransform)
            {
                Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Exibe o painel de conquistas.
        /// </summary>
        public void ShowAchievements()
        {
            gameObject.SetActive(true);
            titleText.text = "Conquistas";
        }

        /// <summary>
        /// Oculta o painel de conquistas.
        /// </summary>
        public void HideAchievements()
        {
            gameObject.SetActive(false);
        }
    }
}
