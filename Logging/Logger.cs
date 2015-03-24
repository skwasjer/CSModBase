// © 2015 skwas

using System;
using System.Diagnostics;

namespace skwas.CitiesSkylines
{
	public enum LogType
	{
		Info,
		Warning,
		Error
	}

	public abstract class Logger
		: ILogger
	{
		public Logger()
		{
			IncludeMethod = false;
			IncludeTimestamp = false;
		}

		public bool IncludeTimestamp { get; set; }

		public bool IncludeMethod { get; set; }

		public void Info(string text, params object[] args)
		{
			Write(LogType.Info, text, args);
		}

		public void Warning(string text, params object[] args)
		{
			Write(LogType.Warning, text, args);
		}
		public void Error(string text, params object[] args)
		{
			Write(LogType.Error, text, args);
		}

		private void Write(LogType type, string text, params object[] args)
		{
			if (IncludeMethod)
			{
				var frame = new StackFrame(3);
				var method = frame.GetMethod();

				text = string.Format("{0}->{1}: {2}", method.DeclaringType.Name, method.Name, string.Format(text, args));
			}
			else
				text = string.Format(text, args);

			if (IncludeTimestamp)
				text = string.Format("{0:u}\t{1}", DateTime.Now, text);

			Write(type, text);
		}

		protected abstract void Write(LogType type, string text);
	}
}
