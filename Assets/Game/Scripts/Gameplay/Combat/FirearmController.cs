using StalinKilledMelons.Gameplay.Audio;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Combat
{
    /// <summary>
    /// Controla a arma de fogo, permitindo disparos de projéteis.
    /// </summary>
    public class FirearmController : MonoBehaviour
    {
        [SerializeField] private GameObject projectile; // Prefab do projétil
        [SerializeField] private float projectileImpulse = 20f; // Impulso do projétil
        [SerializeField] private float timeBetweenShots = 2f; // Tempo entre os disparos
        [SerializeField] private float maximumShootDistance = 10f; // Distância máxima de disparo
        [SerializeField] private int firearmGroup = 0; // Grupo da arma de fogo
        [SerializeField] private bool isFromPlayer = false; // Indica se a arma pertence ao jogador

        private float lastShootTime;
        private Transform playerTransform;

        /// <summary>
        /// Indica se a arma pertence ao jogador.
        /// </summary>
        public bool IsPlayer { get { return isFromPlayer; } }

        /// <summary>
        /// Retorna o grupo da arma de fogo.
        /// </summary>
        public int FirearmGroup { get { return firearmGroup; } }

        private void Awake()
        {
            lastShootTime = -timeBetweenShots;

            if (!isFromPlayer)
            {
                var player = GameObject.FindGameObjectWithTag("Player");
                playerTransform = player.transform;
            }
        }

        /// <summary>
        /// Realiza um disparo.
        /// </summary>
        public void Shoot()
        {
            if (Time.time >= lastShootTime + timeBetweenShots)
            {
                lastShootTime = Time.time;

                if (isFromPlayer)
                {
                    var obj = Instantiate(projectile, transform.position, Quaternion.identity);
                    obj.GetComponent<Rigidbody2D>().AddForce(projectileImpulse * transform.up);

                    PlaySound();
                }
                else
                {
                    var distance = playerTransform.position - transform.position;
                    if (Mathf.Abs(distance.magnitude) <= maximumShootDistance)
                    {
                        var direction = distance.normalized;

                        var obj = Instantiate(projectile, transform.position, Quaternion.identity);
                        obj.GetComponent<Rigidbody2D>().AddForce(projectileImpulse * new Vector2(direction.x, direction.y));

                        PlaySound();
                    }
                }
            }
        }

        private void PlaySound()
        {
            SoundManager.PlaySound(Sound.GunFire, transform.position);
        }
    }
}
