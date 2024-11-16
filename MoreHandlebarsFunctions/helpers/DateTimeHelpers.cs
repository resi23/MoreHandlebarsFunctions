using HandlebarsDotNet;

namespace MoreHandlebarsFunctions;

public static class DateTimeHelpers
{
    public static void RegisterHelpers()
    {
        // Date format
        // Example: {{formatDate "2024-11-16"}} -> "16.11.2024"
        // Example: {{formatDate "2024-11-16" "MMMM dd, yyyy"}} -> "November 16, 2024"
        Handlebars.RegisterHelper("formatDate", (writer, context, parameters) =>
        {
            if (parameters.Length < 1)
            {
                writer.WriteSafeString("Kein Datum angegeben");
                return;
            }

            string defaultFormat = "dd.MM.yyyy";

            var date = DateTime.TryParse(parameters[0]?.ToString(), out var parsedDate)
                ? parsedDate
                : DateTime.Now;

            string format = parameters.Length == 2
                ? parameters[1]?.ToString()
                : defaultFormat;

            writer.WriteSafeString(date.ToString(format));
        });

        // Timestamp to Date format
        // Example: {{formatTimestamp 1731763200}} -> "16.11.2024"
        // Example: {{formatTimestamp 1731763200 "MMMM dd, yyyy HH:mm:ss"}} -> "November 16, 2024 00:00:00"
        Handlebars.RegisterHelper("formatTimestamp", (writer, context, parameters) =>
        {
            if (parameters.Length < 1)
            {
                writer.WriteSafeString("Kein Timestamp angegeben");
                return;
            }

            string defaultFormat = "dd.MM.yyyy";

            if (!long.TryParse(parameters[0]?.ToString(), out var timestamp))
            {
                writer.WriteSafeString("Ungültiger Timestamp");
                return;
            }

            var date = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;

            string format = parameters.Length == 2
                ? parameters[1]?.ToString()
                : defaultFormat;

            writer.WriteSafeString(date.ToString(format));
        });

        // Adds a specified number of seconds, minutes, or hours to a given time.
        // Example: {{addTime "2024-11-16 12:00:00" 30 "minutes"}} -> "16.11.2024 12:30:00"
        // Example: {{addTime "2024-11-16 12:00:00" 2 "hours"}} -> "16.11.2024 14:00:00"
        // Example: {{addTime "2024-11-16 12:00:00" 60}} -> "16.11.2024 12:01:00"
        Handlebars.RegisterHelper("addTime", (writer, context, parameters) =>
        {
            if (parameters.Length < 2 || !DateTime.TryParse(parameters[0]?.ToString(), out var date))
            {
                writer.WriteSafeString("Ungültiges Datum");
                return;
            }

            if (!int.TryParse(parameters[1]?.ToString(), out var value))
            {
                writer.WriteSafeString(date.ToString("dd.MM.yyyy HH:mm:ss"));
                return;
            }

            var unit = parameters.Length > 2 ? parameters[2]?.ToString()?.ToLower() : "seconds";

            date = unit switch
            {
                "minutes" => date.AddMinutes(value),
                "hours" => date.AddHours(value),
                _ => date.AddSeconds(value)
            };

            writer.WriteSafeString(date.ToString("dd.MM.yyyy HH:mm:ss"));
        });
    }
}