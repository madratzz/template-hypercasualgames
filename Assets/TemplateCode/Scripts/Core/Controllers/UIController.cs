using System.Linq;
using CustomUtilities;
using Sirenix.OdinInspector;

namespace TemplateCode.Scripts.Core.Controllers
{
	public class UIController : Singleton<UIController>
	{
		private UIPanelType m_currentPanelType, m_previousPanelType;
		[ShowInInspector] private UIPanel[] m_uiPanels;
		public UIPanel consentPanel;
		public UIPanel gamePlayPanel;
		public UIPanel levelCompletePanel;
		public UIPanel levelFailPanel;
		public UIPanel mainMenuPanel;
		public UIPanel revivePanel;
		public UIPanel rewardPanel;
		public UIPanel settingsPanel;
		public UIPanel splashPanel;

		[Button(ButtonSizes.Medium)]
		private void ValidatePanels()
		{
			if (splashPanel != null)
			{
				splashPanel.name = "SplashCanvas";
				splashPanel.type = UIPanelType.Splash;
			}

			if (consentPanel != null)
			{
				consentPanel.name = "ConsentCanvas";
				consentPanel.type = UIPanelType.Consent;
			}

			if (mainMenuPanel != null)
			{
				mainMenuPanel.name = "MainMenuCanvas";
				mainMenuPanel.type = UIPanelType.MainMenu;
			}

			if (settingsPanel != null)
			{
				settingsPanel.name = "SettingsCanvas";
				settingsPanel.type = UIPanelType.Settings;
			}

			if (gamePlayPanel != null)
			{
				gamePlayPanel.name = "GamePlayCanvas";
				gamePlayPanel.type = UIPanelType.Gameplay;
			}

			if (levelCompletePanel != null)
			{
				levelCompletePanel.name = "LevelCompleteCanvas";
				levelCompletePanel.type = UIPanelType.LevelComplete;
			}

			if (levelFailPanel != null)
			{
				levelFailPanel.name = "LevelFailCanvas";
				levelFailPanel.type = UIPanelType.LevelFail;
			}

			if (revivePanel != null)
			{
				revivePanel.name = "ReviveCanvas";
				revivePanel.type = UIPanelType.Revive;
			}

			if (rewardPanel != null)
			{
				rewardPanel.name = "RewardCanvas";
				rewardPanel.type = UIPanelType.Reward;
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
			HidePanel(m_currentPanelType);
			m_currentPanelType = type;
			var gamePanel = m_uiPanels.First(panel => panel.type == type);
			gamePanel.gameObject.SetActive(true);
			gamePanel.ShowPanel();
		}

		private void HidePanel(UIPanelType type)
		{
			m_previousPanelType = type;
			var gamePanel = m_uiPanels.First(panel => panel.type == type);
			gamePanel.HidePanel();
			gamePanel.OnBackwardsComplete += DisablePanel;
		}

		private void DisablePanel()
		{
			var gamePanel = m_uiPanels.First(panel => panel.type == m_previousPanelType);
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
		Reward
	}
}