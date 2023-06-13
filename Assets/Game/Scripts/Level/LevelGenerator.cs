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
        public Vector3 rotation; // Rotação do bloco (em euler angles)
        public LevelTheme theme;
    }

    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private TileSettings[] tileSettings; // Array de configurações dos blocos do nível
        [SerializeField] private int mapWidth = 10; // Largura do mapa
        [SerializeField] private int mapHeight = 10; // Altura do mapa
        [SerializeField] private float tileWidth = 1f; // Largura do tile
        [SerializeField] private float tileHeight = 1f; // Altura do tile

        private Transform levelContainer; // Transform para agrupar os blocos do nível

        private void Start()
        {
            levelContainer = new GameObject("Level").transform; // Cria um objeto vazio para agrupar os blocos do nível

            GenerateLevel(mapWidth, mapHeight); // Gera o nível com base na largura e altura do mapa
        }

        public void GenerateLevel(int width, int height)
        {
            GameObject terrainObject = FindOrCreateTerrainObject();

            // Limpa os blocos existentes
            foreach (Transform child in terrainObject.transform)
            {
                Destroy(child.gameObject);
            }

            // Gera novos blocos
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Determina a posição do bloco
                    Vector3 tilePosition = new Vector3(x * tileWidth, 0, y * tileHeight);

                    // Obtém uma configuração de bloco aleatória
                    TileSettings randomTileSettings = GetRandomTileSetting();

                    // Instancia o objeto de bloco
                    GameObject tile = Instantiate(randomTileSettings.tilePrefab, tilePosition, Quaternion.Euler(randomTileSettings.rotation));

                    // Define o objeto de terreno como pai do bloco
                    tile.transform.SetParent(terrainObject.transform);
                }
            }
        }

        private GameObject FindOrCreateTerrainObject()
        {
            GameObject terrainObject = GameObject.FindGameObjectWithTag("Terrain");

            // Cria o objeto de terreno se ele não existir
            if (terrainObject == null)
            {
                terrainObject = new GameObject("Terrain");
                terrainObject.tag = "Terrain";
                terrainObject.transform.position = Vector3.zero;
            }

            return terrainObject;
        }

        private TileSettings GetRandomTileSetting()
        {
            int randomIndex = Random.Range(0, tileSettings.Length); // Gera um índice aleatório dentro do intervalo do array
            return tileSettings[randomIndex]; // Retorna a configuração correspondente ao índice aleatório
        }
    }
}
