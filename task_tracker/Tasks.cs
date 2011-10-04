using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace task_tracker
{
	public class Task
	{
		[XmlAttribute("Date")]
		public DateTime Date;
		
		[XmlElement("Start")]
		public DateTime Start;
		
		[XmlElement("Finished")]
		public DateTime Finished;
		
		[XmlElement("Summary")]
		public string Summary;
		
		[XmlElement("Description")]
		public string Description;
		
		[XmlElement("Priority")]
		public int Priority; //0 Next, 1 Today, 2 This week, 3 This month, 4 This year.
		
		[XmlElement("InProgress")]
		public bool InProgress;
		
		public Task() {}
		
		public Task(DateTime date, string summary, string description, int priority, bool inprogress)
		{
			Date = date;
			Summary = summary;
			Description = description;
			Priority = priority;
			InProgress = inprogress;
		}
	}
	
	[XmlRoot("TaskList")]
	public class Tasks
	{
		[XmlArray("Tasks")]
		public List<Task> tasks;
		
		public Tasks()
		{
			tasks = new List<Task>();
		}
		
		internal void Load()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			Load(Path.Combine(path, "tracker/tasks.xml"));
		}
		
		internal void Remove(Task task)
		{
			Task current = null;
			foreach (Task old in tasks)
			{
				if (old.Date == task.Date)
				{
					current = old;
				}
			}
			if (current != null)
			{
				tasks.Remove(current);
			}
		}
		
		private void Load(string path)
		{
			if (!File.Exists(path))
			{
				Save();
			}
			var serializer = new XmlSerializer(typeof(Tasks));
			var stream = new FileStream(path, FileMode.Open);
			var data = serializer.Deserialize(stream) as Tasks;
			stream.Close();
			this.tasks = data.tasks;
		}
		
		internal void Save()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			Save(Path.Combine(path, "tracker/tasks.xml"));
		}
		
		private void Save(string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Tasks));
			TextWriter writer = new StreamWriter(path);
			serializer.Serialize(writer, this);
			writer.Close();
		}
		
		internal Task GetPriority()
		{
			Task next = new Task();
			next.Priority = 5;
			foreach (Task task in tasks)
			{
				if (task.Priority < next.Priority && task.Finished == DateTime.MinValue && !task.InProgress)
				{
					next = task;
				}
			}
			if (next.Priority == 5)
			{
				return null;
			}
			else
			{
				return next;
			}
		}
		
		internal Task CurrentTask()
		{
			Task current = null;
			foreach (Task task in tasks)
			{
				if (task.InProgress)
				{
					current = task;
				}
			}
			return current;
		}
		
		internal void SetCurrentTaskFinished()
		{
			Task task = CurrentTask();
			if (task != null)
			{
				task.Finished = DateTime.Now;
				task.InProgress = false;
				Save();
			}
		}
		
		internal void FinishCurrentTaskAndStartPriorityTask()
		{
			Task task = GetPriority();
			SetCurrentTaskFinished();
			task.InProgress = true;
			task.Start = DateTime.Now;
			Save();
		}
		
		internal void PostponePriorityTask()
		{
			Task task = GetPriority();
			if (task.Priority < 4)
			{
				task.Priority += 1;
				Save();
			}
		}
	}
}

