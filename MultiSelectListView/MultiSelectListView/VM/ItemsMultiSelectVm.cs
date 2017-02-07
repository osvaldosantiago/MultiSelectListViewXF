using System;
using Xamarin.Forms;

namespace MultiSelectListViewXF
{
	public class ItemsMultiSelectVm: BaseViewModel
	{
		public ItemsMultiSelectVm(Persona person)
		{
			Persona = person;
		}

		protected int _index;
		public int Index
		{
			get { return _index; }
			set
			{
				_index = value;
				OnPropertyChanged(nameof(Index));
			}
		}

		protected bool _isSelected = false;
		public bool IsSelected
		{
			get { return _isSelected; }
			set
			{
				_isSelected = value;
				OnPropertyChanged(nameof(IsSelected));
			}
		}
		protected Color _ItemBackground = Color.FromHex("#B3E5FC");
		public Color ItemBackground
		{
			get { return _ItemBackground; }
			set
			{
				_ItemBackground = value;
				OnPropertyChanged(nameof(ItemBackground));
			}
		}

		protected Color _TextColor = Color.FromHex("#000000");
		public Color TextColor
		{
			get { return _TextColor; }
			set
			{
				_TextColor = value;
				OnPropertyChanged(nameof(TextColor));
			}
		}

		Persona _personaEnty;
		public Persona Persona
		{
			get { return _personaEnty; }
			set
			{
				_personaEnty = value;
				OnPropertyChanged(nameof(Persona));
			}
		}

	}
}
