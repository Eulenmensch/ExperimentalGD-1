using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite: MonoBehaviour
{
	public List<Parasite> playerSegments;

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
        AddNewSegment(sColor);

        GetComponent<DrawTrail>().CreateTrail();
    }

    public void AddNewSegment(SerializableColor color)
	{
	
	}
}
