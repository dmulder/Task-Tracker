using System;
using System.IO;
using System.Xml.Serialization;

namespace task_tracker
{
	public class TaskSettings
	{
		[XmlElement("Interval")]
		public int interval;
		
		public TaskSettings () {}
		
		internal TaskSettings Load()
		{
			string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			return Load(Path.Combine(path, "settings.xml"));
		}
		
		private TaskSettings Load(string path)
		{
			var serializer = new XmlSerializer(typeof(TaskSettings));
			var stream = new FileStream(path, FileMode.Open);
			var data = serializer.Deserialize(stream) as TaskSettings;
			stream.Close();
			return data;
		}
		
		internal void Save()
		{
			string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			Save(Path.Combine(path, "settings.xml"));
		}
		
		private void Save(string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(TaskSettings));
			TextWriter writer = new StreamWriter(path);
			serializer.Serialize(writer, this);
			writer.Close();
		}
	}
}

