using System.Net.Sockets;
using System.Text;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace syslog_playground;

public static class SyslogCustomExtensions
{
    public static LoggerConfiguration SyslogCustom(this LoggerSinkConfiguration loggerConfiguration,
        string server = "127.0.0.1",
        int port = 5324)
    {
        return loggerConfiguration.Sink(new SyslogCustomSink(server, port));
    }
}

public class SyslogCustomSink : ILogEventSink
{
    private readonly UdpClient _udpClient;
    private readonly string _server;
    private readonly int _port;

    public SyslogCustomSink(string server, int port)
    {
        _udpClient = new UdpClient();
        _server = server;
        _port = port;
    }

    public void Emit(LogEvent logEvent)
    {
        var message = BuildMessage(logEvent);
        var messageBytes = Encoding.UTF8.GetBytes(message);

        _udpClient.Send(messageBytes, message.Length, _server, _port);
    }

    private static string BuildMessage(LogEvent logEvent)
    {
        var sb = new StringBuilder();
        sb.Append($"{DateTime.Now:yyyy'/'MM'/'dd hh:mm:ss},");
        sb.Append($"{logEvent.Level.ToString()},");
        sb.Append($"{Guid.NewGuid()},");
        sb.Append($"{typeof(Program).Assembly.GetName().Name},");
        sb.Append($"{Environment.MachineName},");

        foreach (var prop in logEvent.Properties)
        {
            sb.Append($"{prop.Key}={prop.Value.ToString()},");
        }
        
        sb.Append("LoggerVersion=V3");
        var message = sb.ToString();
        return message;
    }
}