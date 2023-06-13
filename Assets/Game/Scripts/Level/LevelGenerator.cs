using UnityEngine;

namespace StalinKilledMelons.Level
{
    /// <summary>
    /// Temas possíveis para um nível.
    /// </summary>
    public enum LevelTheme
    {
        Desert,
        SnowyPlain,
        CountrysideCity,
        IndustrialDistrict,
        CoastalTown,
        PalaceGardens,
        PalaceInterior,
        CityOutskirts
    }

    /// <summary>
    /// Configurações de um bloco do nível.
    /// </summary>
    [System.Serializable]
    public class TileSettings
    {
        public GameObject tilePrefab; // Prefab do bloco.
        public Vector3 rotation; // Rotação do bloco (em euler angles).
        public LevelTheme theme; // Tema do bloco.
    }

    /// <summary>
    /// Gera o nível do jogo.
    /// </summary>
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private TileSettings[] tileSettings; // Array de configurações dos blocos do nível.
        [SerializeField] private int maxWidth = 10; // Largura máxima do nível.
        [SerializeField] private int maxHeight = 10; // Altura máxima do nível.
        [SerializeField] private int tileWidth = 1; // Largura do bloco.
        [SerializeField] private int tileHeight = 1; // Altura do bloco.

        public Transform LevelContainer { get; private set; } // Transform para agrupar os blocos do nível.

        public int MaxWidth { get { return maxWidth; } } // Largura máxima do nível.
        public int MaxHeight { get { return maxHeight; } } // Altura máxima do nível.
        public int TileWidth { get { return tileWidth; } } // Largura do bloco.
        public int TileHeight { get { return tileHeight; } } // Altura do bloco.

        private int width; // Largura do nível.
        private int height; // Altura do nível.

        private void Start()
        {
            LevelContainer = new GameObject("Level").transform; // Cria um objeto vazio para agrupar os blocos do nível.

            GenerateLevel();
        }

        /// <summary>
        /// Gera o nível do jogo.
        /// </summary>
        public void GenerateLevel()
        {
            GameObject terrainObject = GameObject.FindGameObjectWithTag("Terrain");

            // Cria o objeto do terreno se ele não existir.
            if (terrainObject == null)
            {
                terrainObject = new GameObject("Terrain");
                terrainObject.tag = "Terrain";
                terrainObject.transform.position = Vector3.zero;
            }

            // Limpa os blocos existentes.
            foreach (Transform child in terrainObject.transform)
            {
                Destroy(child.gameObject);
            }

            // Gera novos blocos.
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Determina a posição do bloco.
                    Vector3 tilePosition = new Vector3(x * tileWidth, 0, y * tileHeight);

                    // Instancia o bloco.
                    GameObject tile = Instantiate(GetRandomTileSetting().tilePrefab, tilePosition, Quaternion.identity);

                    // Define o objeto do terreno como pai do bloco.
                    tile.transform.SetParent(terrainObject.transform);
                }
            }
        }

        /// <summary>
        /// Retorna uma configuração aleatória de bloco.
        /// </summary>
        /// <returns>A configuração aleatória de bloco.</returns>
        public TileSettings GetRandomTileSetting()
        {
            int randomIndex = Random.Range(0, tileSettings.Length); // Gera um índice aleatório dentro do intervalo do array.
            return tileSettings[randomIndex]; // Retorna a configuração correspondente ao índice aleatório.
        }

        /// <summary>
        /// Define a largura e altura do nível.
        /// </summary>
        /// <param name="width">A largura do nível.</param>
        /// <param name="height">A altura do nível.</param>
        public void SetLevelSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
