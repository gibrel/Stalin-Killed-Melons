using StalinKilledMelons.Audio;
using StalinKilledMelons.Skills;
using UnityEngine;

namespace StalinKilledMelons.Combat
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private int damage = 20;
        [SerializeField] private float duration = 5f;
        [SerializeField] private GameObject explosionEffect;

        private void Awake()
        {
            SelfDestruct selfDestruct = gameObject.AddComponent<SelfDestruct>();
            selfDestruct.Duration = duration;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.GetComponent<Transform>().parent.TryGetComponent<HealthController>(out var health))
            {
                health.TakeDamage(damage);
            }

            Instantiate(explosionEffect, transform.position, Quaternion.identity);

            PlaySound();

            Destroy(gameObject);
        }

        private void PlaySound()
        {
            SoundManager.PlaySound(SoundManager.Sound.GrenadeExplosion, transform.position);
        }

    }
}