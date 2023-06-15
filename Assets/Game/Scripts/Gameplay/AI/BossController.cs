namespace StalinKilledMelons.Gameplay.AI
{
    /// <summary>
    /// Classe respons�vel por controlar o chefe do n�vel.
    /// </summary>
    public class BossController : EnemyController
    {
        private bool isInvulnerable; // Indica se o chefe est� invulner�vel

        public bool IsInvulnerable { get => isInvulnerable; }

        protected override void Awake()
        {
            base.Awake();

            // Inicialize as vari�veis espec�ficas do chefe
            isInvulnerable = false;
        }

        protected override void Update()
        {
            base.Update();

            // L�gica adicional do chefe
            if (isInvulnerable)
            {
                // Implemente o comportamento do chefe enquanto estiver invulner�vel
            }
        }

        protected override void HandleInput()
        {
            base.HandleInput();

            // Implemente as a��es espec�ficas do chefe aqui
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

        // Outros m�todos e l�gica espec�ficos do chefe
    }
}
