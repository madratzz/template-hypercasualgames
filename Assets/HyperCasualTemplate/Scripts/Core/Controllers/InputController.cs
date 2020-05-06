using System;
using CustomUtilities;
using Lean.Touch;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HyperCasualTemplate.Scripts.Core.Controllers
{
	public class InputController : Singleton<InputController>
	{
		//LeanTouch Hooks
		[SerializeField]
		private LeanTouch touch;
		[SerializeField]
		private LeanFingerSwipe fingerSwipeLeft;
		[SerializeField]
		private LeanFingerSwipe fingerSwipeRight;
		[SerializeField]
		private LeanFingerTap fingerTap;


		//InputManager Events
		public static Action OnSwipeLeft;
		public static Action OnSwipeRight;
		public static Action OnTap;

		[BoxGroup("Settings")]
		[SerializeField]
		private bool isInputEnabled;

		[BoxGroup("Debugging")]
		[SerializeField] private bool debugEnabled;

		// Start is called before the first frame update
		void Start()
		{
			FindTouchReferences();

			fingerSwipeLeft.OnFinger.AddListener(OnFingerSwipeLeft);
			fingerSwipeRight.OnFinger.AddListener(OnFingerSwipeRight);
			fingerTap.OnFinger.AddListener(OnFingerTap);
		}

		[Button(ButtonSizes.Medium)]
		private void FindTouchReferences()
		{
			touch = FindObjectOfType<LeanTouch>();
			fingerSwipeLeft = GameObject.Find("SwipeLeft").GetComponent<LeanFingerSwipe>();
			fingerSwipeRight = GameObject.Find("SwipeRight").GetComponent<LeanFingerSwipe>();
			fingerTap = GameObject.Find("LeanTouch").GetComponent<LeanFingerTap>();
		}

		private void OnFingerSwipeLeft(LeanFinger leanFinger)
		{
			if (isInputEnabled)
			{
				if (debugEnabled)
					Debug.Log("Input: Swipe Left");
				OnSwipeLeft?.Invoke();
			}
			else
			{
				if (debugEnabled)
				{
					Debug.Log("Input not Enabled");
				}
			}
		}

		private void OnFingerSwipeRight(LeanFinger leanFinger)
		{
			if (isInputEnabled)
			{
				if (debugEnabled)
					Debug.Log("Input: Swipe Right");
				OnSwipeRight?.Invoke();
			}
			else
			{
				if (debugEnabled)
				{
					Debug.Log("Input not Enabled");
				}
			}
		}

		private void OnFingerTap(LeanFinger leanFinger)
		{
			if (isInputEnabled)
			{
				if (debugEnabled)
					Debug.Log("Input: Tap");
				OnTap?.Invoke();
			}
			else
			{
				if (debugEnabled)
				{
					Debug.Log("Input not Enabled");
				}
			}
		}

		private void OnDestroy()
		{
			fingerSwipeLeft.OnFinger.RemoveListener(OnFingerSwipeLeft);
			fingerSwipeRight.OnFinger.RemoveListener(OnFingerSwipeRight);
			fingerTap.OnFinger.RemoveListener(OnFingerTap);
		}

		public void EnableInput()
		{
			isInputEnabled = true;
		}

		public void DisableInput()
		{
			isInputEnabled = false;
		}
	}
}