using HandlebarsDotNet;

namespace MoreHandlebarsFunctions;

public static class StringHelpers
{
    public static void RegisterHelpers()
    {
        // Converts a string to lower case.
        // Example: {{toLower "JELLYFIN"}} -> "jellyfin"
        Handlebars.RegisterHelper("toLower", (writer, context, parameters) =>
        {
            var input = parameters[0]?.ToString() ?? string.Empty;
            writer.WriteSafeString(input.ToLowerInvariant());
        });

        // Converts a string to upper case.
        // Example: {{toUpper "jellyfin"}} -> "JELLYFIN"
        Handlebars.RegisterHelper("toUpper", (writer, context, parameters) =>
        {
            var input = parameters[0]?.ToString() ?? string.Empty;
            writer.WriteSafeString(input.ToUpperInvariant());
        });

        // Removes leading and trailing spaces from a string.
        // Example: {{trim "  Jellyfin "}} -> "Jellyfin"
        Handlebars.RegisterHelper("trim", (writer, context, parameters) =>
        {
            var input = parameters[0]?.ToString() ?? string.Empty;
            writer.WriteSafeString(input.Trim());
        });

        // Truncates text after a certain length and optionally adds "...".
        // Example: {{truncate "Jellyfin is awesome" 10}} -> "Jellyfin i..."
        // Example: {{truncate "Short text" 20}} -> "Short text"
        Handlebars.RegisterHelper("truncate", (writer, context, parameters) =>
        {
            if (parameters.Length < 2 || !int.TryParse(parameters[1]?.ToString(), out var length))
            {
                writer.WriteSafeString(parameters[0]?.ToString());
                return;
            }

            var input = parameters[0]?.ToString() ?? string.Empty;
            writer.WriteSafeString(input.Length > length ? input.Substring(0, length) + "..." : input);
        });
        
        // Replaces a specific string with another.
        // Example: {{replace "Jellyfin is great" "great" "wonderful"}} -> "Jellyfin is wonderful"
        Handlebars.RegisterHelper("replace", (writer, context, parameters) =>
        {
            if (parameters.Length < 3)
            {
                writer.WriteSafeString("Fehlende Parameter");
                return;
            }

            var input = parameters[0]?.ToString() ?? string.Empty;
            var search = parameters[1]?.ToString() ?? string.Empty;
            var replace = parameters[2]?.ToString() ?? string.Empty;

            writer.WriteSafeString(input.Replace(search, replace));
        });
        
        // Converts a string to a URL-friendly version (removes special characters, replaces spaces with -).
        // Example: {{slugify "Jellyfin: Your home cinema!"}} -> "jellyfin-your-home-cinema"
        Handlebars.RegisterHelper("slugify", (writer, context, parameters) =>
        {
            if (parameters.Length < 1 || string.IsNullOrEmpty(parameters[0]?.ToString()))
            {
                writer.WriteSafeString("Ungültiger Text");
                return;
            }

            var input = parameters[0]?.ToString() ?? string.Empty;
            var slug = System.Text.RegularExpressions.Regex.Replace(input, @"[^a-zA-Z0-9\s-]", string.Empty)
                .Trim()
                .Replace(" ", "-")
                .ToLowerInvariant();

            writer.WriteSafeString(slug);
        });
    }
}