using UnityEngine;

public class GameConstants : MonoBehaviour
{
	public static float SplashDuration = 4f;

	public static string GameName = "King's Choices";
	public static string StudioName = "Ozi Technology";

	public static string UserConsent = "UserConsent";
	public static float UserConsentClickDuration = 0.15f;


	public static string PrivacyPolicyHeader = "Thank you for installing " + GameName;

	public static string PrivacyPolicyText =
		" We respect and value your privacy and data security and would like to get your consent on processing your game data in making " +
		GameName + " better and show you only relevant ads. " +
		"You can check in detail how we use your data here<Href>";

	public static string PrivacyPolicyFooter = " I agree to the terms of " + StudioName + " and their Partners. " +
	                                           "This is to confirm that i'm older than 16 years or have my guardians permission.";

	public static string TutorialShown = "TutorialShown";

	public static string VC1 = "VC1";

	public static string LevelNumberPref = "LevelNumber";
}