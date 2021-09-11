﻿using System;
using UIKit;

namespace Microsoft.Maui.Handlers
{
	public partial class PageHandler : ContentViewHandler, INativeViewHandler
	{
		PageViewController? _pageViewController;
		UIViewController? INativeViewHandler.ViewController => _pageViewController;
		public PageViewController? ViewController 
		{
			get => _pageViewController;
			set => _pageViewController = value;
		}

		protected override ContentView CreateNativeView()
		{
			_ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a LayoutView");
			_ = MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null");

			ViewController = new PageViewController(VirtualView, this.MauiContext);

			if (_pageViewController?.CurrentNativeView is ContentView pv)
				return pv;

			throw new InvalidOperationException($"PageViewController.View must be a {nameof(ContentView)}");
		}

		public static void MapTitle(PageHandler handler, IContentView page)
		{
			if (handler is INativeViewHandler invh && invh.ViewController != null)
			{
				if (page is ITitledElement titled)
				{
					invh.ViewController.Title = titled.Title;
				}
			}
		}
	}
}
