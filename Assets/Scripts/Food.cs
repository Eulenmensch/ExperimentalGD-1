using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Parasite _parasite;
    public enum FoodTypes { blue, red, yellow };

    public FoodTypes parasiteGain01;
    public FoodTypes parasiteGain02;

    public Transform _targetOrgan;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _parasite = FindObjectOfType<Parasite>();

        if (this.name.Contains("00"))
        {
            _targetOrgan = GameObject.Find("OrganPurple00").transform;
        } 
        else if (this.name.Contains("01"))
        {
            _targetOrgan = GameObject.Find("OrganOrange01").transform;

        }
        else
        {
            _targetOrgan = GameObject.Find("OrganGreen02").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetOrgan.position, .04f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AddPointsToParasite(parasiteGain01, 1);
            AddPointsToParasite(parasiteGain02, 1);
            Destroy(this.gameObject);
        }
    }

    public void AddPointsToParasite(FoodTypes stats, int increase)
    {
        switch (stats)
        {
            case FoodTypes.blue:
                if (_parasite.statBlue < _parasite.statBlueMax)
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

        if (_parasite.statBlue == _parasite.statBlueMax
            && _parasite.statRed == _parasite.statRedMax
            && _parasite.statYellow == _parasite.statYellowMax)
        {
            FindObjectOfType<CanvasController>().OnGameWon();

        }
    }

}
