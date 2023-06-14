namespace StalinKilledMelons
{
    /// <summary>
    /// Classe que armazena as constantes do projeto.
    /// </summary>
    public static class Constants
    {
        // Strings de Headers para Unity Editor
        public const string MusicHeader = "Música";
        public const string SoundFxHeader = "Efeitos Sonoros";

        // String de Resources
        public const string GameAssetsResource = "GameAssets";

        // Strings de tags
        public const string PlayerTag = "Player";
        public const string GameControllerTag = "GameController";
        public const string TerrainTag = "Terrain";
        public const string LevelLoaderTag = "LevelLoader";
        public const string SpawnPointTag = "SpawnPoint";
        public const string PlayerPreferencesTag = "PlayerPreferences";

        // Strings de Game Objects
        public const string MusicPlayerGameObj = "Music Player";
        public const string OneShotSoundGameObj = "One Shot Sound";
        public const string SoundGameObj = "Sound";
        public const string LevelGameObj = "Level";
        public const string TerrainGameObj = TerrainTag;

        // Strings de controle
        public const string VolumeAudioMixer = "volume";
        public const string HorizontalAxisControll = "Horizontal";
        public const string VerticalAxisControll = "Vertical";

        // Strings de preferências de usuário
        public const string PlayerNameKey = "PlayerName";
        public const string SoundVolumeKey = "SoundVolume";
        public const string MusicVolumeKey = "MusicVolume";
        public const string SpawnFrequencyKey = "SpawnFrequency";
        public const string GameTimeKey = "GameTime";
        public const string PlayerProgressKey = "PlayerProgress";
        public const string HighScoreKey = "HighScore";

        // Strings de gatilho para animação
        public const string ExplosionTrigger = "Explode";
        public const string StartTrigger = "Start";

        // Strings de nomes de cenas - verificar se existem na pasta Game/Scenes
        public const string StartupScene = "Startup";
        public const string MainMenuScene = "MainMenu";
        public const string GameLevelScene = "GameLevel";

        // Variáveis de controle
        public const float DefaultSoundVolume = 0.5f;
        public const float DefaultMusicVolume = 0.8f;
        public const int MaxPlayerHealth = 100;
        public const int MaxPlayerLives = 3;
        public const int MaxEnemiesOnScreen = 10;
        public const float MaxDistanceToSpawn = 9999f; // Distância máxima permitida para spwanar inimigos.
        public const float MinDistanceToSpawn = 20f;
        public const float MaxLevelDuration = 180f;
        public const float MinLevelDuration = 60f;
    }
}
