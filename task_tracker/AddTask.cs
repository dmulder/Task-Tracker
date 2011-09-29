using System;

namespace task_tracker
{
	public partial class AddTask : Gtk.Dialog
	{
		private bool InProgress;
		
		public AddTask (bool inprogress)
		{
			InProgress = inprogress;
			this.Build();
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			Task task = new Task(DateTime.Now, summary.Text, description.Buffer.Text, 0, InProgress);
			tasks.tasks.Add(task);
			tasks.Save();
			this.Destroy();
		}

		protected void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}
	}
}

