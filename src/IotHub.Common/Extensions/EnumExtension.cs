namespace IotHub.Common.Extensions
{
    public static class EnumExtension
    {
        public static string ToIntegerString(this System.Enum enumValue)
        {
            return enumValue.ToString("D");
        }
    }
}
