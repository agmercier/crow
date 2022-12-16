using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_firstkiwi : MonoBehaviour
{
    public GameObject firstKiwi;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(firstKiwi);
        return;
    }
}
