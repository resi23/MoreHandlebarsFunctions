using MediaBrowser.Common.Plugins;

namespace MoreHandlebarsFunctions;

public class MoreHandlebarsFunctions : BasePlugin
{
    public MoreHandlebarsFunctions()
    {
        DateTimeHelpers.RegisterHelpers();
        JSONHelpers.RegisterHelpers();
        ListHelpers.RegisterHelpers();
        LogicHelpers.RegisterHelpers();
        MathHelpers.RegisterHelpers();
        NumberHelpers.RegisterHelpers();
        StringHelpers.RegisterHelpers();
    }
    
    public override Guid Id => new Guid("f40cce45-5889-4172-8a20-a1c1f74de459");

    public override string Name => "MoreHandlebarsFunctions";

    public override string Description => "Ein Plugin, das benutzerdefinierte Handlebars-Funktionen bereitstellt.";
}