using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for subeffects. Actual subeffects may derive from this class
/// </summary>
[System.Serializable]
public class Subeffect
{
	// some variables common for all subeffects

	//// Start is called before the first frame update
	//void Start()
	//{

	//}

	//// Update is called once per frame
	//void Update()
	//{

	//}

	public virtual void Apply() {}
}
