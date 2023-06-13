using UnityEngine;

namespace StalinKilledMelons.Gameplay.Combat
{

    /// <summary>
    /// Classe responsável por gerar uma explosão no ambiente.
    /// </summary>
    public class ExplosionGenerator : MonoBehaviour
    {
        public float explosionRadius = 5f; // Raio da explosão
        public float explosionForce = 10f; // Força da explosão
        public float damage = 50f; // Dano causado pela explosão

        public GameObject explosionParticlesPrefab; // Prefab das partículas da explosão
        public Animator explosionAnimator; // Animator para controlar a animação da explosão

        private void Start()
        {
            Explode();
        }

        /// <summary>
        /// Gera a explosão, causando dano e aplicando força aos objetos afetados.
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
                // Instancia as partículas da explosão
                Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity);
            }

            if (explosionAnimator != null)
            {
                // Ativa a animação da explosão
                explosionAnimator.SetTrigger("Explode");
            }

            // Destroi o objeto da explosão após um tempo
            Destroy(gameObject, 1f);
        }
    }
}