using System;
using Xamarin.Forms;
using System.Linq;
namespace AttachedProperties
{
	public static class ShadowAttachedProperties
	{
		public static readonly BindableProperty HasShadowProperty =
			BindableProperty.Create("HasShadow", typeof(bool), typeof(ShadowAttachedProperties), false,
									propertyChanged: HasShadowChanged);

		// Should really do some checking around the casts
		static void HasShadowChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var view = bindable as Label;

			// Adds or removes the effect based on HasShadow being set
			if ((bool)newValue)
			{
				view.Effects.Add(new ShadowEffect());
			}
			else
			{
				var effect = view.Effects.FirstOrDefault(v => v is ShadowEffect);
				if (effect != null)
					view.Effects.Remove(effect);
			}
		}

		public static readonly BindableProperty ShadowColorProperty =
			BindableProperty.Create("ShadowColor", typeof(Color), typeof(ShadowAttachedProperties), Color.Black);

		public static void SetHasShadowProperty(BindableObject view, bool hasShadow)
		{
			view.SetValue(HasShadowProperty, hasShadow);
		}

		public static bool GetHasShadowProperty(BindableObject view)
		{
			return (bool)view.GetValue(HasShadowProperty);
		}

		public static void SetShadowColorProperty(BindableObject view, Color shadowColor)
		{
			view.SetValue(ShadowColorProperty, view);
		}

		public static Color GetShadowColorProperty(BindableObject view)
		{
			return (Color)view.GetValue(ShadowColorProperty);
		}
	}
}
