using Microsoft.Maui.Platform;

namespace BorderFillChangeTest;

public class BorderBehavior : PlatformBehavior<Layout>
{
    // please excuse my preferred compact syntax for BindableProperty declarations...

    public Color BorderColor { get => (Color)GetValue(BorderColorProperty); set => SetValue(BorderColorProperty, value); }
    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(BorderBehavior), Colors.Transparent);

    public double BorderWidth { get => (double)GetValue(BorderWidthProperty); set => SetValue(BorderWidthProperty, value); }
    public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(BorderBehavior), default);

    public double CornerRadius { get => (double)GetValue(CornerRadiusProperty); set => SetValue(CornerRadiusProperty, value); }
    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(BorderBehavior), default);

#if IOS || MACCATALYST

    protected override void OnAttachedTo(Layout bindable, UIKit.UIView platformView) {
        platformView.Layer.BorderWidth = (nfloat)BorderWidth;
        platformView.Layer.BorderColor = BorderColor.ToCGColor();
        platformView.Layer.CornerRadius = (nfloat)CornerRadius;

        PropertyChanged += (s, e) => {
            if ( e.PropertyName == BorderColorProperty.PropertyName ) {
                platformView.Layer.BorderColor = BorderColor.ToCGColor();
            } else if ( e.PropertyName == BorderWidthProperty.PropertyName ) {
                platformView.Layer.BorderWidth = (nfloat)BorderWidth;
            } else if ( e.PropertyName == CornerRadiusProperty.PropertyName ) {
                platformView.Layer.CornerRadius = (nfloat)CornerRadius;
            }
        };
    }

#endif

}
