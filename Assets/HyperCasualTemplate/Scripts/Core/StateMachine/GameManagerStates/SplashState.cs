using CustomUtilities;
using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class SplashState:IState
	{
		private readonly GameManager m_gameManager;
		private readonly UIPanel m_panel;

		private bool m_hasSplashEnded;

		public bool HasSplashEnded => m_hasSplashEnded;

		public SplashState(GameManager gameManager, UIPanel panel)
		{
			m_gameManager = gameManager;
			m_panel = panel;
		}


		public void Update()
		{
			return;
		}

		public void OnEnter()
		{
			Debug.Log($"Entering State {GetType()}");

			UIController.Instance.ShowPanel(m_panel.Type);
			m_panel.OnForwardComplete += () =>
			{
				UIController.Instance.AfterWait(() => m_panel.HidePanel(), 1.5f);
			};

			m_panel.OnBackwardsComplete+=()=>m_hasSplashEnded = true;

			//Init Ad Network Here
		}

		public void OnExit()
		{
			Debug.Log($"Exiting State {GetType()}");
			//UIController.Instance.ShowPanel(UIPanelType.Consent);
			//UIController.Instance.ShowPanel(UIPanelType.MainMenu);
		}


		private void HidePanel()
		{
			m_panel.OnBackwardsComplete += () => m_panel.gameObject.SetActive(false);
			m_panel.HidePanel();
		}
	}
}