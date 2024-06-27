namespace Game
{
    public class GameStateChanger
    {

        private GameStateBase _currentGameState;

        public void ChangeState(GameStateBase gamestate)
        {
            _currentGameState?.Exit();

            _currentGameState = gamestate;
            _currentGameState.gameStateChanger = this;
            _currentGameState.Enter();
        }
    }
}
