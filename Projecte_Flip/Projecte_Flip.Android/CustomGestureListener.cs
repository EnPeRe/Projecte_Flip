using System;
using Android.Views;

namespace Projecte_Flip.Droid
{
    public class CustomGestureListener : GestureDetector.SimpleOnGestureListener
    {
        #region .: Constants :.

        private const int SwipeThreshold = 100;
        private const int SwipeVelocityThreshold = 100;

        #endregion

        #region .: Private Fields :. 

        private MotionEvent _mLastOnDownEvent;

        #endregion

        #region .: Public Events :. 

        public event EventHandler OnSwipeLeft;
        public event EventHandler OnSwipeRight;

        #endregion

        #region .: Overriden Methods :.

        public override bool OnDown(MotionEvent e)
        {
            _mLastOnDownEvent = e;

            return true;
        }

        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            if (e1 == null)
                e1 = _mLastOnDownEvent;

            var diffY = e2.GetY() - e1.GetY();
            var diffX = e2.GetX() - e1.GetX();

            if (Math.Abs(diffX) > Math.Abs(diffY))
            {
                if (Math.Abs(diffX) > SwipeThreshold && Math.Abs(velocityX) > SwipeVelocityThreshold)
                {
                    if (diffX > 0)
                        OnSwipeRight?.Invoke(this, EventArgs.Empty);
                    else
                        OnSwipeLeft?.Invoke(this, EventArgs.Empty);
                }
            }

            return base.OnFling(e1, e2, velocityX, velocityY);
        }

        #endregion
    }
}