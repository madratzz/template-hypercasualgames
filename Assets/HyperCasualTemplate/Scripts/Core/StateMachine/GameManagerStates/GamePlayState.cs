using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Controllers.UIControllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class GamePlayState : BaseMenuState
	{
		private readonly Button m_pauseButton;


		public bool HasPressedPause { get; private set; }
		public bool HasWon { get; private set; }
		public bool HasLost { get; private set; }

		public bool HasGameCompleted { get; private set; }

		public GamePlayState(GameManager gameManager, UIPanel panel) : base(gameManager, panel)
		{
		}

		public GamePlayState(GameManager gameManager, UIPanel panel, Button pauseButton) : base(gameManager, panel)
		{
			m_pauseButton = pauseButton;
		}

		public override void OnEnter()
		{
			base.OnEnter();
			HasWon = false;
			HasGameCompleted = false;


			//Camera Setting
			CameraController.Instance.ShowCamera(CameraType.Gameplay);

			InputController.Instance.EnableInput();

			GameManager.StartGame();


			//Bind Buttons
			m_pauseButton.onClick.AddListener(OnPauseButton);
		}

		public override void Update()
		{
			base.Update();

			//HasGameCompleted = true;
			//HasWon = true;
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
			HasGameCompleted = false;
		}

		private void OnPauseButton()
		{
			Panel.backwardsComplete += () => HasPressedPause = true;
			HidePanel();
		}

		protected override void HidePanel()
		{
			Panel.backwardsComplete += () => Panel.gameObject.SetActive(false);
			Panel.HidePanel();
		}
	}
}