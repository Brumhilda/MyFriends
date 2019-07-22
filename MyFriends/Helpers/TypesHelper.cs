using MyFriends.Api;
using MyFriends.Core;

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

        public static int GetIconId(this string str, UserInfoType type)
        {
            switch (type)
            {
                case UserInfoType.Fruit:
                    var fruitType = str.ToFruitType();
                    return fruitType == FruitType.Apple
                        ? Resource.Mipmap.ic_fruit_apple
                        : fruitType == FruitType.Banana
                            ? Resource.Mipmap.ic_fruit_banana
                            : fruitType == FruitType.Strawberry
                                ? Resource.Mipmap.ic_fruit_strawberry
                                : 0;
                case UserInfoType.Gender:
                    var gender = str.ToGenderType();
                    return gender == GenderType.Female
                        ? Resource.Mipmap.ic_gender_female
                        : gender == GenderType.Male
                            ? Resource.Mipmap.ic_gender_male
                            : 0;
                case UserInfoType.EyeColor:
                    var eyeColor = str.ToEyeColorType();
                    return eyeColor == EyeColorType.Blue
                        ? Resource.Mipmap.ic_eye_blue
                        : eyeColor == EyeColorType.Brown
                            ? Resource.Mipmap.ic_eye_brown
                            : eyeColor == EyeColorType.Green
                                ? Resource.Mipmap.ic_eye_green
                                : 0;
                default:
                    return 0;
            }
        }
    }
}
