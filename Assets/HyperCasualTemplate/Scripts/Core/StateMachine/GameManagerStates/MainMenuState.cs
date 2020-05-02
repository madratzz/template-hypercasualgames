using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class MainMenuState : IState
	{
		private readonly GameManager m_gameManager;
		private readonly Button m_playButton;
		private readonly Button m_RemoveAdsButton;
		private readonly Button m_settingsButton;

		public MainMenuState(GameManager gameManager, Button playButton, Button settingsButton, Button removeAdsButton)
		{
			m_gameManager = gameManager;
			m_playButton = playButton;
			m_settingsButton = settingsButton;
			m_RemoveAdsButton = removeAdsButton;
		}

		public bool HasPressedSettings { get; private set; }

		public bool HasPressedPlay { get; private set; }

		public void Update()
		{
		}

		public void OnEnter()
		{
			UIController.Instance.ShowPanel(UIPanelType.MainMenu);
			//Bind Buttons
			m_playButton.onClick.AddListener(OnPlayButton);
			m_settingsButton.onClick.AddListener(OnSettingsButton);
			m_RemoveAdsButton.onClick.AddListener(OnRemoveAdsButton);
		}

		public void OnExit()
		{
			//UnBind Buttons
			m_playButton.onClick.RemoveListener(OnPlayButton);
			m_settingsButton.onClick.RemoveListener(OnSettingsButton);
			m_RemoveAdsButton.onClick.RemoveListener(OnRemoveAdsButton);
		}

		private void OnPlayButton()
		{
			HasPressedPlay = true;
		}

		private void OnSettingsButton()
		{
			HasPressedSettings = true;
		}

		private void OnRemoveAdsButton()
		{
			//Make a call to InAPP Manager
		}
	}
}