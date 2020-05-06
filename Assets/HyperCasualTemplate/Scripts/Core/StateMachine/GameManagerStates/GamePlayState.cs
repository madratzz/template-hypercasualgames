using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using Sirenix.OdinInspector.Editor.Drawers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class GamePlayState:BaseMenuState
	{
		private readonly Button m_pauseButton;


		public bool HasPressedPause { get; private set; }
		public bool HasWon { get; private set; }
		public bool HasLost { get; private set; }

		public GamePlayState(GameManager gameManager, UiPanel panel):base(gameManager, panel)
		{
		}

		public GamePlayState(GameManager gameManager, UiPanel panel, Button pauseButton):base(gameManager, panel)
		{
			m_pauseButton = pauseButton;
		}

		public override void OnEnter()
		{
			base.OnEnter();
			
			InputController.Instance.EnableInput();

			GameManager.StartGame();

			//Bind Buttons
			m_pauseButton.onClick.AddListener(OnPauseButton);
		}

		public override void OnExit()
		{
			base.OnExit();
			
			InputController.Instance.DisableInput();

			//UnBindButtons
			m_pauseButton.onClick.RemoveListener(OnPauseButton);

			//Reset State
			HasPressedPause = false;
			HasLost = false;
			HasWon = false;
		}

		private void OnPauseButton()
		{
			Panel.backwardsComplete += () => HasPressedPause = true;
			HidePanel();
		}

		private void HidePanel()
		{
			Panel.backwardsComplete += () => Panel.gameObject.SetActive(false);
			Panel.HidePanel();
		}
	}
}