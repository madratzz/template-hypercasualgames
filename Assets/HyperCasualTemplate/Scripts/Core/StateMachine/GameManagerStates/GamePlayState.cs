using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using Sirenix.OdinInspector.Editor.Drawers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class GamePlayState:IState
	{
		private readonly GameManager m_gameManager;
		private readonly UIPanel m_panel;

		private readonly Button m_pauseButton;


		public bool HasPressedPause { get; private set; }
		public bool HasWon { get; private set; }
		public bool HasLost { get; private set; }

		public GamePlayState(GameManager gameManager, UIPanel panel)
		{
			m_gameManager = gameManager;
			m_panel = panel;
		}

		public GamePlayState(GameManager gameManager, UIPanel panel, Button pauseButton)
		{
			m_gameManager = gameManager;
			m_panel = panel;
			m_pauseButton = pauseButton;
		}
		public void Update()
		{

		}

		public void OnEnter()
		{
			UIController.Instance.ShowPanel(m_panel.Type);

			m_gameManager.StartGame();

			//Bind Buttons
			m_pauseButton.onClick.AddListener(OnPauseButton);
		}

		public void OnExit()
		{
			//UnBindButtons
			m_pauseButton.onClick.RemoveListener(OnPauseButton);

			//Reset State
			HasPressedPause = false;
			HasLost = false;
			HasWon = false;
		}

		private void OnPauseButton()
		{
			m_panel.OnBackwardsComplete += () => HasPressedPause = true;
			HidePanel();
		}

		private void HidePanel()
		{
			m_panel.OnBackwardsComplete += () => m_panel.gameObject.SetActive(false);
			m_panel.HidePanel();
		}
	}
}