using UnityEngine;

namespace StalinKilledMelons.Gameplay.Skills
{
    /// <summary>
    /// Classe base para habilidades.
    /// </summary>
    public abstract class BaseSkill : MonoBehaviour
    {
        /// <summary>
        /// Ativa a habilidade.
        /// </summary>
        public abstract void Activate();

        /// <summary>
        /// Desativa a habilidade.
        /// </summary>
        public abstract void Deactivate();
    }
}
