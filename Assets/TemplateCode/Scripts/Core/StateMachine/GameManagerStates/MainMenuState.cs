using TemplateCode.Scripts.Core.Controllers;
using TemplateCode.Scripts.Core.Managers;

namespace TemplateCode.Scripts.Core.StateMachine.GameManagerStates
{
	internal class MainMenuState:IState
	{
		private readonly GameManager m_gameManager;

		public MainMenuState(GameManager gameManager)
		{
			m_gameManager = gameManager;
		}
		public void Update()
		{

		}

		public void OnEnter() => UIController.Instance.ShowPanel(UIPanelType.MainMenu);

		public void OnExit()
		{

		}
	}
}