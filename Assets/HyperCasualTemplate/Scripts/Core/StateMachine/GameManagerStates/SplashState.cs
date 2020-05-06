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

		public SplashState(GameManager gameManager, UiPanel panel):base(gameManager, panel)
		{
		}

		public override void OnEnter()
		{
			base.OnEnter();

			Panel.forwardComplete += () =>
			{
				UIController.Instance.AfterWait(() => Panel.HidePanel(), 1.5f);
			};

			Panel.backwardsComplete+=()=>m_hasSplashEnded = true;

			//Init Ad Network Here
		}
	}
}