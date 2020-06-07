using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite: MonoBehaviour
{
	public List<Player> historicPlayers;
	public Player activePlayer;

	public int statBlue;
    public int statRed;
    public int statYellow;

    public int statBlueMax;
    public int statRedMax;
    public int statYellowMax;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DrawTrail>().CreateTrail();
    }

	public void GeneratePlayer()
	{
		//TO DO spawn head????

		for (int i = 0; i < historicPlayers.Count; i++)
		{
			AddParasiteSegment(historicPlayers[i]);
		}

		AddParasiteSegment(activePlayer);

	}

	public void AddParasiteSegment(Player player)
	{
		// spawn segment attached to the head in a correct colour
	
	}

	public void LoadHistoricTrails()
	{
		// recover trailPositions from each player and draw them on screen.
	}
}
