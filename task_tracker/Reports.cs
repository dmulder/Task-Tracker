using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

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
			foreach (Task task in finishedTasks)
			{
				tasks.Remove(task);
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
					report += "- " + task.Summary + "\n";
				}
			}
			foreach (Task task in tasks.tasks)
			{
				if (task.InProgress == true || task.IsWorked(day))
				{
					report += "- Working on: " + task.Summary + "\n";
				}
			}
			return report;
		}
		
		internal string CompileWeeklyReport(DateTime end)
		{
			DateTime last_monday = FindLastMonday(end);
			last_monday.AddHours(-(last_monday.Hour));
			string finished = "";
			string in_progress = "";
			foreach (Task task in finishedTasks)
			{
				if (task.Finished >= last_monday && task.Finished <= end)
				{
					finished += "- " + task.Summary + "\n";
				}
			}
			foreach (Task task in tasks.tasks)
			{
				bool was_worked = false;
				foreach (DateTime day in task.Worked)
				{
					if (day >= last_monday && day <= end)
					{
						was_worked = true;
					}
				}
				if (task.InProgress == true || was_worked)
				{
					in_progress += "- " + task.Summary + "\n";
				}
			}
			TaskSettings settings = new TaskSettings();
			settings = settings.Load();
			return settings.name + "\n\nRED Issues:\n\nAMBER Issues:\n\nGREEN Issues:\n" + finished + in_progress + "\nPlan for next week:\n" + in_progress + GetPlanned(end);
		}
		
		private string GetPlanned(DateTime end)
		{
			string planned = "";
			foreach (Task task in tasks.tasks)
			{
				if (!task.InProgress && task.Priority >= 10 && task.Priority < 15)
				{
					planned += "- " + task.Summary + "\n";
				}
			}
			return planned;
		}
		
		private DateTime FindLastMonday(DateTime end)
		{
			DateTime monday = end;
			while (monday.DayOfWeek != DayOfWeek.Monday)
			{
				monday = monday.AddDays(-1);
			}
			return monday;
		}
		
		static internal void SendReport(string message)
		{
			SendReport(message, DateTime.Now);
		}
		
		static internal void SendReport(string message, DateTime date)
		{
			TaskSettings settings = new TaskSettings();
			settings = settings.Load();
			SendReport(settings.email, settings.destination, settings.subject, message, date);
		}
		
		static internal void SendReport(string from_email, string to_email, string subject, string message, DateTime today)
		{
			TaskSettings settings = new TaskSettings();
			settings = settings.Load();
			MailAddress from_address = new MailAddress(from_email, settings.name);
			MailAddress to_address = new MailAddress(to_email);
			MailMessage mail = new MailMessage(from_address, to_address);
			string date = today.Year + "-" + today.Month + "-" + today.Day;
			mail.Subject = subject.Replace("<Date>", date);
			mail.Body = message;
			SmtpClient smtpclient = new SmtpClient(settings.smtpServer);
			smtpclient.Credentials = new NetworkCredential(settings.email, settings.password);
			smtpclient.Port = 25;
			smtpclient.Send(mail);
		}
		
		private int Hours(DateTime start, DateTime finish)
		{
			TimeSpan time = finish - start;
			return time.Hours;
		}
	}
}

