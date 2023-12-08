using Core;

namespace Services.DrawLoggers.SQLLite
{
    internal class StoredDrawSQLLite : IStoredDraw
    {
        public long Id { get; init; }

        public string DrawerName { get; init; }

        public IReadOnlyList<IGroup> Groups { get; init; }
    }
}
