namespace TemplateCode.Scripts.Core.StateMachine
{
	public interface IState
	{
		void Update();

		void OnEnter();

		void OnExit();
	}
}