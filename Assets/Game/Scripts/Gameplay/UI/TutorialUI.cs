using StalinKilledMelons.Gameplay.Tutorial;
using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Controla a UI do tutorial.
    /// </summary>
    public class TutorialUI : MonoBehaviour
    {
        [SerializeField] private Text tutorialText; // O objeto de texto para exibir as instruções do tutorial
        [SerializeField] private Button continueButton; // O botão para continuar para o próximo passo do tutorial
        [SerializeField] private Animator tutorialAnimator; // O animator para controlar as animações da UI do tutorial

        private TutorialManager tutorialManager; // Referência ao TutorialManager

        public bool IsTutorialUIActive { get; private set; } // Indica se a UI do tutorial está ativa

        private void Start()
        {
            // Obtém a referência ao TutorialManager
            tutorialManager = FindObjectOfType<TutorialManager>();

            // Configura o botão de continuar para avançar para o próximo passo do tutorial
            continueButton.onClick.AddListener(OnContinueButtonClicked);
        }

        /// <summary>
        /// Atualiza a UI do tutorial com o texto fornecido.
        /// </summary>
        /// <param name="text">O texto para exibir na UI do tutorial.</param>
        public void UpdateTutorialText(string text)
        {
            tutorialText.text = text;
        }

        /// <summary>
        /// Ativa ou desativa a exibição da UI do tutorial.
        /// </summary>
        /// <param name="isActive">Determina se a UI do tutorial deve ser ativada ou desativada.</param>
        public void SetTutorialUIActive(bool isActive)
        {
            IsTutorialUIActive = isActive;
            gameObject.SetActive(isActive);
        }

        /// <summary>
        /// Controla a animação de transição da UI do tutorial.
        /// </summary>
        /// <param name="isShowing">Determina se a UI do tutorial está sendo mostrada ou escondida.</param>
        public void AnimateTutorialUI(bool isShowing)
        {
            tutorialAnimator.SetBool(Constants.ShowTrigger, isShowing);
        }

        /// <summary>
        /// Manipula o evento de clique no botão de continuar.
        /// </summary>
        private void OnContinueButtonClicked()
        {
            tutorialManager.CompleteCurrentStep();
        }
    }
}