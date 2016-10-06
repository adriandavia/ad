using System;
using Gtk;

namespace Org.InstitutoSerpis.Ad
{
	public class TreeViewHelper
	{
		public static void AppendColumns(TreeView treeView, string[] columnNames){
			foreach (string columnName in columnNames) {
				treeView.AppendColumn (columnName, new CellRendererText (),
                   delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter){
						int column = Array.IndexOf(treeView.Columns, tree_column);
	                   	CellRendererText CellRendererText =(CellRendererText) cell;
					    object value = tree_model.GetValue(iter, column);
						CellRendererText.Text = value.ToString();
					}
               	);
			}
		}
	}
}

