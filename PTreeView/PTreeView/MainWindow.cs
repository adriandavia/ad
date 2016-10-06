using System;
using Gtk;
using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;
using Org.InstitutoSerpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		string[] columnNames = {"id","nombre","precio"};
		TreeViewHelper.AppendColumns (treeView, columnNames);
		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal), typeof(long));
		listStore.AppendValues (1L, "categoria 1", 1.50);
		listStore.AppendValues (1L, "categoria 2", 1.50);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
