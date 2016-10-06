using System;
using System.Data;

namespace PArticulo
{
	public partial class Añadir : Gtk.Window
	{
		public Añadir () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			saveAction.Activated += delegate {
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
				dbCommand.CommandText = "insert into articulo (nombre, precio, categoria) values (@nombre, @precio, @cateogira)";
				string nombre = entry1.Text;
				decimal precio = entry2.Text;
				int categoria = entry3.Text;
		};
		}
	}
}

