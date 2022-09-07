using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 1. EnemySpawner.cs�� �����Ͽ� Enemy �������� ���������� �����ϰ� ������.
//  1.1.�ݵ�� �ڷ�ƾ���� �ۼ��ؾ� �Ѵ�.

public class EnemySpawner : MonoBehaviour
{
    // �ʿ��� ������ �����ΰ�? -> Enemy ������, ���������� ������ �ϴ� �ð� ����

    public GameObject spawnPrefab_Normal;        // ������ ���� ������
    public GameObject spawnPrefab_Special;       // �Ŀ� �� �ִϹ�
    public float interval = 0.5f;   // ������ �ð� ����

    protected float minY = -4.0f;     // ������ �Ͼ�� ���� ����
    protected float maxY = 4.0f;      // ������ �Ͼ�� �ְ� ����


    // �ʿ��� ����� �����ΰ�? -> Enemy �������� �����ϴ� �ڷ�ƾ
    private void Start()
    {

        StartCoroutine(Spawn());

    }

    protected virtual IEnumerator Spawn()
    {
        while (true) // ���� �ݺ�
        {
            GameObject prefab = spawnPrefab_Normal; // �⺻������ �����ϴ� ���� spawnPrefab_Normal
            if (Random.value < 0.1f) 
            {
                prefab = spawnPrefab_Special; // 10%���� Ȯ���� spawnPrefab_Special�� ����
            }
            
            GameObject powerObj = Instantiate(prefab, transform); // �����ϰ� �θ� �� ������Ʈ�� ����
            powerObj.transform.Translate(0, Random.Range(minY, maxY), 0); //���� ���� ��ġ ����
            yield return new WaitForSeconds(interval); //interval ��ŭ ����
        }
    }


    // ���߿� ������ �׻� �׸��� �Լ�
    protected virtual void OnDrawGizmos()
    {
        //Gizmos.color = new Color(1,0,0);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY) + 2, 1));
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

