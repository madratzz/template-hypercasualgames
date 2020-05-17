using System;
using CustomUtilities;
using HyperCasualTemplate.Scripts.Core.Controllers.UIControllers;
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

			var splash = new SplashState(this, UIController.Instance.SplashPanel);

			var consent = new ConsentState(this, UIController.Instance.ConsentPanel,
				UIController.Instance.ConsentAgreedButton, UIController.Instance.ConsentPrivacyPolicyButton);

			var mainMenu = new MainMenuState(this, UIController.Instance.MainMenuPanel,
				UIController.Instance.MainMenuPlayButton,
				UIController.Instance.MainMenuSettingsButton,
				UIController.Instance.MainMenuRemoveAdsButton);

			var settings = new SettingsState(this, UIController.Instance.SettingsPanel,
				UIController.Instance.SettingsBackButton);

			var tutorial = new TutorialState(this, UIController.Instance.TutorialPanel,
				UIController.Instance.TutorialDoneButton);

			var gameplay = new GamePlayState(this, UIController.Instance.GamePlayPanel,
				UIController.Instance.GameplayPauseButton);

			var pause = new PauseState(this, UIController.Instance.PausePanel,
				UIController.Instance.PauseResumeButton);

			var win = new WinState(this, UIController.Instance.LevelCompletePanel,
				UIController.Instance.WinContinueButton);

			var fail = new FailState(this, UIController.Instance.LevelFailPanel,
				UIController.Instance.FailContinueButton);

			var revive = new ReviveState(this, UIController.Instance.RevivePanel,
				UIController.Instance.ReviveContinueButton);

			var reward = new RewardState(this, UIController.Instance.RewardPanel,
				UIController.Instance.RewardCollectButton);

			//Adding Transitions
			At(splash, consent, CanShowConsent());
			At(splash, mainMenu, CanShowMainMenu());

			At(consent, mainMenu, CanShowMainMenu());

			At(mainMenu, tutorial, CanPlayTutorial());
			At(mainMenu, gameplay, CanPlayGame());
			At(mainMenu, settings, CanShowSettings());

			At(tutorial, gameplay, () => tutorial.HasTutorialFinished);

			At(gameplay, pause, CanPauseGame());

			At(pause, gameplay, CanResumeGame());
			At(pause, gameplay, CanRestartGame());
			At(pause, mainMenu, PauseToMainMenu());

			At(gameplay, win, GameToWin());
			At(gameplay, fail, GameToFail());

			At(win, mainMenu, WinToMainMenu());


			m_gameStateMachine.SetState(splash);

			void At(IState from, IState to, Func<bool> condition) =>
				m_gameStateMachine.AddTransition(from, to, condition);

			//Adding Conditions for Transitions
			// Func<bool> HasSplashEnded() => ()=>splash.HasSplashEnded;
			// Func<bool>UserConsentGiven()=>()=> PlayerPrefs.GetInt(GameConstants.UserConsent,0) == 1;
			Func<bool> CanShowConsent() => () =>
				splash.HasSplashEnded && PlayerPrefs.GetInt(GameConstants.UserConsentAgreed, 0) != 1;

			Func<bool> CanShowMainMenu() => () =>
				splash.HasSplashEnded && PlayerPrefs.GetInt(GameConstants.UserConsentAgreed, 0) == 1;

			Func<bool> CanShowSettings() => () => mainMenu.HasPressedSettings;

			Func<bool> CanPlayGame() => () =>
				mainMenu.HasPressedPlay && PlayerPrefs.GetInt(GameConstants.TutorialCompleted, 0) == 1;

			Func<bool> CanPlayTutorial() => () =>
				mainMenu.HasPressedPlay && PlayerPrefs.GetInt(GameConstants.TutorialCompleted, 0) == 0;

			Func<bool> CanPauseGame() => () => gameplay.HasPressedPause;
			Func<bool> CanResumeGame() => () => pause.HasPressedResume;
			Func<bool> CanRestartGame() => () => pause.HasPressedRestart;
			Func<bool> PauseToMainMenu() => () => pause.HasPressedMainMenu;
			Func<bool> GameToWin() => () => gameplay.HasWon;
			Func<bool> GameToFail() => () => gameplay.HasLost;
			Func<bool> WinToMainMenu() => () => win.HasPressedContinue;
		}

		private void Update() => m_gameStateMachine.Update();

		public void StartGame()
		{
			Debug.Log($"Starting Game");
		}
		public void StartTutorial()
		{
			Debug.Log($"Starting Tutorial");
		}

		public void LevelCompleted()
		{
			Debug.Log($"Level Completed");
		}
	}
}