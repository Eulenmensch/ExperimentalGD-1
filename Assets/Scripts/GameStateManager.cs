using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public GameStateData gameStateData;

	public List<Organ> defaulOrgans;

	private void Start()
	{
		CreateNewState();
	}
	public void CreateNewState()
	{
		gameStateData = new GameStateData();
		gameStateData.organs = defaulOrgans;
	}

	public void SaveState()
	{

	}

	public void LoadState()
	{

	}
}
