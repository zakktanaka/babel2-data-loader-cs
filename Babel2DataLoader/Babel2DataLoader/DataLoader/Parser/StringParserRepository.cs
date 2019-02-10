using Babel2.DataLoader.Parser.RepositoryImpl;

namespace Babel2.DataLoader.Parser
{
    public static class StringParserRepository
    {
        public static IStringParserRepository DefaultRepository { get; } = new StringParserRepositoryImpl();
    }
}
