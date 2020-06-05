using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
	public SerializableColor color; // colour 
	public string playerName; //(optional)
	public string IP;
	public Vector3[] trailPositions;


	public void Initialize()
	{
		GetIP();
		GenerateRandomColor();
	}
	
	private void GetIP()
	{
		IP = IPManager.GetIP(ADDRESSFAM.IPv6);
	}

	private  void GenerateRandomColor()
	{
		color.r = Random.Range(0, 256);
		color.g = Random.Range(0, 256);
		color.b = Random.Range(0, 256);
		color.a = 255;
	}
    
} 

