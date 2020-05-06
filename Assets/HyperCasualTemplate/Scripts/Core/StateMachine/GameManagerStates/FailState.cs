using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class FailState:BaseMenuState
	{
		private readonly Button m_continueButton;

		public FailState(GameManager gameManager, UIPanel panel, Button continueButton):base(gameManager, panel)
		{
			m_continueButton = continueButton;
		}
	}
}