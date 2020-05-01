using System.Linq;
using TemplateCode.Scripts.Core.Controllers;
using TemplateCode.Scripts.Core.Managers;
using UnityEngine;

namespace TemplateCode.Scripts.Core.StateMachine
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
			//Debug.Log($"HasSplashEnded: {HasSplashEnded}");
		}

		public void OnEnter()
		{
			Debug.Log($"Entering State {GetType()}");
			UIController.Instance.ShowPanel(UIPanelType.Splash);
			UIController.Instance.splashPanel.OnForwardComplete+=()=>m_hasSplashEnded = true;
		}

		public void OnExit()
		{
			Debug.Log($"Exiting State {GetType()}");
			//UIController.Instance.ShowPanel(UIPanelType.Consent);
			UIController.Instance.splashPanel.OnForwardComplete-=()=>m_hasSplashEnded = true;
			//UIController.Instance.ShowPanel(UIPanelType.MainMenu);
		}
	}
}