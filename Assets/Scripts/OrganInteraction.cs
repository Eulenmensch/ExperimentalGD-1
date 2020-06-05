using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganInteraction : MonoBehaviour
{
    public enum ParasiteStats { blue, red, yellow };

    public Parasite _parasite;

    public ParasiteStats parasiteGain01;
    public ParasiteStats parasiteGain02;
    public int statIncreaseAmount;


    public Organ _organ;

    Transform _attackedOrgan;
    Coroutine _eatingCoroutine;



    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _attackedOrgan = this.transform;
        if (this.transform.childCount > 0)
        {
            _attackedOrgan = this.transform.GetChild(0);
        }
        _eatingCoroutine = StartCoroutine(EatOrgan(_attackedOrgan));
        collision.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(_eatingCoroutine);
    }

    private IEnumerator EatOrgan(Transform organ)
    {
        while (true)
        {
            AddPointsToParasite(parasiteGain01);
            AddPointsToParasite(parasiteGain02);

            organ.localScale -= new Vector3(0.21f, 0.21f, 0);
            if (organ.localScale.x <= 0)
            {
                Destroy(organ.gameObject);
                yield break;
            }
            yield return new WaitForSeconds(_organ.destructionRate);
        }

    }

    private void AddPointsToParasite(ParasiteStats stats)
    {
        switch (stats)
        {
            case ParasiteStats.blue:
                _parasite.statBlue += statIncreaseAmount;
                break;
            case ParasiteStats.red:
                _parasite.statGreen += statIncreaseAmount;
                break;
            case ParasiteStats.yellow:
                _parasite.statYellow += statIncreaseAmount;
                break;
        }
    }
}
