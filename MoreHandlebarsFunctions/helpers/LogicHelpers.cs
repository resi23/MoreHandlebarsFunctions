using HandlebarsDotNet;

namespace MoreHandlebarsFunctions;

public static class LogicHelpers
{
    public static void RegisterHelpers()
    {
        // Compares whether two values are equal.
        // Returns "true" if the values are equal, otherwise "false".
        // Example: {{equals "abc" "abc"}} -> "true"
        // Example: {{equals 5 10}} -> "false"
        // Example: {{equals "hello" "world"}} -> "false"
        Handlebars.RegisterHelper("equals", (writer, context, parameters) =>
        {
            if (parameters.Length < 2)
            {
                writer.WriteSafeString("false");
                return;
            }

            writer.WriteSafeString(parameters[0]?.ToString() == parameters[1]?.ToString() ? "true" : "false");
        });

        // Executes different outputs based on whether two values are equal.
        // If the values are equal, returns the third parameter. Otherwise, returns the fourth parameter (optional).
        // Example: {{ifEquals "abc" "abc" "Yes" "No"}} -> "Yes"
        // Example: {{ifEquals 5 10 "Equal" "Not Equal"}} -> "Not Equal"
        // Example: {{ifEquals "test" "test" "Success"}} -> "Success" (no "else" case provided)
        Handlebars.RegisterHelper("ifEquals", (writer, context, parameters) =>
        {
            if (parameters.Length < 3)
            {
                writer.WriteSafeString("Error: Missing parameters");
                return;
            }

            writer.WriteSafeString(parameters[0]?.ToString() == parameters[1]?.ToString()
                ? parameters[2]?.ToString()
                : parameters.Length > 3
                    ? parameters[3]?.ToString()
                    : string.Empty);
        });
    }
}