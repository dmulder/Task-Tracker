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
		
		static void HandleDoNothing(object sender, ActionArgs e)
		{
			//Do Nothing. Dumb, I know, but mono throws an exception if I don't have this here.
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
			EditTask(tasks.GetPriority());
		}
		
		static void HandleAddTask(object sender, ActionArgs e)
		{
			AddTask(true);
		}
	}
}

