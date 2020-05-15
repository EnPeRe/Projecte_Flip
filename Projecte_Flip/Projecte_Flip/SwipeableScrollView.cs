using System;
using Xamarin.Forms;

namespace Projecte_Flip
{
    public class SwipeableScrollView : ContentView
    {
        public event EventHandler SwipeRight;

        public void OnSwipeRight() =>
            SwipeRight?.Invoke(this, EventArgs.Empty);
    }
}
