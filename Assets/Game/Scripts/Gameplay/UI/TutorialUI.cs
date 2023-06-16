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
        [SerializeField] private Text tutorialText; // O objeto de texto para exibir as instru��es do tutorial
        [SerializeField] private Button continueButton; // O bot�o para continuar para o pr�ximo passo do tutorial
        [SerializeField] private Animator tutorialAnimator; // O animator para controlar as anima��es da UI do tutorial

        private TutorialManager tutorialManager; // Refer�ncia ao TutorialManager

        public bool IsTutorialUIActive { get; private set; } // Indica se a UI do tutorial est� ativa

        private void Start()
        {
            // Obt�m a refer�ncia ao TutorialManager
            tutorialManager = FindObjectOfType<TutorialManager>();

            // Configura o bot�o de continuar para avan�ar para o pr�ximo passo do tutorial
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
        /// Ativa ou desativa a exibi��o da UI do tutorial.
        /// </summary>
        /// <param name="isActive">Determina se a UI do tutorial deve ser ativada ou desativada.</param>
        public void SetTutorialUIActive(bool isActive)
        {
            IsTutorialUIActive = isActive;
            gameObject.SetActive(isActive);
        }

        /// <summary>
        /// Controla a anima��o de transi��o da UI do tutorial.
        /// </summary>
        /// <param name="isShowing">Determina se a UI do tutorial est� sendo mostrada ou escondida.</param>
        public void AnimateTutorialUI(bool isShowing)
        {
            tutorialAnimator.SetBool(Constants.ShowTrigger, isShowing);
        }

        /// <summary>
        /// Manipula o evento de clique no bot�o de continuar.
        /// </summary>
        private void OnContinueButtonClicked()
        {
            tutorialManager.CompleteCurrentStep();
        }
    }
}