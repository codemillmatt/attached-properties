using System;
using System.Windows.Input;
using Xamarin.Forms;
namespace AttachedProperties
{
public class EditorAttached
{
	public static BindableProperty CompletedCommandProperty =
		BindableProperty.CreateAttached("CompletedCommand", typeof(ICommand),
									typeof(Nullable), null, propertyChanged: HandleChanged);

	public static ICommand GetCompletedCommand(BindableObject view)
	{
		return (ICommand)view.GetValue(CompletedCommandProperty);
	}

	public static void SetCompletedCommand(BindableObject view, ICommand cmd)
	{
		view.SetValue(CompletedCommandProperty, cmd);
	}

	static void HandleChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var editor = bindable as Editor;

		if (editor == null)
			return;

		editor.Completed += (sender, e) =>
		{
			var s = sender as Editor;
			var command = GetCompletedCommand(s);

			command.Execute(null);
		};
	}
}
}
