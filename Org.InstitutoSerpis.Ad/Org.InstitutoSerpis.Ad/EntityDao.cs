using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Org.InstitutoSerpis.Ad
{
	public class EntityDao
	{
		private const string SELECT_SQL = "select * from {0}";
		public static List<TEntity> GetList<TEntity>() {
			Type typeEntity = typeof(TEntity);
			List<TEntity> list = new List<TEntity> ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = string.Format (SELECT_SQL, typeEntity.Name.ToLower ());
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				TEntity entity = Activator.CreateInstance<TEntity> ();
				setProperties (entity, dataReader);
				list.Add (entity);
			}
			dataReader.Close ();
			return list;
		}

		private static void setProperties(object entity, IDataReader dataReader) {
			Type typeEntity = entity.GetType ();
			foreach (PropertyInfo propertyInfo in typeEntity.GetProperties()) {
				object value = dataReader [propertyInfo.Name.ToLower ()];
				if (value is DBNull)
					value = null;
				propertyInfo.SetValue (entity, value, null);
			}
		}
	}


}

