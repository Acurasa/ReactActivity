using System.Reflection;
using System.Runtime.CompilerServices;
using SQLitePCL;

namespace Application.Activities.ManualMappings;

public static partial class MapAuto
{
    public static void Map<T, K>(T source, K target) where T : class where K : class
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (target == null) throw new ArgumentNullException(nameof(target));

        var fromProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var toProps = typeof(K).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var fromProp in fromProps)
        {
            var toProp = toProps
                .FirstOrDefault(p => p.Name == fromProp.Name && p.PropertyType == fromProp.PropertyType);
            if (toProp == null || !toProp.CanWrite) continue;

            var value = fromProp.GetValue(source);
            toProp.SetValue(target, value);
        }
    }
}