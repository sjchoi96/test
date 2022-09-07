using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UIElements;

public class PowerUp : MonoBehaviour
{
    public float moveSpeed = 1.0f;          // �̵��ӵ�
    public float dirChangeTime = 5.0f;      // �̵����� �ٲ�µ� �ɸ��� �ð�
    public float selfDestroyTime = 10.0f;   // �������µ� �ɸ��� �ð�
    

    Player player;  // �Ŀ��� �������� �̵����� ������ �ʿ��� �÷��̾�
    Vector2 dir;    // ���� �̵�����
    WaitForSeconds waitTime;  // �ڷ�ƾ���� ����ϱ� ���� ��ٸ��� �ð�

    private void Start()
    {
        waitTime = new WaitForSeconds(dirChangeTime); // dirChangeTime ��ŭ ��ٸ����� waitTime �̸� ����
        player = FindObjectOfType<Player>();  // Player Ÿ���� ã��
        SetRandomDir();  // �����ϰ� ���� �̵����� ����
        StartCoroutine(DirChange());  // �ڷ�ƾ �����ؼ� ���� �ð� �������� �̵����� ����ǰ� ����
        Destroy(this.gameObject, selfDestroyTime);  // selfDestroyTime �� �Ŀ� ������ �������
    }

    private void Update()
    { 
        
        transform.Translate(moveSpeed * Time.deltaTime * dir);

    }

    IEnumerator DirChange()
    {
        while(true) // ���� �ݺ�
        {
            yield return waitTime;  // dirChangeTime ��ŭ ����� �Ŀ�
            SetRandomDir(false);    // �����ϰ� ���� �̵� ���� ����
        }
    }

    void SetRandomDir(bool allRandom = true)  // ����Ʈ �Ķ����. ���� �������� ������ ����Ʈ ���� ��� ����.
    {
        if (allRandom)
        {
            dir = Random.insideUnitCircle;  // ������ 1�� ������ ������ ��ġ ���� => �� ���� �������� ������ ��ġ�� ���� ���� ���� ����
            dir = dir.normalized;  // ���� ���ͷ� ����
        }
        else
        {
            Vector2 playerToPowerUp = transform.position - player.transform.position; // �÷��̾� ��ġ���� �Ŀ��� ������ ��ġ�� ���� ���� ���� ���.
            playerToPowerUp = playerToPowerUp.normalized;  // �������ͷ� ����

            if (Random.value < 0.6) // 60%Ȯ��
            {
                // playerToPowerUp ���͸� z ������ -90~+90 ��ŭ ȸ�����Ѽ� dir �� �ֱ�
                dir = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * playerToPowerUp;
            }
            else // 40%Ȯ��
            {
               
                dir = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * playerToPowerUp;
            }
              
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            dir = Vector2.Reflect(dir, collision.contacts[0].normal);
   
        }
    }

}
