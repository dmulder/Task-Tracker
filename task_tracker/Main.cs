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
			RequestWork.DisplayMessage();
			Application.Run();
		}

		static void HandleWatchElapsed (object sender, ElapsedEventArgs e)
		{
			RequestWork.DisplayMessage();
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
			
			//Daily Report
			MenuItem dailyreport = new MenuItem("Daily Report");
			dailyreport.Show();
			dailyreport.Activated += HandleDailyReportActivated;
			menu.Append(dailyreport);
			
			//Weekly Report
			MenuItem weeklyreport = new MenuItem("Weekly Report");
			weeklyreport.Show();
			weeklyreport.Activated += HandleWeeklyReportActivated;
			menu.Append(weeklyreport);
			
			//Exit Menu Item.
			MenuItem exit = new MenuItem("Exit");
			exit.Show();
			exit.Activated += HandleExit;
			menu.Append(exit);
			
			menu.Popup(null,null,null,3,Gtk.Global.CurrentEventTime);
		}
		
		static void HandleDailyReportActivated(object sender, EventArgs e)
		{
			Reports dailyreport = new Reports();
			string report = dailyreport.CompileDailyReport();
		}
		
		static void HandleWeeklyReportActivated(object sender, EventArgs e)
		{
			
		}
		
		static void HandleSettingsActivated(object sender, EventArgs e)
		{
			Dialog_Settings settings = new Dialog_Settings();
			settings.Show();
			
		}

		static void MenuAddTaskActivated(object sender, EventArgs e)
		{
			RequestWork.AddTask(false);
		}

		static void HandleShowActivated(object sender, EventArgs e)
		{
			RequestWork.DisplayMessage();
		}
		
		static void HandleExit(object sender, EventArgs e)
		{
			Application.Quit();
		}
	}
}
