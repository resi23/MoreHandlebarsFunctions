using HandlebarsDotNet;

namespace MoreHandlebarsFunctions;

public static class MathHelpers
{
    public static void RegisterHelpers()
    {
        // Adds two numbers (Parameter1 + Parameter2).
        // Example: {{add 5 3}} -> "8"
        // Example: {{add "10.5" "2.3"}} -> "12.8"
        Handlebars.RegisterHelper("add", (writer, context, parameters) =>
        {
            if (parameters.Length < 2)
            {
                writer.WriteSafeString("0");
                return;
            }

            if (double.TryParse(parameters[0]?.ToString(), out var a) &&
                double.TryParse(parameters[1]?.ToString(), out var b))
            {
                writer.WriteSafeString((a + b).ToString());
            }
            else
            {
                writer.WriteSafeString("NaN");
            }
        });
        
        // Subtracts the second number from the first (Parameter1 - Parameter2).
        // Example: {{subtract 10 4}} -> "6"
        // Example: {{subtract "15.2" "5.1"}} -> "10.1"
        Handlebars.RegisterHelper("subtract", (writer, context, parameters) =>
        {
            if (parameters.Length < 2)
            {
                writer.WriteSafeString("0");
                return;
            }

            if (double.TryParse(parameters[0]?.ToString(), out var a) &&
                double.TryParse(parameters[1]?.ToString(), out var b))
            {
                writer.WriteSafeString((a - b).ToString());
            }
            else
            {
                writer.WriteSafeString("NaN");
            }
        });
        
        // Multiplies two numbers (Parameter1 * Parameter2).
        // Example: {{multiply 6 7}} -> "42"
        // Example: {{multiply "3.5" "2"}} -> "7"
        Handlebars.RegisterHelper("multiply", (writer, context, parameters) =>
        {
            if (parameters.Length < 2)
            {
                writer.WriteSafeString("0");
                return;
            }

            if (double.TryParse(parameters[0]?.ToString(), out var a) &&
                double.TryParse(parameters[1]?.ToString(), out var b))
            {
                writer.WriteSafeString((a * b).ToString());
            }
            else
            {
                writer.WriteSafeString("NaN");
            }
        });

        // Divides the first number by the second (Parameter1 / Parameter2).
        // Example: {{divide 10 2}} -> "5"
        // Example: {{divide "9" "3"}} -> "3"
        // Handles division by zero and outputs "Infinity".
        Handlebars.RegisterHelper("divide", (writer, context, parameters) =>
        {
            if (parameters.Length < 2)
            {
                writer.WriteSafeString("0");
                return;
            }

            if (double.TryParse(parameters[0]?.ToString(), out var a) &&
                double.TryParse(parameters[1]?.ToString(), out var b))
            {
                if (Math.Abs(b) < 1e-10) // Verhindert Division durch 0
                {
                    writer.WriteSafeString("Infinity");
                }
                else
                {
                    writer.WriteSafeString((a / b).ToString());
                }
            }
            else
            {
                writer.WriteSafeString("NaN");
            }
        });

        // Checks if Parameter1 is less than Parameter2 (Parameter1 < Parameter2)
        // Example: {{lessThan 3 5}} -> "true"
        // Example: {{lessThan 5 3}} -> "false"
        Handlebars.RegisterHelper("lessThan", (writer, context, parameters) =>
        {
            if (parameters.Length < 2 || !double.TryParse(parameters[0]?.ToString(), out var a) || !double.TryParse(parameters[1]?.ToString(), out var b))
            {
                writer.WriteSafeString("false");
                return;
            }

            writer.WriteSafeString(a < b ? "true" : "false");
        });

        // Checks if Parameter1 is less than or equal to Parameter2 (Parameter1 <= Parameter2)
        // Example: {{lessThanOrEqual 3 3}} -> "true"
        // Example: {{lessThanOrEqual 5 3}} -> "false"
        Handlebars.RegisterHelper("lessThanOrEqual", (writer, context, parameters) =>
        {
            if (parameters.Length < 2 || !double.TryParse(parameters[0]?.ToString(), out var a) || !double.TryParse(parameters[1]?.ToString(), out var b))
            {
                writer.WriteSafeString("false");
                return;
            }

            writer.WriteSafeString(a <= b ? "true" : "false");
        });

        // Checks if Parameter1 is greater than Parameter2 (Parameter1 > Parameter2)
        // Example: {{greaterThan 5 3}} -> "true"
        // Example: {{greaterThan 3 5}} -> "false"
        Handlebars.RegisterHelper("greaterThan", (writer, context, parameters) =>
        {
            if (parameters.Length < 2 || !double.TryParse(parameters[0]?.ToString(), out var a) || !double.TryParse(parameters[1]?.ToString(), out var b))
            {
                writer.WriteSafeString("false");
                return;
            }

            writer.WriteSafeString(a > b ? "true" : "false");
        });

        // Checks if Parameter1 is greater than or equal to Parameter2 (Parameter1 >= Parameter2)
        // Example: {{greaterThanOrEqual 5 5}} -> "true"
        // Example: {{greaterThanOrEqual 3 5}} -> "false"
        Handlebars.RegisterHelper("greaterThanOrEqual", (writer, context, parameters) =>
        {
            if (parameters.Length < 2 || !double.TryParse(parameters[0]?.ToString(), out var a) || !double.TryParse(parameters[1]?.ToString(), out var b))
            {
                writer.WriteSafeString("false");
                return;
            }

            writer.WriteSafeString(a >= b ? "true" : "false");
        });
    }
}