using StalinKilledMelons.Combat;
using StalinKilledMelons.UI;
using UnityEngine;

namespace StalinKilledMelons.Skills
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private FirearmController[] firearms;

        void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (Time.timeScale == 0f) return;

            foreach (FirearmController gun in firearms)
            {
                if (gun.IsPlayer)
                {
                    if (Input.GetMouseButton(gun.FirearmGroup))
                    {
                        gun.Shoot();
                    }
                }
                else
                {
                    gun.Shoot();
                }
            }
        }
    }

}