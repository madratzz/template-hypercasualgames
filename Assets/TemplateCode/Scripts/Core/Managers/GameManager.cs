using System;
using TemplateCode.Scripts.Core.Controllers;
using CustomUtilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TemplateCode.Scripts.Core.Managers
{
	public class GameManager : Singleton<GameManager>
	{
		public static Action<GameState> OnStateChanged;

		[BoxGroup("Game State Info")] [EnumToggleButtons] [SerializeField]
		private GameState currentState;

		public GameState CurrentState => currentState;


		private void OnEnable()
		{
			OnStateChanged += OnGameStateChanged;
		}

		private void OnDisable()
		{
			OnStateChanged -= OnGameStateChanged;
		}

		// Start is called before the first frame update
		private void Start()
		{
			ChangeGameState(GameState.SPLASH);
		}

		public void ChangeGameState(GameState gameState)
		{
			currentState = gameState;
			OnStateChanged?.Invoke(gameState);
		}


		//CallBacks
		public void OnGameStateChanged(GameState gameState)
		{
			switch (gameState)
			{
				case GameState.SPLASH:
					UIController.instance.ShowPanel(UIPanelType.Splash);
					break;
				case GameState.CONSENT:
					break;
				case GameState.MAINMENU:
					break;
				case GameState.TUTORIAL:
					break;
				case GameState.GAMEPLAY:
					break;
				case GameState.REWARD:
					break;
				case GameState.BONUSLEVEL:
					break;
				case GameState.LEVELCOMPLETE:
					break;
				case GameState.LEVELFAILED:
					break;
				case GameState.REVIEVE:
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
			}
		}
	}


	public enum GameState
	{
		SPLASH,
		CONSENT,
		MAINMENU,
		TUTORIAL,
		GAMEPLAY,
		REWARD,
		BONUSLEVEL,
		LEVELCOMPLETE,
		LEVELFAILED,
		REVIEVE
	}
}