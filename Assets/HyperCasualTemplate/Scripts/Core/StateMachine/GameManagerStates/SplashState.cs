using CustomUtilities;
using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Controllers.UIControllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using CameraType = HyperCasualTemplate.Scripts.Core.Controllers.CameraType;

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

			//Camera Setting
			CameraController.Instance.ShowCamera(CameraType.MainMenu);

			Panel.forwardComplete += () =>
			{
				UIController.Instance.AfterWait(() => Panel.HidePanel(), 1.5f);
			};

			Panel.backwardsComplete+=()=>m_hasSplashEnded = true;

			//Init Ad Network Here
		}
	}
}