using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;

using Org.InstitutoSerpis.Ad;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection; //Alcance para toda la clase 
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{

		Build ();
		dbConnection = new MySqlConnection (
			"database = dbprueba; user id = root; password = sistemas"
		);
		dbConnection.Open ();
		List <Articulo> list = new List <Articulo> ();
		//Rellenar TreeView
		string selectSQL = "select * from articulo";
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = selectSQL;
		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read ()) {
			long id = (long) dataReader ["id"];
			string nombre = (string) dataReader ["nombre"];
			decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?) dataReader  ["precio"];
			long? categoria = dataReader ["categoria"] is DBNull ? null : (long?) dataReader ["categoria"];
			Articulo articulo = new Articulo (id, nombre, precio, categoria);
			list.Add (articulo);
		}
		dataReader.Close ();

		TreeViewHelper.Fill (treeView, list);
	}	

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}
