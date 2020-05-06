using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class ConsentState:BaseMenuState
	{
		private readonly Button m_consentAgreeButton;

		public ConsentState(GameManager gameManager,UiPanel panel, Button consentAgreeButton):base(gameManager, panel)
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
			Panel.backwardsComplete+=()=>PlayerPrefs.SetInt(GameConstants.UserConsentAgreed, 1);
			HidePanel();
		}


		private void HidePanel()
		{
			Panel.backwardsComplete += () => Panel.gameObject.SetActive(false);
			Panel.HidePanel();
		}
	}
}