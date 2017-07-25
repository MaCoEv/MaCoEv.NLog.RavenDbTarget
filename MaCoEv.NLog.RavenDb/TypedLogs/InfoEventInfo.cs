﻿using System;

// ReSharper disable once CheckNamespace
namespace NLog.TypedLogs
{
	public class InfoEventInfo : LogEventInfo
	{
		public InfoEventInfo() { }

		public InfoEventInfo(LogLevel level, string loggerName, string message)
			: base(level, loggerName, message) { }

		public InfoEventInfo(LogLevel level, string loggerName, IFormatProvider formatProvider, string message, object[] parameters)
			: base(level, loggerName, formatProvider, message, parameters) { }

		public InfoEventInfo(LogLevel level, string loggerName, IFormatProvider formatProvider, string message, object[] parameters, Exception exception)
			: base(level, loggerName, formatProvider, message, parameters, exception) { }

		public static InfoEventInfo CreateFromLogEventInfo(LogEventInfo logEvent)
		{
			return new InfoEventInfo(logEvent.Level, logEvent.LoggerName, logEvent.FormatProvider, logEvent.Message, logEvent.Parameters, logEvent.Exception);
		}
	}
}
