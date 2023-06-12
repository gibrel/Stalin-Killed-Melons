using StalinKilledMelons.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace StalinKilledMelons.AI
{
    public class EnemyController : MonoBehaviour
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

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
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
                    ErraticMovement();
                }
            }
            else
            {
                navigation.SetTarget(player.transform);
                ErraticMovement();
            }
        }

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

        private void Activate()
        {
            activated = true;
            navigation.SetTarget(player.transform);
        }

        private void ErraticMovement()
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
    }
}
