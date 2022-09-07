using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    GameObject explosion;

    float spawnY; // ���� �Ǿ��� ���� ���� ����
    float timeElapsed; // ���� ���ۺ��� �󸶳� �ð��� �������� ����� ���� ����

    public float amplitude; // �������� ����Ǵ� �� �Ʒ� ����. ���� sin �� -1~+1 �ε� �װ��� �����ϴ� ����
    public float frequency; // ���� �׷����� �ѹ� ���µ� �ɸ��� �ð�

    private void Awake()
    {
        
    }

    private void Start()
    {
        explosion = transform.GetChild(0).gameObject;
        //explosion.SetActive(false); // Ȱ��ȭ ���¸� ����(��Ȱ��ȭ)

        spawnY = transform.position.y;
        timeElapsed = 0.0f;
    }

    private void Update()
    {
        // Time.deltaTime : ���� �����ӿ��� ���� �����ӱ����� �ð�
        //magnitude = Random.Range(1.0f, 3.0f);
        //frequencyTime = Random.Range(1.0f, 3.0f);
        

        timeElapsed += Time.deltaTime * frequency;
        float newY = spawnY + Mathf.Sin(timeElapsed) * amplitude; // Mathf.Sin �� ����� 0���� �����ؼ� +1 ���� �����ϴٰ� -1 ���� ����. �ٽ� +1 ���� ���� �ݺ�.
        float newX = transform.position.x - speed * Time.deltaTime;


        transform.position = new Vector3(newX, newY, 0.0f);
        



        //transform.Translate(speed * Time.deltaTime * Vector3.left, Space.World);
        //transform.Translate(speed * Time.deltaTime * new Vector3(-1,0), Space.Self);  // new�� ���� ����� ������ Vector3.left�� ���� �ͺ��ٴ� ������.
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //GameObject obj = Instantiate(explosion, transform.position, Quaternion.identity);
            //Destroy(obj, 0.42f);
            explosion.SetActive(true);  // �Ѿ˿� �¾��� �� �ͽ��÷����� Ȱ��ȭ ��Ű��
            explosion.transform.parent = null;  // �ͽ��÷����� �θ�(Enemy) ������ �����Ѵ�.

            Destroy(this.gameObject);   // Enemy�� �ı��Ѵ�.
        }
    }
}