using System;

namespace task_tracker
{
	public partial class AddTask : Gtk.Dialog
	{
		private bool edit = false;
		private Task task;
		
		public AddTask()
		{
			this.Build();
		}
		
		public AddTask (bool inprogress) : this()
		{
			current.Active = inprogress;
		}
		
		public AddTask (Task editTask) : this(editTask.InProgress)
		{
			task = editTask;
			edit = true;
			summary.Text = task.Summary;
			description.Buffer.Text = task.Description;
			priority.Active = task.Priority;
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			if (current.Active)
			{
				tasks.SetCurrentTaskFinished();
			}
			if (!edit)
			{
				task = new Task(DateTime.Now, summary.Text, description.Buffer.Text, priority.Active, current.Active);
				if (current.Active)
				{
					task.Start = DateTime.Now;
				}
				tasks.tasks.Add(task);
				tasks.Save();
			}
			else
			{
				tasks.Remove(task);
				task = new Task(DateTime.Now, summary.Text, description.Buffer.Text, priority.Active, current.Active);
				if (current.Active)
				{
					task.Start = DateTime.Now;
				}
				tasks.tasks.Add(task);
				tasks.Save();
			}
			this.Destroy();
		}

		protected void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}
	}
}
