using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using NServiceBus;

namespace __NAME__.Core.Profiles
{
    public class LiteLoggingProfile : IConfigureLoggingForProfile<Lite>
    {
        public void Configure(IConfigureThisEndpoint specifier)
        {
            SetLoggingLibrary
                .Log4Net<ColoredConsoleAppender>(null,
                                                 x =>
                                                     {
                                                         x.AddMapping(ErrorLevel);
                                                         x.AddMapping(WarnLevel);
                                                         x.AddMapping(DebugLevel);
                                                         x.AddMapping(InfoLevel);
                                                         x.Layout = new PatternLayout("%d [%t] %m%n");
                                                     });
        }

        private static readonly ColoredConsoleAppender.LevelColors ErrorLevel = new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Error,
                ForeColor =
                    ColoredConsoleAppender.Colors.Red |
                    ColoredConsoleAppender.Colors.HighIntensity
            };

        private static readonly ColoredConsoleAppender.LevelColors WarnLevel = new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Warn,
                ForeColor = ColoredConsoleAppender.Colors.Yellow
            };

        private static readonly ColoredConsoleAppender.LevelColors DebugLevel = new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Debug,
                ForeColor = ColoredConsoleAppender.Colors.Cyan
            };

        private static readonly ColoredConsoleAppender.LevelColors InfoLevel = new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Info,
                ForeColor = ColoredConsoleAppender.Colors.White
            };
    }
}