using TemplateCode.Scripts.Core.Controllers;

namespace TemplateCode.Scripts.Core.StateMachine
{
	internal class Splash:IState
	{
		private bool m_hasSplashEnded;
		public void Tick()
		{

		}

		public void OnEnter()
		{
			UIController.Instance.ShowPanel(UIPanelType.Splash);
		}

		public void OnExit()
		{
			UIController.Instance.ShowPanel(UIPanelType.Consent);
			UIController.Instance.ShowPanel(UIPanelType.MainMenu);
		}
	}
}