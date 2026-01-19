using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3f;
    public float destroyX = -25f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}