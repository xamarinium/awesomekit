using Android.Content;
using Android.Graphics;
using Awesomekit.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(Button), typeof(FlatButtonRenderer))]
namespace Awesomekit.Droid.Renderers
{
    public class FlatButtonRenderer : ButtonRenderer
    {
        public FlatButtonRenderer(Context context) : base(context)
        {
            
        }
        
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
        }
    }
}