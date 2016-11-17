using System;
using System.Collections.Generic;
using System.Data;

using Org.InstitutoSerpis.Ad;

namespace PArticulo
{
	public class CategoriaDao
	{
		private const string SELECT_SQL = "select * from categoria order by nombre";
		public static List<Categoria> GetList() {
			List<Categoria> list = new List<Categoria> ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_SQL;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				long id = (long)dataReader ["id"];
				string nombre = (string)dataReader ["nombre"];
				Categoria categoria = new Categoria (id, nombre);
				list.Add (categoria);
			}
			dataReader.Close ();
			return list;
		}
	}
}

