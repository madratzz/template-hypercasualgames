using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HyperCasualTemplate.Scripts.Core.Controllers
{
	public class UiPanel : MonoBehaviour
	{
		[SerializeField] private DOTweenAnimation[] animations;

		private int m_counter;
		private int m_direction;

		public Action backwardsComplete;
		public Action forwardComplete;
		[SerializeField] private UIPanelType type;

		[TabGroup("Debug")] [SerializeField] private bool isDebugMode;

		private void OnValidate()
		{
			GetAllTweens();
		}

		public UIPanelType Type
		{
			get => type;
			set => type = value;
		}

		public void ShowPanel()
		{
			TestPlayForward();
		}

		public void HidePanel()
		{
			TestPlayBackwards();
		}

		[Button(ButtonSizes.Medium)]
		private void GetAllTweens()
		{
			animations = GetComponentsInChildren<DOTweenAnimation>();

			foreach (var doTweenAnimation in animations)
			{
				doTweenAnimation.autoKill = false;
				doTweenAnimation.autoPlay = false;
			}
		}

		private void IncrementCounter()
		{
			m_counter++;
			if (m_counter < animations.Length) return;

			if (m_direction == 1)
			{
				if (isDebugMode)
					Debug.Log("ForwardComplete");
				forwardComplete?.Invoke();
			}
			else
			{
				if (isDebugMode)
					Debug.Log("BackwardsComplete");
				backwardsComplete?.Invoke();
			}
		}

		//Test Area
		[TabGroup("Debug")]
		[Button(ButtonSizes.Small)]
		private void TestPlayForward()
		{
			m_counter = 0;
			m_direction = 1;

			try
			{
				var tweens = animations[0].GetTweens();
				foreach (var tween in tweens) tween.OnComplete(IncrementCounter);
				if (isDebugMode)
					Debug.Log("PlayingForwards");
				foreach (var doTweenAnimation in animations) doTweenAnimation.DOPlayForward();
			}
			catch (Exception e)
			{
				Debug.LogError($"The parent: {name}:{type.ToString()} has no Child Tweens \n {e}");
			}
		}

		[TabGroup("Debug")]
		[Button(ButtonSizes.Small)]
		private void TestPlayBackwards()
		{
			m_counter = 0;
			m_direction = -1;

			try
			{
				var tweens = animations[0].GetTweens();
				foreach (var tween in tweens) tween.OnRewind(IncrementCounter);
				if (isDebugMode)
					Debug.Log("PlayingBackwards");
				foreach (var doTweenAnimation in animations) doTweenAnimation.DOPlayBackwards();
			}
			catch (Exception e)
			{
				Debug.LogError($"The parent: {name}:{type.ToString()} has no Child Tweens \n {e}");
			}
		}
	}
}