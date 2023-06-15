using StalinKilledMelons.Gameplay.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace StalinKilledMelons.Gameplay.AI
{
    /// <summary>
    /// Controla o comportamento de um inimigo.
    /// </summary>
    public class EnemyController : CharacterController
    {
        [SerializeField] private float activationDistance = 10f;
        [SerializeField] private float viewAngle = 60f;
        [SerializeField] private float erraticMovementInterval = 2f;
        [SerializeField] private float erraticMovementRange = 3f;

        private GameObject player;
        private NavMeshAgent navMeshAgent;
        private Navigation navigation;
        private bool activated = false;
        private bool erraticallyMoving = false;
        private float lastErraticMovementTime;

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.FindGameObjectWithTag(Constants.PlayerTag);
            navMeshAgent = GetComponent<NavMeshAgent>();
            navigation = GetComponent<Navigation>();
        }

        private void Update()
        {
            if (!activated)
            {
                if (ShouldActivate())
                {
                    Activate();
                }
                else
                {
                    PerformErraticMovement();
                }
            }
            else
            {
                navigation.SetTarget(player.transform);
                PerformErraticMovement();
            }
        }

        /// <summary>
        /// Verifica se o inimigo deve ser ativado.
        /// </summary>
        /// <returns><c>true</c> se o inimigo deve ser ativado, caso contr�rio, <c>false</c>.</returns>
        private bool ShouldActivate()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= activationDistance)
            {
                Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
                float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

                if (angleToPlayer <= viewAngle)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Ativa o inimigo.
        /// </summary>
        public void Activate()
        {
            activated = true;
            navigation.SetTarget(player.transform);
        }

        /// <summary>
        /// Desativa o inimigo.
        /// </summary>
        public void Deactivate()
        {
            activated = false;
        }

        /// <summary>
        /// Define o novo alvo para o inimigo.
        /// </summary>
        /// <param name="target">O novo alvo para o inimigo.</param>
        public void SetTarget(Transform target)
        {
            navigation.SetTarget(target);
        }

        /// <summary>
        /// Realiza o movimento err�tico.
        /// </summary>
        private void PerformErraticMovement()
        {
            if (Time.time - lastErraticMovementTime >= erraticMovementInterval)
            {
                if (!erraticallyMoving)
                {
                    erraticallyMoving = true;
                    Vector3 randomDestination = transform.position + Random.insideUnitSphere * erraticMovementRange;
                    navigation.SetTarget(randomDestination);
                }
                else
                {
                    erraticallyMoving = false;
                    navigation.SetTarget(player.transform);
                }

                lastErraticMovementTime = Time.time;
            }
        }

        protected override void HandleInput()
        {
            // Implementa��o vazia, pois o inimigo n�o lida com entrada do jogador

            // Outras a��es do inimigo
            if (isShooting)
            {
                // Implementa��o para o disparo do inimigo
            }

            if (isRunning)
            {
                // Implementa��o para a corrida do inimigo
            }

            if (isDodging)
            {
                // Implementa��o para a esquiva do inimigo
            }

            if (isBlocking)
            {
                // Implementa��o para o bloqueio do inimigo
            }
        }
    }
}
