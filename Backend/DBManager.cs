﻿using Backend.Models;
using Microsoft.AspNetCore.Hosting.Server;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Transactions;

namespace Backend
{
    public class DBManager
    {
        private MySqlConnection connection;

        public DBManager() {
            string connectionString =
                $"server=localhost;" +
                $"userid=root;" +
                $"password=Geheim123*;" +
                $"database=Pendelo;";

            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public void Close() {
            connection.Close();
        }

        //User

        // REGISTER
        public DBResult CreateUser(string username, string email, string password) {
            try {

                string sqlQuery = "INSERT INTO pnd_users(username, email, password) VALUES (@username, @email, " +
                    "@password) ";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection)) {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();

                }
                return new DBResult(true, "", "Konto erstellt");
            }
            catch (Exception ex) {
                return new DBResult(false, "Database failed: " + ex.Message);
            }

        }
        public DBResult IsUserTaken(string username, string email) {

            string sqlQuery = "SELECT Count(*) as ExistingUser FROM pnd_users WHERE username = @Username OR  email = @Email;";
            try {
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection)) {

                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 0) {
                        return new DBResult(true, "", count > 0);
                    } else return new DBResult(false, "UserName oder Email bereits vergeben");

                }
            }
            catch (Exception ex) {
                return new DBResult(false, "Database failed");
            }
        }

        // LOGIN
        public DBResult CheckEmail(string email) {
            try {
                string query = "SELECT * FROM pnd_users WHERE email = @Email";

                using (MySqlCommand cmd = new MySqlCommand(query, connection)) {

                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 0) {
                        return new DBResult(false, "User nicht gefunden");
                    } else {
                        return new DBResult(true, "", count > 0);
                    }


                }
            }
            catch {
                return new DBResult(false, "Database failed");
            }

        }
        public bool? CheckLogin(string email, string password) {

           
                string query = "SELECT (pnd_users.password = @password ) As 'check' FROM pnd_users WHERE pnd_users.email = @email;";

                bool? check = null;

                using (MySqlCommand _command = new MySqlCommand(query, connection)) {
                   
                    _command.Parameters.AddWithValue("@email", email );
                    _command.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader _reader = _command.ExecuteReader()) {
                        if (_reader.Read()) {
                            check = _reader.GetBoolean("check");
                        }
                    }
                }
            return check;
        }

        public int? GetUserIDFromUsername(string _username) {

            string _sql = "SELECT user_id FROM pnd_users WHERE username = @username";

            int? _userID = null;

            using (MySqlCommand _command = new MySqlCommand(_sql, connection)) {
                _command.Parameters.AddWithValue("@username", _username);

                using (MySqlDataReader _reader = _command.ExecuteReader()) {
                    if (_reader.Read()) {
                        _userID = _reader.GetInt32("user_id");
                    }
                }
            }

           

            return _userID;
        }

        //RIDES

        public void CreateTransaction(int _id, Ride ride) {
        
            string _sql = "INSERT INTO `pendelo`.`pnd_rides`(`user_id`,`km`,`datetime`" +
                "VALUES (@name, @transaction, @startDate, @endDate, @userid);";

            using (MySqlCommand _command = new MySqlCommand(_sql, connection)) {
                _command.Parameters.AddWithValue("@km", ride.Km);
                _command.Parameters.AddWithValue("@datetime", ride.Datetime);
                _command.Parameters.AddWithValue("@userid", _id);

                _command.ExecuteNonQuery();
            }

            
        }

    }
}
