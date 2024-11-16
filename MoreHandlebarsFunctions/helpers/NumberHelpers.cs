using HandlebarsDotNet;

namespace MoreHandlebarsFunctions;

public static class NumberHelpers
{
    public static void RegisterHelpers()
    {
        // Rounds a number to the nearest integer.
        // Example: {{round 4.7}} -> "5"
        // Example: {{round 3.2}} -> "3"
        // Example: {{round "abc"}} -> "NaN"
        Handlebars.RegisterHelper("round", (writer, context, parameters) =>
        {
            if (parameters.Length < 1 || !double.TryParse(parameters[0]?.ToString(), out var value))
            {
                writer.WriteSafeString("NaN");
                return;
            }

            writer.WriteSafeString(Math.Round(value).ToString());
        });


        // Calculates the percentage of a number relative to a total.
        // Returns a string formatted as a percentage with two decimal places.
        // Example: {{percentage 50 200}} -> "25.00%"
        // Example: {{percentage 1 4}} -> "25.00%"
        // Example: {{percentage 10 0}} -> "NaN" (division by zero)
        // Example: {{percentage "abc" 100}} -> "NaN" (invalid input)
        Handlebars.RegisterHelper("percentage", (writer, context, parameters) =>
        {
            if (parameters.Length < 2 ||
                !double.TryParse(parameters[0]?.ToString(), out var part) ||
                !double.TryParse(parameters[1]?.ToString(), out var total) || total == 0)
            {
                writer.WriteSafeString("NaN");
                return;
            }

            writer.WriteSafeString(((part / total) * 100).ToString("F2") + "%");
        });
    }
}