using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class WinState:IState
	{
		private readonly GameManager m_gameManager;
		private readonly UIPanel m_panel;

		private readonly Button m_continueButton;

		public WinState(GameManager gameManager, UIPanel panel, Button button)
		{
			m_gameManager = gameManager;
			m_panel = panel;
			m_continueButton = button;
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

		private void HidePanel()
		{
			m_panel.OnBackwardsComplete += () => m_panel.gameObject.SetActive(false);
			m_panel.HidePanel();
		}
	}
}