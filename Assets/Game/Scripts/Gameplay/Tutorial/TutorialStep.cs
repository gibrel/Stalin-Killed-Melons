using UnityEngine;

namespace StalinKilledMelons.Gameplay.Tutorial
{
    /// <summary>
    /// Representa um passo individual do tutorial.
    /// </summary>
    public class TutorialStep : MonoBehaviour
    {
        [SerializeField] private string stepText; // O texto a ser exibido neste passo do tutorial
        [SerializeField] private GameObject[] interactiveElements; // Os elementos interativos relacionados a este passo
        [SerializeField] private TutorialStep nextStep; // O próximo passo do tutorial após este

        /// <summary>
        /// Obtém o texto deste passo do tutorial.
        /// </summary>
        public string StepText => stepText;

        /// <summary>
        /// Obtém os elementos interativos relacionados a este passo do tutorial.
        /// </summary>
        public GameObject[] InteractiveElements => interactiveElements;

        /// <summary>
        /// Obtém o próximo passo do tutorial após este.
        /// </summary>
        public TutorialStep NextStep => nextStep;

        /// <summary>
        /// Aguarda pela conclusão deste passo do tutorial.
        /// </summary>
        public YieldInstruction WaitForCompletion()
        {
            // Implemente a lógica para aguardar pela conclusão deste passo
            // Por exemplo, aguardar pelo jogador pressionar um botão, concluir uma ação, etc.
            // Retorne a instrução de espera apropriada

            return null; // Substitua com a instrução de espera apropriada
        }

        /// <summary>
        /// Executa as ações quando este passo do tutorial for concluído.
        /// </summary>
        public void CompleteStep()
        {
            // Implemente as ações a serem executadas quando o passo for concluído
        }
    }
}