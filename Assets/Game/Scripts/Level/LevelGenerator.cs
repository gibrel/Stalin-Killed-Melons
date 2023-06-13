using UnityEngine;

namespace StalinKilledMelons.Level
{
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

    [System.Serializable]
    public class TileSettings
    {
        public GameObject tilePrefab;
        public Vector3 rotation; // Rota��o do bloco (em euler angles)
        public LevelTheme theme;
    }

    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private TileSettings[] tileSettings; // Array de configura��es dos blocos do n�vel
        [SerializeField] private int maxWidth = 10; // Largura m�xima do n�vel
        [SerializeField] private int maxHeight = 10; // Altura m�xima do n�vel
        [SerializeField] private int tileWidth = 1; // Largura do bloco
        [SerializeField] private int tileHeight = 1; // Altura do bloco

        public Transform LevelContainer { get; private set; } // Transform para agrupar os blocos do n�vel

        public int MaxWidth { get { return maxWidth; } }
        public int MaxHeight { get { return maxHeight; } }
        public int TileWidth { get { return tileWidth; } }
        public int TileHeight { get { return tileHeight; } }

        private int width; // Largura do n�vel
        private int height; // Altura do n�vel

        private void Start()
        {
            LevelContainer = new GameObject("Level").transform; // Cria um objeto vazio para agrupar os blocos do n�vel

            GenerateLevel();
        }

        public void GenerateLevel()
        {
            GameObject terrainObject = GameObject.FindGameObjectWithTag("Terrain");

            // Create terrain object if it doesn't exist
            if (terrainObject == null)
            {
                terrainObject = new GameObject("Terrain");
                terrainObject.tag = "Terrain";
                terrainObject.transform.position = Vector3.zero;
            }

            // Clear existing tiles
            foreach (Transform child in terrainObject.transform)
            {
                Destroy(child.gameObject);
            }

            // Generate new tiles
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Determine the tile position
                    Vector3 tilePosition = new Vector3(x * tileWidth, 0, y * tileHeight);

                    // Instantiate the tile object
                    GameObject tile = Instantiate(GetRandomTileSetting().tilePrefab, tilePosition, Quaternion.identity);

                    // Set the terrain object as the parent of the tile
                    tile.transform.SetParent(terrainObject.transform);
                }
            }
        }

        public TileSettings GetRandomTileSetting()
        {
            int randomIndex = Random.Range(0, tileSettings.Length); // Gera um �ndice aleat�rio dentro do intervalo do array
            return tileSettings[randomIndex]; // Retorna a configura��o correspondente ao �ndice aleat�rio
        }

        public void SetLevelSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }

}
