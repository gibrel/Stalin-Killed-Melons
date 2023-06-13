using StalinKilledMelons.Gameplay.Combat;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Skills
{
    /// <summary>
    /// Classe responsável pelo controle de disparo de armas.
    /// </summary>
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private FirearmController[] firearms;

        private void Update()
        {
            Shoot();
        }

        /// <summary>
        /// Realiza o disparo das armas controladas pelo jogador.
        /// </summary>
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
