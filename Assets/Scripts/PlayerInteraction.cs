using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float eatingSpeed;
    Transform attackedOrgan;
    Coroutine eatingCoroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.childCount > 0)
        {
            attackedOrgan = collision.transform.GetChild(0);
        }
         eatingCoroutine = StartCoroutine(EatOrgan(attackedOrgan));
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.childCount > 0)
        {
            attackedOrgan = collision.transform.GetChild(0);
        }
        StopCoroutine(eatingCoroutine);
    }

    private IEnumerator EatOrgan(Transform organ)
    {
        while (true)
        {
            organ.localScale -= new Vector3(0.21f, 0.21f, 0);
            if (organ.localScale.x <= 0)
            {
                Debug.Log("Destroyed! " + organ.name);
                Destroy(organ.gameObject);
            }
            yield return new WaitForSeconds(eatingSpeed);
        }

    }
}
