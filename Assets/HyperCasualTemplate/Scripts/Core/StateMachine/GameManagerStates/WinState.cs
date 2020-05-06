using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class WinState:BaseMenuState
	{
		private readonly Button m_continueButton;

		public WinState(GameManager gameManager, UIPanel panel, Button button):base(gameManager, panel)
		{
			m_continueButton = button;
		}
	}
}