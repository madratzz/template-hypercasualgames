using HyperCasualTemplate.Scripts.Core.Controllers.UIControllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class WinState:BaseMenuState
	{
		private readonly Button m_continueButton;
		public bool HasPressedContinue { get; private set; }

		public WinState(GameManager gameManager, UIPanel panel, Button button):base(gameManager, panel)
		{
			m_continueButton = button;
		}

		public override void OnEnter()
		{
			base.OnEnter();
			HasPressedContinue = false;
			GameManager.LevelCompleted();

			//Bind Buttons
			m_continueButton.onClick.AddListener(LevelContinueButton);
		}

		public override void OnExit()
		{
			base.OnExit();
			//UnBind Buttons
			m_continueButton.onClick.RemoveListener(LevelContinueButton);
			HasPressedContinue = false;
		}

		public void LevelContinueButton()
		{

			//PlayerPrefs.SetInt("CurrentLevel",LevelManager.Instance.currentLevel+1);
			//PlayerPrefs.Save();
			//Debug.Log($"Pressing Level Complete Continue button: Setting Level#: {PlayerPrefs.GetInt("CurrentLevel")}");

			HasPressedContinue = true;

		}
	}
}