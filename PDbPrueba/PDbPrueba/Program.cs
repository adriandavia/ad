using System;
using MySql.Data.MySqlClient;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Probando acceso a dbprueba");
			MySqlConnection mySqlConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");
			mySqlConnection.Open ();
			//OPERACIONES...
			mySqlConnection.Close ();

		}
	}
}
