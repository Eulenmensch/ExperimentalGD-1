using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
	public SerializableColor color; // colour 
	public string playerName; //(optional)
	public string IP;

	public void GetIP()
	{
		IP = IPManager.GetIP(ADDRESSFAM.IPv6);
	}
    
} 

