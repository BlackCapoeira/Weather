using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Services;
using Weather.ViewModels;
using Xamarin.Forms;

namespace Weather.Views
{
	public partial class MainView : ContentPage
	{
		private MainViewModel _viewModel;


		public MainView()
		{
			InitializeComponent();

			_viewModel = new MainViewModel();
			BindingContext = _viewModel;

		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await _viewModel.LoadWeather();
		}
}
}
