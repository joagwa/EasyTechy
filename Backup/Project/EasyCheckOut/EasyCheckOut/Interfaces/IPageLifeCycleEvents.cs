using System;

namespace EasyCheckOut
{
	public interface IPageLifeCycleEvents
	{
		void OnAppearing();
		void OnDisappearing();
		void OnLayoutChanged();
	}
}

