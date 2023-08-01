using Serilog;
using syslog_playground;

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.SyslogCustom()
    .CreateLogger();

var processId = Guid.NewGuid().ToString();
logger.Information("{processId} Starting...", processId);
var counter = 0;

while (counter < 10)
{
    logger.Information("{processId} {iteration}", processId, counter);
    counter++;
}

logger.Information("{processId} Stopping...", processId);

Console.ReadLine();