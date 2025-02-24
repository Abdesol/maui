﻿using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.DeviceTests.Stubs
{
	public partial class SearchBarStub : StubBase, ISearchBar, ITextInputStub
	{
		string _text;

		public string Text 
		{ 
			get => _text; 
			set => SetProperty(ref _text, value, onChanged: OnTextChanged); 
		}

		public event EventHandler<StubPropertyChangedEventArgs<string>> TextChanged;

		void OnTextChanged(string oldValue, string newValue) =>
			TextChanged?.Invoke(this, new StubPropertyChangedEventArgs<string>(oldValue, newValue));

		public string Placeholder { get; set; }
		
		public Color PlaceholderColor { get; set; }

		public Color TextColor { get; set; }

		public Color CancelButtonColor { get; set; }

		public double CharacterSpacing { get; set; }

		public Font Font { get; set; }

		public TextAlignment HorizontalTextAlignment { get; set; }

		public TextAlignment VerticalTextAlignment { get; set; }

		public bool IsTextPredictionEnabled { get; set; } = true;

		public bool IsReadOnly { get; set; }

		public int MaxLength { get; set; } = int.MaxValue;

		public Keyboard Keyboard { get; set; }

		public void SearchButtonPressed() { }
	}
}