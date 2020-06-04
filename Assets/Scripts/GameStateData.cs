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

	public List<PlayerSegment> playerSegments;

	public List<string> historicalIPs;

	public void AssignRandomCode( int codeLength)
	{

	}

	public string GetCurrentIP()
	{
		return string.Empty;

	}

}
