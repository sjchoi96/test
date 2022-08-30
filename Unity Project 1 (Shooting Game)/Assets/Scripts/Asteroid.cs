using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float rotationSpeed = 180.0f;

    public float moveSpeed = 3.0f;

    public Vector3 direction = Vector3.left;

    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation *= Quaternion.Euler (new(0, 0, 90)); // 계속 90도씩 회전
        //transform.rotation *= Quaternion.Euler(new(0,0,rotationSpeed * Time.deltaTime));
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);

        transform.Translate(moveSpeed * Time.deltaTime * direction, Space.World);


        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + direction);
    }

}
