using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect : MonoBehaviour
{  
    [SerializeField] int effectStackMax;

    List<Subeffect> subeffects;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("EffectActivated");
        collision.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //Apply();
    }


    public void Apply()
	{
		for (int i = 0; i < subeffects.Count; i++)
		{
			subeffects[i].Apply();
		}
	}
}
