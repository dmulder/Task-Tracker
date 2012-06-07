using System;
using Gtk;
using System.Collections.Generic;

namespace task_tracker
{
	public partial class AddTask : Gtk.Dialog
	{
		private ListStore subtaskList;
		internal bool edit = false;
		internal Task task;
		
		public AddTask()
		{
			this.Build();
			PopulateWindow();
		}

		public AddTask (bool inprogress) : this()
		{
			current.Active = inprogress;
		}
		
		public AddTask (Task editTask) : this(editTask.InProgress)
		{
			task = editTask;
			Refresh();
			edit = true;
			summary.Text = task.Summary;
			description.Buffer.Text = task.Description;
			int prio = 0;
			if (task.Priority < 5)
				prio = 0;
			else if (task.Priority < 10)
				prio = 1;
			else if (task.Priority < 15)
				prio = 2;
			else if (task.Priority < 20)
				prio = 3;
			else if (task.Priority < 25)
				prio = 4;
			priority.Active = prio;
		}

		void PopulateWindow ()
		{
			TreeViewColumn finished = new TreeViewColumn ();
			finished.Title = "Finished";
			TreeViewColumn description = new TreeViewColumn ();
			description.Title = "Description";
			TreeViewColumn inProgress = new TreeViewColumn ();
			inProgress.Title = "In Progress";
			TreeViewColumn id = new TreeViewColumn ();
			id.Visible = false;

			subtaskTreeView.HeadersVisible = true;
			subtaskTreeView.AppendColumn (finished);
			subtaskTreeView.AppendColumn (description);
			subtaskTreeView.AppendColumn (inProgress);
			subtaskTreeView.AppendColumn (id);

			subtaskList = new ListStore (typeof(bool), typeof(string), typeof(bool), typeof(string));
			subtaskTreeView.Model = subtaskList;

			//Render the cells
			CellRendererToggle finishedCell = new CellRendererToggle ();
			finished.PackStart (finishedCell, true);
			finishedCell.Xpad = 10;
			finishedCell.Ypad = 10;
			finishedCell.Activatable = true;
			finishedCell.Toggled += HandleFinishedCellToggled;
			CellRendererText descriptionCell = new CellRendererText ();
			description.PackStart (descriptionCell, true);
			descriptionCell.Xpad = 10;
			descriptionCell.Ypad = 10;
			descriptionCell.Editable = true;
			descriptionCell.Edited += HandleDescriptionCellEdited;
			CellRendererToggle inProgressCell = new CellRendererToggle ();
			inProgress.PackStart (inProgressCell, true);
			inProgressCell.Xpad = 10;
			inProgressCell.Ypad = 10;
			inProgressCell.Activatable = true;
			inProgressCell.Toggled += HandleInProgressCellToggled;
			CellRendererText idCell = new CellRendererText ();
			id.PackStart (idCell, true);
			idCell.Xpad = 10;
			idCell.Ypad = 10;

			finished.AddAttribute (finishedCell, "active", 0);
			description.AddAttribute (descriptionCell, "text", 1);
			inProgress.AddAttribute (inProgressCell, "active", 2);
			id.AddAttribute(idCell, "text", 3);
		}

		void HandleInProgressCellToggled (object o, ToggledArgs args)
		{
			TreeIter iter;
			subtaskList.GetIterFromString (out iter, args.Path);
			if ((bool)subtaskList.GetValue (iter, 2))
				subtaskList.SetValue (iter, 2, false);
			else
				subtaskList.SetValue (iter, 2, true);
		}

		void HandleFinishedCellToggled (object o, ToggledArgs args)
		{
			TreeIter iter;
			subtaskList.GetIterFromString(out iter, args.Path);
			if ((bool) subtaskList.GetValue(iter, 0))
				subtaskList.SetValue(iter, 0, false);
			else
				subtaskList.SetValue(iter, 0, true);
		}

		void HandleDescriptionCellEdited (object o, EditedArgs args)
		{
			TreeIter iter;
			subtaskList.GetIterFromString(out iter, args.Path);
			subtaskList.SetValue(iter, 1, args.NewText);
		}

		private void Refresh()
		{
			subtaskList.Clear();
			task.Subtasks.Sort(Subtask.CompareSubtasks);

			foreach (Subtask subtask in task.Subtasks)
			{
				subtaskList.AppendValues(subtask.Finished == DateTime.MinValue ? false : true, subtask.Description, subtask.IsWorked(DateTime.Now), subtask.ID.ToString());
			}
		}

		protected void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			if (current.Active)
			{
				tasks.SetTaskNotActive();
			}
			List<Subtask> subtasks = Subtasks();
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
				task.Subtasks = subtasks;
				tasks.tasks.Add(task);
				tasks.Save();
			}
			else
			{
				DateTime start = task.Date;
				List<DateTime> worked = new List<DateTime>();
				foreach (DateTime date in task.Worked)
				{
					worked.Add(date);
				}
				tasks.Remove(task);
				task = new Task(start, summary.Text, description.Buffer.Text, priority.Active*5, current.Active);
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
				task.Subtasks = subtasks;
				tasks.tasks.Add(task);
				tasks.Save();
			}
		}

		private List<Subtask> Subtasks()
		{
			List<Subtask> subtasks = new List<Subtask>();
			TreeIter iter;
			bool valid = subtaskList.GetIterFirst(out iter);
			int priority = 0;
			while (valid) {
				int id = Convert.ToInt32((string) subtaskList.GetValue(iter, 3));
				Subtask subtask = task.FindSubtask(id);
				bool formFinished = (bool) subtaskList.GetValue(iter, 0);
				DateTime date;
				if (subtask != null)
					if (subtask.Finished != DateTime.MinValue && formFinished)
						date = subtask.Finished;
					else if (subtask.Finished == DateTime.MinValue && !formFinished)
						date = DateTime.MinValue;
					else if (subtask.Finished != DateTime.MinValue && !formFinished)
						date = DateTime.MinValue;
				else
					if (formFinished)
						date = DateTime.Now;
					else
						date = DateTime.MinValue;
				Subtask newsubtask = new Subtask(id, (string) subtaskList.GetValue(iter, 1), date, priority);
				try { // Bail out if the current subtask has no Worked
					foreach (DateTime time in subtask.Worked) {
						newsubtask.Worked.Add(time);
					}
				} catch {}
				if ((bool) subtaskList.GetValue(iter, 2) && !newsubtask.IsWorked(DateTime.Now)) {
					newsubtask.Worked.Add(DateTime.Now);
				}
				subtasks.Add(newsubtask);
				priority++;
				valid = subtaskList.IterNext(ref iter);
			}
			return subtasks;
		}

		protected void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}

		protected void OnAddSubtaskbtnClicked (object sender, EventArgs e)
		{
			subtaskList.AppendValues(false, "", Task.GenerateRandomID().ToString());
		}
	}
}
