namespace StalinKilledMelons.Gameplay.AI
{
    /// <summary>
    /// Classe responsável por controlar o chefe do nível.
    /// </summary>
    public class BossController : EnemyController
    {
        private bool isInvulnerable; // Indica se o chefe está invulnerável

        public bool IsInvulnerable { get => isInvulnerable; }

        protected override void Awake()
        {
            base.Awake();

            // Inicialize as variáveis específicas do chefe
            isInvulnerable = false;
        }

        protected override void Update()
        {
            base.Update();

            // Lógica adicional do chefe
            if (isInvulnerable)
            {
                // Implemente o comportamento do chefe enquanto estiver invulnerável
            }
        }

        protected override void HandleInput()
        {
            base.HandleInput();

            // Implemente as ações específicas do chefe aqui
            if (isShooting)
            {
                // Implemente o disparo do chefe
            }

            if (isRunning)
            {
                // Implemente a corrida do chefe
            }

            if (isDodging)
            {
                // Implemente a esquiva do chefe
            }

            if (isBlocking)
            {
                // Implemente o bloqueio do chefe
            }
        }

        // Outros métodos e lógica específicos do chefe
    }
}
