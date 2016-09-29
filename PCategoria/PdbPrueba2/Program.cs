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
			dbConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");
			dbConnection.Open ();
			while (true) {
				Option option = getOption ();
				switch (option) {
				case Option.SALIR:
					dbConnection.Close ();
					return;
				case Option.NUEVO:
					/*INICIALIZACIÓN PEREZOSA --> if (dbConnection.State != ConnectionState.Open) 
						dbConnection.Open ();*/
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
		private static Option getOption(){
			string pattern = "^[01234]$"; //EXPRESION REGULAR
			while (true) {
				Console.WriteLine ("0. Salir");
				Console.WriteLine ("1. Nuevo");
				Console.WriteLine ("2. Editar");
				Console.WriteLine ("3. Borrar");
				Console.WriteLine ("4. Listar");
				Console.Write ("Opcion: ");
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
			try{
				dbCommand.ExecuteNonQuery ();
			} catch (MySqlException ex){
				Console.WriteLine (getUserMessage(ex));
			}
		}

		private const int ER_DUP_ENTRY = 1062;
		private static string getUserMessage (MySqlException ex){
			switch (ex.Number) {
			case ER_DUP_ENTRY:
				return "Dato duplicado. Ese dato ya existe en la base de datos";
			}
			return ex.Message;
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

		private static string UPDATE_SQL = "update categoria set nombre = @nombre where id = @id";
		private static void editar(){
			long id = readlong ("ID: ");
			string nombre = readString ("Nombre: ");
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = UPDATE_SQL;
			addPArameter (dbCommand, "nombre", nombre);
			addPArameter (dbCommand, "id", id);
			try{
				int filas = dbCommand.ExecuteNonQuery (); //Devolvera 0 o 1
				if (filas == 0)
					Console.WriteLine ("Id no existente. No existe ningún registro con ese Id.");
			}catch(MySqlException ex){
				Console.WriteLine (getUserMessage(ex));
			}
		}

		private static string DELETE_SQL = "delete from categoria where id = @id";
		private static void eliminar(){
			long id = readlong ("ID: ");
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = DELETE_SQL;
			addPArameter (dbCommand, "id", id);
			int filas = dbCommand.ExecuteNonQuery (); //Devolvera 0 o 1 
			if (filas == 0)
				Console.WriteLine ("Id no existente. No existe ningún registro con ese Id.");
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

		private static string SELECT_SQL = "select * from categoria order by id";
		private static void listar(){
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_SQL;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			Console.WriteLine ("Lista: ");
			while(dataReader.Read ()){
				Console.WriteLine ("{0,5} id: - nombre: {1}", dataReader ["id"], dataReader ["nombre"]);
			}
			dataReader.Close ();
		}

		private static void addPArameter(IDbCommand dbCommand, string name, object value){
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
			dbDataParameter.ParameterName = name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add (dbDataParameter);
		}
	}
}
