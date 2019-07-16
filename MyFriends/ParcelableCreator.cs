using Android.OS;
using Android.Runtime;
using System;
using System.Collections.Generic;

namespace MyFriends
{
    public sealed class ParcelableCreator<T> : Java.Lang.Object, IParcelableCreator
    where T : Java.Lang.Object, new()
    {
        private readonly Func<Parcel, T> _createFunc;


        public ParcelableCreator(Func<Parcel, T> createFromParcelFunc)
        {
            _createFunc = createFromParcelFunc;
        }

        public Java.Lang.Object CreateFromParcel(Parcel source)
        {
            return _createFunc(source);
        }

        public Java.Lang.Object[] NewArray(int size)
        {
            return new T[size];
        }
    }
}
