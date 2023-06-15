using System.Collections;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Skills
{
    /// <summary>
    /// Classe responsável por destruir um objeto após um determinado período de tempo como uma habilidade.
    /// </summary>
    public class SelfDestruct : BaseSkill
    {
        [SerializeField] private float duration = 1f;

        /// <summary>
        /// Duração antes do objeto ser destruído.
        /// </summary>
        public float Duration { get { return duration; } set { duration = value; } }

        private void Start()
        {
            StartCoroutine(SelfDestructSequence());
        }

        /// <summary>
        /// Sequência de autodestruição do objeto.
        /// </summary>
        private IEnumerator SelfDestructSequence()
        {
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
        }

        /// <summary>
        /// Ativa a habilidade de autodestruição.
        /// </summary>
        public override void Activate()
        {
            enabled = true;
        }

        /// <summary>
        /// Desativa a habilidade de autodestruição.
        /// </summary>
        public override void Deactivate()
        {
            enabled = false;
        }
    }
}
