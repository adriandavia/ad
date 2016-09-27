using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		pvisualizar.AppendColumn ("id", new CellRendererText (), "text", 0);
		pvisualizar.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		pvisualizar.AppendColumn ("precio", new CellRendererText (), "text", 2);
		pvisualizar.AppendColumn ("categoria", new CellRendererText (), "text", 3);

		ListStore liststore = new ListStore (typeof(long), typeof(string), typeof(string), typeof(long));

		pvisualizar.Model = liststore;

		IDbConnection connect = new MySqlConnection ("Database=dbprueba;user=root;password=sistemas");
		connect.Open ();
		fillListStore (liststore, connect);

	}	
	private void fillListStore (ListStore listStore, IDbConnection connect){
		listStore.Clear ();
		IDbCommand dbcommand = connect.CreateCommand ();
		dbcommand.CommandText = "select * from articulo order by id";
		IDataReader dataReader = dbcommand.ExecuteReader ();
		while (dataReader.Read()) {
			listStore.AppendValues (dataReader ["id"], dataReader ["nombre"],""+dataReader ["precio"], dataReader ["categoria"]);
		}
		dataReader.Close ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
