using System;
using Gtk;
using Notifications;

namespace task_tracker
{
	public partial class Dialog_Settings : Gtk.Dialog
	{
		public Dialog_Settings ()
		{
			this.Build ();
			TaskSettings settings = new TaskSettings();
			settings = settings.Load();
			interval.Text = (settings.interval/1000/60).ToString();
			email_address.Text = settings.email;
			email_subject.Text = settings.subject;
			email_destination.Text = settings.destination;
			smtp_server.Text = settings.smtpServer;
			email_password.Text = settings.password;
		}

		protected void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			TaskSettings settings = new TaskSettings();
			string data = interval.Text;
			try
			{
				settings.interval = Int32.Parse(data)*1000*60; //Convert Minutes into milliseconds.
				settings.email = email_address.Text;
				settings.subject = email_subject.Text;
				settings.destination = email_destination.Text;
				settings.smtpServer = smtp_server.Text;
				settings.password = email_password.Text;
				settings.Save();
				this.Destroy();
			}
			catch (Exception i)
			{
				Notification error = new Notification("Error", i.Message, Stock.Stop);
				error.Show();
			}
		}
	}
}


