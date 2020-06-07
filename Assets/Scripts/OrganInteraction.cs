using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganInteraction : MonoBehaviour
{
    public enum FoodTypes { blue, red, yellow };

    public Parasite _parasite;

    public FoodTypes parasiteGain01;
    public FoodTypes parasiteGain02;
    public int statIncreaseAmount;

    public Coroutine _eatingCoroutine;

	public int organIndex;
    public Organ _organ;

    public Transform hpAmount;
    public Transform fleshAmount;

    public float sizeModifier;
    float currentScaleHP;
    float currentScaleFlesh;

    FoodSpawner foodSpawner;

    private void OnEnable()
    {
        FindObjectOfType<GameStateManager>().OnInitialized += Initialize;
    }
    private void OnDisable()
    {
        FindObjectOfType<GameStateManager>().OnInitialized -= Initialize;
    }

    private void Initialize()
    {
        foodSpawner = FindObjectOfType<FoodSpawner>();
        _organ = FindObjectOfType<GameStateManager>().gameStateData.organs[organIndex];

        if (this.gameObject.transform.childCount > 1)
        {
            hpAmount = this.gameObject.transform.GetChild(0);
            fleshAmount = this.gameObject.transform.GetChild(1);
        }
       
        if(_organ.currentFleshAmount <= 0)
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
        }

        currentScaleHP = CalculateScale(_organ.maxHP, _organ.currentHP);
        currentScaleFlesh = CalculateScale(_organ.maxFlesh, _organ.currentFleshAmount);

        hpAmount.localScale = new Vector3(currentScaleHP, currentScaleHP, 0);
        fleshAmount.localScale = new Vector3(currentScaleFlesh, currentScaleFlesh, 0);
        sizeModifier = 1 / _organ.maxHP;
    }

    public float CalculateScale(float max, float current)
    {
        return 1 - (current / max);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_organ.currentHP > 0)
        {
            _eatingCoroutine = StartCoroutine(EatOrgan());
        }
        else if (_organ.currentFleshAmount > 0)
        {
            _eatingCoroutine = StartCoroutine(EatFlesh());
        }
        else
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
        }

        collision.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StopCoroutine(_eatingCoroutine);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food") && collision.GetComponent<Food>()._targetOrgan.name == this.name)
        {
            if(_organ.currentHP > 0)
            {
                if (_organ.currentHP < _organ.maxHP)
                {
                    _organ.currentHP++;
                }
                currentScaleHP = CalculateScale(_organ.maxHP, _organ.currentHP);
                hpAmount.localScale = new Vector3(currentScaleHP, currentScaleHP, 0);
            }
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator EatOrgan()
    {
        while (true)
        {
            if (hpAmount.localScale.x >= 1)
            {
                hpAmount.localScale = Vector2.one;
                _eatingCoroutine = StartCoroutine(EatFlesh());
                yield break;
            }

            yield return new WaitForSeconds(_organ.destructionRate);

            AddPointsToParasite(parasiteGain01, statIncreaseAmount);
            AddPointsToParasite(parasiteGain02, statIncreaseAmount);

            _organ.currentHP--;
            currentScaleHP = CalculateScale(_organ.maxHP, _organ.currentHP);
            hpAmount.localScale = new Vector3(currentScaleHP, currentScaleHP, 0);

            
        }

    }

    public IEnumerator EatFlesh()
    {
        SetOrganAsDead();
        while (true)
        {
            if (fleshAmount.localScale.x >= 1)
            {
                fleshAmount.localScale = Vector2.one;
                this.GetComponent<CircleCollider2D>().enabled = false;
                yield break;
            }

            yield return new WaitForSeconds(_organ.destructionRate);

            AddPointsToParasite(parasiteGain01, statIncreaseAmount*2);
            AddPointsToParasite(parasiteGain02, statIncreaseAmount*2);

            _organ.currentFleshAmount--;
            currentScaleFlesh = CalculateScale(_organ.maxFlesh, _organ.currentFleshAmount);
            fleshAmount.localScale = new Vector3(currentScaleFlesh, currentScaleFlesh, 0);
        }

    }

    void SetOrganAsDead()
    {
        if (this.name.Contains("00"))
        {
            foodSpawner.stillAlive00 = false;
        }
        if (this.name.Contains("01"))
        {
            foodSpawner.stillAlive01 = false;
        }
        if (this.name.Contains("02"))
        {
            foodSpawner.stillAlive02 = false;
        }
    }

    public void AddPointsToParasite(FoodTypes stats, int increase)
    {
        switch (stats)
        {
            case FoodTypes.blue:
                if(_parasite.statBlue < _parasite.statBlueMax)
                    _parasite.statBlue += increase;
                break;
            case FoodTypes.red:
                if (_parasite.statRed < _parasite.statRedMax)
                    _parasite.statRed += increase;
                break;
            case FoodTypes.yellow:
                if (_parasite.statYellow < _parasite.statYellowMax)
                    _parasite.statYellow += increase;
                break;
        }

        if(_parasite.statBlue == _parasite.statBlueMax 
            && _parasite.statRed == _parasite.statRedMax 
            && _parasite.statYellow == _parasite.statYellowMax)
        {
            FindObjectOfType<CanvasController>().OnGameWon();

        }
    }


    public IEnumerator LooseLife(int timer)
    {
        while(timer > 0)
        {
            yield return new WaitForSeconds(2f);

            if(_organ.currentHP > 0)
            {
                _organ.currentHP--;
                currentScaleHP = CalculateScale(_organ.maxHP, _organ.currentHP);
                hpAmount.localScale = new Vector3(currentScaleHP, currentScaleHP, 0);
            }
            else
            {
                yield break;
            }
            timer--;
        }

        yield return null;
    }
}
