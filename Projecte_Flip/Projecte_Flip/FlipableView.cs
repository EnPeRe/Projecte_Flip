using Xamarin.Forms;

namespace Projecte_Flip
{
    public class FlipableView : SwipeableView
    {
        public static readonly BindableProperty IsFlippedProperty = BindableProperty.Create(nameof(IsFlipped),
                typeof(bool), typeof(FlipableView), false, BindingMode.Default, null);

        public bool IsFlipped
        {
            get { return (bool)this.GetValue(IsFlippedProperty); }
            set { this.SetValue(IsFlippedProperty, value); }
        }
    }
}
