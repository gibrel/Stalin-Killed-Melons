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
        [SerializeField] private TutorialStep nextStep; // O pr�ximo passo do tutorial ap�s este

        /// <summary>
        /// Obt�m o texto deste passo do tutorial.
        /// </summary>
        public string StepText => stepText;

        /// <summary>
        /// Obt�m os elementos interativos relacionados a este passo do tutorial.
        /// </summary>
        public GameObject[] InteractiveElements => interactiveElements;

        /// <summary>
        /// Obt�m o pr�ximo passo do tutorial ap�s este.
        /// </summary>
        public TutorialStep NextStep => nextStep;

        /// <summary>
        /// Aguarda pela conclus�o deste passo do tutorial.
        /// </summary>
        public YieldInstruction WaitForCompletion()
        {
            // Implemente a l�gica para aguardar pela conclus�o deste passo
            // Por exemplo, aguardar pelo jogador pressionar um bot�o, concluir uma a��o, etc.
            // Retorne a instru��o de espera apropriada

            return null; // Substitua com a instru��o de espera apropriada
        }

        /// <summary>
        /// Executa as a��es quando este passo do tutorial for conclu�do.
        /// </summary>
        public void CompleteStep()
        {
            // Implemente as a��es a serem executadas quando o passo for conclu�do
        }
    }
}