// © 2015 skwas

using System.Collections.Generic;
using ColossalFramework.Plugins;
using ColossalFramework.UI;

namespace skwas.CitiesSkylines
{
	/// <summary>
	/// The DebugOutputPanel can overflow and cause the game to crash at the moment. So be careful when using IngameLogger too much.
	/// </summary>
	public class IngameLogger
		: Logger
	{
		private static readonly Dictionary<LogType, PluginManager.MessageType> LogTypeConverter =
			new Dictionary<LogType, PluginManager.MessageType>()
			{
				{ LogType.Info, PluginManager.MessageType.Message }, 
				{ LogType.Warning, PluginManager.MessageType.Warning}, 
				{ LogType.Error, PluginManager.MessageType.Error}
			}; 

		#region Overrides of Logger

		protected override void Write(LogType type, string text)
		{
			// Note that the game crashes after writing too much log items.  Only using in DEBUG.
#if DEBUG
			UIView.library.Get<DebugOutputPanel>("DebugOutputPanel").OnClear();
			DebugOutputPanel.AddMessage(LogTypeConverter[type], text);
#endif
		}

		#endregion
	}
}
