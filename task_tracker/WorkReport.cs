using System;

namespace task_tracker
{
	public partial class WorkReport : Gtk.Dialog
	{
		TaskSettings settings;
		
		public WorkReport (DateTime end)
		{
			this.Build ();
			LoadSettings(end);
		}
		
		internal void LoadSettings(DateTime end)
		{
			settings = new TaskSettings();
			settings = settings.Load();
			destination_email_address.Text = settings.weeklyDestination;
			email_subject.Text = "Work Report for week " + (int)(DateTime.Now.DayOfYear*0.142857143) + ", " + DateTime.Now.Year;
			Reports report = new Reports();
			email_body.Buffer.Text = report.CompileWeeklyReport(end);
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			settings.weeklyDestination = destination_email_address.Text;
			settings.Save();
			Reports.SendReport(settings.email, destination_email_address.Text, email_subject.Text, email_body.Buffer.Text, DateTime.Now);
			this.Destroy();
		}

		protected void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}
	}
}

