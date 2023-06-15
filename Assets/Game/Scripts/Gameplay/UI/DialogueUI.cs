using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe responsável por gerenciar a interface do usuário durante o diálogo.
    /// </summary>
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private Text dialogueText; // Texto do diálogo
        [SerializeField] private Text characterNameText; // Nome do personagem
        [SerializeField] private Image characterImage; // Imagem do personagem
        [SerializeField] private GameObject choicesPanel; // Painel de opções de escolha
        [SerializeField] private Transform choiceButtonParent; // Painel que contém os botões de escolha
        [SerializeField] private GameObject choiceButtonPrefab; // Prefab do botão de escolha

        private List<Button> choiceButtons; // Lista dos botões de escolha
        private int selectedChoiceIndex; // Índice da opção selecionada pelo jogador
        private bool isDialogueVisible; // Indica se a UI de diálogo está visível

        public bool IsDialogueVisible { get => isDialogueVisible; }


        private void Awake()
        {
            choiceButtons = new List<Button>();
        }

        /// <summary>
        /// Exibe a UI de diálogo.
        /// </summary>
        public void ShowDialogueUI()
        {
            isDialogueVisible = true;
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Oculta a UI de diálogo.
        /// </summary>
        public void HideDialogueUI()
        {
            isDialogueVisible = false;
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Exibe o texto do diálogo, nome do personagem e imagem do personagem na UI.
        /// </summary>
        /// <param name="dialogueText">O texto do diálogo.</param>
        /// <param name="characterName">O nome do personagem.</param>
        /// <param name="characterImage">A imagem do personagem.</param>
        public void ShowDialogue(string dialogueText, string characterName, Sprite characterImage)
        {
            this.dialogueText.text = dialogueText;
            characterNameText.text = characterName;
            this.characterImage.sprite = characterImage;
        }

        /// <summary>
        /// Exibe as opções de escolha na UI.
        /// </summary>
        /// <param name="choices">As opções de escolha.</param>
        public void ShowChoices(List<string> choices)
        {
            ClearChoiceButtons();

            for (int i = 0; i < choices.Count; i++)
            {
                int choiceIndex = i;
                GameObject choiceButtonObject = Instantiate(choiceButtonPrefab, choiceButtonParent);
                Button choiceButton = choiceButtonObject.GetComponent<Button>();
                Text choiceButtonText = choiceButtonObject.GetComponentInChildren<Text>();

                choiceButtonText.text = choices[i];
                choiceButton.onClick.AddListener(() => SelectChoice(choiceIndex));

                choiceButtons.Add(choiceButton);
            }

            choicesPanel.SetActive(true);
        }

        /// <summary>
        /// Oculta as opções de escolha na UI.
        /// </summary>
        public void HideChoices()
        {
            ClearChoiceButtons();
            choicesPanel.SetActive(false);
        }

        /// <summary>
        /// Índice da opção selecionada pelo jogador.
        /// </summary>
        public int SelectedChoiceIndex => selectedChoiceIndex;

        /// <summary>
        /// Seleciona uma opção de escolha.
        /// </summary>
        /// <param name="choiceIndex">O índice da opção selecionada.</param>
        private void SelectChoice(int choiceIndex)
        {
            selectedChoiceIndex = choiceIndex;
        }

        /// <summary>
        /// Limpa a lista de botões de escolha.
        /// </summary>
        private void ClearChoiceButtons()
        {
            foreach (Button choiceButton in choiceButtons)
            {
                Destroy(choiceButton.gameObject);
            }

            choiceButtons.Clear();
        }
    }
}
