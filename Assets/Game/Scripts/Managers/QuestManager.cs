using System;
using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia as missões do jogo.
    /// </summary>
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private List<Quest> quests; // Lista de missões disponíveis no jogo

        private Dictionary<string, Quest> questDictionary; // Dicionário para mapear os IDs das missões com as instâncias de Quest

        // Eventos para notificar quando uma missão é iniciada, atualizada ou concluída
        public event Action<Quest> OnQuestStarted;
        public event Action<Quest> OnQuestUpdated;
        public event Action<Quest> OnQuestCompleted;

        private void Awake()
        {
            InitializeQuests();
        }

        /// <summary>
        /// Inicializa as missões e preenche o dicionário de missões.
        /// </summary>
        private void InitializeQuests()
        {
            questDictionary = new Dictionary<string, Quest>();

            foreach (Quest quest in quests)
            {
                questDictionary.Add(quest.ID, quest);
            }
        }

        /// <summary>
        /// Inicia uma missão com o ID especificado.
        /// </summary>
        /// <param name="questID">O ID da missão a ser iniciada.</param>
        public void StartQuest(string questID)
        {
            if (questDictionary.ContainsKey(questID))
            {
                Quest quest = questDictionary[questID];
                quest.StartQuest();

                OnQuestStarted?.Invoke(quest);
            }
            else
            {
                Debug.LogWarning($"QuestManager: No quest found with ID '{questID}'.");
            }
        }

        /// <summary>
        /// Atualiza o progresso de uma missão com o ID especificado.
        /// </summary>
        /// <param name="questID">O ID da missão a ser atualizada.</param>
        /// <param name="progress">O progresso atual da missão.</param>
        public void UpdateQuestProgress(string questID, int progress)
        {
            if (questDictionary.ContainsKey(questID))
            {
                Quest quest = questDictionary[questID];
                quest.UpdateProgress(progress);

                OnQuestUpdated?.Invoke(quest);
            }
            else
            {
                Debug.LogWarning($"QuestManager: No quest found with ID '{questID}'.");
            }
        }

        /// <summary>
        /// Completa uma missão com o ID especificado.
        /// </summary>
        /// <param name="questID">O ID da missão a ser concluída.</param>
        public void CompleteQuest(string questID)
        {
            if (questDictionary.ContainsKey(questID))
            {
                Quest quest = questDictionary[questID];
                quest.CompleteQuest();

                OnQuestCompleted?.Invoke(quest);
            }
            else
            {
                Debug.LogWarning($"QuestManager: No quest found with ID '{questID}'.");
            }
        }
    }

    /// <summary>
    /// Classe que representa uma missão no jogo.
    /// </summary>
    [Serializable]
    public class Quest
    {
        public string ID; // ID único da missão
        public string title; // Título da missão
        public string description; // Descrição da missão
        public int targetProgress; // Progresso alvo da missão
        public bool isCompleted; // Indica se a missão está concluída

        // Adicione aqui quaisquer outros parâmetros ou informações necessárias para a missão

        /// <summary>
        /// Inicia a missão.
        /// </summary>
        public void StartQuest()
        {
            isCompleted = false;
            // Lógica adicional para iniciar a missão
        }

        /// <summary>
        /// Atualiza o progresso da missão.
        /// </summary>
        /// <param name="progress">O progresso atual da missão.</param>
        public void UpdateProgress(int progress)
        {
            // Lógica para atualizar o progresso da missão

            // Verifica se a missão foi concluída
            if (progress >= targetProgress)
            {
                CompleteQuest();
            }
        }

        /// <summary>
        /// Marca a missão como concluída.
        /// </summary>
        public void CompleteQuest()
        {
            isCompleted = true;
            // Lógica adicional para concluir a missão
        }
    }
}
