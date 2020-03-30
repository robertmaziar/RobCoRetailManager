﻿using Caliburn.Micro;
using RRMDesktopUI.EventModels;
using RRMDesktopUI.Library.Api;
using System;
using System.Threading.Tasks;

namespace RRMDesktopUI.ViewModels
{
	public class LoginViewModel : Screen
    {
		// Testing purposes only.
		private string _userName = "rob@robco.com";
		private string _password = "Pwd12345.";
		
		private IAPIHelper _apiHelper;
		private IEventAggregator _events;

		public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
		{
			_apiHelper = apiHelper;
			_events = events;
		}

		public string UserName
		{
			get { return _userName; }
			set 
			{ 
				_userName = value;
				NotifyOfPropertyChange(() => UserName);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}

		public string Password
		{
			get { return _password; }
			set 
			{ 
				_password = value;
				NotifyOfPropertyChange(() => Password);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}

		public bool IsErrorVisible
		{
			get 
			{
				bool output = false;
				
				if (!String.IsNullOrWhiteSpace(ErrorMessage))
				{
					output = true;
				}

				return output; 
			}
		}

		private string _errorMessage;

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set 
			{
				_errorMessage = value;
				NotifyOfPropertyChange(() => IsErrorVisible);
				NotifyOfPropertyChange(() => ErrorMessage);
			}
		}

		public bool CanLogIn
		{
			get
			{
				bool output = false;

				if (!String.IsNullOrWhiteSpace(UserName) && !String.IsNullOrWhiteSpace(Password))
				{
					output = true;
				}

				return output;
			}
		}

		public async Task LogIn()
		{
			try
			{
				ErrorMessage = "";
				var result = await _apiHelper.Authenticate(UserName, Password);

				await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

				_events.PublishOnUIThread(new LogOnEvent());
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}
	}
}
