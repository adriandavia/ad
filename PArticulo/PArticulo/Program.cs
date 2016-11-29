using System;
using Gtk;

namespace PArticulo{

	class MainClass{

		public static void Main (string[] args){
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.EntityDao = new ArticuloDao ();
			win.Show ();
			Application.Run ();
		}
	}
}
