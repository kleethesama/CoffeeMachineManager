using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CoffeeMachineManager.Utilities
{
    public class EnumExtensions
    {
        public static string GetDisplayName<T>(T value) where T : struct, Enum
        {
            var displayAttribute = value.GetType()
                                        .GetMember(value.ToString())
                                        .First()
                                        .GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null)
            {
                return displayAttribute.GetName();
            }
            return Enum.GetName(value);
        }
    }
}
