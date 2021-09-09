#nullable enable
#if __IOS__ || MACCATALYST
using NativeView = Microsoft.Maui.Handlers.ContentView;
#elif __ANDROID__
using NativeView = Microsoft.Maui.Handlers.ContentViewGroup;
#elif WINDOWS
using NativeView = Microsoft.Maui.Handlers.ContentPanel;
#elif NETSTANDARD
using NativeView = System.Object;
#endif

namespace Microsoft.Maui.Handlers
{
	public partial class BorderHandler : IViewHandler
	{
		public static IPropertyMapper<IBorder, BorderHandler> BorderMapper = new PropertyMapper<IBorder, BorderHandler>(ViewMapper)
		{
			[nameof(IContentView.Background)] = MapBackground,
			[nameof(IContentView.Content)] = MapContent,
			[nameof(IBorderStroke.Shape)] = MapStrokeShape,
			[nameof(IBorderStroke.Stroke)] = MapStroke,
			[nameof(IBorderStroke.StrokeThickness)] = MapStrokeThickness,
			[nameof(IBorderStroke.StrokeLineCap)] = MapStrokeLineCap,
			[nameof(IBorderStroke.StrokeLineJoin)] = MapStrokeLineJoin,
			[nameof(IBorderStroke.StrokeDashPattern)] = MapStrokeDashPattern,
			[nameof(IBorderStroke.StrokeDashOffset)] = MapStrokeDashOffset,
			[nameof(IBorderStroke.StrokeMiterLimit)] = MapStrokeMiterLimit
		};

		public static CommandMapper<IBorder, BorderHandler> BorderCommandMapper = new(ViewCommandMapper)
		{
		};

		public BorderHandler() : base(BorderMapper, BorderCommandMapper)
		{

		}

		protected BorderHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null)
			: base(mapper, commandMapper ?? ViewCommandMapper)
		{
		}

		public BorderHandler(IPropertyMapper? mapper = null) : base(mapper ?? BorderMapper)
		{

		}

		public static void MapBackground(BorderHandler handler, IBorder border)
		{
#if WINDOWS
			handler.UpdateValue(nameof(IViewHandler.ContainerView));

			bool hasBorder = layout.Shape != null && layout.Stroke != null;

 			if(!hasBorder)
 				((NativeView?)handler.NativeView)?.UpdateBackground(layout);
 			else
 				((WrapperView?)handler.ContainerView)?.UpdateBackground(layout);
#endif
			((NativeView?)handler.NativeView)?.UpdateBackground(border);
		}

		public static void MapStrokeShape(BorderHandler handler, IBorder border)
		{
#if WINDOWS
#else
			((NativeView?)handler.NativeView)?.UpdateStrokeShape(border);
#endif

			MapBackground(handler, border);
		}

		public static void MapStroke(BorderHandler handler, IBorder border)
		{
#if WINDOWS
			handler.UpdateValue(nameof(IViewHandler.ContainerView));
			((WrapperView?)handler.ContainerView)?.UpdateStroke(layout);
#else
			((NativeView?)handler.NativeView)?.UpdateStroke(border);
#endif
			MapBackground(handler, border);
		}

		public static void MapStrokeThickness(BorderHandler handler, IBorder border)
		{
#if WINDOWS
			handler.UpdateValue(nameof(IViewHandler.ContainerView));
			((WrapperView?)handler.ContainerView)?.UpdateStrokeThickness(layout);
#else
			((NativeView?)handler.NativeView)?.UpdateStrokeThickness(border);
#endif
			MapBackground(handler, border);
		}

		public static void MapStrokeLineCap(BorderHandler handler, IBorder border)
		{
#if WINDOWS
			handler.UpdateValue(nameof(IViewHandler.ContainerView));
			((WrapperView?)handler.ContainerView)?.UpdateStrokeLineCap(layout);
#else
			((NativeView?)handler.NativeView)?.UpdateStrokeLineCap(border);
#endif
		}

		public static void MapStrokeLineJoin(BorderHandler handler, IBorder border)
		{
#if WINDOWS
			handler.UpdateValue(nameof(IViewHandler.ContainerView));
			((WrapperView?)handler.ContainerView)?.UpdateStrokeLineJoin(layout);
#else
			((NativeView?)handler.NativeView)?.UpdateStrokeLineJoin(border);
#endif
		}

		public static void MapStrokeDashPattern(BorderHandler handler, IBorder border)
		{
#if WINDOWS
			handler.UpdateValue(nameof(IViewHandler.ContainerView));
			((WrapperView?)handler.ContainerView)?.UpdateStrokeDashPattern(layout);
#else
			((NativeView?)handler.NativeView)?.UpdateStrokeDashPattern(border);
#endif
		}

		public static void MapStrokeDashOffset(BorderHandler handler, IBorder border)
		{
#if WINDOWS
			handler.UpdateValue(nameof(IViewHandler.ContainerView));
			((WrapperView?)handler.ContainerView)?.UpdateStrokeDashOffset(layout);
#else
			((NativeView?)handler.NativeView)?.UpdateStrokeDashOffset(border);
#endif
		}

		public static void MapStrokeMiterLimit(BorderHandler handler, IBorder border)
		{
#if WINDOWS
			handler.UpdateValue(nameof(IViewHandler.ContainerView));
			((WrapperView?)handler.ContainerView)?.UpdateStrokeMiterLimit(layout);
#else
			((NativeView?)handler.NativeView)?.UpdateStrokeMiterLimit(border);
#endif
		}
	}
}
