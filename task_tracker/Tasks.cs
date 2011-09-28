using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace task_tracker
{
	public class TaskData
	{
		[XmlAttribute("Date")]
		public DateTime Date;
		
		[XmlElement("Summary")]
		public string Summary;
		
		[XmlElement("Task")]
		public string Task;
		
		[XmlElement("Priority")]
		public int Priority; //1 Next, 2 Today, 3 This week, 4 This month, 5 This year.
		
		[XmlElement("InProgress")]
		public bool InProgress;
		
		public TaskData() {}
		
		public TaskData(DateTime date, string summary, string task, int priority, bool inprogress)
		{
			Date = date;
			Summary = summary;
			Task = task;
			Priority = priority;
			InProgress = inprogress;
		}
	}
	
	[XmlRoot("TaskList")]
	public class Tasks
	{
		[XmlArray("Tasks")]
		public List<TaskData> tasks;
		
		public Tasks(){tasks = new List<TaskData>();}
	}
	
	static internal class TaskWork
	{
		static internal Tasks Load()
		{
			string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			return Load(Path.Combine(path, "tasks.xml"));
		}
		
		static private Tasks Load(string path)
		{
			var serializer = new XmlSerializer(typeof(Tasks));
			var stream = new FileStream(path, FileMode.Open);
			var tasks = serializer.Deserialize(stream) as Tasks;
			stream.Close();
			return tasks;
		}
		
		static internal void Save(Tasks task)
		{
			string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			Save(task, Path.Combine(path, "tasks.xml"));
		}
		
		static private void Save(Tasks task, string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Tasks));
			TextWriter writer = new StreamWriter(path);
			serializer.Serialize(writer, task);
			writer.Close();
		}
	}


}

