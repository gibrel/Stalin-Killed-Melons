using UnityEngine;

namespace StalinKilledMelons.General
{
    /// <summary>
    /// Responsável por gerenciar a criação e spawn de inimigos no jogo.
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefabs; // Prefabs dos inimigos que podem ser spawnados.
        [SerializeField] private int maxSimultaneousEnemies = 10; // Quantidade máxima de inimigos simultâneos permitidos.
        [SerializeField] private float minDistanceToSpawn = 20f; // Distância mínima em relação ao jogador para spawnar inimigos.
        [SerializeField] private float timeBetweenSpawns = 5f; // Tempo mínimo entre cada spawn.

        private Transform playerTransform; // Referência à transformação do jogador.
        private GameObject[] spawnPoints; // Pontos de spawn no cenário.
        private int currentEnemies = 0; // Quantidade atual de inimigos spawnados.
        private float timeFromLastSpawn = 0; // Tempo desde o último spawn.

        private const int MAX_DISTANCE_FROM_ORIGIN = 9999; // Distância máxima permitida para spwanar inimigos.

        /// <summary>
        /// Quantidade atual de inimigos spawnados.
        /// </summary>
        public int CurrentEnemyCount { get => currentEnemies; }

        /// <summary>
        /// Diminui a quantidade de inimigos spawnados.
        /// </summary>
        public void DecreaseEnemyCount()
        {
            currentEnemies--;
            if (currentEnemies < 0) currentEnemies = 0;
        }

        private void Awake()
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint"); // Encontra os pontos de spawn no cenário.
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Encontra a transformação do jogador.
        }

        private void Update()
        {
            // Verifica se um novo inimigo pode ser spawnado.
            if (Time.time > timeFromLastSpawn
                && currentEnemies < maxSimultaneousEnemies
                && enemyPrefabs.Length > 0
                && spawnPoints.Length > 0)
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            GameObject enemyPrefab = SelectEnemyPrefab(); // Seleciona um prefab de inimigo para spawnar.

            if (enemyPrefab == null) return;

            Vector3 spawnPosition = SelectSpawnPointPosition(); // Seleciona a posição de spawn.

            if (Mathf.Abs(spawnPosition.magnitude) >= Mathf.Abs((Vector3.one * MAX_DISTANCE_FROM_ORIGIN).magnitude)) return;

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Instancia o inimigo spawnado.

            currentEnemies++;

            timeFromLastSpawn = Time.time + timeBetweenSpawns; // Atualiza o tempo do último spawn.
        }

        private Vector3 SelectSpawnPointPosition()
        {
            Vector3 closestAllowedPoint = Vector3.one * 9999;

            foreach (GameObject spawnPoint in spawnPoints)
            {
                Vector3 position = spawnPoint.transform.position;

                float distanceFromPlayer = Mathf.Abs((playerTransform.position - position).magnitude);

                // Verifica se a posição de spawn está dentro da distância mínima e é a mais próxima até agora.
                if (distanceFromPlayer >= minDistanceToSpawn
                    && Mathf.Abs(position.magnitude) < Mathf.Abs(closestAllowedPoint.magnitude))
                {
                    closestAllowedPoint = position;
                }
            }

            return closestAllowedPoint;
        }

        private GameObject SelectEnemyPrefab()
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            return enemyPrefabs[randomIndex];
        }
    }
}
