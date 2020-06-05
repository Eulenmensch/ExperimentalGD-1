using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateData
{
	public string code = string.Empty;

	public SerializableColor[] vertexColors;

	public Organ organ1;
	public Organ organ2;
	public Organ organ3;

	public List<Player> playerSegments;

	public List<string> historicalIPs;

	public List<Effect> activeEffects;  

	public string GenerateRandomCode( int codeLength)
	{
		string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		string randomString = string.Empty;
		for (int i = 0; i < codeLength; i++)
		{
			int rnd = Random.Range(0, chars.Length);
			randomString += chars[rnd];
		}
		return randomString;
	}

	public void AssignRandomCode()
	{
		code = GenerateRandomCode(5);
	}

	public string GetCurrentIP()
	{
		return string.Empty;

	}

}
