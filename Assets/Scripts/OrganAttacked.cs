using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganAttacked : MonoBehaviour
{
    [SerializeField] float destructionDelta;
    Transform attackedOrgan;
    Coroutine eatingCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.transform.childCount > 0)
        {
            attackedOrgan = this.transform.GetChild(0);
        }
        eatingCoroutine = StartCoroutine(EatOrgan(attackedOrgan));
        collision.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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
            yield return new WaitForSeconds(destructionDelta);
        }

    }
}
