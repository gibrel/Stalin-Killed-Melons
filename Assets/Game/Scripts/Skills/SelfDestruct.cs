using System.Collections;
using UnityEngine;

namespace StalinKilledMelons.Skills
{
    public class SelfDestruct : MonoBehaviour
    {
        [SerializeField] private float duration = 1f;

        public float Duration { get { return duration; } set { duration = value; } }

        private void Start()
        {
            StartCoroutine(SelfDestructSequence());
        }

        private IEnumerator SelfDestructSequence()
        {
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
        }
    }
}
