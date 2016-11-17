using System;
using System.Data;

namespace Org.InstitutoSerpis.Ad
{
	public class DbCommandHelper
	{
		public static void AddParameter(IDbCommand dbCommand, string name, object value){
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
			dbDataParameter.ParameterName = name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add(dbDataParameter);
		}
	}
}

