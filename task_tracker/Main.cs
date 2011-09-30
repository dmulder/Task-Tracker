using System;
using Gtk;
using Notifications;
using System.Timers;

namespace task_tracker
{
	class MainClass
	{
		private static Timer watch; //Add pause/start buttons to menu.
		
		public static void Main (string[] args)
		{
			Application.Init();
			StatusIcon icon = StatusIcon.NewFromStock(Stock.Add);
			icon.Visible = true;
			icon.Tooltip = "Task Tracker";
			icon.PopupMenu += OnStatusIconPopupMenu;
			watch = new Timer(1800000);
			watch.Elapsed += HandleWatchElapsed;
			watch.Start();
			RequestWork();
			Application.Run();
		}

		static void HandleWatchElapsed (object sender, ElapsedEventArgs e)
		{
			RequestWork();
		}
		
		static void OnStatusIconPopupMenu(object sender, EventArgs e)
		{
			watch.Start();
			Menu menu = new Menu();
			
			//Add Task Menu Item.
			MenuItem addTask = new MenuItem("Add Task");
			addTask.Show();
			addTask.Activated += MenuAddTaskActivated;
			menu.Append(addTask);
			
			//Settings Menu Item.
			MenuItem settings = new MenuItem("Settings");
			settings.Show();
			settings.Activated += HandleSettingsActivated;
			menu.Append(settings);
			
			//Exit Menu Item.
			MenuItem exit = new MenuItem("Exit");
			exit.Show();
			exit.Activated += HandleExit;
			menu.Append(exit);
			
			menu.Popup(null,null,null,3,Gtk.Global.CurrentEventTime);
		}

		static void HandleSettingsActivated (object sender, EventArgs e)
		{
			Dialog_Settings settings = new Dialog_Settings();
			settings.Show();
		}

		static void MenuAddTaskActivated (object sender, EventArgs e)
		{
			AddTask(false);
		}

		static void HandleShowActivated (object sender, EventArgs e)
		{
			RequestWork();
		}
		
		static void RequestWork()
		{
			Notification notify = new Notification("Work", "What are you working on?");
			notify.AddAction("AddTask", "Add Task", HandleAddTask);
			notify.Show();
		}
		
		static void HandleAddTask(object sender, EventArgs e)
		{
			AddTask(true);
		}
		
		static void AddTask(bool InProgress)
		{
			AddTask task = new AddTask(InProgress);
			task.Show();
		}
		
		static void HandleExit(object sender, EventArgs e)
		{
			Application.Quit();
		}
	}
}
