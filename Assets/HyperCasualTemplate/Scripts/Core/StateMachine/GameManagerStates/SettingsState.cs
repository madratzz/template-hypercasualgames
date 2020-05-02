using DG.Tweening.Core.Enums;
using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class SettingsState:IState
	{

		private readonly GameManager m_gameManager;
		private readonly Button m_backButton;

		public SettingsState(GameManager gameManager, Button backButton)
		{
			m_gameManager = gameManager;
			m_backButton = backButton;
		}

		public void Update()
		{

		}

		public void OnEnter()
		{
			UIController.Instance.ShowPanel(UIPanelType.Settings);
		}

		public void OnExit()
		{

		}
	}
}