namespace StateMachine.Level
{
    public class StateMachine : Base.StateMachine<Context>
    {
        private readonly Context _context = new();

        protected override Context Context => _context;
    }
}
