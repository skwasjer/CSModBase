// © 2015 skwas

using System;

namespace skwas.CitiesSkylines
{
	/// <summary>
	/// Logs info to a logger of choice. Note I use ConditionalAttribute to disable the logging functionality in Release.
	/// </summary>
	public static class Log
	{
		public static ILogger Output = new IngameLogger();

		public static void Info(string text, params object[] args)
		{
			if (Output == null) return;
			Output.Info(text, args);
		}

		public static void Warning(string text, params object[] args)
		{
			if (Output == null) return;
			Output.Warning(text, args);
		}

		public static void Error(string text, params object[] args)
		{
			if (Output == null) return;
			Output.Error(text, args);
		}

		public static void Exception(Exception exception)
		{
			Error(exception.ToString());
		}
	}
}
