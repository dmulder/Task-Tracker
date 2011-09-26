using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace task_tracker
{
	internal class TaskData
	{
		[XmlAttribute("Date")]
		internal DateTime Date;
		
		internal string Summary;
		internal string Task;
		internal int Priority; //1 Next, 2 Today, 3 This week, 4 This month, 5 This year.
		internal bool InProgress;
		
		public TaskData(string summary, string task, int priority, bool inprogress)
		{
			Summary = summary;
			Task = task;
			Priority = priority;
			InProgress = inprogress;
		}
	}
	
	internal class Tasks
	{
		[XmlAttribute("Tasks")]
		internal List<TaskData> tasks;
		
		public Tasks(){}
		
		internal Tasks Load()
		{
			return Load(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "tasks.xml"));
		}
		
		private Tasks Load(string path)
		{
			var serializer = new XmlSerializer(typeof(TaskData));
			var stream = new FileStream(path, FileMode.Open);
			var tasks = serializer.Deserialize(stream) as Tasks;
			stream.Close();
			return tasks;
		}
		
		internal void Save()
		{
			Save(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "tasks.xml"));
		}
		
		private void Save(string path)
		{
			var serializer = new XmlSerializer(typeof(TaskData));
			var stream = new FileStream(path, FileMode.Create);
			serializer.Serialize(stream, this);
			stream.Close();
		}
	}


}

