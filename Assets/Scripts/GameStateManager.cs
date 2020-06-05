using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class GameStateManager : MonoBehaviour
{
	public GameStateData gameStateData;

	public List<Organ> defaulOrgans;

	public Player currentPlayer;

	Parasite _parasite;

	public string serializationPreview;

	private void Awake()
	{
		
		_parasite = FindObjectOfType<Parasite>();
		CreateNewState();
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			SaveState();
		}
	}
	public void CreateNewState()
	{
		gameStateData = new GameStateData();
		gameStateData.organs = defaulOrgans;
		gameStateData.AssignRandomCode();
		gameStateData.historicPlayers = new List<Player>();

		currentPlayer = new Player();
		currentPlayer.Initialize();

		_parasite.activePlayer = currentPlayer;
		_parasite.historicPlayers = new List<Player>();
	}

	public void SaveState()
	{
		currentPlayer.trailPositions = _parasite.GetComponent<DrawTrail>().GetTrailPositions();
		gameStateData.historicPlayers.Add(currentPlayer);
		serializationPreview = SerializeObjectToString<GameStateData>(gameStateData);

	}

	public void LoadState()
	{

	}

	public static string SerializeObjectToString<T>(T toSerialize)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

		using (StringWriter textWriter = new StringWriter())
		{
			xmlSerializer.Serialize(textWriter, toSerialize);
			return textWriter.ToString();
		}
	}

}
