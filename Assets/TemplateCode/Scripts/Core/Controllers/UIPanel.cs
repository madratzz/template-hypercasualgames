using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TemplateCode.Scripts.Core.Controllers
{
	public class UIPanel : MonoBehaviour
	{
		[SerializeField] private DOTweenAnimation[] animations;

		private int m_counter;
		private int m_direction;

		public Action OnBackwardsComplete;
		public Action OnForwardComplete;
		public UIPanelType type;

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
				Debug.Log("ForwardComplete");
				OnForwardComplete?.Invoke();
			}
			else
			{
				Debug.Log("BackwardsComplete");
				OnBackwardsComplete?.Invoke();
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
			}
			catch (Exception e)
			{
				Debug.LogError($"The parent: {name}:{type.ToString()} has no Child Tweens \n {e}");
				throw;
			}

			Debug.Log("PlayingForwards");
			foreach (var doTweenAnimation in animations) doTweenAnimation.DOPlayForward();
		}

		[TabGroup("Debug")]
		[Button(ButtonSizes.Small)]
		private void TestPlayBackwards()
		{
			m_counter = 0;
			m_direction = -1;

			var tweens = animations[0].GetTweens();
			foreach (var tween in tweens) tween.OnRewind(IncrementCounter);

			Debug.Log("PlayingBackwards");
			foreach (var doTweenAnimation in animations) doTweenAnimation.DOPlayBackwards();
		}
	}
}