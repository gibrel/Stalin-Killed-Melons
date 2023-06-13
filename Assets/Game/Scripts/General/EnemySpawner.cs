using UnityEngine;

namespace StalinKilledMelons.General
{
    /// <summary>
    /// Respons�vel por gerenciar a cria��o e spawn de inimigos no jogo.
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefabs; // Prefabs dos inimigos que podem ser spawnados.
        [SerializeField] private int maxSimultaneousEnemies = 10; // Quantidade m�xima de inimigos simult�neos permitidos.
        [SerializeField] private float minDistanceToSpawn = 20f; // Dist�ncia m�nima em rela��o ao jogador para spawnar inimigos.
        [SerializeField] private float timeBetweenSpawns = 5f; // Tempo m�nimo entre cada spawn.

        private Transform playerTransform; // Refer�ncia � transforma��o do jogador.
        private GameObject[] spawnPoints; // Pontos de spawn no cen�rio.
        private int currentEnemies = 0; // Quantidade atual de inimigos spawnados.
        private float timeFromLastSpawn = 0; // Tempo desde o �ltimo spawn.

        private const int MAX_DISTANCE_FROM_ORIGIN = 9999; // Dist�ncia m�xima permitida para spwanar inimigos.

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
            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint"); // Encontra os pontos de spawn no cen�rio.
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Encontra a transforma��o do jogador.
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

            Vector3 spawnPosition = SelectSpawnPointPosition(); // Seleciona a posi��o de spawn.

            if (Mathf.Abs(spawnPosition.magnitude) >= Mathf.Abs((Vector3.one * MAX_DISTANCE_FROM_ORIGIN).magnitude)) return;

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Instancia o inimigo spawnado.

            currentEnemies++;

            timeFromLastSpawn = Time.time + timeBetweenSpawns; // Atualiza o tempo do �ltimo spawn.
        }

        private Vector3 SelectSpawnPointPosition()
        {
            Vector3 closestAllowedPoint = Vector3.one * 9999;

            foreach (GameObject spawnPoint in spawnPoints)
            {
                Vector3 position = spawnPoint.transform.position;

                float distanceFromPlayer = Mathf.Abs((playerTransform.position - position).magnitude);

                // Verifica se a posi��o de spawn est� dentro da dist�ncia m�nima e � a mais pr�xima at� agora.
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
