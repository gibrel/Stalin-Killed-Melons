using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.Gameplay
{
    /// <summary>
    /// Gerencia a reutilização eficiente de objetos do jogo, como projéteis, explosões, power-ups e inimigos.
    /// </summary>
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance { get; private set; }

        [SerializeField] private GameObject prefab;
        [SerializeField] private int initialPoolSize = 10;

        private Queue<GameObject> objectPool = new Queue<GameObject>();

        /// <summary>
        /// Chamado quando o objeto é criado.
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                InitializePool();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Inicializa o pool de objetos.
        /// </summary>
        private void InitializePool()
        {
            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject obj = Instantiate(prefab, transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }

        /// <summary>
        /// Obtém um objeto do pool.
        /// </summary>
        /// <returns>O objeto obtido do pool.</returns>
        public GameObject GetObjectFromPool()
        {
            if (objectPool.Count == 0)
            {
                ExpandPool();
            }

            GameObject obj = objectPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Devolve um objeto para o pool.
        /// </summary>
        /// <param name="obj">O objeto a ser devolvido.</param>
        public void ReturnObjectToPool(GameObject obj)
        {
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

        /// <summary>
        /// Expande o pool de objetos adicionando novos objetos.
        /// </summary>
        private void ExpandPool()
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }
}