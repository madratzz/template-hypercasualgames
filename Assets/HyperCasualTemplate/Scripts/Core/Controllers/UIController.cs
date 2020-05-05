using System.Linq;
using CustomUtilities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.Controllers
{
	public class UIController : Singleton<UIController>
	{
		#region Panels

		private UIPanelType m_currentPanelType, m_previousPanelType;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel consentPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel tutorialPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel gamePlayPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel levelCompletePanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel levelFailPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel mainMenuPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel revivePanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel rewardPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel settingsPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel splashPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField]
		private UIPanel pausePanel;

		public UIPanel ConsentPanel => consentPanel;
		public UIPanel TutorialPanel => tutorialPanel;
		public UIPanel GamePlayPanel => gamePlayPanel;
		public UIPanel LevelCompletePanel => levelCompletePanel;
		public UIPanel LevelFailPanel => levelFailPanel;
		public UIPanel MainMenuPanel => mainMenuPanel;
		public UIPanel RevivePanel => revivePanel;
		public UIPanel RewardPanel => rewardPanel;
		public UIPanel SettingsPanel => settingsPanel;
		public UIPanel PausePanel => pausePanel;
		public UIPanel SplashPanel => splashPanel;

		#endregion


		#region Buttons

		[BoxGroup("ConsentMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_consentAgreedButton;

		[BoxGroup("ConsentMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_consentPrivacyPolicyButton;

		[BoxGroup("MainMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_mainMenuPlayButton;

		[BoxGroup("MainMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_mainMenuSettingsButton;

		[BoxGroup("MainMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_mainMenuRemoveAdsButton;

		[BoxGroup("SettingsMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_settingsBackButton;

		[BoxGroup("TutorialMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_tutorialDoneButton;

		[BoxGroup("GameplayMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_gameplayPauseButton;

		[BoxGroup("PauseMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_pauseResumeButton;

		[BoxGroup("PauseMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_pauseRestartButton;

		[BoxGroup("PauseMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_pauseMainMenuButton;

		[BoxGroup("WinMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_winContinueButton;

		[BoxGroup("FailMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_failContinueButton;

		[BoxGroup("ReviveMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_reviveContinueButton;

		[BoxGroup("RewardMenuButtons", centerLabel: true)] [SerializeField]
		private Button m_rewardCollectButton;

		public Button ConsentAgreedButton => m_consentAgreedButton;
		public Button ConsentPrivacyPolicyButton => m_consentPrivacyPolicyButton;
		public Button MainMenuPlayButton => m_mainMenuPlayButton;
		public Button MainMenuSettingsButton => m_mainMenuSettingsButton;
		public Button MainMenuRemoveAdsButton => m_mainMenuRemoveAdsButton;
		public Button SettingsBackButton => m_settingsBackButton;

		public Button GameplayPauseButton => m_gameplayPauseButton;

		public Button PauseResumeButton => m_pauseResumeButton;

		public Button PauseRestartButton => m_pauseRestartButton;

		public Button PauseMainMenuButton => m_pauseMainMenuButton;

		public Button WinContinueButton => m_winContinueButton;

		public Button FailContinueButton => m_failContinueButton;

		public Button ReviveContinueButton => m_reviveContinueButton;

		public Button RewardCollectButton => m_rewardCollectButton;

		public Button TutorialDoneButton => m_tutorialDoneButton;

		#endregion

		[ShowInInspector] private UIPanel[] m_uiPanels;

		[Button(ButtonSizes.Medium)]
		private void ValidatePanels()
		{
			#region PanelValidation

			if (splashPanel != null)
			{
				splashPanel.name = "SplashCanvas";
				splashPanel.Type = UIPanelType.Splash;
			}

			if (consentPanel != null)
			{
				consentPanel.name = "ConsentCanvas";
				consentPanel.Type = UIPanelType.Consent;
			}

			if (mainMenuPanel != null)
			{
				mainMenuPanel.name = "MainMenuCanvas";
				mainMenuPanel.Type = UIPanelType.MainMenu;
			}

			if (settingsPanel != null)
			{
				settingsPanel.name = "SettingsCanvas";
				settingsPanel.Type = UIPanelType.Settings;
			}

			if (gamePlayPanel != null)
			{
				gamePlayPanel.name = "GamePlayCanvas";
				gamePlayPanel.Type = UIPanelType.Gameplay;
			}

			if (levelCompletePanel != null)
			{
				levelCompletePanel.name = "LevelCompleteCanvas";
				levelCompletePanel.Type = UIPanelType.LevelComplete;
			}

			if (levelFailPanel != null)
			{
				levelFailPanel.name = "LevelFailCanvas";
				levelFailPanel.Type = UIPanelType.LevelFail;
			}

			if (revivePanel != null)
			{
				revivePanel.name = "ReviveCanvas";
				revivePanel.Type = UIPanelType.Revive;
			}

			if (rewardPanel != null)
			{
				rewardPanel.name = "RewardCanvas";
				rewardPanel.Type = UIPanelType.Reward;
			}

			if (pausePanel != null)
			{
				pausePanel.name = "PauseCanvas";
				pausePanel.Type = UIPanelType.Pause;
			}

			m_uiPanels = GetComponentsInChildren<UIPanel>(true);

			#endregion

			#region ButtonValidation

			if (m_consentAgreedButton)
			{
				m_consentAgreedButton.name = "Consent_Agreed_Btn";
			}

			if (m_consentPrivacyPolicyButton)
			{
				m_consentPrivacyPolicyButton.name = "Consent_PrivacyPolicy_Btn";
			}

			if (m_mainMenuPlayButton)
			{
				m_mainMenuPlayButton.name = "MainMenu_Play_Btn";
			}

			if (m_mainMenuSettingsButton)
			{
				m_mainMenuSettingsButton.name = "MainMenu_Settings_Btn";
			}

			if (m_settingsBackButton)
			{
				m_settingsBackButton.name = "Settings_Back_Btn";
			}

			if (m_tutorialDoneButton)
			{
				m_tutorialDoneButton.name = "Tutorial_Done_Btn";
			}

			if (m_gameplayPauseButton)
			{
				m_gameplayPauseButton.name = "Gameplay_Pause_Btn";
			}

			if (m_pauseResumeButton)
			{
				m_pauseResumeButton.name = "Pause_Resume_Btn";
			}

			if (m_pauseRestartButton)
			{
				m_pauseRestartButton.name = "Pause_Restart_Btn";
			}

			if (m_pauseMainMenuButton)
			{
				m_pauseMainMenuButton.name = "Pause_MainMenu_Btn";
			}

			if (m_reviveContinueButton)
			{
				m_reviveContinueButton.name = "Revive_Continue_Btn";
			}

			if (m_winContinueButton)
			{
				m_winContinueButton.name = "Win_Continue_Btn";
			}


			if (m_failContinueButton)
			{
				m_failContinueButton.name = "Fail_Continue_Btn";
			}

			if (m_rewardCollectButton)
			{
				m_rewardCollectButton.name = "Reward_Collect_Btn";
			}

			#endregion
		}

		protected override void Awake()
		{
			base.Awake();
			m_uiPanels = GetComponentsInChildren<UIPanel>(true);
		}

		[Button(ButtonSizes.Medium)]
		public void ShowPanel(UIPanelType type)
		{
			Debug.Log($"Showing Panel: {type.ToString()}");
			HidePanel(m_currentPanelType);
			m_currentPanelType = type;
			var gamePanel = m_uiPanels.First(panel => panel.Type == type);
			gamePanel.gameObject.SetActive(true);
			gamePanel.ShowPanel();
		}

		private void HidePanel(UIPanelType type)
		{
			m_previousPanelType = type;
			var gamePanel = m_uiPanels.First(panel => panel.Type == type);
			gamePanel.HidePanel();
			gamePanel.OnBackwardsComplete += DisablePanel;
		}

		private void DisablePanel()
		{
			var gamePanel = m_uiPanels.First(panel => panel.Type == m_previousPanelType);
			gamePanel.gameObject.SetActive(false);
		}
	}

	[Title("Panel Type")]
	public enum UIPanelType
	{
		Splash,
		Consent,
		Tutorial,
		MainMenu,
		Settings,
		Gameplay,
		LevelComplete,
		LevelFail,
		Revive,
		Reward,
		Pause
	}
}