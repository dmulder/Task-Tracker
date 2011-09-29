using System;

namespace task_tracker
{
	public partial class Settings_Dialog : Gtk.Dialog
	{
		public Settings_Dialog ()
		{
			this.Build ();
		}

		protected void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			
		}
	}
}

