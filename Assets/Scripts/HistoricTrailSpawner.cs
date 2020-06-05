using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoricTrailSpawner : MonoBehaviour
{
	public GameObject trailPrefab;
	GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
		gameStateManager = FindObjectOfType<GameStateManager>();
		gameStateManager.OnInitialized += SetHistoricTrails;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void SetHistoricTrails()
	{
		List<Player> historicPlayers = gameStateManager.gameStateData.historicPlayers;

		for (int i = 0; i < historicPlayers.Count; i++)
		{
			LineRenderer lineRenderer = Instantiate(trailPrefab, this.transform).GetComponent<LineRenderer>();
			lineRenderer.positionCount = historicPlayers[i].trailPositions.Length;
			lineRenderer.SetPositions(historicPlayers[i].trailPositions);
			lineRenderer.material.color = new Color(historicPlayers[i].color.r / 256f, historicPlayers[i].color.g / 256f, historicPlayers[i].color.b / 256f, historicPlayers[i].color.a / 256f);
		}
	}
}
