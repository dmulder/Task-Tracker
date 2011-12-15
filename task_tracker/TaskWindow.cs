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
			inProgressCell.Xpad = 10;
			inProgressCell.Ypad = 10;
			CellRendererText summaryCell = new CellRendererText();
			summary.PackStart(summaryCell, true);
			summaryCell.Xpad = 10;
			summaryCell.Ypad = 10;
			summaryCell.Editable = true;
			summaryCell.Edited += HandleSummaryCellEdited;
			CellRendererText dateCell = new CellRendererText();
			date.PackStart(dateCell, true);
			dateCell.Xpad = 10;
			dateCell.Ypad = 10;
			
			inProgress.AddAttribute(inProgressCell, "active", 0);
			summary.AddAttribute(summaryCell, "text", 1);
			date.AddAttribute(dateCell, "text", 2);
			
			Refresh();
		}

		private void HandleSummaryCellEdited (object o, EditedArgs args)
		{
			TreeIter iter;
			TreePath path = new Gtk.TreePath (args.Path);
			taskList.GetIter (out iter, path);
			
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
			OpenAddTask(task, false);
		}
		
		private void OpenAddTask(Task task, bool edit)
		{
			AddTask dialog = new AddTask(task);
			dialog.edit = edit;
			dialog.Close += HandleDialogClose;
			dialog.Show();
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
		}

		protected void OnEditTaskBtnClicked (object sender, System.EventArgs e)
		{
			Task task = SelectedTask();
			if (task != null)
			{
				OpenAddTask(task, true);
			}
		}
	}
}

