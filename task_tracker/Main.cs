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
		private static StatusIcon icon;
		
		public static void Main (string[] args)
		{
			Application.Init();
			icon = StatusIcon.NewFromStock(Stock.ZoomIn);
			icon.Visible = true;
			icon.Tooltip = "Task Tracker";
			icon.PopupMenu += OnStatusIconPopupMenu;
			icon.Activate += MenuViewTaskActivated;
			TaskSettings settings = new TaskSettings();
			settings = settings.Load();
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

//			//Add Task Menu Item.
//			MenuItem addTask = new MenuItem("Add Task");
//			addTask.Show();
//			addTask.Activated += MenuAddTaskActivated;
//			menu.Append(addTask);
			
			//Tasks Menu Item.
			MenuItem tasks = new MenuItem("Tasks");
			tasks.Show();
			tasks.Activated += HandleViewTaskListActivated;
			menu.Append(tasks);
			
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
			menu.Popup(null, null, MainMenuPosition, 3, Gtk.Global.CurrentEventTime);
		}

		static void MainMenuPosition(Gtk.Menu menu, out int x, out int y, out bool push_in)
		{
			Gdk.ModifierType mod = new Gdk.ModifierType();
			icon.Screen.RootWindow.GetPointer(out x, out y, out mod);
			y = menu.Screen.Height - 190;
			push_in = true;
		}

		static void HandleViewTaskListActivated (object sender, EventArgs e)
		{
			TaskWindow taskList = new TaskWindow();
			taskList.Show();
		}

		static void HandleEditTaskActivated (object sender, EventArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			RequestWork.EditTask(tasks.CurrentTask());
		}
		
		static void HandleSelectedReportActivated(object sender, EventArgs e)
		{
			Select_Date selected = new Select_Date(false);
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
			notify.AddAction("select", "Select Date", HandleSelectedReportActivated);
			notify.Urgency = Urgency.Critical;
			notify.Show();
		}
		
		static void MenuFinishTaskActivated(object sender, EventArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			Task task = tasks.CurrentTask();
			tasks.SetCurrentTaskFinished();
			Notification notify = new Notification();
			notify.Summary = "Task Finished";
			notify.Body = task.Summary;
			notify.Urgency = Urgency.Critical;
			notify.Show();
			RequestWork.SuggestTask();
		}
		
		static void HandleSendDaily(object sender, ActionArgs e)
		{
			Reports.SendReport(dailyreportmessage);
		}
		
		static void HandleWeeklyReportActivated(object sender, EventArgs e)
		{
			WorkReport report = new WorkReport(DateTime.Now);
			report.Show();
		}
		
		static void HandleSettingsActivated(object sender, EventArgs e)
		{
			Dialog_Settings settings = new Dialog_Settings();
			settings.Show();
		}
		
		static void MenuViewTaskActivated(object sender, EventArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			Task current = tasks.CurrentTask();
			Notification notify = new Notification(current.Summary, current.Description);
			notify.AddAction("edit", "Edit", HandleEditTaskActivated);
			notify.AddAction("finish", "Mark Finished", MenuFinishTaskActivated);
			notify.AddAction("list", "Tasks", HandleViewTaskListActivated);
			notify.Urgency = Urgency.Critical;
			notify.Show();
		}
		
		static void MenuSuggestTaskActivated(object sender, EventArgs e)
		{
			RequestWork.SuggestTask();
		}

//		static void MenuAddTaskActivated(object sender, EventArgs e)
//		{
//			RequestWork.AddTask(false);
//		}

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
