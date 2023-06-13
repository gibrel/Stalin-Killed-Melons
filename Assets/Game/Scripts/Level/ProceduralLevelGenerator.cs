using UnityEngine;

namespace StalinKilledMelons.Level
{
    /// <summary>
    /// Classe respons�vel por gerar um n�vel proceduralmente.
    /// </summary>
    public class ProceduralLevelGenerator : MonoBehaviour
    {
        [SerializeField] private LevelGenerator levelGenerator; // Refer�ncia ao script LevelGenerator
        [SerializeField] private int minimumTiles = 25; // N�mero m�nimo de tiles no mapa
        [SerializeField] private int maximumTiles = 50; // N�mero m�ximo de tiles no mapa

        private void Start()
        {
            GenerateProceduralLevel();
        }

        /// <summary>
        /// Gera um n�vel procedural utilizando o LevelGenerator.
        /// </summary>
        private void GenerateProceduralLevel()
        {
            int width = Random.Range(3, 10); // Largura aleat�ria do mapa
            int height = Random.Range(3, 10); // Altura aleat�ria do mapa

            // Verifique se a largura e a altura do mapa est�o dentro dos limites definidos pelo LevelGenerator
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

            int tileCount = Random.Range(minimumTiles, maximumTiles); // N�mero aleat�rio de tiles no mapa

            for (int i = 0; i < tileCount; i++)
            {
                // Obtenha uma configura��o de tile aleat�ria do LevelGenerator
                TileSettings tileSettings = levelGenerator.GetRandomTileSetting();

                // Determine a posi��o aleat�ria para o tile
                int x = Random.Range(0, width);
                int y = Random.Range(0, height);
                Vector3 tilePosition = new Vector3(x * levelGenerator.TileWidth, 0, y * levelGenerator.TileHeight);

                // Instantiate o objeto de tile usando a configura��o aleat�ria e a posi��o
                GameObject tile = Instantiate(tileSettings.tilePrefab, tilePosition, Quaternion.Euler(tileSettings.rotation));

                // Defina o tema do tile
                tile.GetComponent<Tile>().SetTheme(tileSettings.theme);

                // Defina o objeto de tile como filho do container de n�vel no LevelGenerator
                tile.transform.SetParent(levelGenerator.LevelContainer);
            }

            // Gere o n�vel usando o LevelGenerator
            levelGenerator.GenerateLevel();
        }
    }
}
