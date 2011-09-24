using System;
using Gtk;

namespace task_tracker
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init();
			StatusIcon icon = StatusIcon.NewFromStock(Stock.MediaPlay);
			icon.Visible = true;
			icon.Tooltip = "Task Tracker";
			icon.PopupMenu += OnStatusIconPopupMenu;
			Application.Run();
		}
		
		static void OnStatusIconPopupMenu(object sender, EventArgs e)
		{
			Menu menu = new Menu();
			MenuItem exit = new MenuItem("Exit");
			exit.Show();
			exit.Activated += HandleExit;
			menu.Append(exit);
			menu.Popup(null,null,null,3,Gtk.Global.CurrentEventTime);
		}

		static void HandleExit (object sender, EventArgs e)
		{
			Application.Quit();
		}
		
	}
}
