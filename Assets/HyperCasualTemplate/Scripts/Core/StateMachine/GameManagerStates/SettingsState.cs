using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Controllers.UIControllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class SettingsState : BaseMenuState
	{
		private readonly Button m_backButton;

		public bool HasPressedBackButton { get; private set; }

		public SettingsState(GameManager gameManager, UIPanel panel, Button backButton):base(gameManager, panel)
		{
			m_backButton = backButton;
		}


		public override void OnEnter()
		{
			base.OnEnter();
			//BindButtons
			m_backButton.onClick.AddListener(OnBackButton);
		}

		public override void OnExit()
		{
			base.OnExit();
			m_backButton.onClick.RemoveListener(OnBackButton);

			//Reset State
			HasPressedBackButton = false;
		}

		private void OnBackButton()
		{
			HasPressedBackButton = true;
			HidePanel();
		}
	}
}