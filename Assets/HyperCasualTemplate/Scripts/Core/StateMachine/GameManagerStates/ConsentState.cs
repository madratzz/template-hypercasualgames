using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class ConsentState:IState
	{
		private readonly GameManager m_gameManager;
		private readonly Button m_consentAgreeButton;

		public ConsentState(GameManager gameManager, Button consentAgreeButton)
		{
			m_gameManager = gameManager;
			m_consentAgreeButton = consentAgreeButton;
		}

		public void Update()
		{

		}

		public void OnEnter()
		{
			UIController.Instance.ShowPanel(UIPanelType.Consent);
			//Bind Buttons
			m_consentAgreeButton.onClick.AddListener(OnConsentAgree);
		}

		public void OnExit()
		{
			PlayerPrefs.Save();
			//UnBindButtons
			m_consentAgreeButton.onClick.RemoveListener(OnConsentAgree);
		}

		private static void OnConsentAgree() => PlayerPrefs.SetInt(GameConstants.UserConsent, 1);
	}
}