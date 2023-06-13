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
        [SerializeField] private int mapWidth = 10; // Largura do mapa
        [SerializeField] private int mapHeight = 10; // Altura do mapa
        [SerializeField] private float tileWidth = 1f; // Largura do tile
        [SerializeField] private float tileHeight = 1f; // Altura do tile

        private Transform levelContainer; // Transform para agrupar os blocos do n�vel

        private void Start()
        {
            levelContainer = new GameObject("Level").transform; // Cria um objeto vazio para agrupar os blocos do n�vel

            GenerateLevel(mapWidth, mapHeight); // Gera o n�vel com base na largura e altura do mapa
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
                    // Determina a posi��o do bloco
                    Vector3 tilePosition = new Vector3(x * tileWidth, 0, y * tileHeight);

                    // Obt�m uma configura��o de bloco aleat�ria
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

            // Cria o objeto de terreno se ele n�o existir
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
            int randomIndex = Random.Range(0, tileSettings.Length); // Gera um �ndice aleat�rio dentro do intervalo do array
            return tileSettings[randomIndex]; // Retorna a configura��o correspondente ao �ndice aleat�rio
        }
    }
}
