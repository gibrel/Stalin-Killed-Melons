using System;
using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia as miss�es do jogo.
    /// </summary>
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private List<Quest> quests; // Lista de miss�es dispon�veis no jogo

        private Dictionary<string, Quest> questDictionary; // Dicion�rio para mapear os IDs das miss�es com as inst�ncias de Quest

        // Eventos para notificar quando uma miss�o � iniciada, atualizada ou conclu�da
        public event Action<Quest> OnQuestStarted;
        public event Action<Quest> OnQuestUpdated;
        public event Action<Quest> OnQuestCompleted;

        private void Awake()
        {
            InitializeQuests();
        }

        /// <summary>
        /// Inicializa as miss�es e preenche o dicion�rio de miss�es.
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
        /// Inicia uma miss�o com o ID especificado.
        /// </summary>
        /// <param name="questID">O ID da miss�o a ser iniciada.</param>
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
        /// Atualiza o progresso de uma miss�o com o ID especificado.
        /// </summary>
        /// <param name="questID">O ID da miss�o a ser atualizada.</param>
        /// <param name="progress">O progresso atual da miss�o.</param>
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
        /// Completa uma miss�o com o ID especificado.
        /// </summary>
        /// <param name="questID">O ID da miss�o a ser conclu�da.</param>
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
    /// Classe que representa uma miss�o no jogo.
    /// </summary>
    [Serializable]
    public class Quest
    {
        public string ID; // ID �nico da miss�o
        public string title; // T�tulo da miss�o
        public string description; // Descri��o da miss�o
        public int targetProgress; // Progresso alvo da miss�o
        public bool isCompleted; // Indica se a miss�o est� conclu�da

        // Adicione aqui quaisquer outros par�metros ou informa��es necess�rias para a miss�o

        /// <summary>
        /// Inicia a miss�o.
        /// </summary>
        public void StartQuest()
        {
            isCompleted = false;
            // L�gica adicional para iniciar a miss�o
        }

        /// <summary>
        /// Atualiza o progresso da miss�o.
        /// </summary>
        /// <param name="progress">O progresso atual da miss�o.</param>
        public void UpdateProgress(int progress)
        {
            // L�gica para atualizar o progresso da miss�o

            // Verifica se a miss�o foi conclu�da
            if (progress >= targetProgress)
            {
                CompleteQuest();
            }
        }

        /// <summary>
        /// Marca a miss�o como conclu�da.
        /// </summary>
        public void CompleteQuest()
        {
            isCompleted = true;
            // L�gica adicional para concluir a miss�o
        }
    }
}
