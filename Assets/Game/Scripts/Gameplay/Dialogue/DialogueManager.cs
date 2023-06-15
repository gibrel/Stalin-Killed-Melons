using StalinKilledMelons.Gameplay.UI;
using System.Collections.Generic;
using UnityEngine;
using static StalinKilledMelons.Gameplay.Dialogue.DialogueNode;

namespace StalinKilledMelons.Gameplay.Dialogue
{
    /// <summary>
    /// Classe responsável por gerenciar o diálogo entre personagens.
    /// </summary>
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [SerializeField] private DialogueUI dialogueUI;

        private DialogueNode currentNode; // Nó de diálogo atual
        private DialogueNode[] dialogueNodes; // Árvore de diálogo

        private Dictionary<string, Sprite> characterImages; // Dicionário para mapear nomes de personagens com suas respectivas imagens

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
        /// Inicia o diálogo a partir do nó de diálogo inicial.
        /// </summary>
        /// <param name="dialogueTree">A árvore de diálogo.</param>
        public void StartDialogue(DialogueNode[] dialogueTree)
        {
            dialogueNodes = dialogueTree;
            characterImages = new Dictionary<string, Sprite>();

            // Carrega as imagens dos personagens
            LoadCharacterImages();

            // Inicia o diálogo a partir do nó de diálogo inicial
            currentNode = dialogueNodes[0];
            ShowDialogueNode(currentNode);
        }

        /// <summary>
        /// Avança para o próximo nó de diálogo.
        /// </summary>
        public void ContinueDialogue()
        {
            if (currentNode != null)
            {
                if (currentNode.choices.Count > 0)
                {
                    // O nó atual possui opções de escolha
                    dialogueUI.HideChoices();
                    ShowDialogueNode(currentNode.choices[dialogueUI.SelectedChoiceIndex].nextNode);
                }
                else if (currentNode.nextNode != null)
                {
                    // Avança para o próximo nó de diálogo
                    ShowDialogueNode(currentNode.nextNode);
                }
                else
                {
                    // Fim do diálogo
                    EndDialogue();
                }
            }
        }

        /// <summary>
        /// Exibe um nó de diálogo na interface do usuário.
        /// </summary>
        /// <param name="node">O nó de diálogo a ser exibido.</param>
        private void ShowDialogueNode(DialogueNode node)
        {
            currentNode = node;
            string characterName = currentNode.characterName;
            Sprite characterImage = characterImages.ContainsKey(characterName) ? characterImages[characterName] : null;

            dialogueUI.ShowDialogue(node.dialogueText, characterName, characterImage);

            if (currentNode.choices.Count > 0)
            {
                // O nó atual possui opções de escolha
                List<string> choices = new List<string>();
                foreach (Choice choice in currentNode.choices)
                {
                    choices.Add(choice.choiceText);
                }
                dialogueUI.ShowChoices(choices);
            }
        }

        /// <summary>
        /// Carrega as imagens dos personagens a partir dos sprites atribuídos no Unity Editor.
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
        /// Finaliza o diálogo.
        /// </summary>
        private void EndDialogue()
        {
            // Implemente a lógica para finalizar o diálogo
        }
    }

    /// <summary>
    /// Classe que representa um nó de diálogo.
    /// </summary>
    [System.Serializable]
    public class DialogueNode
    {
        public string characterName; // Nome do personagem
        public Sprite characterSprite; // Imagem do personagem
        public string dialogueText; // Texto do diálogo

        public List<Choice> choices = new List<Choice>(); // Opções de escolha para o jogador

        public DialogueNode nextNode; // Próximo nó de diálogo (quando não há escolhas)

        /// <summary>
        /// Classe que representa uma opção de escolha.
        /// </summary>
        [System.Serializable]
        public class Choice
        {
            public string choiceText; // Texto da opção
            public DialogueNode nextNode; // Próximo nó de diálogo após escolher essa opção
        }
    }
}
