using System;

namespace HyperCasualTemplate.Scripts.Core.StateMachine
{
	public interface IState
	{
		void Update();

		void OnEnter();

		void OnExit();
	}
}