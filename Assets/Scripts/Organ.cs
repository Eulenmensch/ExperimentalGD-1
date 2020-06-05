using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Organ
{
    public float maxHP;
    public float maxFlesh;
	public float currentHP;
	public float currentFleshAmount;
    public float destructionRate;
	public float regenerationRate;
	public SerializableColor color;
	public List<Effect> effects;

}
