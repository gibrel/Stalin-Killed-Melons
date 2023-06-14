using UnityEngine;

namespace StalinKilledMelons.Managers
{
    /// <summary>
    /// Gerencia o salvamento e carregamento do progresso do jogador.
    /// </summary>
    public static class SaveLoadManager
    {
        /// <summary>
        /// Salva o progresso do jogador.
        /// </summary>
        public static void SavePlayerProgress(PlayerProgressData playerProgressData)
        {
            string json = JsonUtility.ToJson(playerProgressData);
            PlayerPrefs.SetString(Constants.PlayerProgressKey, json);
        }

        /// <summary>
        /// Carrega o progresso do jogador.
        /// </summary>
        /// <returns>O progresso do jogador.</returns>
        public static PlayerProgressData LoadPlayerProgress()
        {
            string json = PlayerPrefs.GetString(Constants.PlayerProgressKey);
            if (!string.IsNullOrEmpty(json))
            {
                return JsonUtility.FromJson<PlayerProgressData>(json);
            }
            else
            {
                return new PlayerProgressData();
            }
        }
    }

    /// <summary>
    /// Dados do progresso do jogador.
    /// </summary>
    [System.Serializable]
    public class PlayerProgressData
    {
        public int score; // Pontuação do jogador.
        public int unlockedLevels; // Níveis desbloqueados.

        // Outras preferências do jogador podem ser adicionadas aqui.

        public PlayerProgressData()
        {
            score = 0;
            unlockedLevels = 1;
        }
    }
}
