using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


public class Asteroid : MonoBehaviour
{

    public float rotateSpeed = 180.0f;

    public float moveSpeed = 3.0f;

    public Vector3 direction = Vector3.left;

    public GameObject asteroid;

    GameObject explosion;

    public int HP = 3;

    public float minMoveSpeed = 2.0f;
    public float maxMoveSpeed = 4.0f;
    public float minRotateSpeed = 30.0f;
    public float maxRotateSpeed = 360.0f;

    public GameObject small;
    [Range(1,16)]
    public int splitCount;

    float lifeTime;
    public float minLifeTime = 4.0f;
    public float maxLifeTime = 6.0f;
    

    private void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = false;
        sprite.flipY = false;

        //int rand = Random.Range(0, 100) % 2;
        //sprite.flipX = (rand == 0);

        int rand = Random.Range(0, 4); // rand 라는 변수는 0 부터 3까지 랜덤으로 선택됨
        // rand 가 
        // 0 (0b_00), 1 ( 0b_01), 2 (0b_10), 3(0b_11)
        sprite.flipX = (rand & 0b_01) != 0; // rand의 제일 오른쪽 비트가 1이면 true, 0이면 false
        sprite.flipY = (rand & 0b_10) != 0; // rand의 오른쪽 2번째 자리가 1이면 true, 0이면 false

        rotateSpeed = Random.Range(30, 360);
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        float ratio = (moveSpeed - minMoveSpeed) / (maxMoveSpeed - minMoveSpeed);
        //rotateSpeed = ratio * (maxRotateSpeed - minRotateSpeed) + minRotateSpeed;
        rotateSpeed = Mathf.Lerp(minRotateSpeed, maxRotateSpeed, ratio);

        // 위에 rotateSpeed 둘다 같은 뜻의 식

        //asteroidLifetime = Random.Range(3.0f, 5.0f);
        //Crush(Destroy(this.gameObject, asteroidLifetime));

        lifeTime = Random.Range(minLifeTime, maxLifeTime);
    }

    void Start()
    {
        
        explosion = transform.GetChild(0).gameObject;

        StartCoroutine(SelfCrush());
        
    }

    IEnumerator SelfCrush()
    {
        yield return new WaitForSeconds(lifeTime);

        Crush();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation *= Quaternion.Euler (new(0, 0, 90)); // 계속 90도씩 회전
        //transform.rotation *= Quaternion.Euler(new(0,0,rotationSpeed * Time.deltaTime));


        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);

        transform.Translate(moveSpeed * Time.deltaTime * direction, Space.World);

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + direction * 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Bullet"))
        {
            HP--;

            if(HP <= 0)
            {
                Crush();
            }

        }
    }

    void Crush()
    {
        
        explosion.SetActive(true);
        explosion.transform.parent = null;

        //5% 10% 85%

        //float randTest = Random.Range(0.0f, 1.0f);
        //if (randTest < 0.05f)
        //{
        //    //5%
        //}
        //else if (randTest < 0.15f)
        //{
        //    //10%
        //}
        //else
        //{
        //    //85%
        //}


        //5% 확률
        if (Random.Range(0.0f, 1.0f) < 0.05f)
        {
            // 5% 확률
            splitCount = 20; //5%확률로 20개가 튀어나온다.
        }
        else
        {
            //95% 확률
            splitCount = Random.Range(3, 6); // 1/3 확률로 3~5가 나온다
        }

        float random = Random.Range(1.0f, 360.0f);
        float angleGap = random / (float)splitCount;
                
        for (int i = 0; i < splitCount; i++)
        {
            Instantiate(small, transform.position, Quaternion.Euler(0, 0, (angleGap * i)));

        }

        Destroy(this.gameObject);
        

    }

}
