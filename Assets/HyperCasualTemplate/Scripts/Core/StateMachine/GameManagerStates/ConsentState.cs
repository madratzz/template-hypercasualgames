using HyperCasualTemplate.Scripts.Core.Controllers;
using HyperCasualTemplate.Scripts.Core.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasualTemplate.Scripts.Core.StateMachine.GameManagerStates
{
	internal class ConsentState:IState
	{
		private readonly GameManager m_gameManager;
		private readonly UIPanel m_panel;

		private readonly Button m_consentAgreeButton;

		public ConsentState(GameManager gameManager,UIPanel panel, Button consentAgreeButton)
		{
			m_gameManager = gameManager;
			m_panel = panel;
			m_consentAgreeButton = consentAgreeButton;
		}

		public void Update()
		{

		}

		public void OnEnter()
		{
			UIController.Instance.ShowPanel(m_panel.Type);
			//Bind Buttons
			m_consentAgreeButton.onClick.AddListener(OnConsentAgree);
		}

		public void OnExit()
		{
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