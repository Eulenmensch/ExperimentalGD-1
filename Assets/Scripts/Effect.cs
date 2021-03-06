﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{  
    public int effectStackMax;

    public float effectDuration;
    public float currentTimer;
    public bool isActivated;

    public enum EffectType { InstantFood, MoreFood, MoreTime, Regeneration};

    public EffectType effectType;
    public int instantGain = 3;
    public int moreTime = 30;


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
