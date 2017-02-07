using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MultiSelectListViewXF
{
	public partial class CustomCellView : ContentView
	{
		public CustomCellView()
		{
			InitializeComponent();
		}
		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			var item = this.BindingContext as ItemsMultiSelectVm;
			if (item == null)
				return;
			ContentXF.BackgroundColor = item.ItemBackground;
		}

	}
}
