using StalinKilledMelons.Audio;
using UnityEngine;

namespace StalinKilledMelons.Combat
{
    public class FirearmController : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private float projectileInpulse = 20f;
        [SerializeField] private float timeBetweenShots = 2f;
        [SerializeField] private float maximunShootDistance = 10f;
        [SerializeField] private int firearmGroup = 0;
        [SerializeField] private bool isFromPlayer = false;

        private float lastShootTime;
        private Transform playerTransform;

        public bool IsPlayer { get { return isFromPlayer; } }
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

        public void Shoot()
        {
            if (Time.time >= lastShootTime + timeBetweenShots)
            {
                lastShootTime = Time.time;

                if (isFromPlayer)
                {
                    var obj = Instantiate(projectile, transform.position, Quaternion.identity);
                    obj.GetComponent<Rigidbody2D>().AddForce(projectileInpulse * transform.up);

                    PlaySound();
                }
                else
                {
                    var distance = playerTransform.position - transform.position;
                    if (Mathf.Abs(distance.magnitude) <= maximunShootDistance)
                    {
                        var direction = distance.normalized;

                        var obj = Instantiate(projectile, transform.position, Quaternion.identity);
                        obj.GetComponent<Rigidbody2D>().AddForce(projectileInpulse * new Vector2(direction.x, direction.y));

                        PlaySound();
                    }
                }
            }
        }

        private void PlaySound()
        {
            SoundManager.PlaySound(SoundManager.Sound.GunFire, transform.position);
        }
    }
}
