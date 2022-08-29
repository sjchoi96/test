
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //public delegate void DelegateName();    // �̷� ������ ��������Ʈ�� �ִ� (���Ͼ��� �Ķ���͵� ���� �Լ��� �����ϴ� ��������Ʈ)
    //public DelegateName del;      // DelegateName Ÿ������ del�̶�� �̸��� ��������Ʈ�� ����
    //Action del2;                  // ����Ÿ���� void, �Ķ���͵� ���� ��������Ʈ del2�� ����
    //Action<int> del3;             // ����Ÿ���� void, �Ķ���ʹ� int �ϳ��� ��������Ʈ del3�� ����
    //Func<int, float> del4;        // ����Ÿ���� int�� �Ķ���ʹ� float �ϳ��� ��������Ʈ del4�� ����

    public float speed = 1.0f;      // �÷��̾��� �̵� �ӵ�(�ʴ� �̵� �ӵ�)
    Vector3 dir;                    // �̵� ����(�Է¿� ���� �����)
    float boost = 1.0f;

    Rigidbody2D rigid;

    public GameObject bullet;

    PlayerInputAction inputActions;

    Animator anim;

    //bool isFiring = false;
    public float fireInterval = 0.2f;
    //float fireTimeCount = 0.0f;

    IEnumerator fireCoroutine;

    // Awake -> OnEnable -> Start : ��ü������ �� ����

    /// <summary>
    /// �� ��ũ��Ʈ�� ����ִ� ���� ������Ʈ�� ������ ���Ŀ� ȣ��
    /// </summary>
    private void Awake()
    {
        inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>();    // �ѹ��� ã�� �����ؼ� ��� ����(�޸� �� ���� ���� �Ƴ���)
        anim = GetComponent<Animator>();
        fireCoroutine = Fire();
    }

    /// <summary>
    /// �� ��ũ��Ʈ�� ����ִ� ���� ������Ʈ�� Ȱ��ȭ �Ǿ����� ȣ��
    /// </summary>
    private void OnEnable()
    {
        inputActions.Player.Enable();   // ������Ʈ�� �����Ǹ� �Է��� �޵��� Ȱ��ȭ
        inputActions.Player.Move.performed += OnMove;   // Move�׼��� performed �� �� OnMove �Լ� �����ϵ��� ����
        inputActions.Player.Move.canceled += OnMove;    // Move�׼��� canceled �� �� OnMove �Լ� �����ϵ��� ����
        inputActions.Player.Fire.performed += OnFireStart;
        inputActions.Player.Fire.canceled += OnFireStop;
        inputActions.Player.Boost.performed += OnBoostOn;
        inputActions.Player.Boost.canceled += OnBoostOff;
    }

    

    /// <summary>
    /// �� ��ũ��Ʈ�� ����ִ� ���� ������Ʈ�� ��Ȱ��ȭ �Ǿ��� �� ȣ��
    /// </summary>
    private void OnDisable()
    {
        inputActions.Player.Fire.performed += OnFireStart;
        inputActions.Player.Fire.canceled += OnFireStop;
        inputActions.Player.Boost.performed += OnBoostOn;
        inputActions.Player.Boost.canceled += OnBoostOff;
        inputActions.Player.Move.canceled -= OnMove;    // ������ ���� �Լ� ����(������ ����)
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();  // ������Ʈ�� ������� �� �̻� �Է��� ���� �ʵ��� ��Ȱ��ȭ
    }

    /// <summary>
    /// ������ ��. ù��° Update �Լ��� ����Ǳ� ������ ȣ��.
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// �� �����Ӹ��� ȣ��.
    /// </summary>
    //private void Update()
    //{
    //    //transform.position += (speed * Time.deltaTime * dir);
    //    //transform.Translate(speed * Time.deltaTime * dir);
    //    //transform.Translate(speed * Time.deltaTime * dir.x, speed * Time.deltaTime * dir.y, 0);

    //    //transform.position = dir;
    //}

    /// <summary>
    /// ���� �ð� ����(���� ������Ʈ �ð� ����)���� ȣ��
    /// </summary>
    private void FixedUpdate()
    {
        //transform.Translate(speed * Time.fixedDeltaTime * dir);

        // �� ��ũ��Ʈ ������ ��� �ִ� ���� ������Ʈ���� Rigidbody2D ������Ʈ�� ã�� ����.(������ null)
        // �׷��� GetComponent�� ���ſ� �Լ� => (Update�� FixedUpdateó�� �ֱ��� �Ǵ� ���� ȣ��Ǵ� �Լ� �ȿ����� �Ⱦ��� ���� ����)
        // Rigidbody2D rigid = GetComponent<Rigidbody2D>();    

        // rigid.AddForce(speed * Time.fixedDeltaTime * dir); // ������ �ִ� �������� �� �� ����
        rigid.MovePosition(transform.position + boost * speed * Time.fixedDeltaTime * dir); // ������ ���� �������� ó���� �� ����

        //fireTimeCount += Time.fixedDeltaTime;
        //if (isFiring && fireTimeCount > fireInterval)
        //{
        //    Instantiate(bullet, transform.position, Quaternion.identity);
        //    fireTimeCount = 0.0f;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("OnCollisionEnter2D"); // Collider �� �ε������� ����
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D"); // Collider �� ��� �����ϰ� ���� �� (�� �����Ӹ��� ȣ��)
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D"); // Collider �� ������ �������� ���� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnCollisionEnter2D"); // Trigger �� ������ ����... collider �� �ٸ����� trigger �� ��ġ�� ����
    }

    private void OnTriggerStay2D(Collider2D collision)
    { 
        Debug.Log("OnCollisionEnter2D"); // Trigger �� ���������� (�� �����Ӹ��� ȣ��)
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnCollisionEnter2D"); // Trigger �� ������ ��
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Exception : ���� ��Ȳ( ������ �ؾ� ���� ������ �ȵǾ��ִ� ���� �϶� )
        //throw new NotImplementedException();    // NotImplementedException �� �����ض�. => �ڵ� ������ �˷��ֱ� ���� ������ ���̴� �ڵ�

        //Debug.Log("�̵� �Է�");
        dir = context.ReadValue<Vector2>();    // ��� �������� �������� �ϴ����� �Է¹���

        // dir.y > 0  ;  W�� ������.
        // dir.y == 0 ;  W,S �� �ƹ��͵� �ȴ�����.
        // dir.y < 0  ;  S �� ������.

        anim.SetFloat("InputY", dir.y);
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("�߻�!");
        Instantiate(bullet, transform.position, Quaternion.identity);

        //��float value = Random.Range(0.0f, 10.0f); //using system �� ���־���!! .. value ���� 0.0 ~ 10.0 �� �������� ����.

    }

    private void OnBoostOn(InputAction.CallbackContext context)
    {
        boost *= 2.0f;
    }

    private void OnBoostOff(InputAction.CallbackContext context)
    {
        boost = 1.0f;
    }
    private void OnFireStart(InputAction.CallbackContext obj)
    {
        //isFiring = true;
        StartCoroutine(fireCoroutine);
    }

    private void OnFireStop(InputAction.CallbackContext obj)
    {
        //isFiring = false;
        StopCoroutine(fireCoroutine);

    }

    IEnumerator Fire()
    {
        //yield return null; //���� �����ӿ� �̾ �����ض�
        //yield return new WaitForSeconds(1.0f); //1���Ŀ� �̾ �����ض�

        while(true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireInterval);
        }
    }

}
