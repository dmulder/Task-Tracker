using System;
using Notifications;

namespace task_tracker
{
	public partial class Select_Date : Gtk.Dialog
	{
		internal static string dailyreportmessage = "";
		internal static DateTime selected;
		
		public Select_Date ()
		{
			this.Build ();
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			selected = calendar.GetDate();
			Reports dailyreport = new Reports();
			dailyreportmessage = dailyreport.CompileDailyReport(selected);
			Notification notify = new Notification();
			notify.Summary = "Daily Report " + selected.ToShortDateString();
			notify.Body = dailyreportmessage;
			notify.AddAction("send", "Send", HandleSendDaily);
			notify.Show();
			this.Destroy();
		}
		
		static void HandleSendDaily(object sender, ActionArgs e)
		{
			Reports.SendReport(dailyreportmessage, selected);
		}

		protected void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}
	}
}

