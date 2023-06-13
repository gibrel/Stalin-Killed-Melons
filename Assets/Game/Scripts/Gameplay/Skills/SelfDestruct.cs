using System.Collections;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Skills
{
    /// <summary>
    /// Classe respons�vel por destruir um objeto ap�s um determinado per�odo de tempo.
    /// </summary>
    public class SelfDestruct : MonoBehaviour
    {
        [SerializeField] private float duration = 1f;

        /// <summary>
        /// Dura��o antes do objeto ser destru�do.
        /// </summary>
        public float Duration { get { return duration; } set { duration = value; } }

        private void Start()
        {
            StartCoroutine(SelfDestructSequence());
        }

        /// <summary>
        /// Sequ�ncia de autodestrui��o do objeto.
        /// </summary>
        private IEnumerator SelfDestructSequence()
        {
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
        }
    }
}
