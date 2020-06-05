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

    Transform _attackedOrgan;
    Coroutine _eatingCoroutine;

	public int organIndex;
    public Organ _organ;

    Transform hpAmount;
    Transform fleshAmount;

    float sizeModifier;
    float currentScaleHP;
    float currentScaleFlesh;

    private void Start()
    {
		_organ = FindObjectOfType<GameStateManager>().gameStateData.organs[organIndex];

        if(this.gameObject.transform.childCount > 1)
        {
            hpAmount = this.gameObject.transform.GetChild(0);
            fleshAmount = this.gameObject.transform.GetChild(1);
        }

        if((_organ.maxHP - _organ.currentHP) != 0)
        {
            currentScaleHP = 1 / (_organ.maxHP - _organ.currentHP);
        }
        else
        {
            currentScaleHP = 0;
        }

        if((_organ.maxFlesh - _organ.currentFleshAmount) != 0)
        {
            currentScaleFlesh = 1/(_organ.maxFlesh - _organ.currentFleshAmount);
        }
        else
        {
            currentScaleFlesh = 0;
        }

        hpAmount.localScale = new Vector3(currentScaleHP, currentScaleHP, 0);
        fleshAmount.localScale = new Vector3(currentScaleFlesh, currentScaleFlesh, 0);
        sizeModifier = 1 / _organ.maxHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_organ.currentHP > 0)
        {
            _eatingCoroutine = StartCoroutine(EatOrgan());
        }
        else if(_organ.currentFleshAmount > 0)
        {
            Debug.Log("STARTED");
            _eatingCoroutine = StartCoroutine(EatFlesh());
        }
        
        collision.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(_eatingCoroutine);
    }

    private IEnumerator EatOrgan()
    {
        while (true)
        {
            _organ.currentHP--;
            AddPointsToParasite(parasiteGain01);
            AddPointsToParasite(parasiteGain02);

            hpAmount.localScale += new Vector3(sizeModifier, sizeModifier, 0);
            if (hpAmount.localScale.x >=1)
            {
                hpAmount.localScale = Vector2.one;
                Debug.Log("ORGAN DESTROYED");
                sizeModifier = 1 / _organ.maxFlesh;
                _eatingCoroutine = StartCoroutine(EatFlesh());
                yield break;
            }
            yield return new WaitForSeconds(_organ.destructionRate);
        }

    }

    private IEnumerator EatFlesh()
    {
        while (true)
        {
            _organ.currentFleshAmount--;
            AddPointsToParasite(parasiteGain01);
            AddPointsToParasite(parasiteGain02);

            fleshAmount.localScale += new Vector3(sizeModifier, sizeModifier, 0);
            if (fleshAmount.localScale.x >= 1)
            {
                fleshAmount.localScale = Vector2.one;
                fleshAmount.parent.GetComponent<CircleCollider2D>().enabled = false;
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
                _parasite.statRed += statIncreaseAmount;
                break;
            case ParasiteStats.yellow:
                _parasite.statYellow += statIncreaseAmount;
                break;
        }
    }
}
