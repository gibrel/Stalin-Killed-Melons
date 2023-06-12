using StalinKilledMelons.General;
using StalinKilledMelons.UI;
using System.Collections;
using UnityEngine;

namespace StalinKilledMelons.Combat
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private float health;
        [SerializeField] private float maxHealth = 100;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private float timeToDie = 1f;
        [SerializeField] private bool timeMode = false;

        private SpawnPointManager spawnPointManager;
        private GameTimer gameTimer;
        private ScoreManager scoreManager;

        public float MaxHealth { get { return maxHealth; } }
        public float Health { get { return health; } }

        private void Awake()
        {
            var gameController = GameObject.FindGameObjectWithTag("GameController");
            spawnPointManager = gameController.GetComponent<SpawnPointManager>();
            gameTimer = gameController.GetComponent<GameTimer>();
            scoreManager = gameController.GetComponent<ScoreManager>();
        }

        private void Start()
        {
            if (timeMode)
            {
                maxHealth = (int)gameTimer.GameTime;
                healthBar.SetMaximunHealth(maxHealth);
            }
            else
            {
                health = maxHealth;
                healthBar.SetMaximunHealth(maxHealth);
            }
        }

        private void Update()
        {
            if (timeMode)
            {
                health = (int)gameTimer.LackingGameTime;
                healthBar.SetHealth(health);
            }
        }

        public void TakeDamage(float damage)
        {
            if (!timeMode && !gameTimer.TimeHasRunOut)
            {
                health -= damage;
                if (health <= 0)
                {
                    health = 0;
                    StartCoroutine(SelfDestruct());
                }
                healthBar.SetHealth(health);

                if (!transform.CompareTag("Player"))
                {
                    scoreManager.AddPoints(damage);
                }
            }
        }

        private IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToDie);
            if (!gameObject.CompareTag("Player"))
            {
                spawnPointManager.DecreaseObjects();
            }
            Destroy(gameObject);
        }
    }

}