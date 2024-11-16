using HandlebarsDotNet;

namespace MoreHandlebarsFunctions;

public static class ListHelpers
{
    public static void RegisterHelpers()
    {
        // Returns the first element of a list.
        // Example: {{first myList}} -> "FirstElement" (if myList = ["FirstElement", "SecondElement", "ThirdElement"])
        // Example: {{first emptyList}} -> "N/A" (if emptyList = [])
        Handlebars.RegisterHelper("first", (writer, context, parameters) =>
        {
            var list = parameters[0] as IEnumerable<object>;
            writer.WriteSafeString(list?.FirstOrDefault()?.ToString() ?? "N/A");
        });


        // Returns the last element of a list.
        // Example: {{last myList}} -> "ThirdElement" (if myList = ["FirstElement", "SecondElement", "ThirdElement"])
        // Example: {{last emptyList}} -> "N/A" (if emptyList = [])
        Handlebars.RegisterHelper("last", (writer, context, parameters) =>
        {
            var list = parameters[0] as IEnumerable<object>;
            writer.WriteSafeString(list?.LastOrDefault()?.ToString() ?? "N/A");
        });
    }
}