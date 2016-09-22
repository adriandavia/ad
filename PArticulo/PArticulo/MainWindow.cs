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
	}	


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
