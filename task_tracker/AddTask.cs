using System;
using System.Collections.Generic;

namespace task_tracker
{
	public partial class AddTask : Gtk.Dialog
	{
		internal bool edit = false;
		internal Task task;
		
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
			priority.Active = task.Priority/5;
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			if (current.Active)
			{
				tasks.SetTaskNotActive();
			}
			if (!edit)
			{
				task = new Task(DateTime.Now, summary.Text, description.Buffer.Text, priority.Active*5, current.Active);
				if (current.Active)
				{
					task.Start = DateTime.Now;
					if (!task.IsWorked(DateTime.Now))
					{
						task.Worked.Add(DateTime.Now);
					}
				}
				tasks.tasks.Add(task);
				tasks.Save();
			}
			else
			{
				List<DateTime> worked = new List<DateTime>();
				foreach (DateTime date in task.Worked)
				{
					worked.Add(date);
				}
				tasks.Remove(task);
				task = new Task(DateTime.Now, summary.Text, description.Buffer.Text, priority.Active*5, current.Active);
				foreach (DateTime date in worked)
				{
					task.Worked.Add(date);
				}
				if (current.Active)
				{
					task.Start = DateTime.Now;
					if (!task.IsWorked(DateTime.Now))
					{
						task.Worked.Add(DateTime.Now);
					}
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
