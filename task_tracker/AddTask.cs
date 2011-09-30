using System;

namespace task_tracker
{
	public partial class AddTask : Gtk.Dialog
	{
		public AddTask (bool inprogress)
		{
			current.Active = inprogress;
			this.Build();
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			Task task = new Task(DateTime.Now, summary.Text, description.Buffer.Text, 0, current.Active);
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

