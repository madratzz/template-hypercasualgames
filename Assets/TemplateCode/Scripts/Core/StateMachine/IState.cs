namespace TemplateCode.Scripts.Core.StateMachine
{
	public interface IState
	{
		void Tick();

		void OnEnter();

		void OnExit();
	}
}