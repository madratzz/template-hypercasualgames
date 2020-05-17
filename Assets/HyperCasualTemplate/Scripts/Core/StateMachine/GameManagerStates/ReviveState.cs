using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Controllers.UIControllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class ReviveState:BaseMenuState
	{
		private readonly Button m_collectButton;

		public bool CanShowRewarded { get; private set; }

		public ReviveState(GameManager gameManager, UIPanel panel, Button collectButton):base(gameManager, panel)
		{
			m_collectButton = collectButton;
		}

		public override void OnEnter()
		{
			base.OnEnter();

			//Bind Buttons
			m_collectButton.onClick.AddListener(OnCollectButton);
		}

		public override void OnExit()
		{
			base.OnExit();
			//UnBind Buttons
			m_collectButton.onClick.RemoveListener(OnCollectButton);
		}

		public override void Update()
		{
			base.Update();
			//Set Rewarded Video Bool here
			//CanShowRewarded = isRewardedVideoAvailable();
		}

		private void OnCollectButton()
		{

		}
	}
}