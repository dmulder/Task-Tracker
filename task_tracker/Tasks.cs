using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace task_tracker
{
	public class Subtask
	{
		[XmlAttribute("ID")]
		public int ID;

		[XmlElement("Description")]
		public string Description;

		[XmlAttribute("Finished")]
		public DateTime Finished;

		[XmlAttribute("Priority")]
		public int Priority;

		public Subtask () {}

		public Subtask (int id, string description, DateTime finished, int priority)
		{
			ID = id;
			Description = description;
			Finished = finished;
			Priority = priority;
		}

		internal static int CompareSubtasks(Subtask x, Subtask y)
		{
			if (x.Priority < y.Priority)
			{
				return -1;
			}
			else if (x.Priority > y.Priority)
			{
				return 1;
			}
			return 0;
		}
	}

	public class Task
	{
		[XmlAttribute("ID")]
		public int ID = 0;

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
		
		[XmlAttribute("Priority")]
		public int Priority; //0 Next, 1 Today, 2 This week, 3 This month, 4 This year (all multiplied by 5 for postponement).
		
		[XmlAttribute("InProgress")]
		public bool InProgress;
		
		[XmlArray("Worked")]
		public List<DateTime> Worked;

		[XmlArray("Subtasks")]
		public List<Subtask> Subtasks;
		
		public Task() {}
		
		public Task(DateTime date, string summary, string description, int priority, bool inprogress)
		{
			ID = Task.GenerateRandomID();
			Date = date;
			Summary = summary;
			Description = description;
			Priority = priority;
			InProgress = inprogress;
			Worked = new List<DateTime>();
		}

		internal static int GenerateRandomID()
		{
			Random rand = new Random (DateTime.Now.Millisecond);
			return rand.Next (100000000, 999999999); //Generate a random ID.
		}
		
		internal bool IsWorked(DateTime day)
		{
			foreach (DateTime worked in Worked)
			{
				if (worked.ToShortDateString() == day.ToShortDateString())
				{
					return true;
				}
			}
			return false;
		}

		internal Subtask FindSubtask(int id)
		{
			try
			{
				foreach (Subtask subtask in Subtasks)
				{
					if (subtask.ID == id)
						return subtask;
				}
			} catch {}
			return null;
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
			// Necessary for backwords compatibility (updates old tasks.xml and adds IDs to each task).
			bool changed_ids = false;
			foreach (Task task in tasks) {
				if (task.ID == 0) {
					changed_ids = true;
					task.ID = Task.GenerateRandomID();
				}
			}
			if (changed_ids)
				this.Save();
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
			next.Priority = 25;
			foreach (Task task in tasks)
			{
				if (task.Priority < next.Priority && task.Finished == DateTime.MinValue && !task.InProgress)
				{
					next = task;
				}
			}
			if (next.Priority == 25)
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
			if (current == null)
			{
				return GetPriority();
			}
			else
			{
				return current;
			}
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
		
		internal void SetTaskNotActive()
		{
			Task task = CurrentTask();
			if (task != null)
			{
				task.InProgress = false;
				Save();
			}
		}
		
		internal void FinishCurrentTaskAndStartPriorityTask()
		{
			Task task = GetPriority();
			SetTaskNotActive();
			task.InProgress = true;
			task.Start = DateTime.Now;
			if (!task.IsWorked(DateTime.Now))
			{
				task.Worked.Add(DateTime.Now);
			}
			Save();
		}
		
		internal void PostponePriorityTask()
		{
			List<int> badvals = new List<int>();
			badvals.Add(4);
			badvals.Add(9);
			badvals.Add(14);
			badvals.Add(19);
			Task task = GetPriority();
			if (!badvals.Contains(task.Priority) && task.Priority < 24)
			{
				task.Priority += 1;
				Save();
			}
		}
		
		internal void Sort()
		{
			tasks.Sort(CompareTasks);
		}
		
		internal void Reverse()
		{
			tasks.Reverse();
		}
		
		private static int CompareTasks(Task x, Task y)
		{
			if (x.Priority == y.Priority)
			{
				if (x.Date > y.Date)
				{
					return -1;
				}
				else if (x.Date < y.Date)
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
			else if (x.Priority < y.Priority)
			{
				return 1;
			}
			else if (x.Priority > y.Priority)
			{
				return -1;
			}
			return 0;
		}
		
		internal Task Find(int id)
		{
			foreach (Task task in tasks)
			{
				if (task.ID == id)
				{
					return task;
				}
			}
			return null;
		}
	}
}

