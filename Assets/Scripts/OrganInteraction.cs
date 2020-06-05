using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganInteraction : MonoBehaviour
{
    public Player _player;
    
    Transform _attackedOrgan;
    Coroutine _eatingCoroutine;
    Organ _organ;

    private void Start()
    {
        _organ = GetComponent<Organ>();
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
            _player.statBlue++;

            organ.localScale -= new Vector3(0.21f, 0.21f, 0);
            if (organ.localScale.x <= 0)
            {
                Debug.Log("Destroyed! " + organ.name);
                Destroy(organ.gameObject);
                yield break;
            }
            yield return new WaitForSeconds(_organ.destructionRate);
        }

    }
}
