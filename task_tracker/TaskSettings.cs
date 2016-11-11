using System;
using System.IO;
using System.Xml.Serialization;

namespace task_tracker
{
	public class TaskSettings
	{
		[XmlElement("Interval")]
		public int interval = 1200000;
		
		[XmlElement("Name")]
		public string name;
		
		[XmlElement("Email")]
		public string email;
		
		[XmlElement("Destination")]
		public string destination;
		
		[XmlElement("WeeklyDestination")]
		public string weeklyDestination;
		
		[XmlElement("Subject")]
		public string subject;

		[XmlElement("SMTPPort")]
		public string smtpport;
		
		[XmlElement("SMTPServer")]
		public string smtpServer;
		
		[XmlElement("Password")]
		public string password;
		
		public TaskSettings () {}
		
		internal TaskSettings Load()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			return Load(Path.Combine(path, "tracker/settings.xml"));
		}
		
		private TaskSettings Load(string path)
		{
			if (!File.Exists(path))
			{
				Save();
			}
			var serializer = new XmlSerializer(typeof(TaskSettings));
			var stream = new FileStream(path, FileMode.Open);
			var data = serializer.Deserialize(stream) as TaskSettings;
			stream.Close();
			return data;
		}
		
		internal void Save()
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tracker");
			Directory.CreateDirectory(path);
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

