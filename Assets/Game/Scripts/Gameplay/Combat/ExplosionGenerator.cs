using UnityEngine;

namespace StalinKilledMelons.Gameplay.Combat
{

    /// <summary>
    /// Classe respons�vel por gerar uma explos�o no ambiente.
    /// </summary>
    public class ExplosionGenerator : MonoBehaviour
    {
        public float explosionRadius = 5f; // Raio da explos�o
        public float explosionForce = 10f; // For�a da explos�o
        public float damage = 50f; // Dano causado pela explos�o

        public GameObject explosionParticlesPrefab; // Prefab das part�culas da explos�o
        public Animator explosionAnimator; // Animator para controlar a anima��o da explos�o

        private void Start()
        {
            Explode();
        }

        /// <summary>
        /// Gera a explos�o, causando dano e aplicando for�a aos objetos afetados.
        /// </summary>
        private void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider hitCollider in colliders)
            {
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);

                    // Aplica dano ao objeto se ele tiver um componente de vida
                    HealthController healthController = hitCollider.GetComponent<HealthController>();
                    if (healthController != null)
                    {
                        healthController.TakeDamage(damage);
                    }
                }
            }

            if (explosionParticlesPrefab != null)
            {
                // Instancia as part�culas da explos�o
                Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity);
            }

            if (explosionAnimator != null)
            {
                // Ativa a anima��o da explos�o
                explosionAnimator.SetTrigger("Explode");
            }

            // Destroi o objeto da explos�o ap�s um tempo
            Destroy(gameObject, 1f);
        }
    }
}