using System;
using Gtk;

namespace PArticulo
{
	public class WindowHelper
	{
		public static bool Confirm(Window parent, string message){
			//TODO implementar 
			MessageDialog messageDialog = new MessageDialog(
				parent,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				message
				);
			messageDialog.Title = parent.Title;
			ResponseType response = (ResponseType) messageDialog.Run();
			messageDialog.Destroy();
			return response == ResponseType.Yes;
		}
	}
}

