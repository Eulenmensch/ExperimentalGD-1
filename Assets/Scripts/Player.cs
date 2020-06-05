using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player: MonoBehaviour
{
	public SerializableColor color; // colour 
	public string playerName; //(optional)
	public string IP;

    public int statBlue;
    public int statGreen;
    public int statYellow;

    public int statBlueMax;
    public int statGreenMax;
    public int statYellowMax;

    // Start is called before the first frame update
    void Start()
    {
        SerializableColor sColor = new SerializableColor
        {
            r = 1,
            g = 1,
            b = 1,
            a = 1
        };

        GetComponent<DrawTrail>().CreateTrail();
    }

	public void GetIP()
	{
		IP = IPManager.GetIP(ADDRESSFAM.IPv6);
	}
    
} 

