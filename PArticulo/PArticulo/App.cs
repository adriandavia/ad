using System;
using System.Data;

//PARA USAR DBCONNECTION EN CUALQUIER CLASE
namespace PArticulo
{
	public class App
	{
		private static App instance = new App();
		public static App Instance {
			get { return instance;}
		}

		private App (){
		}
		private IDbConnection dbConnection;
		public IDbConnection DbConnection{
			get { return dbConnection;}
			set { dbConnection = value;}
		}
	}
}

