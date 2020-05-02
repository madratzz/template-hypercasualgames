using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class GamePlayState:IState
	{
		private readonly GameManager m_gameManager;
		private readonly Button m_pauseButton;


		public bool HasPressedPause { get; private set; }

		public GamePlayState(GameManager gameManager)
		{
			m_gameManager = gameManager;
		}

		public GamePlayState(GameManager gameManager, Button pauseButton)
		{
			m_gameManager = gameManager;
			m_pauseButton = pauseButton;
		}
		public void Update()
		{

		}

		public void OnEnter()
		{
			m_gameManager.StartGame();

			//Bind Buttons
			m_pauseButton.onClick.AddListener(OnPauseButton);
		}

		public void OnExit()
		{
			//UnBindButtons
			m_pauseButton.onClick.RemoveListener(OnPauseButton);
		}

		private void OnPauseButton()
		{
			HasPressedPause = true;
		}
	}
}