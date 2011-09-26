using System;
using Gtk;
using Notifications;

namespace task_tracker
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init();
			StatusIcon icon = StatusIcon.NewFromStock(Stock.Add);
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
			MenuItem show = new MenuItem("Show");
			show.Show();
			show.Activated += HandleShowActivated;
			menu.Append(show);
			menu.Popup(null,null,null,3,Gtk.Global.CurrentEventTime);
		}

		static void HandleShowActivated (object sender, EventArgs e)
		{
			Notification notify = new Notification("Work", "What are you working on?");
			notify.AddAction("AddTask", "Add Task", HandleAddTask);
			notify.Show();
		}
		
		static void HandleAddTask(object sender, EventArgs e)
		{
			AddTask task = new AddTask();
			task.Show();
		}

		static void HandleExit(object sender, EventArgs e)
		{
			Application.Quit();
		}
		
	}
}
