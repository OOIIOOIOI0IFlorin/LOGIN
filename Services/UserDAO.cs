﻿using System;
using System.Data.SqlClient;
using WEBSITE2023.Models;

namespace WEBSITE2023.Services
{
	public class UserDAO
	{
		string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public bool FindUserByNameAndPassword(UserModel user)
		{

			bool success = false;


			string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password =@password";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(sqlStatement, connection);

				command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
				command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					if (reader.HasRows)
					{
						success = true;
					}

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}

			}
			return success;
			// return true if found in db.
		}

	}
}
