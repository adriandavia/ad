using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

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
				string nombre = entryNombre.Text;
				decimal precio = (decimal)spinButtonPrecio.Value;
				TreeIter treeIter; 
				comboBoxCategoria.GetActiveIter(out treeIter);
				object item = comboBoxCategoria.Model.GetValue(treeIter, 0);
				object value = item == Null.Value ? null : (object)(((Categoria)item).Id);
				Console.WriteLine ("value='{0}'", value);
//				string insertSql = "insert into articulo (nombre, precio, categoria) " +
//					"values (@nombre, @precio, @categoria)";
//				string insertSql = "insert into articulo (nombre, precio) " +
//					"values (@nombre, @precio)";
//				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
//				dbCommand.CommandText = insertSql;
//				DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
//				DbCommandHelper.AddParameter(dbCommand, "precio", precio);
//				dbCommand.ExecuteNonQuery();
			};

			entryNombre.Changed += delegate {
				string content = entryNombre.Text.Trim();
				saveAction.Sensitive = content != string.Empty;
			};

			fill();
		}

		private void fill() {
			List<Categoria> list = new List<Categoria> ();
			string selectSql = "select * from categoria order by nombre";
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = selectSql;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				long id = (long)dataReader ["id"];
				string nombre = (string)dataReader ["nombre"];
				Categoria categoria = new Categoria (id, nombre);
				list.Add (categoria);
			}
			dataReader.Close ();

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

