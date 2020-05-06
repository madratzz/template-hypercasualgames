using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class ConsentState:BaseMenuState
	{
		private readonly Button m_consentAgreeButton;

		public ConsentState(GameManager gameManager,UIPanel panel, Button consentAgreeButton):base(gameManager, panel)
		{
			m_consentAgreeButton = consentAgreeButton;
		}


		public override void OnEnter()
		{
			base.OnEnter();

			//Bind Buttons
			m_consentAgreeButton.onClick.AddListener(OnConsentAgree);
		}

		public override void OnExit()
		{
			base.OnExit();

			PlayerPrefs.Save();
			//UnBindButtons
			m_consentAgreeButton.onClick.RemoveListener(OnConsentAgree);
		}

		private void OnConsentAgree()
		{
			m_panel.OnBackwardsComplete+=()=>PlayerPrefs.SetInt(GameConstants.UserConsentAgreed, 1);
			HidePanel();
		}


		private void HidePanel()
		{
			m_panel.OnBackwardsComplete += () => m_panel.gameObject.SetActive(false);
			m_panel.HidePanel();
		}
	}
}