using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Org.InstitutoSerpis.Ad;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : base(Gtk.WindowType.Toplevel) {
			this.Build ();
			spinButtonPrecio.Value = 0; //stetic bug
			saveAction.Sensitive = false;
			saveAction.Activated += delegate {
				Console.WriteLine ("saveAction.Activated");
			};
			entryNombre.Changed += delegate {
				string content = entryNombre.Text.Trim();
				saveAction.Sensitive = content != string.Empty;
			};
			List<Categoria> list = new List<Categoria> ();
			list.Add (new Categoria (1L, "categoría 1"));
			list.Add (new Categoria (2L, "categoría 2"));
			list.Add (new Categoria (3L, "categoría 3"));

			ComboBoxHelper.Fill(comboBoxCategoria, list, "Nombre");
		}

	}

	public class Categoria {
		public Categoria (long id, string nombre) {
			Id = id;
			Nombre = nombre;
		}

		public long Id { get; set; }
		public string Nombre { get; set; }
	}
}

