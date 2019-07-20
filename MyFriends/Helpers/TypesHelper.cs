using MyFriends.Api;

namespace MyFriends
{
    public static class TypesHelper
    {
        public static GenderType ToGenderType(this string str)
        {
            return str.CompareTo(GenderType.Female.ToString()) == 0
                ? GenderType.Female
                : str.CompareTo(GenderType.Male.ToString()) == 0
                    ? GenderType.Male
                    : GenderType.Other;
        }

        public static EyeColorType ToEyeColorType(this string str)
        {
            return str.CompareTo(EyeColorType.Blue.ToString()) == 0
                ? EyeColorType.Blue
                : str.CompareTo(EyeColorType.Brown.ToString()) == 0
                    ? EyeColorType.Brown
                    : str.CompareTo(EyeColorType.Green.ToString()) == 0
                        ? EyeColorType.Green
                        : EyeColorType.Other;
        }

        public static FruitType ToFruitType(this string str)
        {
            return str.CompareTo(FruitType.Apple.ToString()) == 0
                ? FruitType.Apple
                : str.CompareTo(FruitType.Banana.ToString()) == 0
                    ? FruitType.Banana
                    : str.CompareTo(FruitType.Strawberry.ToString()) == 0
                        ? FruitType.Strawberry
                        : FruitType.Other;
        }

        public static int GetIconId(this string str)
        {
            return 0;
        }
    }
}
