using StalinKilledMelons.Gameplay.UI;
using System.Collections;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Tutorial
{
    /// <summary>
    /// Gerencia o tutorial, exibindo os passos sequencialmente.
    /// </summary>
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private TutorialStep[] tutorialSteps; // Os passos do tutorial
        [SerializeField] private TutorialUI tutorialUI; // O objeto da UI do tutorial

        private int currentStepIndex; // O índice do passo atual do tutorial

        private void Start()
        {
            // Inicia o tutorial
            StartTutorial();
        }

        /// <summary>
        /// Inicia o tutorial.
        /// </summary>
        private void StartTutorial()
        {
            currentStepIndex = 0;
            StartCoroutine(ShowCurrentStep());
        }

        /// <summary>
        /// Exibe o passo atual do tutorial.
        /// </summary>
        private IEnumerator ShowCurrentStep()
        {
            // Verifica se o tutorial foi concluído
            if (currentStepIndex >= tutorialSteps.Length)
            {
                // Tutorial concluído
                tutorialUI.SetTutorialUIActive(false);
                yield break;
            }

            // Obtém o passo atual
            TutorialStep currentStep = tutorialSteps[currentStepIndex];

            // Atualiza a UI do tutorial com o texto do passo atual
            tutorialUI.UpdateTutorialText(currentStep.StepText);

            // Ativa a UI do tutorial
            tutorialUI.SetTutorialUIActive(true);

            // Aguarda pela interação do jogador ou por algum evento específico para continuar
            yield return currentStep.WaitForCompletion();

            // Completa o passo atual
            currentStep.CompleteStep();

            // Avança para o próximo passo do tutorial
            currentStepIndex++;
            yield return StartCoroutine(ShowCurrentStep());
        }

        /// <summary>
        /// Completa o passo atual do tutorial.
        /// Chamado pelo TutorialUI quando o jogador concluir o passo.
        /// </summary>
        public void CompleteCurrentStep()
        {
            // Verifica se o tutorial está ativo e se o índice do passo atual é válido
            if (tutorialUI.IsTutorialUIActive && currentStepIndex < tutorialSteps.Length)
            {
                // Obtém o passo atual
                TutorialStep currentStep = tutorialSteps[currentStepIndex];

                // Chama o método CompleteStep do passo atual
                currentStep.CompleteStep();
            }
        }
    }
}