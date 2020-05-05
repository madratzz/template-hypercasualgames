using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class FailState:IState
	{
		private readonly GameManager m_gameManager;
		private readonly UIPanel m_panel;

		private readonly Button m_continueButton;

		public FailState(GameManager gameManager, UIPanel panel, Button continueButton)
		{
			m_gameManager = gameManager;
			m_panel = panel;
			m_continueButton = continueButton;
		}

		public void Update()
		{
		}

		public void OnEnter()
		{
			UIController.Instance.ShowPanel(m_panel.Type);

		}

		public void OnExit()
		{
		}
	}
}