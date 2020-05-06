using System;
using System.Linq;
using CustomUtilities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.Controllers
{
	[RequireComponent(typeof(Button))]
	public class UIController : Singleton<UIController>
	{
		#region Panels

		private UIPanelType m_currentPanelType, m_previousPanelType;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel consentPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel tutorialPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel gamePlayPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel levelCompletePanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel levelFailPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel mainMenuPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel revivePanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel rewardPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel settingsPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel splashPanel;

		[BoxGroup("UIPanels", centerLabel: true)] [SerializeField][Required]
		private UiPanel pausePanel;

		public UiPanel ConsentPanel => consentPanel;
		public UiPanel TutorialPanel => tutorialPanel;
		public UiPanel GamePlayPanel => gamePlayPanel;
		public UiPanel LevelCompletePanel => levelCompletePanel;
		public UiPanel LevelFailPanel => levelFailPanel;
		public UiPanel MainMenuPanel => mainMenuPanel;
		public UiPanel RevivePanel => revivePanel;
		public UiPanel RewardPanel => rewardPanel;
		public UiPanel SettingsPanel => settingsPanel;
		public UiPanel PausePanel => pausePanel;
		public UiPanel SplashPanel => splashPanel;

		#endregion


		#region Buttons

		[BoxGroup("ConsentMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button consentAgreedButton;

		[BoxGroup("ConsentMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button consentPrivacyPolicyButton;

		[BoxGroup("MainMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button mainMenuPlayButton;

		[BoxGroup("MainMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button mainMenuSettingsButton;

		[BoxGroup("MainMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button mainMenuRemoveAdsButton;

		[BoxGroup("SettingsMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button settingsBackButton;

		[BoxGroup("TutorialMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button tutorialDoneButton;

		[BoxGroup("GameplayMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button gameplayPauseButton;

		[BoxGroup("PauseMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button pauseResumeButton;

		[BoxGroup("PauseMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button pauseRestartButton;

		[BoxGroup("PauseMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button pauseMainMenuButton;

		[BoxGroup("WinMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button winContinueButton;

		[BoxGroup("FailMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button failContinueButton;

		[BoxGroup("ReviveMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button reviveContinueButton;

		[BoxGroup("RewardMenuButtons", centerLabel: true)] [SerializeField][Required]
		private Button rewardCollectButton;

		public Button ConsentAgreedButton => consentAgreedButton;
		public Button ConsentPrivacyPolicyButton => consentPrivacyPolicyButton;
		public Button MainMenuPlayButton => mainMenuPlayButton;
		public Button MainMenuSettingsButton => mainMenuSettingsButton;
		public Button MainMenuRemoveAdsButton => mainMenuRemoveAdsButton;
		public Button SettingsBackButton => settingsBackButton;

		public Button GameplayPauseButton => gameplayPauseButton;

		public Button PauseResumeButton => pauseResumeButton;

		public Button PauseRestartButton => pauseRestartButton;

		public Button PauseMainMenuButton => pauseMainMenuButton;

		public Button WinContinueButton => winContinueButton;

		public Button FailContinueButton => failContinueButton;

		public Button ReviveContinueButton => reviveContinueButton;

		public Button RewardCollectButton => rewardCollectButton;

		public Button TutorialDoneButton => tutorialDoneButton;

		#endregion

		[BoxGroup("Utilities")]
		[ShowInInspector] private UiPanel[] m_uiPanels;
		[BoxGroup("Utilities")]
		[ShowInInspector] private Button[] m_buttons;

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

			m_uiPanels = GetComponentsInChildren<UiPanel>(true);

			#endregion

			#region ButtonValidation

			if (consentAgreedButton)
			{
				consentAgreedButton.name = "Consent_Agreed_Btn";
			}

			if (consentPrivacyPolicyButton)
			{
				consentPrivacyPolicyButton.name = "Consent_PrivacyPolicy_Btn";
			}

			if (mainMenuPlayButton)
			{
				mainMenuPlayButton.name = "MainMenu_Play_Btn";
			}

			if (mainMenuSettingsButton)
			{
				mainMenuSettingsButton.name = "MainMenu_Settings_Btn";
			}

			if (settingsBackButton)
			{
				settingsBackButton.name = "Settings_Back_Btn";
			}

			if (tutorialDoneButton)
			{
				tutorialDoneButton.name = "Tutorial_Done_Btn";
			}

			if (gameplayPauseButton)
			{
				gameplayPauseButton.name = "Gameplay_Pause_Btn";
			}

			if (pauseResumeButton)
			{
				pauseResumeButton.name = "Pause_Resume_Btn";
			}

			if (pauseRestartButton)
			{
				pauseRestartButton.name = "Pause_Restart_Btn";
			}

			if (pauseMainMenuButton)
			{
				pauseMainMenuButton.name = "Pause_MainMenu_Btn";
			}

			if (reviveContinueButton)
			{
				reviveContinueButton.name = "Revive_Continue_Btn";
			}

			if (winContinueButton)
			{
				winContinueButton.name = "Win_Continue_Btn";
			}


			if (failContinueButton)
			{
				failContinueButton.name = "Fail_Continue_Btn";
			}

			if (rewardCollectButton)
			{
				rewardCollectButton.name = "Reward_Collect_Btn";
			}

			m_buttons = GetComponentsInChildren<Button>(true);

			#endregion
		}

		protected override void Awake()
		{
			base.Awake();
			m_uiPanels = GetComponentsInChildren<UiPanel>(true);
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
			gamePanel.backwardsComplete += DisablePanel;
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