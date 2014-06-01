using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour
{

    public GameObject moveObjectToEnter;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball 1")
        {
            StartCoroutine(EnableCollider());
        }
    }


    IEnumerator EnableCollider()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(1);
        collider.enabled = true;
    }
}
