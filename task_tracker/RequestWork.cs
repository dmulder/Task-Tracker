using System;
using Notifications;

namespace task_tracker
{
	public class RequestWork
	{
		static internal void DisplayMessage()
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			Task current = tasks.CurrentTask();
			Notification notify;
			if (current != null)
			{
				notify = new Notification("Tasks", "Are you still working on this task?\n" + current.Summary);
				notify.AddAction("yes", "Yes", HandleDoNothing);
				notify.AddAction("view", "View", HandleEditTask);
				notify.AddAction("finish", "Finish", HandleFinishedTask);
				notify.Timeout = 0;
				notify.Urgency = Urgency.Critical;
				notify.Show();
			}
			else
			{
				SuggestTask();
			}
		}
		
		static void HandleDoNothing(object sender, ActionArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			Task current = tasks.CurrentTask();
			if (!current.IsWorked(DateTime.Now))
			{
				current.Worked.Add(DateTime.Now);
			}
			tasks.Save();
			SetPidginStatus("Busy", current.Summary);
		}

		static void SetPidginStatus(string status, string message)
		{
			try
			{
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.EnableRaisingEvents = false; 
				proc.StartInfo.FileName = "purple-remote";
				proc.StartInfo.Arguments = String.Format("\"setstatus?status={0}&message={1}\"", status, message);
				proc.Start();
			} catch {}
		}
		
		static void HandleFinishedTask(object sender, ActionArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			Task task = tasks.CurrentTask();
			tasks.SetCurrentTaskFinished();
			Notification notify = new Notification();
			notify.Summary = "Task Finished";
			notify.Body = task.Summary;
			notify.Urgency = Urgency.Critical;
			notify.Show();
			SuggestTask();
		}

		static internal void AddTask(bool InProgress)
		{
			AddTask task = new AddTask(InProgress);
			task.Show();
		}
		
		static void HandleSuggestTask(object sender, ActionArgs e)
		{
			SuggestTask();
		}
		
		static internal void SuggestTask()
		{
			SetPidginStatus("Available", "");
			Notification notify;
			Tasks tasks = new Tasks();
			tasks.Load();
			Task task = tasks.GetPriority();
			if (task != null)
			{
				notify = new Notification("Tasks", "This is the next priority task:\n" + task.Summary);
				notify.AddAction("select", "Select", HandleSelectTask);
				notify.AddAction("postpone", "Delay", HandlePostponeTask);
				notify.AddAction("AddTask", "Add Task", HandleAddTask);
				notify.Timeout = 0;
				notify.Urgency = Urgency.Critical;
				notify.Show();
			}
			else
			{
				notify = new Notification("Tasks", "What are you working on?");
				notify.AddAction("AddTask", "Add Task", HandleAddTask);
				notify.Timeout = 0;
				notify.Urgency = Urgency.Critical;
				notify.Show();
			}
		}
		
		static void SelectTask()
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			tasks.FinishCurrentTaskAndStartPriorityTask();
			Task current = tasks.CurrentTask();
			SetPidginStatus("Busy", current.Summary);
		}
		
		static void HandlePostponeTask(object sender, ActionArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			tasks.PostponePriorityTask();
			SuggestTask();
		}
		
		static void HandleSelectTask(object sender, ActionArgs e)
		{
			SelectTask();
		}
		
		static internal void EditTask(Task task)
		{
			if (task != null)
			{
				AddTask taskEdit = new AddTask(task);
				taskEdit.Show();
			}
			else
			{
				SuggestTask();
			}
		}
		
		static void HandleEditTask(object sender, ActionArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			EditTask(tasks.CurrentTask());
		}
		
		static void HandleAddTask(object sender, ActionArgs e)
		{
			AddTask(true);
		}
	}
}

