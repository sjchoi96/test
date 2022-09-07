using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //public delegate void DelegateName();    // 이런 종류의 델리게이트가 있다 (리턴없고 파라메터도 없는 함수를 저장하는 델리게이트)
    //public DelegateName del;      // DelegateName 타입으로 del이라는 이름의 델리게이트를 만듬
    //Action del2;                  // 리턴타입이 void, 파라메터도 없는 델리게이트 del2를 만듬
    //Action<int> del3;             // 리턴타입이 void, 파라메터는 int 하나인 델리게이트 del3을 만듬
    //Func<int, float> del4;        // 리턴타입이 int고 파라메터는 float 하나인 델리게이트 del4를 만듬

    //public 변수----------------------------------------------------------------------
    [Header("각종 프리팹")]
    public GameObject bulletPrefab;   // 총알용프리팹
    public GameObject explosionPrefab; // 비행기 폭팔용 프리팹

    [Header("플레이어 스텟")]
    public float speed = 1.0f;      // 플레이어의 이동 속도(초당 이동 속도)
    public float fireInterval = 0.5f; // 총알 발사 시간 간격

    [Header("게임 기본 설정")]
    public float InvincibleTime = 1.0f;
    public int initialLife = 3;     // 플레이어 체력


    // private 변수-----------------------------------------------------------------------
    
    private int life; 
    // 현재 생명 수치

    private int power = 0; 
    // 파워업 아이템을 획득한 갯수 (최대값은 3개)

    private float timeElapsed = 0.0f; 
    // 무적상태에 들어간 시간 (의 30배)

    private float boost = 1.0f; 
    // 부스트 속도

    private float fireAngle = 30.0f; 
    // 총알이 한번에 여러발 발사될 때 총알간의 사이 각도

    private bool isInvincibleMode = false; 
    // 무적상태 표시용 (true = 무적 . false = 일반상태)

    private bool isDead = false; 
    // 플레이어 사망여부 (true = 사망 . false = 살아있음)

    private Transform firePositionRoot; 
    // 총알이 발사될 위치와 회전을 가지고 있는 트랜스폼

    private GameObject flash;  
    // 총알이 발사될때 보일 플래시 이펙트 게임 오브젝트

    private Vector3 dir;      
    // 이동 방향(입력에 따라 변경됨)

    private IEnumerator fireCoroutine; 
    // 총알 연사용 코루틴

    private PlayerInputAction inputActions;
    // InputSystem 용 입력액션

    private Rigidbody2D rigid;
    private Animator anim;
    private Collider2D bodyCollider;
    private SpriteRenderer spriteRenderer;
    // 델리게이트 -------------------------------------------------------------------------
    public Action<int> onLifeChange;

    // 프로퍼티 --------------------------------------------------------------------------


    int Power
    {
        get => power;
        set
        {
            power = value;  // 들어온 값으로 파워 설정
            if (power > 3)  // 파워가 3을 벗어나면 3을 제한
                power = 3;

            // 기존에 있는 파이어 포지션 제거
            while (firePositionRoot.childCount > 0)
            {
                Transform temp = firePositionRoot.GetChild(0);  // firePositionRoot의 첫번째 자식을
                temp.parent = null;         // 부모 제거하고
                Destroy(temp.gameObject);   // 삭제 시키기
            }

            // 파워 등급에 맞기 새로 배치
            for (int i = 0; i < power; i++)
            {
                GameObject firePos = new GameObject();  // 빈 오브젝트 생성하기
                firePos.name = $"FirePosition_{i}";
                firePos.transform.parent = firePositionRoot;        // firePositionRoot의 자식으로 추가
                firePos.transform.localPosition = Vector3.zero;     // 로컬 위치를 (0,0,0)으로 변경. 아래줄과 같은 기능
                //firePos.transform.position = firePositionRoot.transform.position;

                // 파워가 1 일때  : 0도
                // 파워가 2 일때  : -15도, +15도
                // 파워가 3 일때  : -30도, 0도, +30도
                firePos.transform.rotation = Quaternion.Euler(0, 0, (power - 1) * (fireAngle * 0.5f) + i * -fireAngle);
                firePos.transform.Translate(1.0f, 0, 0);

            }
        }
    }


    //생명 수치용 프로퍼티
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

                // (변수명)?. : 왼쪽변수가 null이면 null. null이 아니면 (변수명) 멤버에 접근
                onLifeChange?.Invoke(life); // 라이프가 변경될때 onLifeCHange델리게이트에 등록된 함수들을 실행시킨다.
            }
        }
    }

    // class A{};
    // class B : A{};
    // A test = new B();

    // 함수 ------------------------------------------------------------------------------

    // Awake -> OnEnable -> Start : 대체적으로 이 순서

    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 생성된 직후에 호출
    /// </summary>
    private void Awake()
    {
        

        inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>();    // 한번만 찾고 저장해서 계속 쓰기(메모리 더 쓰고 성능 아끼기)
        anim = GetComponent<Animator>();
        bodyCollider = GetComponent<Collider2D>(); // collider 가 capsulecollider2d 의 부모이기 때문에 같이 사용 가능하다.
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
    /// 매 프레임마다 호출.
    /// </summary>
    private void Update()
    {
        if (isInvincibleMode)
        {
            timeElapsed += Time.deltaTime * 30.0f;
            float alpha = (Mathf.Cos(timeElapsed) + 1.0f) * 0.5f; // cos의 결과를 1~0으로 변경
            spriteRenderer.color = new Color(1, 1, 1, alpha);
        }
    }

    /// <summary>
    /// 일정 시간 간격(물리 업데이트 시간 간격)으로 호출
    /// </summary>
    private void FixedUpdate()
    {
        if (!isDead)
        {
            //transform.Translate(speed * Time.fixedDeltaTime * dir);

            // 이 스크립트 파일이 들어 있는 게임 오브젝트에서 Rigidbody2D 컴포넌트를 찾아 리턴.(없으면 null)
            // 그런데 GetComponent는 무거운 함수 => (Update나 FixedUpdate처럼 주기적 또는 자주 호출되는 함수 안에서는 안쓰는 것이 좋다)
            // Rigidbody2D rigid = GetComponent<Rigidbody2D>();    

            // rigid.AddForce(speed * Time.fixedDeltaTime * dir); // 관성이 있는 움직임을 할 때 유용
            rigid.MovePosition(transform.position + boost * speed * Time.fixedDeltaTime * dir); // 관성이 없는 움직임을 처리할 때 유용

            //fireTimeCount += Time.fixedDeltaTime;
            //if ( isFiring && fireTimeCount > fireInterval )
            //{
            //    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //    fireTimeCount = 0.0f;
            //}
        }
        else
        {
            rigid.AddForce(Vector2.left * 0.1f, ForceMode2D.Impulse);   // 죽었을 때 뒤로 돌면서 튕겨나가기
            rigid.AddTorque(10.0f);
        }
    }

    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 활성화 되었을때 호출
    /// </summary>
    private void OnEnable()
    {
        inputActions.Player.Enable();   // 오브젝트가 생성되면 입력을 받도록 활성화
        inputActions.Player.Move.performed += OnMove;   // Move액션이 performed 일 때 OnMove 함수 실행하도록 연결
        inputActions.Player.Move.canceled += OnMove;    // Move액션이 canceled 일 때 OnMove 함수 실행하도록 연결
        inputActions.Player.Fire.performed += OnFireStart;
        inputActions.Player.Fire.canceled += OnFireStop;
        inputActions.Player.Boost.performed += OnBoostOn;
        inputActions.Player.Boost.canceled += OnBoostOff;
    }

    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 비활성화 되었을 때 호출
    /// </summary>
    private void OnDisable()
    {
        InputDisable();
    }

    /// <summary>
    /// 입력막기. 액션맵을 비활성화 하고 입력이벤트에 연결된 함수들 제거
    /// </summary>
    void InputDisable()
    {
        inputActions.Player.Boost.canceled -= OnBoostOff;
        inputActions.Player.Boost.performed -= OnBoostOn;
        inputActions.Player.Fire.canceled -= OnFireStop;
        inputActions.Player.Fire.performed -= OnFireStart;
        inputActions.Player.Move.canceled -= OnMove;    // 연결해 놓은 함수 해제(안전을 위해)
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();  // 오브젝트가 사라질때 더 이상 입력을 받지 않도록 비활성화
    }

    /// <summary>
    /// 시작할 때. 첫번째 Update 함수가 실행되기 직전에 호출.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            // 파워업 아이템을 먹었으면
            Power++;                        // 파워 증가 시키고
            Destroy(collision.gameObject);  // 파워업 아이템 삭제
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Life--;

        }
    }

    /// <summary>
    /// 충돌 막은 후 무적모드로 설정, 타이머 초기화
    /// </summary>
    IEnumerator EnterInvincibleMode()
    {
        //bodyCollider.enabled = false;  // 충돌이 안일어나게 만들기
        gameObject.layer = LayerMask.NameToLayer("Invincible");
        isInvincibleMode = true;       // 무적모드 켜기
        timeElapsed = 0.0f;            // 타이머 초기화

        yield return new WaitForSeconds(InvincibleTime);  // 무적시간 동안 대기

        spriteRenderer.color = Color.white; //원래 색으로 되돌리기
        isInvincibleMode = false;  // 무적모드 끄기
        gameObject.layer = LayerMask.NameToLayer("Player");
        //bodyCollider.enabled = !isDead; // 충돌이 다시 발생하게 만들기 (살아있을 때만)
    }

    /// <summary>
    /// 따로 만든 함수 (연습용 for EnterInvincibleMode)
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
    /// 총알 연사용 코루틴 함수
    /// </summary>
    IEnumerator Fire()
    {
        while (true)
        {
            for (int i = 0; i < firePositionRoot.childCount; i++)
            {

                // bullet이라는 프리팹을 firePosition[i]의 위치에 firePosition[i]의 회전으로 만들어라
                Instantiate(bulletPrefab,
                    firePositionRoot.GetChild(i).position, firePositionRoot.GetChild(i).rotation);

                // Instantiate(생성할 프리팹);    // 프리팹이 (0,0,0)위치에 (0,0,0)회전에 (1,1,1)스케일로 만들어짐 
                // Instantiate(생성할 프리팹, 생성할 위치, 생성될 때의 회전)
            }
            flash.SetActive(true); // flash 켜고 
            StartCoroutine(FlashOff()); // 0.1초 후에 flash 를 끄는 코루틴 실행

            yield return new WaitForSeconds(fireInterval); // 발사 시간 간격만큼 대기
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
    //    Debug.Log("OnCollisionExit2D");     // Collider와 접촉이 떨어지는 순간 실행
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Debug.Log("OnTriggerEnter2D");      // 트리거에 들어갔을 때 실행
    //    if(collision.CompareTag("PowerUp"))
    //    {
    //        Power++;
    //        Destroy(collision.gameObject);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("OnTriggerExit2D");       // 트리거에서 나갔을 때 실행
    //}

    /// <summary>
    /// 이동처리용 함수
    /// </summary>
    private void OnMove(InputAction.CallbackContext context)
    {
        // Exception : 예외 상황( 무엇을 해야 할지 지정이 안되어있는 예외 일때 )
        //throw new NotImplementedException();    // NotImplementedException 을 실행해라. => 코드 구현을 알려주기 위해 강제로 죽이는 코드

        //Debug.Log("이동 입력");
        dir = context.ReadValue<Vector2>();    // 어느 방향으로 움직여야 하는지를 입력받음

        //dir.y > 0   // W를 눌렀다.
        //dir.y == 0  // W,S 중 아무것도 안눌렀다.
        //dir.y < 0   // S를 눌렀다.
        anim.SetFloat("InputY", dir.y);

    }

    /// <summary>
    /// 총알 발사 시작 입력 처리용
    /// </summary>
    private void OnFireStart(InputAction.CallbackContext _)
    {
        //float value = Random.Range(0.0f, 10.0f);  // value에는 0.0 ~ 10.0의 랜덤값이 들어간다.
        //isFiring = true;
        StartCoroutine(fireCoroutine);
    }

    /// <summary>
    /// 총알 발사 중지 입력 처리용
    /// </summary>
    private void OnFireStop(InputAction.CallbackContext _)
    {
        StopCoroutine(fireCoroutine); // 코루틴 정지
    }

    /// <summary>
    /// 이동 부스트 발동 입력 처리용
    /// </summary>
    private void OnBoostOn(InputAction.CallbackContext context)
    {
        boost *= 2.0f; // 이동속도 계산에 들어가는 계수를 2로 변경
    }

    /// <summary>
    /// 이동 부스트 해제 입력 처리용
    /// </summary>
    private void OnBoostOff(InputAction.CallbackContext context)
    {
        boost = 1.0f; // 이동 속도 계산에 들어가는 계수를 1로 변경
    }

}
