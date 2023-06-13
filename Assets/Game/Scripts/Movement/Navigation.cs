using UnityEngine;
using UnityEngine.AI;

namespace StalinKilledMelons.Movement
{
    /// <summary>
    /// Classe responsável pelo movimento e navegação do agente no NavMesh.
    /// </summary>
    public class Navigation : MonoBehaviour
    {
        private bool followTransform = true; // Define se o agente deve seguir um transform
        private Transform destination; // Destino do agente (usado quando followTransform é true)
        private Vector3 destinationPoint; // Ponto de destino do agente (usado quando followTransform é false)
        private NavMeshAgent navMeshAgent; // Componente NavMeshAgent para a navegação

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
            destination = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            SetAgentDestination();
        }

        /// <summary>
        /// Define um novo alvo para o agente a seguir (usando um Transform).
        /// </summary>
        /// <param name="newTarget">O novo alvo do agente.</param>
        public void SetTarget(Transform newTarget)
        {
            followTransform = true;
            destination = newTarget;
        }

        /// <summary>
        /// Define um novo alvo para o agente a seguir (usando um ponto de destino).
        /// </summary>
        /// <param name="newTarget">O ponto de destino do agente.</param>
        public void SetTarget(Vector3 newTarget)
        {
            followTransform = false;
            destinationPoint = newTarget;
        }

        private void SetAgentDestination()
        {
            var position = transform.position;

            if (followTransform)
            {
                position.x = destination.position.x;
                position.y = destination.position.y;
            }
            else
            {
                position.x = destinationPoint.x;
                position.y = destinationPoint.y;
            }

            navMeshAgent.SetDestination(position);
        }
    }
}
