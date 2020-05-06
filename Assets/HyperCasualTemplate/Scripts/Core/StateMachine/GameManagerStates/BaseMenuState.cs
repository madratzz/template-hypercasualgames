using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class BaseMenuState:IState
	{
		protected readonly GameManager m_gameManager;
		protected readonly UIPanel m_panel;

		public BaseMenuState(GameManager gameManager, UIPanel panel)
		{
			m_gameManager = gameManager;
			m_panel = panel;
		}

		public virtual void Update()
		{

		}

		public virtual void OnEnter()
		{
			Debug.Log($"Entering State {GetType()}");
			BindClickSound();
			UIController.Instance.ShowPanel(m_panel.Type);
		}

		public virtual void OnExit()
		{
			Debug.Log($"Exiting State {GetType()}");
			UnBindClickSound();
		}

		protected void HidePanel()
		{
			m_panel.OnBackwardsComplete += () => m_panel.gameObject.SetActive(false);
			m_panel.HidePanel();
		}

		private void BindClickSound()
		{
			//Bind Sounds
			var buttons = m_panel.GetComponentsInChildren<Button>();
			foreach (var button in buttons)
			{
				button.onClick.AddListener(SoundController.Instance.PlayButtonSound);
			}
		}

		private void UnBindClickSound()
		{
			///Unbind Sounds
			var buttons = m_panel.GetComponentsInChildren<Button>();
			foreach (var button in buttons)
			{
				button.onClick.RemoveListener(SoundController.Instance.PlayButtonSound);
			}
		}
	}
}