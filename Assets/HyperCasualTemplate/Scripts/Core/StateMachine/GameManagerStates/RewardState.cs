using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class RewardState:BaseMenuState
	{
		private readonly Button m_collectButton;

		public RewardState(GameManager gameManager, UiPanel panel, Button collectButton):base(gameManager, panel)
		{
			m_collectButton = collectButton;
		}

	}
}