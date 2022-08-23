using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 0.1f;
    // ����Ƽ �̺�Ʈ �Լ� : ����Ƽ�� Ư�� Ÿ�ֿ̹� ���� ��Ű�� �Լ�

    // Start �Լ�. ������ ���۵ɶ� (ù��° Update �Լ��� ȣ��Ǳ� ������ ȣ��Ǵ� �Լ�)
    public void Start()
    {
        Debug.Log("Hello Unity");
    }

    // Update �Լ�. �� �����Ӹ��� ȣ��Ǵ� �Լ� 
    private void Update()
    {
        //Vector3 : ���͸� ǥ���ϱ� ���� ����ü, ��ġ�� ǥ���� ���� ���� ����Ѵ�.
        // ���� : ���� ����� ũ�⸦ ��Ÿ���� ����
        //transform.position += Vector3.right;
        /*transform.position += new Vector3(1, 0, 0);*/ //������


        //Time.deltaTime : ���� �����ӿ��� ���� �����ӱ��� �ɸ� �ð�
        transform.position += (speed * Time.deltaTime * Vector3.down); // �Ʒ��� �������� speed ��ŭ �������� (�� �ʸ���)

        new Vector3(1, 0, 0); // ������ Vector3.right;
        new Vector3(-1, 0, 0); // ���� Vector3.left;
        new Vector3(0, 1, 0); // ���� Vector3.up;
        new Vector3(0,-1, 0); // �Ʒ��� Vector3.down;
    }
}
