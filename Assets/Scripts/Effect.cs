using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
	List<Subeffect> subeffects;

	//// Start is called before the first frame update
	//void Start()
	//{

	//}

	//// Update is called once per frame
	//void Update()
	//{

	//}

	public void Apply()
	{
		for (int i = 0; i < subeffects.Count; i++)
		{
			subeffects[i].Apply();
		}
	}
}
