﻿using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PolyGo.Views.Map
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapCampusPage : ContentPage
	{
		public MapCampusPage()
		{
			InitializeComponent();
		}

		void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			double zoomLevel = e.NewValue;
			double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
			if (map.VisibleRegion != null)
			{
				map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongDegrees, latlongDegrees));
					
			}
		}

		async void OnCorpusPinClicked(object sender, EventArgs e)
		{
			Pin pin = sender as Pin;
			switch (pin.Label)
			{
				case "Main building":
					await Shell.Current.GoToAsync($"{nameof(MapMainBuildingPage)}?");
					break;
				case "11 corpus":
					await Shell.Current.GoToAsync($"{nameof(Map11corpusPage)}?");
					break;
			}
		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			Button button = sender as Button;
			switch (button.Text)
			{
				case "Street":
					map.MapType = MapType.Street;
					break;
				case "Satellite":
					map.MapType = MapType.Satellite;
					break;
				case "Hybrid":
					map.MapType = MapType.Hybrid;
					break;
			}
		}
	}
}