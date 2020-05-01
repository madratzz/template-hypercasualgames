using System;
using TemplateCode.Scripts.Core.Controllers;
using CustomUtilities;
using Sirenix.OdinInspector;
using TemplateCode.Scripts.Core.StateMachine;
using TemplateCode.Scripts.Core.StateMachine.GameManagerStates;
using UnityEngine;

namespace TemplateCode.Scripts.Core.Managers
{
	public class GameManager : Singleton<GameManager>
	{
		private GameStateMachine m_gameStateMachine;

		// Start is called before the first frame update
		private void Start()
		{
			m_gameStateMachine = new GameStateMachine();

			//States
			var splash = new SplashState(this);
			var consent = new ConsentState(this);
			var mainMenu = new MainMenuState(this);

			//Adding Transitions
			At(splash,consent, CanShowConsent());
			At(splash,mainMenu,CanShowMainMenu());

			m_gameStateMachine.SetState(splash);

			void At(IState from, IState to, Func<bool> condition) =>
				m_gameStateMachine.AddTransition(from, to, condition);

			//Adding Conditions for Transitions
			Func<bool> HasSplashEnded() => ()=>splash.HasSplashEnded;
			Func<bool>UserConsentGiven()=>()=> PlayerPrefs.GetInt(GameConstants.UserConsent,0) == 1;
			Func<bool> CanShowConsent()=> ()=>splash.HasSplashEnded && PlayerPrefs.GetInt(GameConstants.UserConsent,0)!=1;
			Func<bool> CanShowMainMenu() => () =>
				splash.HasSplashEnded && PlayerPrefs.GetInt(GameConstants.UserConsent, 0) == 1;
		}

		private void Update() => m_gameStateMachine.Tick();
	}

}