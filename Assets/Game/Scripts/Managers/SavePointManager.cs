using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia os pontos de salvamento no jogo.
    /// </summary>
    public class SavePointManager : MonoBehaviour
    {
        private Dictionary<string, SavePointData> savePoints; // Dicionário de pontos de salvamento

        private void Awake()
        {
            // Inicializa o dicionário de pontos de salvamento
            savePoints = new Dictionary<string, SavePointData>();
        }

        /// <summary>
        /// Salva o estado atual do jogo em um ponto de salvamento.
        /// </summary>
        /// <param name="savePointName">O nome do ponto de salvamento.</param>
        public void SaveGame(string savePointName)
        {
            if (savePoints.ContainsKey(savePointName))
            {
                // Salva o estado do jogo no ponto de salvamento
                SavePointData savePointData = savePoints[savePointName];
                savePointData.SaveGameState();

                Debug.Log($"Jogo salvo no ponto de salvamento: {savePointName}");
            }
            else
            {
                Debug.LogWarning($"SavePointManager: Ponto de salvamento '{savePointName}' não encontrado.");
            }
        }

        /// <summary>
        /// Carrega o estado do jogo a partir de um ponto de salvamento.
        /// </summary>
        /// <param name="savePointName">O nome do ponto de salvamento.</param>
        public void LoadGame(string savePointName)
        {
            if (savePoints.ContainsKey(savePointName))
            {
                // Carrega o estado do jogo a partir do ponto de salvamento
                SavePointData savePointData = savePoints[savePointName];
                savePointData.LoadGameState();

                Debug.Log($"Jogo carregado do ponto de salvamento: {savePointName}");
            }
            else
            {
                Debug.LogWarning($"SavePointManager: Ponto de salvamento '{savePointName}' não encontrado.");
            }
        }

        /// <summary>
        /// Adiciona um ponto de salvamento ao gerenciador.
        /// </summary>
        /// <param name="savePointName">O nome do ponto de salvamento.</param>
        /// <param name="savePointData">Os dados do ponto de salvamento.</param>
        public void AddSavePoint(string savePointName, SavePointData savePointData)
        {
            if (!savePoints.ContainsKey(savePointName))
            {
                // Adiciona o ponto de salvamento ao dicionário
                savePoints.Add(savePointName, savePointData);
            }
            else
            {
                Debug.LogWarning($"SavePointManager: Ponto de salvamento '{savePointName}' já existe.");
            }
        }

        /// <summary>
        /// Remove um ponto de salvamento do gerenciador.
        /// </summary>
        /// <param name="savePointName">O nome do ponto de salvamento a ser removido.</param>
        public void RemoveSavePoint(string savePointName)
        {
            if (savePoints.ContainsKey(savePointName))
            {
                // Remove o ponto de salvamento do dicionário
                savePoints.Remove(savePointName);
            }
            else
            {
                Debug.LogWarning($"SavePointManager: Ponto de salvamento '{savePointName}' não encontrado.");
            }
        }
    }

    /// <summary>
    /// Classe que representa os dados de um ponto de salvamento.
    /// </summary>
    public class SavePointData
    {
        // Adicione aqui os campos necessários para salvar os dados do jogo, como pontuações, itens coletados, estados do jogo, etc.
        public int Score { get; set; }
        public List<string> CollectedItems { get; set; }
        public bool IsGameFinished { get; set; }

        /// <summary>
        /// Salva o estado do jogo.
        /// </summary>
        public void SaveGameState()
        {
            // Crie um objeto para armazenar os dados do jogo
            SaveData saveData = new SaveData();
            saveData.score = Score;
            saveData.collectedItems = CollectedItems;
            saveData.isGameFinished = IsGameFinished;

            // Converte o objeto em formato JSON
            string jsonData = JsonUtility.ToJson(saveData);

            // Salva o JSON em um arquivo ou em outra forma de armazenamento
            PlayerPrefs.SetString(Constants.SaveDataKey, jsonData);
            PlayerPrefs.Save();

            Debug.Log("Estado do jogo salvo.");
        }

        /// <summary>
        /// Carrega o estado do jogo.
        /// </summary>
        public void LoadGameState()
        {
            if (PlayerPrefs.HasKey("SaveData"))
            {
                // Obtém o JSON salvo
                string jsonData = PlayerPrefs.GetString("SaveData");

                // Converte o JSON de volta para o objeto SaveData
                SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);

                // Restaura os dados do jogo
                Score = saveData.score;
                CollectedItems = saveData.collectedItems;
                IsGameFinished = saveData.isGameFinished;

                Debug.Log("Estado do jogo carregado.");
            }
            else
            {
                Debug.Log("Nenhum estado de jogo salvo encontrado.");
            }
        }

        // Classe auxiliar para armazenar os dados do jogo
        [System.Serializable]
        sealed class SaveData
        {
            public int score;
            public List<string> collectedItems;
            public bool isGameFinished;
        }
    }
}
