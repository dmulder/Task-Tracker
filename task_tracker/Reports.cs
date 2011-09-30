using System;
using System.Collections.Generic;

namespace task_tracker
{
	public class Reports
	{
		Tasks tasks = new Tasks();
		List<Task> finishedTasks = new List<Task>();
		
		public Reports ()
		{
			tasks.Load();
			FindFinishedTasks();
			finishedTasks.Sort(CompareTasks);
		}
		
		private static int CompareTasks(Task a, Task b)
		{
			if (a.Date < b.Date)
			{
				return -1;
			}
			else if (a.Date > b.Date)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		
		private void FindFinishedTasks()
		{
			foreach (Task task in tasks.tasks)
			{
				if (task.Finished != DateTime.MinValue)
				{
					finishedTasks.Add(task);
				}
			}
		}
		
		internal string CompileDailyReport()
		{
			return CompileDailyReport(DateTime.Now);
		}
		
		internal string CompileDailyReport(DateTime day)
		{
			string report = "";
			foreach (Task task in finishedTasks)
			{
				if (task.Finished.Date == day.Date)
				{
					report += "- " + task.Summary + " (" + Hours(task.Start, task.Finished) + ").\n";
				}
			}
			return report;
		}
		
		private int Hours(DateTime start, DateTime finish)
		{
			TimeSpan time = finish - start;
			return time.Hours;
		}
	}
}

