using UnityEngine;

namespace StalinKilledMelons.Level
{
    /// <summary>
    /// Classe responsável por gerar um nível proceduralmente.
    /// </summary>
    public class ProceduralLevelGenerator : MonoBehaviour
    {
        [SerializeField] private LevelGenerator levelGenerator; // Referência ao script LevelGenerator
        [SerializeField] private int minimumTiles = 25; // Número mínimo de tiles no mapa
        [SerializeField] private int maximumTiles = 50; // Número máximo de tiles no mapa

        private void Start()
        {
            GenerateProceduralLevel();
        }

        /// <summary>
        /// Gera um nível procedural utilizando o LevelGenerator.
        /// </summary>
        private void GenerateProceduralLevel()
        {
            int width = Random.Range(3, 10); // Largura aleatória do mapa
            int height = Random.Range(3, 10); // Altura aleatória do mapa

            // Verifique se a largura e a altura do mapa estão dentro dos limites definidos pelo LevelGenerator
            if (width > levelGenerator.MaxWidth)
            {
                width = levelGenerator.MaxWidth;
            }

            if (height > levelGenerator.MaxHeight)
            {
                height = levelGenerator.MaxHeight;
            }

            // Defina a largura e a altura do mapa no LevelGenerator
            levelGenerator.SetLevelSize(width, height);

            int tileCount = Random.Range(minimumTiles, maximumTiles); // Número aleatório de tiles no mapa

            for (int i = 0; i < tileCount; i++)
            {
                // Obtenha uma configuração de tile aleatória do LevelGenerator
                TileSettings tileSettings = levelGenerator.GetRandomTileSetting();

                // Determine a posição aleatória para o tile
                int x = Random.Range(0, width);
                int y = Random.Range(0, height);
                Vector3 tilePosition = new Vector3(x * levelGenerator.TileWidth, 0, y * levelGenerator.TileHeight);

                // Instantiate o objeto de tile usando a configuração aleatória e a posição
                GameObject tile = Instantiate(tileSettings.tilePrefab, tilePosition, Quaternion.Euler(tileSettings.rotation));

                // Defina o tema do tile
                tile.GetComponent<Tile>().SetTheme(tileSettings.theme);

                // Defina o objeto de tile como filho do container de nível no LevelGenerator
                tile.transform.SetParent(levelGenerator.LevelContainer);
            }

            // Gere o nível usando o LevelGenerator
            levelGenerator.GenerateLevel();
        }
    }
}
