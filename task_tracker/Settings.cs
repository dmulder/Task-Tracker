using System;
using System.Xml.Serialization;

namespace task_tracker
{
	public class Settings
	{
		[XmlElement("Interval")]
		public int interval;
		
		public Settings () {}
		
		internal Settings Load()
		{
			string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			return Load(Path.Combine(path, "settings.xml"));
		}
		
		private Settings Load(string path)
		{
			var serializer = new XmlSerializer(typeof(Settings));
			var stream = new FileStream(path, FileMode.Open);
			var data = serializer.Deserialize(stream) as Settings;
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
			XmlSerializer serializer = new XmlSerializer(typeof(Settings));
			TextWriter writer = new StreamWriter(path);
			serializer.Serialize(writer, this);
			writer.Close();
		}
	}
}

