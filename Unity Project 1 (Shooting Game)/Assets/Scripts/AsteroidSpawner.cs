using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidSpawner : EnemySpawner
{
    private Transform destination;

    private void Awake()
    {
        // ������Ʈ�� ������ ���� => �� ������Ʈ �ȿ� �ִ� �͵��� �ʱ�ȭ �� �� ���
        //      �� ������Ʈ�ȿ� �ִ� ��� ������Ʈ�� ������ �Ϸ�Ǿ���.
        //      �׸��� �� ������Ʈ�� �ڽ� ������Ʈ�鵵 ��� ������ �Ϸ�Ǿ���.

        //destination = transform.Find("DestinationArea");    // "DestinationArea"��� �̸��� ���� �ڽ� ã��
        destination = transform.GetChild(0);    // ù��° �ڽ� ã��
    }

    //private void Start()
    //{
    //    // ù��° ������Ʈ ���� ���� ȣ��
    //    // ���� �ٸ� ������Ʈ�� �����;� �� �� ���

    //}

    protected override IEnumerator Spawn()
    {
        while (true)    // ���� �ݺ�
        {
            GameObject obj = Instantiate(spawnPrefab_Normal, transform);       // �����ϰ� �θ� �� ������Ʈ�� ����
            obj.transform.Translate(0, Random.Range(minY, maxY), 0);    // ���� ���� ���� �ȿ��� �������� ���� ���ϱ�

            Vector3 destPosition = destination.position + new Vector3(0.0f, Random.Range(minY, maxY), 0.0f);    // ������ ��ġ ����

            Asteroid asteroid = obj.GetComponent<Asteroid>();
            if (asteroid != null)
            {
                // ��� destPosition�� ���� ���⺤�͸� ���ϰ�
                // direction�� ���⺤�ͷ� ����� �ش�.
                asteroid.direction = (destPosition - asteroid.transform.position).normalized;
                
            }

            yield return new WaitForSeconds(interval);  // interval��ŭ ���



        }


    }

    // ���߿� ������ �׻� �׸��� �Լ�
    protected override void OnDrawGizmos()
    {
        //Gizmos.color = new Color(1,0,0);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY) + 2, 1));

        if (destination == null)
        {
            destination = transform.GetChild(0);
        }
        Gizmos.DrawWireCube(destination.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY) + 2, 1));
    }


    //IEnumerator EnemySpawn()//float SpawnInterval, GameObject Enemy
    //{
    //    while(true)
    //    {
    //    GameObject obj = Instantiate(Enemy, transform); //�����ϰ� �θ� �� ������Ʈ�� ����
    //    obj.transform.Translate(0, Random.Range(minY, maxY), 0); //�������� ���� �ȿ��� �������� ����
    //    yield return new WaitForSeconds(SpawnInterval); // interval ��ŭ ���
    //    }



    //        //yield return new WaitForSeconds(SpawnInterval);
    //        //GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(13f, 13), Random.Range(-5f, 5), 0), Quaternion.identity);
    //        //StartCoroutine(EnemySpawn(SpawnInterval, Enemy));
    //}

}
