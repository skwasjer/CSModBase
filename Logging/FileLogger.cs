// © 2015 skwas

using System;
using System.IO;
using System.Text;

namespace skwas.CitiesSkylines
{
	public class FileLogger
		: Logger
	{
		public FileLogger(string logFilename)
		{
			if (string.IsNullOrEmpty(logFilename))
				throw new ArgumentNullException("logFilename");

			LogFilename = logFilename;
		}

		public string LogFilename { get; set; }

		#region Overrides of Logger

		protected override void Write(LogType type, string text)
		{
			File.AppendAllText(LogFilename, text + Environment.NewLine, Encoding.UTF8);
		}

		#endregion
	}
}
