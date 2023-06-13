using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.AI
{
    /// <summary>
    /// Controla a inteligência artificial de um grupo de inimigos.
    /// </summary>
    public class AIController : MonoBehaviour
    {
        [SerializeField] private List<EnemyController> enemies = new List<EnemyController>();

        /// <summary>
        /// Chamado quando o objeto é criado.
        /// </summary>
        private void Awake()
        {
            // Encontra todos os colegas no grupo
            FindColleagues();
        }

        /// <summary>
        /// Encontra todos os colegas no grupo.
        /// </summary>
        private void FindColleagues()
        {
            enemies.Clear();
            enemies.AddRange(GetComponentsInChildren<EnemyController>());
        }

        /// <summary>
        /// Ativa todos os colegas do grupo.
        /// </summary>
        public void ActivateEnemies()
        {
            foreach (EnemyController enemy in enemies)
            {
                enemy.Activate();
            }
        }

        /// <summary>
        /// Desativa todos os inimigos do grupo.
        /// </summary>
        public void DeactivateEnemies()
        {
            foreach (EnemyController enemy in enemies)
            {
                enemy.Deactivate();
            }
        }

        /// <summary>
        /// Define um novo alvo para todos os inimigos do grupo.
        /// </summary>
        /// <param name="target">O novo alvo para os inimigos.</param>
        public void SetTargetForEnemies(Transform target)
        {
            foreach (EnemyController enemy in enemies)
            {
                enemy.SetTarget(target);
            }
        }
    }
}
