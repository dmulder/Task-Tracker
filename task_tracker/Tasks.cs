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
		
		public Tasks(){tasks = new List<Task>();}
		
		internal void Load()
		{
			string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			Load(Path.Combine(path, "tasks.xml"));
		}
		
		private void Load(string path)
		{
			var serializer = new XmlSerializer(typeof(Tasks));
			var stream = new FileStream(path, FileMode.Open);
			var data = serializer.Deserialize(stream) as Tasks;
			stream.Close();
			this.tasks = data.tasks;
		}
		
		internal void Save()
		{
			string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			Save(Path.Combine(path, "tasks.xml"));
		}
		
		private void Save(string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Tasks));
			TextWriter writer = new StreamWriter(path);
			serializer.Serialize(writer, this);
			writer.Close();
		}
	}
}

