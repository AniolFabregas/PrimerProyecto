
using System;
using System.IO;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace PlanesVuelo
{
    public static class UserDatabase
    {
        private static readonly string databasePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.db");

        private static readonly string connectionString =
            "Data Source=" + databasePath + ";Version=3;";

        // Inicializar la base de datos
        public static void InitializeDatabase()
        {
            using (SQLiteConnection connection =
                new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL COLLATE NOCASE UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        Salt TEXT NOT NULL
                    );";

                using (SQLiteCommand command =
                    new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Registrar un usuario nuevo
        public static bool RegisterUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            username = username.Trim();

            using (SQLiteConnection connection =
                new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Comprobar si el nombre de usuario ya existe
                string checkSql =
                    "SELECT COUNT(*) FROM Users WHERE Username = @username";

                using (SQLiteCommand checkCommand =
                    new SQLiteCommand(checkSql, connection))
                {
                    checkCommand.Parameters.AddWithValue(
                        "@username", username);

                    long count = (long)checkCommand.ExecuteScalar();

                    if (count > 0)
                        return false;
                }

                // Generar salt aleatorio
                byte[] salt = new byte[16];

                using (RandomNumberGenerator rng =
                    RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }

                // Generar hash de la contraseña
                byte[] hash;

                using (Rfc2898DeriveBytes pbkdf2 =
                    new Rfc2898DeriveBytes(
                        password, salt, 100000,
                        HashAlgorithmName.SHA256))
                {
                    hash = pbkdf2.GetBytes(32);
                }

                // Guardar usuario en SQLite
                string insertSql = @"
                    INSERT INTO Users (Username, PasswordHash, Salt)
                    VALUES (@username, @hash, @salt)";

                using (SQLiteCommand command =
                    new SQLiteCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@username", username);

                    command.Parameters.AddWithValue(
                        "@hash", Convert.ToBase64String(hash));

                    command.Parameters.AddWithValue(
                        "@salt", Convert.ToBase64String(salt));

                    command.ExecuteNonQuery();
                }
            }

            return true;
        }

        // Comprobar las credenciales de un usuario
        public static bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrEmpty(password))
            {
                return false;
            }

            username = username.Trim();

            using (SQLiteConnection connection =
                new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = @"
                    SELECT PasswordHash, Salt
                    FROM Users
                    WHERE Username = @username";

                using (SQLiteCommand command =
                    new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@username", username);

                    using (SQLiteDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        byte[] storedHash =
                            Convert.FromBase64String(reader.GetString(0));

                        byte[] salt =
                            Convert.FromBase64String(reader.GetString(1));

                        byte[] enteredHash;

                        using (Rfc2898DeriveBytes pbkdf2 =
                            new Rfc2898DeriveBytes(
                                password, salt, 100000,
                                HashAlgorithmName.SHA256))
                        {
                            enteredHash = pbkdf2.GetBytes(32);
                        }

                        return CompareHashes(storedHash, enteredHash);
                    }
                }
            }
        }

        // Comparar hashes sin detenerse en la primera diferencia
        private static bool CompareHashes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int difference = 0;

            for (int i = 0; i < a.Length; i++)
            {
                difference |= a[i] ^ b[i];
            }

            return difference == 0;
        }
    }
}
