﻿using System.Collections;

namespace com.Gemfile.Merger
{
	public interface IGameView: IBaseView
	{
		void RequestCoroutine(IEnumerator coroutine);
		IFieldView Field { get; }
		ISwipeInput Swipe { get; }
		IOrientationInput Orientation { get; }
		IUIView UI { get; }
		INavigationView Navigation { get; }
		void Reset();
	}

	public class GameView: BaseView, IGameView
	{
		public ISwipeInput Swipe {
			get { return swipe; }
		}
		ISwipeInput swipe;
		public IOrientationInput Orientation {
			get { return orientation; }
		}
		IOrientationInput orientation;
		public IUIView UI { 
			get { return uiView; }
		}
		IUIView uiView;

		public IFieldView Field {
			get { return fieldView; }
		}
		IFieldView fieldView;

		public INavigationView Navigation {
			get { return navigationView; }
		}
		INavigationView navigationView;

		public override void Init()
		{
			swipe = gameObject.GetComponent<SwipeInput>();
			orientation = gameObject.GetComponent<OrientationInput>();
			fieldView = transform.GetComponentInChildren<FieldView>();
			uiView = transform.GetComponentInChildren<UIView>();
			navigationView = transform.GetComponentInChildren<NavigationView>();
			navigationView.Init();
		}

		public void Reset()
		{
			fieldView.Reset(true);
		}

		public void RequestCoroutine(IEnumerator coroutine)
		{
			StartCoroutine(coroutine);
		}
	}
}
