using System;
using Gtk;
using Notifications;
using System.Timers;

namespace task_tracker
{
	class MainClass
	{
		private static Timer watch;
		private static string dailyreportmessage;
//		private static string weeklyreportmessage;
		
		public static void Main (string[] args)
		{
			Application.Init();
			StatusIcon icon = StatusIcon.NewFromStock(Stock.Add);
			icon.Visible = true;
			icon.Tooltip = "Task Tracker";
			icon.PopupMenu += OnStatusIconPopupMenu;
			TaskSettings settings = new TaskSettings();
			settings = settings.Load();
			if (settings.interval == 0)
			{
				settings.interval = 1200000; //20 Minutes default.
				settings.Save();
			}
			watch = new Timer(settings.interval);
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
			Menu menu = new Menu();
			
			//View Task Menu Item.
			MenuItem viewTask = new MenuItem("View Task");
			viewTask.Show();
			viewTask.Activated += MenuViewTaskActivated;
			menu.Append(viewTask);
			
			//Add Task Menu Item.
			MenuItem addTask = new MenuItem("Add Task");
			addTask.Show();
			addTask.Activated += MenuAddTaskActivated;
			menu.Append(addTask);
			
			//Suggest Task Menu Item.
			MenuItem suggestTask = new MenuItem("Suggest Task");
			suggestTask.Show();
			suggestTask.Activated += MenuSuggestTaskActivated;
			menu.Append(suggestTask);
			
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
			
			//Selected Day Report
			MenuItem selectedreport = new MenuItem("Select Day to Report");
			selectedreport.Show();
			selectedreport.Activated += HandleSelectedReportActivated;
			menu.Append(selectedreport);
			
			//Weekly Report
//			MenuItem weeklyreport = new MenuItem("Weekly Report");
//			weeklyreport.Show();
//			weeklyreport.Activated += HandleWeeklyReportActivated;
//			menu.Append(weeklyreport);
			
			//Exit Menu Item.
			MenuItem exit = new MenuItem("Exit");
			exit.Show();
			exit.Activated += HandleExit;
			menu.Append(exit);
			
			menu.Popup(null,null,null,3,Gtk.Global.CurrentEventTime);
		}
		
		static void HandleSelectedReportActivated(object sender, EventArgs e)
		{
			Select_Date selected = new Select_Date();
			selected.Show();
		}
		
		static void HandleDailyReportActivated(object sender, EventArgs e)
		{
			Reports dailyreport = new Reports();
			dailyreportmessage = dailyreport.CompileDailyReport();
			Notification notify = new Notification();
			notify.Summary = "Daily Report";
			notify.Body = dailyreportmessage;
			notify.AddAction("send", "Send", HandleSendDaily);
			notify.Show();
		}
		
		static void HandleSendDaily(object sender, ActionArgs e)
		{
			Reports.SendReport(dailyreportmessage);
		}
		
//		static void HandleWeeklyReportActivated(object sender, EventArgs e)
//		{
//			Reports weeklyreport = new Reports();
//			weeklyreportmessage = weeklyreport.CompileWeeklyReport();
//			Notification notify = new Notification();
//			notify.Summary = "Weekly Report";
//			notify.Body = weeklyreportmessage;
//			notify.AddAction("send", "Send", HandleSendWeekly);
//			notify.Show();
//		}
//				
//		static void HandleSendWeekly(object sender, ActionArgs e)
//		{
//			Reports.SendReport(weeklyreportmessage);
//		}
		
		static void HandleSettingsActivated(object sender, EventArgs e)
		{
			Dialog_Settings settings = new Dialog_Settings();
			settings.Show();
		}
		
		static void MenuViewTaskActivated(object sender, EventArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			RequestWork.EditTask(tasks.CurrentTask());
		}
		
		static void MenuSuggestTaskActivated(object sender, EventArgs e)
		{
			RequestWork.SuggestTask();
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
