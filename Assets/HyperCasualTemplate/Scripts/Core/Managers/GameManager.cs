using System;
using CustomUtilities;
using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.StateMachine;
using HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates;
using UnityEngine;

namespace HyperCasualTemplate.Scripts.Core.Managers
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
			var consent = new ConsentState(this,UIController.Instance.ConsentAgreedButton);
			var mainMenu = new MainMenuState(this,UIController.Instance.MainMenuPlayButton,UIController.Instance.MainMenuSettingsButton,UIController.Instance.MainMenuRemoveAdsButton);
			var settings = new SettingsState(this,UIController.Instance.SettingsBackButton);
			var gameplay = new GamePlayState(this,UIController.Instance.GameplayPauseButton);
			var pause = new PauseState(this,UIController.Instance.PauseResumeButton);

			//Adding Transitions
			At(splash,consent, CanShowConsent());
			At(splash,mainMenu,CanShowMainMenu());
			At(mainMenu,settings,CanShowSettings());
			At(gameplay, pause, CanPauseGame());
			At(pause,gameplay,CanResumeGame());
			At(pause, gameplay, CanRestartGame());
			At(pause,mainMenu,PauseToMainMenu());
			At(mainMenu, gameplay, CanPlayGame());
			At(consent, mainMenu, CanShowMainMenu());


			m_gameStateMachine.SetState(splash);

			void At(IState from, IState to, Func<bool> condition) =>
				m_gameStateMachine.AddTransition(from, to, condition);

			//Adding Conditions for Transitions
			// Func<bool> HasSplashEnded() => ()=>splash.HasSplashEnded;
			// Func<bool>UserConsentGiven()=>()=> PlayerPrefs.GetInt(GameConstants.UserConsent,0) == 1;
			Func<bool> CanShowConsent()=> ()=>splash.HasSplashEnded && PlayerPrefs.GetInt(GameConstants.UserConsent,0)!=1;
			Func<bool> CanShowMainMenu() => () =>
				splash.HasSplashEnded && PlayerPrefs.GetInt(GameConstants.UserConsent, 0) == 1;

			Func<bool> CanShowSettings() => () => mainMenu.HasPressedSettings;
			Func<bool> CanPlayGame() => () => mainMenu.HasPressedPlay;
			Func<bool> CanPauseGame() => () => gameplay.HasPressedPause;
			Func<bool> CanResumeGame() => () => pause.HasPressedResume;
			Func<bool> CanRestartGame() => () => pause.HasPressedRestart;
			Func<bool> PauseToMainMenu() => () => pause.HasPressedMaineMenu;
		}

		private void Update() => m_gameStateMachine.Update();

		public void StartGame()
		{
			Debug.Log($"Starting Game");
		}
	}

}