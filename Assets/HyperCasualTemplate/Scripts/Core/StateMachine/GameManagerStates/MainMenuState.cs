using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Controllers.UIControllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UI;
using CameraType = HyperCasualTemplate.Scripts.Core.Controllers.CameraType;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class MainMenuState : BaseMenuState
	{
		private readonly Button m_playButton;
		private readonly Button m_RemoveAdsButton;
		private readonly Button m_settingsButton;

		public MainMenuState(GameManager gameManager,UIPanel panel, Button playButton, Button settingsButton, Button removeAdsButton) : base(gameManager,panel)
		{
			m_playButton = playButton;
			m_settingsButton = settingsButton;
			m_RemoveAdsButton = removeAdsButton;
		}

		public bool HasPressedSettings { get; private set; }

		public bool HasPressedPlay { get; private set; }


		public override void OnEnter()
		{
			base.OnEnter();

			//Reset State
			HasPressedPlay = false;
			HasPressedSettings = false;


			//Camera Setting
			CameraController.Instance.ShowCamera(CameraType.MainMenu);

			//Bind Buttons
			m_playButton.onClick.AddListener(OnPlayButton);
			m_settingsButton.onClick.AddListener(OnSettingsButton);
			m_RemoveAdsButton.onClick.AddListener(OnRemoveAdsButton);

			//BindClickSound();

			if (m_playButton==null)
			{
				Debug.Log("PlayBtnNull");
			}

			if (SoundController.Instance==null)
			{
				Debug.Log("SoundControllerNull");
			}


		}

		public override void OnExit()
		{
			base.OnExit();

			//UnBind Buttons
			m_playButton.onClick.RemoveListener(OnPlayButton);
			m_settingsButton.onClick.RemoveListener(OnSettingsButton);
			m_RemoveAdsButton.onClick.RemoveListener(OnRemoveAdsButton);

			//UnBindClickSound();

			//Reset State
			HasPressedPlay = false;
			HasPressedSettings = false;

		}

		private void OnPlayButton()
		{
			//Camera Setting
			CameraController.Instance.ShowCamera(CameraType.Gameplay);

			m_playButton.interactable = false;
			Panel.backwardsComplete += () => HasPressedPlay = true;
			HidePanel();
		}

		private void OnSettingsButton()
		{
			m_settingsButton.interactable = false;
			Panel.backwardsComplete += () => HasPressedSettings = true;
			HidePanel();
		}

		private void OnRemoveAdsButton()
		{
			//Make a call to InAPP Manager
		}
	}
}