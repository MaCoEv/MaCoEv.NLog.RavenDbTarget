using System;

// ReSharper disable once CheckNamespace
namespace NLog.TypedLogs
{
	public class WarnEventInfo : LogEventInfo
	{
		public WarnEventInfo() { }

		public WarnEventInfo(LogLevel level, string loggerName, string message)
			: base(level, loggerName, message) { }

		public WarnEventInfo(LogLevel level, string loggerName, IFormatProvider formatProvider, string message, object[] parameters)
			: base(level, loggerName, formatProvider, message, parameters) { }

		public WarnEventInfo(LogLevel level, string loggerName, IFormatProvider formatProvider, string message, object[] parameters, Exception exception)
			: base(level, loggerName, formatProvider, message, parameters, exception) { }

		public static WarnEventInfo CreateFromLogEventInfo(LogEventInfo logEvent)
		{
			return new WarnEventInfo(logEvent.Level, logEvent.LoggerName, logEvent.FormatProvider, logEvent.Message, logEvent.Parameters, logEvent.Exception);
		}
	}
}
