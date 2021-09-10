using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Microsoft.Maui
{
	public partial class WrapperView : Grid
	{
		FrameworkElement? _child;

		public FrameworkElement? Child
		{
			get { return _child; }
			internal set
			{
				if (_child != null)
				{
					Children.Remove(_child);
				}

				if (value == null)
					return;

				_child = value;
				Children.Add(_child);
			}
		}
	}
}