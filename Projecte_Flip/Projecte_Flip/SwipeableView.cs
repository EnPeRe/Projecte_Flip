using System;
using Xamarin.Forms;

namespace Projecte_Flip
{
    public class SwipeableView : ContentView
    {
        public event EventHandler SwipeRight;
        public event EventHandler SwipeUp;

        public void OnSwipeRight() =>
            SwipeRight?.Invoke(this, EventArgs.Empty);
        public void OnSwipeUp() =>
            SwipeUp?.Invoke(this, EventArgs.Empty);
    }
}
