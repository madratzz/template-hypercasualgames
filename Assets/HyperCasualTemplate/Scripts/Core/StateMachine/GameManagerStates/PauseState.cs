using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class PauseState:BaseMenuState
	{
		private readonly Button m_resumeButton;
		private readonly Button m_restartButton;
		private readonly Button m_mainMenuButton;

		public bool HasPressedResume { get; private set; }
		public bool HasPressedRestart { get; private set; }
		public bool HasPressedMainMenu { get; private set; }
		public PauseState(GameManager gameManager,UIPanel panel, Button resumeButton):base(gameManager, panel)
		{
			m_resumeButton = resumeButton;
		}

		public PauseState(GameManager gameManager, UIPanel panel, Button resumeButton, Button restartButton):base(gameManager, panel)
		{
			m_resumeButton = resumeButton;
			m_restartButton = restartButton;
		}

		public PauseState(GameManager gameManager,UIPanel panel, Button resumeButton, Button restartButton, Button mainMenuButton):base(gameManager, panel)
		{
			m_resumeButton = resumeButton;
			m_restartButton = restartButton;
			m_mainMenuButton = mainMenuButton;
		}


		public override void OnEnter()
		{
			base.OnEnter();

			Time.timeScale = 0;
			//Bind Buttons
			m_resumeButton.onClick.AddListener(OnResumeButton);

			if (m_restartButton)
			{
				m_restartButton.onClick.AddListener(OnRestartButton);
			}

			if (m_mainMenuButton)
			{
				m_mainMenuButton.onClick.AddListener(OnMainMenuButton);
			}
		}

		public override void OnExit()
		{
			base.OnExit();
			
			Time.timeScale = 1;
			//UnBind Buttons
			m_resumeButton.onClick.RemoveListener(OnResumeButton);

			if (m_restartButton)
			{
				m_restartButton.onClick.RemoveListener(OnRestartButton);
			}

			if (m_mainMenuButton)
			{
				m_mainMenuButton.onClick.RemoveListener(OnMainMenuButton);
			}

			//ResetState
			HasPressedRestart = false;
			HasPressedResume = false;
			HasPressedMainMenu = false;
		}

		private void OnResumeButton()
		{
			HasPressedResume = true;
			HidePanel();
		}

		private void OnRestartButton()
		{
			HasPressedRestart = true;
			HidePanel();
		}

		private void OnMainMenuButton()
		{
			HasPressedMainMenu = true;
			Debug.Log(HasPressedMainMenu);
			HidePanel();
		}
	}
}