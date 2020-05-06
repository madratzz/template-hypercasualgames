using CustomUtilities;
using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class SplashState:BaseMenuState
	{
		private bool m_hasSplashEnded;

		public bool HasSplashEnded => m_hasSplashEnded;

		public SplashState(GameManager gameManager, UIPanel panel):base(gameManager, panel)
		{
		}

		public override void OnEnter()
		{
			base.OnEnter();

			m_panel.OnForwardComplete += () =>
			{
				UIController.Instance.AfterWait(() => m_panel.HidePanel(), 1.5f);
			};

			m_panel.OnBackwardsComplete+=()=>m_hasSplashEnded = true;

			//Init Ad Network Here
		}
	}
}