using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;

using Org.InstitutoSerpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		IList list = new List<Articulo> ();
		list.Add (new Articulo(1L, "artículo 1", 1.5m));
		list.Add (new Articulo(2L, "artículo 2", 2.5m));
		list.Add (new Articulo(3L, "artículo 3", 3.5m));

//		IList list = new List<Categoria> ();
//		list.Add (new Categoria(1L, "categoría 1"));
//		list.Add (new Categoria(2L, "categoría 2"));
//		list.Add (new Categoria(3L, "categoría 3"));

		TreeViewHelper.Fill (treeView, list);
		list.Add (new Articulo(4L, "artículo 4", 4.5m));
		TreeViewHelper.Fill (treeView, list);

//		TreeViewHelper.AppendColumns (treeView, typeof(Articulo));
//		TreeViewHelper.AppendColumns (treeView, new string[] { "id", "nombre", "precio" });
//		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal));
//		listStore.AppendValues (1L, "artículo 1", 1.5m);
//		listStore.AppendValues (2L, "artículo 2", 2.5m);
//		treeView.Model = listStore;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

public class Categoria {
	public Categoria(long id, string nombre) {
		Id = id;
		Nombre = nombre;
	}
	public long Id { get; set; }
	public string Nombre { get; set; }
}
public class Articulo {
	public Articulo (long id, string nombre, decimal precio) {
		Id = id;
		Nombre = nombre;
		Precio = precio;
	}
	public long Id { get; set; }
	public string Nombre { get; set; }
	public decimal Precio { get; set; }
}
