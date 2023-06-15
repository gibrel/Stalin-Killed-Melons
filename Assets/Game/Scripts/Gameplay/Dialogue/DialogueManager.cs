using StalinKilledMelons.Gameplay.UI;
using System.Collections.Generic;
using UnityEngine;
using static StalinKilledMelons.Gameplay.Dialogue.DialogueNode;

namespace StalinKilledMelons.Gameplay.Dialogue
{
    /// <summary>
    /// Classe respons�vel por gerenciar o di�logo entre personagens.
    /// </summary>
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [SerializeField] private DialogueUI dialogueUI;

        private DialogueNode currentNode; // N� de di�logo atual
        private DialogueNode[] dialogueNodes; // �rvore de di�logo

        private Dictionary<string, Sprite> characterImages; // Dicion�rio para mapear nomes de personagens com suas respectivas imagens

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Inicia o di�logo a partir do n� de di�logo inicial.
        /// </summary>
        /// <param name="dialogueTree">A �rvore de di�logo.</param>
        public void StartDialogue(DialogueNode[] dialogueTree)
        {
            dialogueNodes = dialogueTree;
            characterImages = new Dictionary<string, Sprite>();

            // Carrega as imagens dos personagens
            LoadCharacterImages();

            // Inicia o di�logo a partir do n� de di�logo inicial
            currentNode = dialogueNodes[0];
            ShowDialogueNode(currentNode);
        }

        /// <summary>
        /// Avan�a para o pr�ximo n� de di�logo.
        /// </summary>
        public void ContinueDialogue()
        {
            if (currentNode != null)
            {
                if (currentNode.choices.Count > 0)
                {
                    // O n� atual possui op��es de escolha
                    dialogueUI.HideChoices();
                    ShowDialogueNode(currentNode.choices[dialogueUI.SelectedChoiceIndex].nextNode);
                }
                else if (currentNode.nextNode != null)
                {
                    // Avan�a para o pr�ximo n� de di�logo
                    ShowDialogueNode(currentNode.nextNode);
                }
                else
                {
                    // Fim do di�logo
                    EndDialogue();
                }
            }
        }

        /// <summary>
        /// Exibe um n� de di�logo na interface do usu�rio.
        /// </summary>
        /// <param name="node">O n� de di�logo a ser exibido.</param>
        private void ShowDialogueNode(DialogueNode node)
        {
            currentNode = node;
            string characterName = currentNode.characterName;
            Sprite characterImage = characterImages.ContainsKey(characterName) ? characterImages[characterName] : null;

            dialogueUI.ShowDialogue(node.dialogueText, characterName, characterImage);

            if (currentNode.choices.Count > 0)
            {
                // O n� atual possui op��es de escolha
                List<string> choices = new List<string>();
                foreach (Choice choice in currentNode.choices)
                {
                    choices.Add(choice.choiceText);
                }
                dialogueUI.ShowChoices(choices);
            }
        }

        /// <summary>
        /// Carrega as imagens dos personagens a partir dos sprites atribu�dos no Unity Editor.
        /// </summary>
        private void LoadCharacterImages()
        {
            foreach (DialogueNode node in dialogueNodes)
            {
                string characterName = node.characterName;
                Sprite characterSprite = node.characterSprite;

                if (!characterImages.ContainsKey(characterName) && characterSprite != null)
                {
                    characterImages.Add(characterName, characterSprite);
                }
            }
        }

        /// <summary>
        /// Finaliza o di�logo.
        /// </summary>
        private void EndDialogue()
        {
            // Implemente a l�gica para finalizar o di�logo
        }
    }

    /// <summary>
    /// Classe que representa um n� de di�logo.
    /// </summary>
    [System.Serializable]
    public class DialogueNode
    {
        public string characterName; // Nome do personagem
        public Sprite characterSprite; // Imagem do personagem
        public string dialogueText; // Texto do di�logo

        public List<Choice> choices = new List<Choice>(); // Op��es de escolha para o jogador

        public DialogueNode nextNode; // Pr�ximo n� de di�logo (quando n�o h� escolhas)

        /// <summary>
        /// Classe que representa uma op��o de escolha.
        /// </summary>
        [System.Serializable]
        public class Choice
        {
            public string choiceText; // Texto da op��o
            public DialogueNode nextNode; // Pr�ximo n� de di�logo ap�s escolher essa op��o
        }
    }
}
