using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifeTime = 3.0f;
    public GameObject hitEffect;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
        // this�� �� Ŭ������ �ν��Ͻ�(�ڱ� �ڽ�)
    }

    private void Update()
    {
        //transform.Translate(speed * Time.deltaTime * new Vector3(1,0) );
        transform.Translate(speed * Time.deltaTime * Vector3.right, Space.Self);  // Space.Self : �ڱ� ����, Space.World : �� ����
    }

    // �浹�� ����� �ö��̴��� �� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Collision : {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hitEffect.transform.parent = null;
            hitEffect.transform.position = collision.contacts[0].point;
            // collision.contacts[0].normal : ���� ����(��� ����)
            // ��� ���� : Ư�� ��鿡 ������ ����
            // ��� ���ʹ� �ݻ縦 ����ϱ� ���� �ݵ�� �ʿ��ϴ�. => �ݻ縦 �̿��ؼ� �׸��ڸ� ����Ѵ�. �������� �ݻ絵 ����Ѵ�.
            // ��� ���͸� ���ϱ� ���� ������ ������ ����Ѵ�.
            hitEffect.gameObject.SetActive(true);
            //Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        // �ſ� ���� ���� �ڵ�
        //if (collision.gameObject.tag == "Enemy") 
        //{
        //}
        // 1. CompareTag�� ���ڿ� ���ڸ� �������� == �� ���ڿ� �񱳶� �� ������.
        // 2. �ʿ� ���� �������� �����.

    }


    //// �浹�� ����� Ʈ������ �� ����
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log($"Trigger : {collision.gameObject.name}");
    //}
}