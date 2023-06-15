using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe respons�vel por gerenciar a interface do usu�rio durante o di�logo.
    /// </summary>
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private Text dialogueText; // Texto do di�logo
        [SerializeField] private Text characterNameText; // Nome do personagem
        [SerializeField] private Image characterImage; // Imagem do personagem
        [SerializeField] private GameObject choicesPanel; // Painel de op��es de escolha
        [SerializeField] private Transform choiceButtonParent; // Painel que cont�m os bot�es de escolha
        [SerializeField] private GameObject choiceButtonPrefab; // Prefab do bot�o de escolha

        private List<Button> choiceButtons; // Lista dos bot�es de escolha
        private int selectedChoiceIndex; // �ndice da op��o selecionada pelo jogador
        private bool isDialogueVisible; // Indica se a UI de di�logo est� vis�vel

        public bool IsDialogueVisible { get => isDialogueVisible; }


        private void Awake()
        {
            choiceButtons = new List<Button>();
        }

        /// <summary>
        /// Exibe a UI de di�logo.
        /// </summary>
        public void ShowDialogueUI()
        {
            isDialogueVisible = true;
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Oculta a UI de di�logo.
        /// </summary>
        public void HideDialogueUI()
        {
            isDialogueVisible = false;
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Exibe o texto do di�logo, nome do personagem e imagem do personagem na UI.
        /// </summary>
        /// <param name="dialogueText">O texto do di�logo.</param>
        /// <param name="characterName">O nome do personagem.</param>
        /// <param name="characterImage">A imagem do personagem.</param>
        public void ShowDialogue(string dialogueText, string characterName, Sprite characterImage)
        {
            this.dialogueText.text = dialogueText;
            characterNameText.text = characterName;
            this.characterImage.sprite = characterImage;
        }

        /// <summary>
        /// Exibe as op��es de escolha na UI.
        /// </summary>
        /// <param name="choices">As op��es de escolha.</param>
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
        /// Oculta as op��es de escolha na UI.
        /// </summary>
        public void HideChoices()
        {
            ClearChoiceButtons();
            choicesPanel.SetActive(false);
        }

        /// <summary>
        /// �ndice da op��o selecionada pelo jogador.
        /// </summary>
        public int SelectedChoiceIndex => selectedChoiceIndex;

        /// <summary>
        /// Seleciona uma op��o de escolha.
        /// </summary>
        /// <param name="choiceIndex">O �ndice da op��o selecionada.</param>
        private void SelectChoice(int choiceIndex)
        {
            selectedChoiceIndex = choiceIndex;
        }

        /// <summary>
        /// Limpa a lista de bot�es de escolha.
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
