using System;
using UnityEngine;

public interface IHasProgress 
{
    public event EventHandler<OnProgressChangedEventArgs> mOnBarChanged;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float mProgressFloat;
    }
}
