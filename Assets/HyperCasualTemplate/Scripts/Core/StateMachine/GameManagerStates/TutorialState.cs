using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class TutorialState:IState
	{
		private readonly GameManager m_gameManager;
		private readonly UIPanel m_panel;
		private readonly Button m_tutorialDoneButton;

		public bool HasTutorialFinished { get; private set; }

		public TutorialState(GameManager gameManager, UIPanel panel, Button tutorialDoneButton)
		{
			m_gameManager = gameManager;
			m_panel = panel;
			m_tutorialDoneButton = tutorialDoneButton;
		}

		public void Update()
		{
		}

		public void OnEnter()
		{
			UIController.Instance.ShowPanel(m_panel.Type);

			//BindButtons
			m_tutorialDoneButton.onClick.AddListener(OnTutorialDone);

		}

		public void OnExit()
		{
			PlayerPrefs.Save();
			m_tutorialDoneButton.onClick.RemoveListener(OnTutorialDone);
		}

		private void OnTutorialDone()
		{
			HasTutorialFinished = true;
			PlayerPrefs.SetInt(GameConstants.TutorialCompleted,1);
		}

		private void HidePanel()
		{
			m_panel.OnBackwardsComplete += () => m_panel.gameObject.SetActive(false);
			m_panel.HidePanel();
		}
	}
}