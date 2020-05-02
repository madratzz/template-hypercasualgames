using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class PauseState:IState
	{
		private readonly GameManager m_gameManager;
		private readonly Button m_resumeButton;
		private readonly Button m_restartButton;
		private readonly Button m_mainMenuButton;

		public bool HasPressedResume { get; private set; }
		public bool HasPressedRestart { get; private set; }
		public bool HasPressedMaineMenu { get; private set; }
		public PauseState(GameManager gameManager, Button resumeButton)
		{
			m_gameManager = gameManager;
			m_resumeButton = resumeButton;
		}

		public PauseState(GameManager gameManager, Button resumeButton, Button restartButton)
		{
			m_gameManager = gameManager;
			m_resumeButton = resumeButton;
			m_restartButton = restartButton;
		}

		public PauseState(GameManager gameManager, Button resumeButton, Button restartButton, Button mainMenuButton)
		{
			m_gameManager = gameManager;
			m_resumeButton = resumeButton;
			m_restartButton = restartButton;
			m_mainMenuButton = mainMenuButton;
		}

		public void Update()
		{

		}

		public void OnEnter()
		{
			Time.timeScale = 0;
			//Bind Buttons
			m_resumeButton.onClick.AddListener(OnResumeButton);
			m_restartButton.onClick.AddListener(OnRestartButton);
			m_mainMenuButton.onClick.AddListener(OnMainMenuButton);
		}

		public void OnExit()
		{
			Time.timeScale = 1;
			//UnBind Buttons
			m_resumeButton.onClick.RemoveListener(OnResumeButton);
			m_restartButton.onClick.RemoveListener(OnRestartButton);
			m_mainMenuButton.onClick.RemoveListener(OnMainMenuButton);
		}

		private void OnResumeButton()
		{
			HasPressedResume = true;
		}

		private void OnRestartButton()
		{
			HasPressedRestart = true;
		}

		private void OnMainMenuButton()
		{
			HasPressedMaineMenu = true;
		}
	}
}