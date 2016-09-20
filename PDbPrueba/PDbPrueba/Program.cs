using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)		{
			string os; //os --> opcion
			int opcion;
			string sid; //sid --> id
			int id;
			//Console.WriteLine ("Probando acceso a dbprueba");
			IDbConnection dbConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");
			dbConnection.Open ();
			IDbCommand comand = dbConnection.CreateCommand ();
			IDbDataParameter dataparameternombre = comand.CreateParameter (); 
			IDbDataParameter dataparameterid = comand.CreateParameter ();
			//Menu
			Console.WriteLine ("0. Salir" + "\n" + "1. Nuevo" + "\n" + "2. Editar" + "\n" + "3. Eliminar" + "\n" + "4. Listar todo");
			Console.Write ("Elegir una opción: ");
			os = Console.ReadLine ();
			opcion = int.Parse (os);
			//Operaciones
			switch (opcion) {
			case 0: 
				Console.Write ("Saliendo");
				Environment.Exit (0);
				break;
			case 1:
				Console.Write ("Nombre de la categoria: ");
				string nombre = Console.ReadLine ();
				comand.CommandText = "insert into categoria (nombre) values (@nombre)";
				parametrosnombre ("nombre", nombre, comand, dataparameternombre);
				comand.ExecuteNonQuery ();
				break;
			case 2:
				Console.WriteLine ();
				seleccionar (comand);
				Console.Write ("¿Qué fila quieres modificar? (ID) ");
				sid = Console.ReadLine ();
				id = int.Parse (sid);
				Console.Write ("¿Por qué nombre vas a cambiarlo? ");
				nombre = Console.ReadLine ();
				comand.CommandText = "update categoria set nombre = @nombre where id = @id";
				parametrosnombre ("nombre", nombre, comand, dataparameternombre);
				parametrosid ("id", id, comand, dataparameterid);
				comand.ExecuteNonQuery ();
				break;
			case 3:
				Console.WriteLine ();
				seleccionar (comand);
				Console.Write ("¿Qué fila quieres borrar? (ID) ");
				sid = Console.ReadLine ();
				id = int.Parse (sid);
				comand.CommandText = "delete from categoria where id = @id";
				parametrosid ("id", id, comand, dataparameterid);
				comand.ExecuteNonQuery ();
				break;
			case 4:
				Console.WriteLine ();
				seleccionar (comand);
				break;
			}
			dbConnection.Close ();
		}
		private static void seleccionar(IDbCommand comand){
			comand.CommandText = "select * from categoria order by id";
			IDataReader dataReader = comand.ExecuteReader ();
			while (dataReader.Read()) {
				Console.WriteLine("id= {0} nombre= {1}", dataReader ["id"], dataReader ["nombre"]);
			}
			dataReader.Close ();
		}
		private static void parametrosnombre(String parametro, String valor, IDbCommand comand, IDbDataParameter dataparameternombre){
			dataparameternombre.ParameterName = parametro;
			dataparameternombre.Value = valor;
			comand.Parameters.Add (dataparameternombre);
		}
		private static void parametrosid(String parametro, int valor, IDbCommand comand, IDbDataParameter dataparameterid){
			dataparameterid.ParameterName = parametro;
			dataparameterid.Value = valor;
			comand.Parameters.Add (dataparameterid);
		}
	}
}