using Core;

namespace Services.DrawLoggers
{
    public interface IDrawLogger
    {
        Task LogAsync(string drawerName, IReadOnlyList<IGroup> groups);

        Task<IReadOnlyList<IStoredDraw>> GetStoredDrawsByNameAsync(string drawerName);
    }
}
