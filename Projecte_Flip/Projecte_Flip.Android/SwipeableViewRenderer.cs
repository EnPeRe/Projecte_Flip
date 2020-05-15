using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Projecte_Flip;
using Projecte_Flip.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SwipeableView), typeof(SwipeableViewRenderer))]
namespace Projecte_Flip.Droid
{
    public class SwipeableViewRenderer : ViewRenderer
    {
        #region .: private Fields :.

        private readonly GestureDetector _detector;
        private readonly CustomGestureListener _listener;
        private float _cameraDistance;

        #endregion

        #region .: Constants :.

        private const int Distance = 8000;

        #endregion

        public SwipeableViewRenderer(Context context) : base(context)
        {
            _listener = new CustomGestureListener();
            _detector = new GestureDetector(context, _listener);
        }

        #region .: Overriden Methods :.

        public override bool DispatchTouchEvent(MotionEvent e)
        {
            if (_detector == null) return base.DispatchTouchEvent(e);

            _detector.OnTouchEvent(e);
            base.DispatchTouchEvent(e);
            return true;
        }

        public override bool OnTouchEvent(MotionEvent ev)
        {
            base.OnTouchEvent(ev);

            return _detector != null && _detector.OnTouchEvent(ev);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                _listener.OnSwipeRight -= HandleOnSwipeRight;
            }

            if (e.OldElement == null)
            {
                _listener.OnSwipeRight += HandleOnSwipeRight;
            }

            if ((SwipeableView)e.NewElement == null) return;

            _cameraDistance = Context.Resources.DisplayMetrics.Density * Distance;
        }

        protected override void OnVisibilityChanged(Android.Views.View changedView, [GeneratedEnum] ViewStates visibility)
        {
            SetCameraDistance(_cameraDistance);
            base.OnVisibilityChanged(changedView, visibility);
        }

        #endregion

        #region .: Private Methods :.
        private void HandleOnSwipeRight(object sender, EventArgs e)
        {
            SetCameraDistance(_cameraDistance);
            ((SwipeableView)Element).OnSwipeRight();
        }

        #endregion
    }
}