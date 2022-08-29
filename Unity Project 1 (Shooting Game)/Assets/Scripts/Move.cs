using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float speed = 1.0f;

    Vector3 dir;


    public void Start()
    {

    }

    private void Update()
    {
        transform.position += (speed * Time.deltaTime * dir);
    }

    private void Test_OldInputManager()
    {
        //Vector3 : ���͸� ǥ���ϱ� ���� ����ü, ��ġ�� ǥ���� ���� ���� ����Ѵ�.
        // ���� : ���� ����� ũ�⸦ ��Ÿ���� ����
        //transform.position += Vector3.right;
        /*transform.position += new Vector3(1, 0, 0);*/ //������


        //Time.deltaTime : ���� �����ӿ��� ���� �����ӱ��� �ɸ� �ð� => 1�����Ӵ� �ɸ� �ð�

        //new Vector3(1, 0, 0); // ������ Vector3.right;
        //new Vector3(-1, 0, 0); // ���� Vector3.left;
        //new Vector3(0, 1, 0); // ���� Vector3.up;
        //new Vector3(0,-1, 0); // �Ʒ��� Vector3.down;
        /*transform.position += (speed * Time.deltaTime * Vector3.down);*/ // �Ʒ��� �������� speed ��ŭ �������� (�� �ʸ���)


        //Input Manager�� �̿��� �Է�ó��
        //Busy wait �� �߻�. (�ϴ����� ������ ���ǰ� �ִ� ���� => ���� ���̺��� ���� => ����Ŀ��)

        //if (Input.GetKeyDown(KeyCode.W) )
        //{
        //    Debug.Log("W�� ��������");
        //    dir = Vector3.up;    
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Debug.Log("S�� ��������");
        //    dir = Vector3.down;
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("A�� ��������");
        //    dir = Vector3.left;
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("D�� ��������");
        //    dir = Vector3.right;
        //}

       

        //Input System
        //Event-driven (�̺�Ʈ �帮��) ������� ���� -> ���� ���� ���� �����Ѵ�. (������ �Ƴ��⿡ ������ ����)

    }

    public void MoveInput(InputAction.CallbackContext context)
    {                
        //if (context.started) //���ε� Ű�� ���� ����
        //{
        //    Debug.Log("�Էµ��� - started");
        //}

        //if (context.performed) //���ε� Ű�� Ȯ���ϰ� ��������
        //{
        //    Debug.Log("�Էµ��� - performed");
        //}

        //if (context.canceled) //���ε� Ű�� ����������.
        //{
        //    Debug.Log("�Էµ��� - canceled");
        //}

        Vector2 inputDir = context.ReadValue<Vector2>();
        Debug.Log(inputDir);
        dir = inputDir; // dir.x = inputDir.x ; dir.y = inputDir.y; dirz = 0.0f;

        // vector : ����� ũ��
        // vector2: ����Ƽ���� �����ϴ� ����ü(struct). 2���� ���͸� ǥ���ϱ� ���� ����ü (x,y)
        // vector3: ����Ƽ���� �����ϴ� ����ü(struct). 3���� ���͸� ǥ���ϱ� ���� ����ü (x,y,z)

    }

    public void FireInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("�߻�!");
        }
    }
}