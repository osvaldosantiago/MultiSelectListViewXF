using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MultiSelectListViewXF
{
	public class MultiSelectVm:BaseViewModel
	{
		public MultiSelectVm()
		{
			ItemMultiSource = new ObservableCollection<ItemsMultiSelectVm>();
			ItemsSelected = new ObservableCollection<ItemsMultiSelectVm>();
			RefreshData();
		}


		protected ItemsMultiSelectVm _itemSelect;
		public ItemsMultiSelectVm ItemSelect
		{
			get { return _itemSelect; }
			set
			{
				if (_itemSelect == value)
					return; _itemSelect = value;
				ItemsSelected.Add(value);
				if (ItemsSelected.Count == 0)
					Selected = "Selected";
				else if (ItemsSelected.Count == 1)
					Selected = "" + ItemsSelected.Count + " Item Selected";
				else
					Selected = "" + ItemsSelected.Count + " Items Selected";
				OnPropertyChanged(nameof(ItemsSelected));
				OnPropertyChanged(nameof(ItemSelect));
			}
		}

		protected ObservableCollection<ItemsMultiSelectVm> _itemsSelected;
		public ObservableCollection<ItemsMultiSelectVm> ItemsSelected
		{
			get { return _itemsSelected; }
			set
			{
				if (_itemsSelected == value)
					return; _itemsSelected = value;	
			}
		}

		protected ObservableCollection<ItemsMultiSelectVm> _itemMultiSource;
		public ObservableCollection<ItemsMultiSelectVm> ItemMultiSource
		{
			get { return _itemMultiSource; }
			set
			{
				if (_itemMultiSource == value)
					return; _itemMultiSource = value;
				OnPropertyChanged(nameof(ItemMultiSource));
			}
		}

		protected string _selected = "Selected";
		public string Selected
		{
			get { return _selected; }
			set
			{
				if (_selected == value)
					return; _selected = value;
				OnPropertyChanged(nameof(Selected));
			}
		}

		async void RefreshData() 
		{
			int con = 0;
			for (int i = 0; i < 10; i++)
			{
				Persona per = new Persona();
				per.Id = i;
				per.Name = "Osvaldo Santiago Estrada";
				per.Address = "Jalisco, Mexico";
				per.Profession = "Software developer";
				per.LastName = "S.E.";

				ItemsMultiSelectVm item = new ItemsMultiSelectVm(per);
				item.Index = con;
				ItemMultiSource.Add(item);
				con++;
			}


		}

		public void ItemToDelete(ItemsMultiSelectVm _deleteTeam)
		{
			ItemsSelected.Remove(_deleteTeam);

			if (ItemsSelected.Count == 0)
				Selected = "Selected";
			else if (ItemsSelected.Count == 1)
				Selected = "" + ItemsSelected.Count + " Item Selected";
			else
				Selected = "" + ItemsSelected.Count + " Items Selected";


			OnPropertyChanged(nameof(Selected));
		}

	}
}
