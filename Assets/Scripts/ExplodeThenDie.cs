using System.Collections;
using UnityEngine;

public class ExplodeThenDie : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
