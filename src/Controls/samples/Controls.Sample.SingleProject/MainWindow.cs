﻿using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.SingleProject
{
	public class MainWindow : Window
	{
		public MainWindow() : base(MauiProgram.UseBlazor ? new BlazorPage() : new MainPage())
		{
		}
	}
}