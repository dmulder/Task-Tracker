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


