// © 2015 skwas

namespace skwas.CitiesSkylines
{
	public interface ILogger
	{
		bool IncludeMethod { get; set; }
		bool IncludeTimestamp { get; set; }

		void Info(string text, params object[] args);
		void Warning(string text, params object[] args);
		void Error(string text, params object[] args);
	}
}