using System.Reflection;

namespace Application.Activities.ManualMappings;

public static partial class MapAuto
{
    public static void Map<T>(T source, T target) where T : class
    {
        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in props)
        {
            if (prop.CanRead && prop.CanWrite)
            {
                var value = prop.GetValue(source);
                prop.SetValue(target, value);
            }
        }
    }
}