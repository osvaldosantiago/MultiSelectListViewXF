using Xamarin.Forms;

namespace MultiSelectListViewXF
{
	public partial class MultiSelectListViewPage : ContentPage
	{
		MultiSelectVm ViewModel;
		public MultiSelectListViewPage()
		{
			InitializeComponent();
			ViewModel = new MultiSelectVm();
			BindingContext = ViewModel;

			myListView.SeparatorColor = Color.Gray;
			myListView.SetBinding(ListView.ItemsSourceProperty, ViewModel.BindTo(x => x.ItemMultiSource));
			myListView.SetBinding(ListView.SelectedItemProperty, nameof(ViewModel.ItemSelect), BindingMode.OneWay);
			myListView.ItemTemplate = new DataTemplate(CreateCell);
			myListView.BackgroundColor = Color.FromHex("#B3E5FC");
			myListView.ItemTapped += LstViewTeams_ItemTapped;
		}

		async void LstViewTeams_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var item = (ItemsMultiSelectVm)e.Item;
			if (item.IsSelected) 
			{
				ViewModel.ItemMultiSource[item.Index].IsSelected = false;
				ViewModel.ItemMultiSource[item.Index].ItemBackground = Color.FromHex("#B3E5FC");
				ViewModel.ItemMultiSource[item.Index].TextColor = Color.FromHex("#000000");
				ViewModel.ItemToDelete(item);
			}
			else
			{
				ViewModel.ItemMultiSource[item.Index].IsSelected = true;
				ViewModel.ItemMultiSource[item.Index].ItemBackground = Color.FromHex("#01579B");
				ViewModel.ItemMultiSource[item.Index].TextColor = Color.FromHex("#FFFFFF");
				ViewModel.ItemSelect = item;
			}
			myListView.ItemTemplate = new DataTemplate(CreateCell);
		}
		Cell CreateCell()
		{
			var view = new CustomCellView() { };
			var cell = new ViewCell();
			cell.View = view;
			cell.Height = 100;
			return cell;
		}

	}
}
