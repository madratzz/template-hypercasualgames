using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Controllers.UIControllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class ConsentState:BaseMenuState
	{
		private readonly Button m_consentAgreeButton;
		private readonly Button m_privacyPolicyButton;

		public ConsentState(GameManager gameManager,UIPanel panel, Button consentAgreeButton, Button privacyPolicyButton):base(gameManager, panel)
		{
			m_consentAgreeButton = consentAgreeButton;
			m_privacyPolicyButton = privacyPolicyButton;
		}


		public override void OnEnter()
		{
			base.OnEnter();

			//Bind Buttons
			m_consentAgreeButton.onClick.AddListener(OnConsentAgree);
			m_privacyPolicyButton.onClick.AddListener(OnPrivacyPolicyButton);
		}

		public override void OnExit()
		{
			base.OnExit();

			PlayerPrefs.Save();
			//UnBindButtons
			m_consentAgreeButton.onClick.RemoveListener(OnConsentAgree);
			m_privacyPolicyButton.onClick.RemoveListener(OnPrivacyPolicyButton);
		}

		private void OnConsentAgree()
		{
			Panel.backwardsComplete+=()=>PlayerPrefs.SetInt(GameConstants.UserConsentAgreed, 1);
			HidePanel();
		}

		private static void OnPrivacyPolicyButton()
		{
			Application.OpenURL(GameConstants.PrivacyPolicyLink);
		}


		private void HidePanel()
		{
			Panel.backwardsComplete += () => Panel.gameObject.SetActive(false);
			Panel.HidePanel();
		}
	}
}