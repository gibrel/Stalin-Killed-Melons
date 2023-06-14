using StalinKilledMelons.Gameplay.UI;
using StalinKilledMelons.Managers;
using System.Collections;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Combat
{
    /// <summary>
    /// Controla a sa�de de um objeto no jogo, permitindo que ele receba danos e seja destru�do quando a sa�de chegar a zero.
    /// </summary>
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private float health; // Sa�de atual
        [SerializeField] private float maxHealth = 100; // Sa�de m�xima
        [SerializeField] private HealthBar healthBar; // Barra de sa�de
        [SerializeField] private float timeToDie = 1f; // Tempo at� a destrui��o ap�s a sa�de chegar a zero
        [SerializeField] private bool timeMode = false; // Modo de jogo baseado em tempo

        private EnemySpawner spawnPointManager; // Gerenciador dos pontos de spawn
        private GameTimer gameTimer; // Timer do jogo
        private ScoreManager scoreManager; // Gerenciador de pontua��o

        /// <summary>
        /// Retorna a sa�de m�xima.
        /// </summary>
        public float MaxHealth { get { return maxHealth; } }

        /// <summary>
        /// Retorna a sa�de atual.
        /// </summary>
        public float Health { get { return health; } }

        private void Awake()
        {
            var gameController = GameObject.FindGameObjectWithTag(Constants.GameControllerTag);
            spawnPointManager = gameController.GetComponent<EnemySpawner>();
            gameTimer = gameController.GetComponent<GameTimer>();
            scoreManager = gameController.GetComponent<ScoreManager>();
        }

        private void Start()
        {
            if (timeMode)
            {
                maxHealth = (int)gameTimer.GameTime;
                healthBar.SetMaxHealth(maxHealth);
            }
            else
            {
                health = maxHealth;
                healthBar.SetMaxHealth(maxHealth);
            }
        }

        private void Update()
        {
            if (timeMode)
            {
                health = (int)gameTimer.RemainingGameTime;
                healthBar.SetHealth(health);
            }
        }

        /// <summary>
        /// Aplica um determinado dano � sa�de do objeto.
        /// </summary>
        /// <param name="damage">Valor do dano a ser aplicado.</param>
        public void TakeDamage(float damage)
        {
            if (!timeMode && !gameTimer.HasTimeRunOut)
            {
                health -= damage;
                if (health <= 0)
                {
                    health = 0;
                    StartCoroutine(SelfDestruct());
                }
                healthBar.SetHealth(health);

                if (!transform.CompareTag(Constants.PlayerTag))
                {
                    scoreManager.AddPoints(damage);
                }
            }
        }

        private IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToDie);
            if (!gameObject.CompareTag(Constants.PlayerTag))
            {
                spawnPointManager.DecreaseEnemyCount();
            }
            Destroy(gameObject);
        }
    }
}
