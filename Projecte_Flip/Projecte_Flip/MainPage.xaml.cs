using Xamarin.Forms;

namespace Projecte_Flip
{
    public partial class MainPage : ContentPage
    {
        #region .: Private Fields :.

        private readonly Easing _customEasing;
        private bool _isSwiping;
        protected uint TurnDuration;

        #endregion

        #region .: Constructor/s :.

        public MainPage()
        {
            InitializeComponent();

            _isSwiping = false;
            _customEasing = Easing.Linear;
            TurnDuration = 250;

            PageOne.SwipeRight += (sender, e) =>
                SwipeGestureRecognizer_Swiped(sender, new SwipedEventArgs(sender, SwipeDirection.Right));
            PageOne.SwipeUp += (sender, e) =>
                SwipeGestureRecognizer_Swiped(sender, new SwipedEventArgs(sender, SwipeDirection.Up));
        }

        #endregion

        #region .: Protected Methods :.

        protected async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            if (_isSwiping)
                return;

            _isSwiping = true;

            switch (e.Direction)
            {
                //PageOne (FlipableView) AND NOT CardFrame (Frame) on animation rotate!

                case SwipeDirection.Left:
                    break;

                case SwipeDirection.Right:

                    await PageOne.RotateYTo(90, TurnDuration, _customEasing); //PageOne AND NOT CardFrame!
                    await PageOne.RotateYTo(180, TurnDuration, _customEasing);
                    PageOne.RotationX = 0;
                    PageOne.RotationY = 0;

                    break;

                case SwipeDirection.Up:
                    await PageOne.RotateXTo(90, 250, Easing.Linear);
                    PageOne.RotationX = 270;
                    await PageOne.RotateXTo(360, 250, Easing.Linear);
                    PageOne.RotationX = 0;                  
                    break;

                case SwipeDirection.Down:
                    // Handle the swipe
                    break;
            }

            _isSwiping = false;
        }

        #endregion
    }
}
