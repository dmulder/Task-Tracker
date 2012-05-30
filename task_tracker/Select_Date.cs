using System;
using Notifications;

namespace task_tracker
{
	public partial class Select_Date : Gtk.Dialog
	{
		internal static string dailyreportmessage = "";
		internal static DateTime selected;
		internal static bool weekly;
		
		public Select_Date (bool weekly_report)
		{
			weekly = weekly_report;
			this.Build ();
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			selected = calendar.GetDate();
			if (!weekly)
			{
				Daily();
			}
			else
			{
				WorkReport report = new WorkReport(selected);
				report.Show();
			}
			this.Destroy();
		}
		
		static void Daily()
		{
			Reports dailyreport = new Reports();
			dailyreportmessage = dailyreport.CompileDailyReport(selected);
			Notification notify = new Notification();
			notify.Summary = "Daily Report " + selected.ToShortDateString();
			notify.Body = dailyreportmessage;
			notify.AddAction("send", "Send", HandleSendReport);
			notify.Urgency = Urgency.Critical;
			notify.Show();
		}
		
		static void HandleSendReport(object sender, ActionArgs e)
		{
			Reports.SendReport(dailyreportmessage, selected);
		}

		protected void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}
	}
}

