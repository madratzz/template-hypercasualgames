using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class SettingsState : IState
	{
		private readonly GameManager m_gameManager;
		private readonly UIPanel m_panel;

		private readonly Button m_backButton;

		public bool HasPressedBackButton { get; private set; }

		public SettingsState(GameManager gameManager, UIPanel panel, Button backButton)
		{
			m_gameManager = gameManager;
			m_panel = panel;
			m_backButton = backButton;
		}

		public void Update()
		{
		}

		public void OnEnter()
		{
			UIController.Instance.ShowPanel(m_panel.Type);
			//BindButtons
			m_backButton.onClick.AddListener(OnBackButton);
		}

		public void OnExit()
		{
			m_backButton.onClick.RemoveListener(OnBackButton);

			//Reset State
			HasPressedBackButton = false;
		}

		private void OnBackButton()
		{
			HasPressedBackButton = true;
			HidePanel();
		}

		private void HidePanel()
		{
			m_panel.OnBackwardsComplete += () => m_panel.gameObject.SetActive(false);
			m_panel.HidePanel();
		}
	}
}