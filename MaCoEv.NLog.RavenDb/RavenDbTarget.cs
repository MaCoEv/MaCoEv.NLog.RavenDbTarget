using System;
using NLog.Config;
using NLog.TypedLogs;
using Raven.Client.Document;

namespace NLog.Targets
{
	[Target("RavenDb")]
	public class RavenDbTarget : TargetWithLayout
	{
		public RavenDbTarget() { }

		private const string LoggerNamePrefix = "Raven.";

		[RequiredParameter] public string Host { get; set; }
		[RequiredParameter] public string Database { get; set; }
		public string ApiKey { get; set; }

		protected DocumentStore Store { get; set; }

		protected override void Write(LogEventInfo logEvent)
		{
			if (Store == null)
			{
				Store = new DocumentStore { Url = Host, DefaultDatabase = Database };
				if (!string.IsNullOrEmpty(ApiKey)) Store.ApiKey = ApiKey;
				Store.Initialize(true);
			}
			SendLogToRaven(logEvent);
		}

		private void SendLogToRaven(LogEventInfo logEvent)
		{
			var factory = new TypedLogEventInfoFactory();
			if (logEvent.LoggerName.StartsWith(LoggerNamePrefix)) return;

			try
			{
				using (var session = Store.OpenSession())
				{
					session.Store(factory.CreateTypedLogEventInfo(logEvent));
					session.SaveChanges();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		protected override void CloseTarget()
		{
			Store.Dispose();
			base.CloseTarget();
		}

		protected class Log
		{
			public int Id { get; set; }
			public string Message { get; set; }
		}
	}
}
