using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    GameObject explosion;

    float spawnY; // 생성 되었을 떄의 기준 높이
    float timeElapsed; // 게임 시작부터 얼마나 시간이 지났나를 기록해 놓는 변수

    public float amplitude; // 사인으로 변경되는 위 아래 차이. 원래 sin 은 -1~+1 인데 그것을 변경하는 변수
    public float frequency; // 사인 그래프가 한번 도는데 걸리는 시간

    private void Awake()
    {
        
    }

    private void Start()
    {
        explosion = transform.GetChild(0).gameObject;
        //explosion.SetActive(false); // 활성화 상태를 끄기(비활성화)

        spawnY = transform.position.y;
        timeElapsed = 0.0f;
    }

    private void Update()
    {
        // Time.deltaTime : 이전 프레임에서 현재 프레임까지의 시간
        //magnitude = Random.Range(1.0f, 3.0f);
        //frequencyTime = Random.Range(1.0f, 3.0f);
        

        timeElapsed += Time.deltaTime * frequency;
        float newY = spawnY + Mathf.Sin(timeElapsed) * amplitude; // Mathf.Sin 의 결과는 0에서 시작해서 +1 까지 증가하다가 -1 까지 감소. 다시 +1 까지 증가 반복.
        float newX = transform.position.x - speed * Time.deltaTime;


        transform.position = new Vector3(newX, newY, 0.0f);
        



        //transform.Translate(speed * Time.deltaTime * Vector3.left, Space.World);
        //transform.Translate(speed * Time.deltaTime * new Vector3(-1,0), Space.Self);  // new로 새로 만들기 때문에 Vector3.left를 쓰는 것보다는 느리다.
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //GameObject obj = Instantiate(explosion, transform.position, Quaternion.identity);
            //Destroy(obj, 0.42f);
            explosion.SetActive(true);  // 총알에 맞았을 때 익스플로젼을 활성화 시키고
            explosion.transform.parent = null;  // 익스플로전의 부모(Enemy) 연결을 제거한다.

            Destroy(this.gameObject);   // Enemy를 파괴한다.
        }
    }
}