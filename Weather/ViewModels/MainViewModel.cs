using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Services;
using Weather.ViewModels.Base;

namespace Weather.ViewModels
{
	public class MainViewModel:ViewModelBase
	{
		private ObservableCollection<WeatherRoot> _names;
		private WeatherService _weatherService;

		public ObservableCollection<WeatherRoot> Weather
		{
			get { return _names; }
			set { _names = value; RaisePropertyChanged();}
		}

		public MainViewModel()
		{
			_weatherService = new WeatherService();
		}

		public async Task LoadWeather()
		{
			var city = await _weatherService.GetWeather("Madrid", Units.Metric);
			var result = await _weatherService.GetForecast(city.CityId);

			Weather = new ObservableCollection<WeatherRoot>();

			foreach (var item in result.Items)
			{
				Weather.Add(item);
			}
		}
	}
}
