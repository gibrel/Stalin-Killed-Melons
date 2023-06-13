using StalinKilledMelons.Gameplay.Audio;
using StalinKilledMelons.Gameplay.Skills;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Combat
{
    /// <summary>
    /// Controla o comportamento de um proj�til no jogo, como causar dano a um objeto, exibir efeitos de explos�o e reproduzir sons.
    /// </summary>
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private int damage = 20; // Dano causado pelo proj�til
        [SerializeField] private float duration = 5f; // Dura��o do proj�til antes de se autodestruir
        [SerializeField] private GameObject explosionEffect; // Prefab do efeito de explos�o

        private void Awake()
        {
            SelfDestruct selfDestruct = gameObject.AddComponent<SelfDestruct>();
            selfDestruct.Duration = duration;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Verifica se o objeto colidido possui o componente HealthController e causa dano a ele
            HealthController health = collision.gameObject.GetComponentInParent<HealthController>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            // Instancia o efeito de explos�o na posi��o do proj�til
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

            PlaySound();

            Destroy(gameObject);
        }

        private void PlaySound()
        {
            SoundManager.PlaySound(Sound.GrenadeExplosion, transform.position);
        }
    }
}
