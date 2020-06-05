using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Organ : MonoBehaviour
{
	public float currentHP;
	public float currentFleshAmount;
    public float destructionRate;
	public float regenerationRate;

	public List<Effect> effects;


    // Start is called before the first frame update
    void Start()
    {
        foreach(Effect effect in effects)
        {
            effect.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
        }
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
