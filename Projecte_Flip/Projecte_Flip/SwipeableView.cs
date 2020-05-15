using System;
using Xamarin.Forms;

namespace Projecte_Flip
{
    public class SwipeableView : ContentView
    {
        public event EventHandler SwipeLeft;
        public event EventHandler SwipeUp;
        public event EventHandler SwipeRight;
        public event EventHandler SwipeDown;

        public void OnSwipeLeft() =>
            SwipeLeft?.Invoke(this, EventArgs.Empty);

        public void OnSwipeUp() =>
            SwipeUp?.Invoke(this, EventArgs.Empty);

        public void OnSwipeRight() =>
            SwipeRight?.Invoke(this, EventArgs.Empty);

        public void OnSwipeDown() =>
            SwipeDown?.Invoke(this, EventArgs.Empty);
    }
}
