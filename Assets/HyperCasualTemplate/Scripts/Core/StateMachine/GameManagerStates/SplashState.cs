using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class SplashState:IState
	{
		private readonly GameManager m_gameManager;
		private bool m_hasSplashEnded;

		public bool HasSplashEnded => m_hasSplashEnded;

		public SplashState(GameManager gameManager)
		{
			m_gameManager = gameManager;
		}


		public void Update()
		{
			return;
		}

		public void OnEnter()
		{
			Debug.Log($"Entering State {GetType()}");
			UIController.Instance.ShowPanel(UIPanelType.Splash);
			UIController.Instance.SplashPanel.OnForwardComplete+=()=>m_hasSplashEnded = true;
		}

		public void OnExit()
		{
			Debug.Log($"Exiting State {GetType()}");
			//UIController.Instance.ShowPanel(UIPanelType.Consent);
			UIController.Instance.SplashPanel.OnForwardComplete-=()=>m_hasSplashEnded = true;
			//UIController.Instance.ShowPanel(UIPanelType.MainMenu);
		}
	}
}