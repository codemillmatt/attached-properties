using System;

using AttachedProperties.iOS;
using Xamarin.Forms;
using UIKit;
using CoreGraphics;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("com.codemilltech")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "ShadowEffect")]
namespace AttachedProperties.iOS
{
	public class LabelShadowEffect : PlatformEffect
	{
		UIColor prevColor;
		CGSize prevOffset;

		protected override void OnAttached()
		{
			var label = Control as UILabel;

			prevColor = label.ShadowColor;
			prevOffset = label.ShadowOffset;

			ChangeShadowColor();
		}

		protected override void OnDetached()
		{
			RevertToOriginal();
		}

		protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
		{
			if (args.PropertyName == ShadowAttachedProperties.HasShadowProperty.PropertyName)
			{
				if (ShadowAttachedProperties.GetHasShadowProperty(Element))
					ChangeShadowColor();
				else
					RevertToOriginal();
			}

			if (args.PropertyName == ShadowAttachedProperties.ShadowColorProperty.PropertyName)
			{
				// only update if has shadow is set to true
				if (ShadowAttachedProperties.GetHasShadowProperty(Element))
					ChangeShadowColor();
			}
		}

		void ChangeShadowColor()
		{
			var color = ShadowAttachedProperties.GetShadowColorProperty(Element);

			var label = Control as UILabel;

			label.ShadowColor = color.ToUIColor();
			label.ShadowOffset = new CGSize(2, 2);
		}

		void RevertToOriginal()
		{
			var label = Control as UILabel;

			label.ShadowColor = prevColor;
			label.ShadowOffset = prevOffset;
		}

	}
}
