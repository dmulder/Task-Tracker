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
				notify.AddAction("yes", "Yes", null);
				notify.AddAction("suggest", "Suggest Task", HandleSuggestTask);
				notify.AddAction("AddTask", "Add Task", HandleAddTask);
				notify.Timeout = 0;
				notify.Show();
			}
			else
			{
				SuggestTask();
			}
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
		
		static void SuggestTask()
		{
			Notification notify;
			Tasks tasks = new Tasks();
			tasks.Load();
			Task task = tasks.GetPriority();
			if (task != null)
			{
				notify = new Notification("Tasks", "This is the next priority task:\n" + task.Summary);
				notify.AddAction("select", "Select", HandleSelectTask);
				notify.AddAction("postpone", "Postpone", HandlePostponeTask);
				notify.AddAction("edit", "Edit Task", HandleEditTask);
				notify.AddAction("AddTask", "Add Task", HandleAddTask);
				notify.Timeout = 0;
				notify.Show();
			}
			else
			{
				notify = new Notification("Tasks", "What are you working on?");
				notify.AddAction("AddTask", "Add Task", HandleAddTask);
				notify.Timeout = 0;
				notify.Show();
			}
		}
		
		static void SelectTask()
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			tasks.FinishCurrentTaskAndStartPriorityTask();
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
		
		static void HandleEditTask(object sender, ActionArgs e)
		{
			Tasks tasks = new Tasks();
			tasks.Load();
			AddTask task = new AddTask(tasks.GetPriority());
			task.Show();
		}
		
		static void HandleAddTask(object sender, ActionArgs e)
		{
			AddTask(true);
		}
	}
}

