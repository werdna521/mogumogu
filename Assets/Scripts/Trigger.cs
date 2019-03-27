using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private static bool lost;

    public static bool IsLost()
    {
        return lost;
    }

    // Start is called before the first frame update
    void Start()
    {
        lost = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        lost = true;
    }
}
