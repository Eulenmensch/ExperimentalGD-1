using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
	public GameStateManager gameStateManager;

	public TMP_InputField codeInputField;
	public TextMeshProUGUI codetoShow;

	public GameObject startScreen;
	public GameObject endScreen;
    public GameObject gameOverScreen;
    public GameObject timer;

    private void Start()
    {
        Time.timeScale = 0;
    }

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
#if UNITY_EDITOR

		if (UnityEditor.EditorApplication.isPlaying)
		{
			UnityEditor.EditorApplication.isPlaying = false;
		}
#endif
	}

	public void StartNewChain()
	{
		gameStateManager.CreateNewState();
        Time.timeScale = 1;
        timer.SetActive(true);
        
	}

	public void ContinueUsingCode()
	{
		gameStateManager.EggCode = codeInputField.text;
		gameStateManager.LoadState();
        Time.timeScale = 1;
        timer.SetActive(true);

    }

    public void OnGameWon()
	{
		GameStateManager.instance.gameWon = true;
        FindObjectOfType<GameStateManager>().SaveState();
		codetoShow.text = gameStateManager.gameStateData.code;
		ShowEndScreen();
	}

    public void OnGameLost()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
