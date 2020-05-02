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

		[Header("Panels")]
		[SerializeField] private UIPanel consentPanel;
		[SerializeField] private UIPanel gamePlayPanel;
		[SerializeField] private UIPanel levelCompletePanel;
		[SerializeField] private UIPanel levelFailPanel;
		[SerializeField] private UIPanel mainMenuPanel;
		[SerializeField] private UIPanel revivePanel;
		[SerializeField] private UIPanel rewardPanel;
		[SerializeField] private UIPanel settingsPanel;
		[SerializeField] private UIPanel splashPanel;
		[SerializeField] private UIPanel pausePanel;

		public UIPanel ConsentPanel => consentPanel;
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

		[Header("Buttons")]
		[SerializeField] private Button m_consentAgreedButton;
		[SerializeField] private Button m_consentPrivacyPolicyButton;
		[SerializeField] private Button m_mainMenuPlayButton;
		[SerializeField] private Button m_mainMenuSettingsButton;
		[SerializeField] private Button m_mainMenuRemoveAdsButton;
		[SerializeField] private Button m_settingsBackButton;
		[SerializeField] private Button m_gameplayPauseButton;
		[SerializeField] private Button m_pauseResumeButton;
		[SerializeField] private Button m_pauseRestartButton;
		[SerializeField] private Button m_pauseMainMenuButton;


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

		#endregion

		[ShowInInspector] private UIPanel[] m_uiPanels;

		[Button(ButtonSizes.Medium)]
		private void ValidatePanels()
		{
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

			if (pausePanel!=null)
			{
				pausePanel.name = "PauseCanvas";
				pausePanel.Type = UIPanelType.Pause;
			}

			m_uiPanels = GetComponentsInChildren<UIPanel>(true);
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