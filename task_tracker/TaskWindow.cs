using System;
using Gtk;

namespace task_tracker
{
	public partial class TaskWindow : Gtk.Window
	{
		private ListStore taskList;
		private Tasks tasks;
		
		public TaskWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			PopulateWindow();
		}
		
		void PopulateWindow()
		{
			tasks = new Tasks();
			
			TreeViewColumn inProgress = new TreeViewColumn();
			TreeViewColumn summary = new TreeViewColumn();
			TreeViewColumn date = new TreeViewColumn();
			
			taskTreeView.HeadersVisible = false;
			taskTreeView.AppendColumn(inProgress);
			taskTreeView.AppendColumn(summary);
			taskTreeView.AppendColumn(date);
			
			taskList = new ListStore(typeof (bool), typeof (string), typeof (string));
			taskTreeView.Model = taskList;
			
			//Render the cells
			CellRendererToggle inProgressCell = new CellRendererToggle();
			inProgress.PackStart(inProgressCell, true);
			CellRendererText summaryCell = new CellRendererText();
			summary.PackStart(summaryCell, true);
			summaryCell.Editable = true;
			summaryCell.Edited += HandleSummaryCellEdited;
			CellRendererText dateCell = new CellRendererText();
			date.PackStart(dateCell, true);
			
			inProgress.AddAttribute(inProgressCell, "active", 0);
			summary.AddAttribute(summaryCell, "text", 1);
			date.AddAttribute(dateCell, "text", 2);
			
			Refresh();
		}

		private void HandleSummaryCellEdited (object o, EditedArgs args)
		{
			TreeIter iter;
			taskList.GetIter (out iter, new Gtk.TreePath (args.Path));
			
			tasks.Load();
			string summary = (string) taskList.GetValue(iter, 1);
			Task task = tasks.Find(summary);
			if (task != null)
			{
				task.Summary = args.NewText;
			}
			tasks.Save();
			Refresh();
		}
		
		private Task SelectedTask()
		{
			TreeIter iter;
			taskTreeView.Selection.GetSelected(out iter);
			string summary = (string) taskList.GetValue(iter, 1);
			Task task = tasks.Find(summary);
			return task;
		}

		protected void OnAddTaskButtonClicked (object sender, System.EventArgs e)
		{
			string enteredTaskText = taskSummary.Text.Trim ();
			taskSummary.Text = "";
			if (enteredTaskText.Length == 0)
				return;
			
			Task task = new Task(DateTime.Now, enteredTaskText, "", 0, false);
			OpenAddTask(task);
		}
		
		private void OpenAddTask(Task task)
		{
			AddTask dialog = new AddTask(task);
			dialog.edit = false;
			dialog.Show();
			dialog.Close += HandleDialogClose;
		}

		void HandleDialogClose (object sender, EventArgs e)
		{
			Refresh();
		}
		
		private void Refresh()
		{
			taskList.Clear();
			tasks.Load();
			tasks.Sort();
			tasks.Reverse();
			
			foreach (Task task in tasks.tasks)
			{
				if (task.Finished == DateTime.MinValue)
				{
					taskList.AppendValues(task.InProgress, task.Summary, task.Date.ToShortDateString());
				}
			}
		}

		protected void OnTaskTreeViewKeyPressEvent (object o, Gtk.KeyPressEventArgs args)
		{
			if (args.Event.Key == Gdk.Key.Delete)
			{
				Task task = SelectedTask();
				string msg = "Are you sure you want to delete this task?";
				MessageDialog message = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.OkCancel, msg);
				int result = message.Run();
				message.Destroy();
				
				if (result == -5)
				{
					tasks.Load();
					tasks.Remove(task);
					tasks.Save();
				}
				Refresh();
			}
			else if (args.Event.Key == Gdk.Key.F12)
			{
				OpenAddTask(SelectedTask());
			}
		}
	}
}

