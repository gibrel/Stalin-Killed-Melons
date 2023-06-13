using UnityEngine;

namespace StalinKilledMelons.General
{
    /// <summary>
    /// Gerencia os pontos de spawn de objetos no jogo.
    /// </summary>
    public class SpawnPointManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] spawnObjects; // Objetos que podem ser spawnados.
        [SerializeField] private int simultaneousObjectsAllowed = 10; // Quantidade máxima de objetos simultâneos permitidos.
        [SerializeField] private float minDistanceToSpawn = 20f; // Distância mínima em relação ao jogador para spawnar objetos.
        [SerializeField] private float timeBetweenSpawns = 5f; // Tempo mínimo entre cada spawn.

        private PlayerPreferences playerPreferences; // Referência às preferências do jogador.
        private Transform playerPosition; // Posição atual do jogador.
        private GameObject[] spawnPoints; // Pontos de spawn no cenário.
        private int currentObjects = 0; // Quantidade atual de objetos spawnados.
        private float timeFromLastSpawn = 0; // Tempo desde o último spawn.

        /// <summary>
        /// Quantidade atual de objetos spawnados.
        /// </summary>
        public int CurrentObjectsQuantity { get => currentObjects; }

        /// <summary>
        /// Diminui a quantidade de objetos spawnados.
        /// </summary>
        public void DecreaseObjects()
        {
            currentObjects--;
            if (currentObjects < 0) currentObjects = 0;
        }

        private void Awake()
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint"); // Encontra os pontos de spawn no cenário.
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform; // Encontra a posição atual do jogador.
            playerPreferences = GameObject.FindGameObjectWithTag("PlayerPreferences").GetComponent<PlayerPreferences>(); // Obtém as preferências do jogador.
        }

        private void Start()
        {
            int spawnFrequency = playerPreferences.SpawnFreq; // Obtém a frequência de spawn das preferências do jogador.

            if (spawnFrequency < 3 || spawnFrequency > 10)
            {
                Debug.LogError("Não foi possível carregar a frequência de spawn como o esperado");
                return;
            }

            timeBetweenSpawns = spawnFrequency; // Define o tempo entre spawns com base na frequência de spawn.
        }

        private void Update()
        {
            // Verifica se um novo objeto pode ser spawnado.
            if (Time.time > timeFromLastSpawn
                && currentObjects < simultaneousObjectsAllowed
                && spawnObjects.Length > 0
                && spawnPoints.Length > 0)
            {
                SpawnObject();
            }
        }

        private void SpawnObject()
        {
            GameObject spawn = SelectSpawn(); // Seleciona um objeto para spawnar.

            if (spawn == null) return;

            Vector3 position = SelectSpawnPointPosition(); // Seleciona a posição de spawn.

            if (Mathf.Abs(position.magnitude) >= Mathf.Abs((Vector3.one * 9999).magnitude)) return;

            Instantiate(spawn, position, Quaternion.identity); // Instancia o objeto spawnado.

            currentObjects++;

            timeFromLastSpawn = Time.time + timeBetweenSpawns; // Atualiza o tempo do último spawn.
        }

        private Vector3 SelectSpawnPointPosition()
        {
            Vector3 closestAllowedPoint = Vector3.one * 9999;

            foreach (GameObject spawnPoint in spawnPoints)
            {
                Vector3 position = spawnPoint.transform.position;

                float distanceFromPlayer = Mathf.Abs((playerPosition.position - position).magnitude);

                // Verifica se a posição de spawn está dentro da distância mínima e é a mais próxima até agora.
                if (distanceFromPlayer >= minDistanceToSpawn
                    && Mathf.Abs(position.magnitude) < Mathf.Abs(closestAllowedPoint.magnitude))
                {
                    closestAllowedPoint = position;
                }
            }

            return closestAllowedPoint;
        }

        private GameObject SelectSpawn()
        {
            int random = Random.Range(0, spawnObjects.Length);
            return spawnObjects[random];
        }
    }
}
