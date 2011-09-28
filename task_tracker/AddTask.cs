using System;

namespace task_tracker
{
	public partial class AddTask : Gtk.Dialog
	{
		private bool InProgress;
		
		public AddTask (bool inprogress)
		{
			InProgress = inprogress;
			this.Build ();
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			Tasks task = new Tasks();
			TaskData data = new TaskData(DateTime.Now, summary.Text, description.Text, 0, InProgress);
			task.tasks.Add(data);
			TaskWork.Save(task);
		}

		protected void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			
		}
	}
}

