using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
        
    public float speed = 5.0f;
    public GameObject bullet;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right , Space.Self); // Space.Self : 자기기준, Space.World : 씬 기준
    }



}
