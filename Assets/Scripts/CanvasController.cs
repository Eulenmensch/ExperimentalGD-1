using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
	public GameStateManager gameStateManager;

	public TMP_InputField codeInputField;
	public TextMeshProUGUI codetoShow;

	public GameObject startScreen;
	public GameObject endScreen;

	public void ShowStartScreen()
	{
		startScreen.SetActive(true);
	}

	public void HideStartScreen()
	{
		startScreen.SetActive(false);
	}

	public void ShowEndScreen()
	{
		endScreen.SetActive(true);
	}
	public void QuitGame()
	{
		Application.Quit();
	}

	public void StartNewChain()
	{
		gameStateManager.CreateNewState();
	}

	public void ContinueUsingCode()
	{
		gameStateManager.EggCode = codeInputField.text;
		gameStateManager.LoadState();
	}

	public void OnGameWon()
	{
		codetoShow.text = gameStateManager.gameStateData.code;
		ShowEndScreen();
	}


}
