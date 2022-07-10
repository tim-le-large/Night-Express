using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public GameObject endpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endpoint.transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == endpoint.transform.position)
        {
            Destroy(this.gameObject);
        }
    }
}
