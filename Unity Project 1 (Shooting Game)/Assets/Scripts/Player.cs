using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //public delegate void DelegateName();    // �̷� ������ ��������Ʈ�� �ִ� (���Ͼ��� �Ķ���͵� ���� �Լ��� �����ϴ� ��������Ʈ)
    //public DelegateName del;      // DelegateName Ÿ������ del�̶�� �̸��� ��������Ʈ�� ����
    //Action del2;                  // ����Ÿ���� void, �Ķ���͵� ���� ��������Ʈ del2�� ����
    //Action<int> del3;             // ����Ÿ���� void, �Ķ���ʹ� int �ϳ��� ��������Ʈ del3�� ����
    //Func<int, float> del4;        // ����Ÿ���� int�� �Ķ���ʹ� float �ϳ��� ��������Ʈ del4�� ����

    //public ����----------------------------------------------------------------------
    [Header("���� ������")]
    public GameObject bulletPrefab;   // �Ѿ˿�������
    public GameObject explosionPrefab; // ����� ���ȿ� ������

    [Header("�÷��̾� ����")]
    public float speed = 1.0f;      // �÷��̾��� �̵� �ӵ�(�ʴ� �̵� �ӵ�)
    public float fireInterval = 0.5f; // �Ѿ� �߻� �ð� ����

    [Header("���� �⺻ ����")]
    public float InvincibleTime = 1.0f;
    public int initialLife = 3;     // �÷��̾� ü��


    // private ����-----------------------------------------------------------------------
    
    private int life; 
    // ���� ���� ��ġ

    private int power = 0; 
    // �Ŀ��� �������� ȹ���� ���� (�ִ밪�� 3��)

    private float timeElapsed = 0.0f; 
    // �������¿� �� �ð� (�� 30��)

    private float boost = 1.0f; 
    // �ν�Ʈ �ӵ�

    private float fireAngle = 30.0f; 
    // �Ѿ��� �ѹ��� ������ �߻�� �� �Ѿ˰��� ���� ����

    private bool isInvincibleMode = false; 
    // �������� ǥ�ÿ� (true = ���� . false = �Ϲݻ���)

    private bool isDead = false; 
    // �÷��̾� ������� (true = ��� . false = �������)

    private Transform firePositionRoot; 
    // �Ѿ��� �߻�� ��ġ�� ȸ���� ������ �ִ� Ʈ������

    private GameObject flash;  
    // �Ѿ��� �߻�ɶ� ���� �÷��� ����Ʈ ���� ������Ʈ

    private Vector3 dir;      
    // �̵� ����(�Է¿� ���� �����)

    private IEnumerator fireCoroutine; 
    // �Ѿ� ����� �ڷ�ƾ

    private PlayerInputAction inputActions;
    // InputSystem �� �Է¾׼�

    private Rigidbody2D rigid;
    private Animator anim;
    private Collider2D bodyCollider;
    private SpriteRenderer spriteRenderer;
    // ��������Ʈ -------------------------------------------------------------------------
    public Action<int> onLifeChange;

    // ������Ƽ --------------------------------------------------------------------------


    int Power
    {
        get => power;
        set
        {
            power = value;  // ���� ������ �Ŀ� ����
            if (power > 3)  // �Ŀ��� 3�� ����� 3�� ����
                power = 3;

            // ������ �ִ� ���̾� ������ ����
            while (firePositionRoot.childCount > 0)
            {
                Transform temp = firePositionRoot.GetChild(0);  // firePositionRoot�� ù��° �ڽ���
                temp.parent = null;         // �θ� �����ϰ�
                Destroy(temp.gameObject);   // ���� ��Ű��
            }

            // �Ŀ� ��޿� �±� ���� ��ġ
            for (int i = 0; i < power; i++)
            {
                GameObject firePos = new GameObject();  // �� ������Ʈ �����ϱ�
                firePos.name = $"FirePosition_{i}";
                firePos.transform.parent = firePositionRoot;        // firePositionRoot�� �ڽ����� �߰�
                firePos.transform.localPosition = Vector3.zero;     // ���� ��ġ�� (0,0,0)���� ����. �Ʒ��ٰ� ���� ���
                //firePos.transform.position = firePositionRoot.transform.position;

                // �Ŀ��� 1 �϶�  : 0��
                // �Ŀ��� 2 �϶�  : -15��, +15��
                // �Ŀ��� 3 �϶�  : -30��, 0��, +30��
                firePos.transform.rotation = Quaternion.Euler(0, 0, (power - 1) * (fireAngle * 0.5f) + i * -fireAngle);
                firePos.transform.Translate(1.0f, 0, 0);

            }
        }
    }


    //���� ��ġ�� ������Ƽ
    int Life
    {
        get => life;
        set
        {
            if (life != value)
            {
                if (life > value)
                {
                    StartCoroutine(EnterInvincibleMode());
                }

                life = value;
                if (life <= 0)
                {
                    life = 0;
                    Dead();
                }

                // (������)?. : ���ʺ����� null�̸� null. null�� �ƴϸ� (������) ����� ����
                onLifeChange?.Invoke(life); // �������� ����ɶ� onLifeCHange��������Ʈ�� ��ϵ� �Լ����� �����Ų��.
            }
        }
    }

    // class A{};
    // class B : A{};
    // A test = new B();

    // �Լ� ------------------------------------------------------------------------------

    // Awake -> OnEnable -> Start : ��ü������ �� ����

    /// <summary>
    /// �� ��ũ��Ʈ�� ����ִ� ���� ������Ʈ�� ������ ���Ŀ� ȣ��
    /// </summary>
    private void Awake()
    {
        

        inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>();    // �ѹ��� ã�� �����ؼ� ��� ����(�޸� �� ���� ���� �Ƴ���)
        anim = GetComponent<Animator>();
        bodyCollider = GetComponent<Collider2D>(); // collider �� capsulecollider2d �� �θ��̱� ������ ���� ��� �����ϴ�.
        spriteRenderer = GetComponent<SpriteRenderer>();

        firePositionRoot = transform.GetChild(0); 
        flash = transform.GetChild(1).gameObject;
        flash.SetActive(false);

        fireCoroutine = Fire();

        life = initialLife;
    }

    private void Start()
    {
        Power = 1;
    }

    /// <summary>
    /// �� �����Ӹ��� ȣ��.
    /// </summary>
    private void Update()
    {
        if (isInvincibleMode)
        {
            timeElapsed += Time.deltaTime * 30.0f;
            float alpha = (Mathf.Cos(timeElapsed) + 1.0f) * 0.5f; // cos�� ����� 1~0���� ����
            spriteRenderer.color = new Color(1, 1, 1, alpha);
        }
    }

    /// <summary>
    /// ���� �ð� ����(���� ������Ʈ �ð� ����)���� ȣ��
    /// </summary>
    private void FixedUpdate()
    {
        if (!isDead)
        {
            //transform.Translate(speed * Time.fixedDeltaTime * dir);

            // �� ��ũ��Ʈ ������ ��� �ִ� ���� ������Ʈ���� Rigidbody2D ������Ʈ�� ã�� ����.(������ null)
            // �׷��� GetComponent�� ���ſ� �Լ� => (Update�� FixedUpdateó�� �ֱ��� �Ǵ� ���� ȣ��Ǵ� �Լ� �ȿ����� �Ⱦ��� ���� ����)
            // Rigidbody2D rigid = GetComponent<Rigidbody2D>();    

            // rigid.AddForce(speed * Time.fixedDeltaTime * dir); // ������ �ִ� �������� �� �� ����
            rigid.MovePosition(transform.position + boost * speed * Time.fixedDeltaTime * dir); // ������ ���� �������� ó���� �� ����

            //fireTimeCount += Time.fixedDeltaTime;
            //if ( isFiring && fireTimeCount > fireInterval )
            //{
            //    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //    fireTimeCount = 0.0f;
            //}
        }
        else
        {
            rigid.AddForce(Vector2.left * 0.1f, ForceMode2D.Impulse);   // �׾��� �� �ڷ� ���鼭 ƨ�ܳ�����
            rigid.AddTorque(10.0f);
        }
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
        InputDisable();
    }

    /// <summary>
    /// �Է¸���. �׼Ǹ��� ��Ȱ��ȭ �ϰ� �Է��̺�Ʈ�� ����� �Լ��� ����
    /// </summary>
    void InputDisable()
    {
        inputActions.Player.Boost.canceled -= OnBoostOff;
        inputActions.Player.Boost.performed -= OnBoostOn;
        inputActions.Player.Fire.canceled -= OnFireStop;
        inputActions.Player.Fire.performed -= OnFireStart;
        inputActions.Player.Move.canceled -= OnMove;    // ������ ���� �Լ� ����(������ ����)
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();  // ������Ʈ�� ������� �� �̻� �Է��� ���� �ʵ��� ��Ȱ��ȭ
    }

    /// <summary>
    /// ������ ��. ù��° Update �Լ��� ����Ǳ� ������ ȣ��.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            // �Ŀ��� �������� �Ծ�����
            Power++;                        // �Ŀ� ���� ��Ű��
            Destroy(collision.gameObject);  // �Ŀ��� ������ ����
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Life--;

        }
    }

    /// <summary>
    /// �浹 ���� �� �������� ����, Ÿ�̸� �ʱ�ȭ
    /// </summary>
    IEnumerator EnterInvincibleMode()
    {
        //bodyCollider.enabled = false;  // �浹�� ���Ͼ�� �����
        gameObject.layer = LayerMask.NameToLayer("Invincible");
        isInvincibleMode = true;       // ������� �ѱ�
        timeElapsed = 0.0f;            // Ÿ�̸� �ʱ�ȭ

        yield return new WaitForSeconds(InvincibleTime);  // �����ð� ���� ���

        spriteRenderer.color = Color.white; //���� ������ �ǵ�����
        isInvincibleMode = false;  // ������� ����
        gameObject.layer = LayerMask.NameToLayer("Player");
        //bodyCollider.enabled = !isDead; // �浹�� �ٽ� �߻��ϰ� ����� (������� ����)
    }

    /// <summary>
    /// ���� ���� �Լ� (������ for EnterInvincibleMode)
    /// </summary>
    IEnumerator GetHit()
    {
        int temp = 0;
        bodyCollider.enabled = false;
        while (temp < InvincibleTime)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(InvincibleTime);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(InvincibleTime);
            temp++;
        }
        bodyCollider.enabled = true;
    }

    /// <summary>
    /// �Ѿ� ����� �ڷ�ƾ �Լ�
    /// </summary>
    IEnumerator Fire()
    {
        while (true)
        {
            for (int i = 0; i < firePositionRoot.childCount; i++)
            {

                // bullet�̶�� �������� firePosition[i]�� ��ġ�� firePosition[i]�� ȸ������ ������
                Instantiate(bulletPrefab,
                    firePositionRoot.GetChild(i).position, firePositionRoot.GetChild(i).rotation);

                // Instantiate(������ ������);    // �������� (0,0,0)��ġ�� (0,0,0)ȸ���� (1,1,1)�����Ϸ� ������� 
                // Instantiate(������ ������, ������ ��ġ, ������ ���� ȸ��)
            }
            flash.SetActive(true); // flash �Ѱ� 
            StartCoroutine(FlashOff()); // 0.1�� �Ŀ� flash �� ���� �ڷ�ƾ ����

            yield return new WaitForSeconds(fireInterval); // �߻� �ð� ���ݸ�ŭ ���
        }
    }

    IEnumerator FlashOff()
    {
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
    }

    void Dead()
    {
        isDead = true;
        GetComponent<Collider2D>().enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Player");
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        InputDisable();
        rigid.gravityScale = 1.0f;
        rigid.freezeRotation = false;
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("OnCollisionExit2D");     // Collider�� ������ �������� ���� ����
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Debug.Log("OnTriggerEnter2D");      // Ʈ���ſ� ���� �� ����
    //    if(collision.CompareTag("PowerUp"))
    //    {
    //        Power++;
    //        Destroy(collision.gameObject);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("OnTriggerExit2D");       // Ʈ���ſ��� ������ �� ����
    //}

    /// <summary>
    /// �̵�ó���� �Լ�
    /// </summary>
    private void OnMove(InputAction.CallbackContext context)
    {
        // Exception : ���� ��Ȳ( ������ �ؾ� ���� ������ �ȵǾ��ִ� ���� �϶� )
        //throw new NotImplementedException();    // NotImplementedException �� �����ض�. => �ڵ� ������ �˷��ֱ� ���� ������ ���̴� �ڵ�

        //Debug.Log("�̵� �Է�");
        dir = context.ReadValue<Vector2>();    // ��� �������� �������� �ϴ����� �Է¹���

        //dir.y > 0   // W�� ������.
        //dir.y == 0  // W,S �� �ƹ��͵� �ȴ�����.
        //dir.y < 0   // S�� ������.
        anim.SetFloat("InputY", dir.y);

    }

    /// <summary>
    /// �Ѿ� �߻� ���� �Է� ó����
    /// </summary>
    private void OnFireStart(InputAction.CallbackContext _)
    {
        //float value = Random.Range(0.0f, 10.0f);  // value���� 0.0 ~ 10.0�� �������� ����.
        //isFiring = true;
        StartCoroutine(fireCoroutine);
    }

    /// <summary>
    /// �Ѿ� �߻� ���� �Է� ó����
    /// </summary>
    private void OnFireStop(InputAction.CallbackContext _)
    {
        StopCoroutine(fireCoroutine); // �ڷ�ƾ ����
    }

    /// <summary>
    /// �̵� �ν�Ʈ �ߵ� �Է� ó����
    /// </summary>
    private void OnBoostOn(InputAction.CallbackContext context)
    {
        boost *= 2.0f; // �̵��ӵ� ��꿡 ���� ����� 2�� ����
    }

    /// <summary>
    /// �̵� �ν�Ʈ ���� �Է� ó����
    /// </summary>
    private void OnBoostOff(InputAction.CallbackContext context)
    {
        boost = 1.0f; // �̵� �ӵ� ��꿡 ���� ����� 1�� ����
    }

}
