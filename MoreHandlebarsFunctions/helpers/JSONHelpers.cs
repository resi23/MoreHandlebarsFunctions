using System.Text.Json;
using HandlebarsDotNet;

namespace MoreHandlebarsFunctions;

public class JSONHelpers
{
    public static void RegisterHelpers()
    {
        // Converts JSON strings to object.
        // Example: {{parseJson '{"key": "value", "number": 42}'}}
        Handlebars.RegisterHelper("parseJson", (writer, context, parameters) =>
        {
            if (parameters.Length < 1 || string.IsNullOrEmpty(parameters[0]?.ToString()))
            {
                writer.WriteSafeString("Ungültiges JSON");
                return;
            }

            try
            {
                var json = JsonSerializer.Deserialize<object>(parameters[0]?.ToString());
                writer.WriteSafeString(JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception)
            {
                writer.WriteSafeString("Ungültiges JSON");
            }
        });
    }
}