using System;
using System.Data;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

//OTRA FORMA DE HACER PDBPRUEBA
namespace PdbPrueba2
{
	class MainClass
	{
		public enum Option {SALIR, NUEVO, EDITAR, ELIMINAR, LISTAR}

		public static IDbConnection dbConnection;

		public static void Main (string[] args)
		{
			dbConnection = new MySqlConnection ("Database = dbprueba, User Id= root, Password= sistemas");
			dbConnection.Open ();
			while (true) {
				Option option = getOption ();
				switch (option) {
				case Option.SALIR:
					dbConnection.Close ();
					return;
				case Option.NUEVO:
					nuevo ();
					break;
				case Option.EDITAR:
					editar ();
					break;
				case Option.ELIMINAR:
					eliminar ();
					break;
				case Option.LISTAR:
					listar ();
					break;
				}
			}
		}
		private static int getOption(){
			string pattern = "^[01234]$"; //EXPRESION REGULAR
			while (true) {
				Console.WriteLine ("0. Salir");
				Console.WriteLine ("1. Nuevo");
				Console.WriteLine ("2. Editar");
				Console.WriteLine ("3. Borrar");
				Console.WriteLine ("4. Listar");
				string option = Console.ReadLine ();
				if (Regex.IsMatch (option, pattern)) {
					return (Option)int.Parse (option);
					Console.WriteLine ("Opción invalida. Vuelve a introducir.");
				}
			}
		}
		private static string INSERT_SQL = "insert into categoria (nombre) values (@nombre)";
		private static void nuevo(){
			string nombre = readString ("Nombre: ");
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = INSERT_SQL;
			addPArameter (dbCommand, "nombre", nombre);
			dbCommand.ExecuteNonQuery ();
		}
		private static string readString (string label){
			while (true) {
				Console.Write (label);
				string data = Console.ReadLine ();
				data = data.Trim ();
				if (!data.Equals (""))
					return data;
				Console.WriteLine ("No puede quedar vacio. Vuelve a introducir.");
			}
		}
		private static string UPDATE_SQL = "update categoria set nombre = @nombre";
		private static void editar(){
			long id = readlong ("ID: ");
			string nombre = readString ("Nombre: ");
		}

		private static string DELETE_SQL = "delete from categoria where id = @id";
		private static void eliminar(){
			long id = readlong ("ID: ");
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = DELETE_SQL;
			addPArameter (dbCommand, "id", id);
			dbCommand.ExecuteNonQuery ();
		}
		private static long readlong (String label){
			while (true) {
				Console.Write (label);
				string data = Console.ReadLine ();
				try{
					return long.Parse(data);
				}catch{
					Console.WriteLine ("Solo permite numeros. Vuelve a introducir.");
				}
			}
		}

		private static void listar(){
		}

		private static void addPArameter(IDbCommand dbCommand, string name, object value){
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
			dbDataParameter.ParameterName = name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add (dbDataParameter);
		}
	}
}
