using TemplateCode.Scripts.Core.Controllers;
using TemplateCode.Scripts.Core.Managers;

namespace TemplateCode.Scripts.Core.StateMachine
{
	internal class ConsentState:IState
	{
		private readonly GameManager m_gameManager;

		public ConsentState(GameManager gameManager)
		{
			m_gameManager = gameManager;
		}

		public void Update()
		{

		}

		public void OnEnter()=>UIController.Instance.ShowPanel(UIPanelType.Consent);

		public void OnExit()
		{

		}
	}
}