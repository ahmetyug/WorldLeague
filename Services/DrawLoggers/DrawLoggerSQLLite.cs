using Core;
using Microsoft.Data.Sqlite;
using Services.DrawLoggers.SQLLite;
using System.Text.Json;

namespace Services.DrawLoggers
{
    public class DrawLoggerSQLLite : IDrawLogger
    {
        private const string CONNECTION_STRING = "Data Source=WorldLeague.sqllite";

        public Task LogAsync(string drawerName, IReadOnlyList<IGroup> groups)
        {
            CreateDrawsTableIfNotExists();

            using (var con = new SqliteConnection(CONNECTION_STRING))
            using (var command = con.CreateCommand())
            {
                var groupsText = JsonSerializer.Serialize(groups);                

                con.Open();

                command.CommandText = "INSERT INTO Draws(Drawer, Groups) VALUES(@Drawer, @Groups)";
                command.Parameters.AddWithValue("@Drawer", drawerName);
                command.Parameters.AddWithValue("@Groups", groupsText);

                command.ExecuteNonQuery();
            }

            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<IStoredDraw>> GetStoredDrawsByNameAsync(string drawerName)
        {
            var storedDraws = new List<IStoredDraw>();

            CreateDrawsTableIfNotExists();

            using (var con = new SqliteConnection(CONNECTION_STRING))
            using (var command = con.CreateCommand())
            {
                con.Open();

                command.CommandText = "SELECT * FROM Draws WHERE Drawer = @Drawer;";
                command.Parameters.AddWithValue("@Drawer", drawerName);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        storedDraws.Add(new StoredDrawSQLLite()
                        {
                            Id = (long)reader["Id"],
                            DrawerName = reader["Drawer"].ToString(),
                            Groups = JsonSerializer.Deserialize<List<GroupSQLLite>>(reader["Groups"].ToString())
                        });
                    }
                }
            }

            return Task.FromResult((IReadOnlyList<IStoredDraw>)storedDraws);
        }

        private void CreateDrawsTableIfNotExists()
        {
            using (var con = new SqliteConnection(CONNECTION_STRING))
            using (var command = con.CreateCommand())
            {
                con.Open();
                command.CommandText = "CREATE TABLE IF NOT EXISTS Draws (Id INTEGER PRIMARY KEY, Drawer VARCHAR(256) NOT NULL, Groups TEXT NOT NULL)";
                command.ExecuteNonQuery();
            }
        }
    }
}
