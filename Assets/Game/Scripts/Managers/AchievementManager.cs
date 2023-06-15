using System;
using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia as conquistas do jogo.
    /// </summary>
    public class AchievementManager : MonoBehaviour
    {
        public static AchievementManager Instance { get; private set; } // Propriedade estática para acessar o gerenciador de conquistas

        [SerializeField] private List<Achievement> achievements; // Lista de conquistas disponíveis no jogo

        private Dictionary<string, Achievement> achievementDictionary; // Dicionário para mapear os IDs das conquistas com as instâncias de Achievement

        // Evento para notificar quando uma conquista é desbloqueada
        public static event Action<Achievement> OnAchievementUnlocked;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                InitializeAchievements();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Inicializa as conquistas e preenche o dicionário de conquistas.
        /// </summary>
        private void InitializeAchievements()
        {
            achievementDictionary = new Dictionary<string, Achievement>();

            foreach (Achievement achievement in achievements)
            {
                achievementDictionary.Add(achievement.ID, achievement);
                achievement.OnProgressUpdated += CheckAchievementUnlock; // Inscreve-se no evento de progresso atualizado de cada conquista
            }
        }

        /// <summary>
        /// Atualiza o progresso de uma conquista com o ID especificado.
        /// </summary>
        /// <param name="achievementID">O ID da conquista a ser atualizada.</param>
        /// <param name="progress">O progresso atual da conquista.</param>
        public void UpdateAchievementProgress(string achievementID, int progress)
        {
            if (achievementDictionary.ContainsKey(achievementID))
            {
                Achievement achievement = achievementDictionary[achievementID];
                achievement.UpdateProgress(progress);
            }
            else
            {
                Debug.LogWarning($"AchievementManager: No achievement found with ID '{achievementID}'.");
            }
        }

        /// <summary>
        /// Verifica se uma conquista foi desbloqueada ao atualizar seu progresso.
        /// </summary>
        /// <param name="achievement">A conquista atualizada.</param>
        private void CheckAchievementUnlock(Achievement achievement)
        {
            if (achievement.IsUnlocked)
            {
                UnlockAchievement(achievement);
            }
        }

        /// <summary>
        /// Desbloqueia uma conquista.
        /// </summary>
        /// <param name="achievement">A conquista a ser desbloqueada.</param>
        private void UnlockAchievement(Achievement achievement)
        {
            OnAchievementUnlocked?.Invoke(achievement);
        }

        /// <summary>
        /// Obtém todas as conquistas disponíveis.
        /// </summary>
        /// <returns>Um dicionário de conquistas com o ID como chave e a instância de Achievement como valor.</returns>
        public Dictionary<string, Achievement> GetAllAchievements()
        {
            return achievementDictionary;
        }

        /// <summary>
        /// Obtém o progresso de uma conquista com o ID especificado.
        /// </summary>
        /// <param name="achievementID">O ID da conquista.</param>
        /// <returns>O progresso atual da conquista.</returns>
        public int GetAchievementProgress(string achievementID)
        {
            if (achievementDictionary.ContainsKey(achievementID))
            {
                Achievement achievement = achievementDictionary[achievementID];
                return achievement.CurrentProgress;
            }

            Debug.LogWarning($"AchievementManager: No achievement found with ID '{achievementID}'.");
            return 0;
        }
    }

    /// <summary>
    /// Classe que representa uma conquista no jogo.
    /// </summary>
    [Serializable]
    public class Achievement
    {
        public string ID; // ID único da conquista
        public string title; // Título da conquista
        public string description; // Descrição da conquista
        public int targetProgress; // Progresso alvo da conquista
        public bool IsUnlocked { get; private set; } // Indica se a conquista está desbloqueada
        public Sprite icon; // Ícone da conquista

        // Evento para notificar quando o progresso da conquista é atualizado
        public event Action<Achievement> OnProgressUpdated;

        private int currentProgress; // Progresso atual da conquista

        public int CurrentProgress => currentProgress;

        /// <summary>
        /// Atualiza o progresso da conquista.
        /// </summary>
        /// <param name="progress">O progresso atual da conquista.</param>
        public void UpdateProgress(int progress)
        {
            currentProgress = progress;

            // Notifica os observadores (Listeners) sobre o progresso atualizado
            OnProgressUpdated?.Invoke(this);
        }

        /// <summary>
        /// Desbloqueia a conquista.
        /// </summary>
        public void Unlock()
        {
            IsUnlocked = true;

            // Lógica adicional para recompensar o jogador por desbloquear a conquista
        }
    }
}
