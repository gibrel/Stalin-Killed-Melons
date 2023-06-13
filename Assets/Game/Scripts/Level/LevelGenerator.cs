using UnityEngine;

namespace StalinKilledMelons.Level
{
    /// <summary>
    /// Temas poss�veis para um n�vel.
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
    /// Configura��es de um bloco do n�vel.
    /// </summary>
    [System.Serializable]
    public class TileSettings
    {
        public GameObject tilePrefab; // Prefab do bloco.
        public Vector3 rotation; // Rota��o do bloco (em euler angles).
        public LevelTheme theme; // Tema do bloco.
    }

    /// <summary>
    /// Gera o n�vel do jogo.
    /// </summary>
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private TileSettings[] tileSettings; // Array de configura��es dos blocos do n�vel.
        [SerializeField] private int maxWidth = 10; // Largura m�xima do n�vel.
        [SerializeField] private int maxHeight = 10; // Altura m�xima do n�vel.
        [SerializeField] private int tileWidth = 1; // Largura do bloco.
        [SerializeField] private int tileHeight = 1; // Altura do bloco.

        public Transform LevelContainer { get; private set; } // Transform para agrupar os blocos do n�vel.

        public int MaxWidth { get { return maxWidth; } } // Largura m�xima do n�vel.
        public int MaxHeight { get { return maxHeight; } } // Altura m�xima do n�vel.
        public int TileWidth { get { return tileWidth; } } // Largura do bloco.
        public int TileHeight { get { return tileHeight; } } // Altura do bloco.

        private int width; // Largura do n�vel.
        private int height; // Altura do n�vel.

        private void Start()
        {
            LevelContainer = new GameObject("Level").transform; // Cria um objeto vazio para agrupar os blocos do n�vel.

            GenerateLevel();
        }

        /// <summary>
        /// Gera o n�vel do jogo.
        /// </summary>
        public void GenerateLevel()
        {
            GameObject terrainObject = GameObject.FindGameObjectWithTag("Terrain");

            // Cria o objeto do terreno se ele n�o existir.
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
                    // Determina a posi��o do bloco.
                    Vector3 tilePosition = new Vector3(x * tileWidth, 0, y * tileHeight);

                    // Instancia o bloco.
                    GameObject tile = Instantiate(GetRandomTileSetting().tilePrefab, tilePosition, Quaternion.identity);

                    // Define o objeto do terreno como pai do bloco.
                    tile.transform.SetParent(terrainObject.transform);
                }
            }
        }

        /// <summary>
        /// Retorna uma configura��o aleat�ria de bloco.
        /// </summary>
        /// <returns>A configura��o aleat�ria de bloco.</returns>
        public TileSettings GetRandomTileSetting()
        {
            int randomIndex = Random.Range(0, tileSettings.Length); // Gera um �ndice aleat�rio dentro do intervalo do array.
            return tileSettings[randomIndex]; // Retorna a configura��o correspondente ao �ndice aleat�rio.
        }

        /// <summary>
        /// Define a largura e altura do n�vel.
        /// </summary>
        /// <param name="width">A largura do n�vel.</param>
        /// <param name="height">A altura do n�vel.</param>
        public void SetLevelSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
