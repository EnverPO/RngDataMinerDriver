using System;

using Skyline.DataMiner.Scripting;

/// <summary>
/// DataMiner QAction Class: Process responses.
/// </summary>
public static class QAction
{
	/// <summary>
	/// The QAction entry point.
	/// </summary>
	/// <param name="protocol">Link with SLProtocol process.</param>
	public static void Run(SLProtocolExt protocol)
	{
		try
		{
			ProcessResponse(protocol);
		}
		catch (Exception ex)
		{
			protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
		}
	}

	public static void ProcessResponse(SLProtocolExt protocol)
	{
		var response = (string)protocol.Rngresponsecontent_14;
		var randomNumber = response.Substring(1, response.Length - 2);
		protocol.RandomValue_15 = randomNumber;
	}
}