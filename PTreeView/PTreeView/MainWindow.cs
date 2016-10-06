using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;
using Org.InstitutoSerpis.Ad;

//FORMA DE PARTICULO DEL PROFESOR
public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		string[] columnNames = {"id", "nombre", "precio"};
		TreeViewHelper.AppendColumns(treeview, columnNames);
		//el rypeof(decimal) no es reconocido por el TreeView
		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal), typeof(long));

		treeView.Model = listStore;

		listStore.AppendValues (1L, "categoria 1", 1.50);
		listStore.AppendValues (1L, "categoria 1", 1.50);
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
