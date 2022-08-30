using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. EnemySpawner.cs�� �����Ͽ� Enemy �������� ���������� �����ϰ� ������.
//  1.1.�ݵ�� �ڷ�ƾ���� �ۼ��ؾ� �Ѵ�.

public class AsteroidSpawner : EnemySpawner
{

    private Transform destination;

    private void Awake() // ������Ʈ ������ ���� Awake �����
    {
        // destination = transform.Find("DestinationArea"); �Ǳ� �Ǵµ� ���� ������
        destination = transform.GetChild(0); //ù��° �ڽ� ã��
    }

    private void Start() // ������Ʈ ���� ���� ȣ��. ���� �ٸ� ������Ʈ�� �����;� �� �� ���
    {
        
    }

    protected override IEnumerator Spawn()
    {
        while (true)    
        {
            GameObject obj = Instantiate(spawnPrefab, transform);  
            obj.transform.Translate(0, Random.Range(minY, maxY), 0);   
            
            Vector3 destPosition = destination.position + new Vector3(0.0f, Random.Range(minY, maxY), 0);
            
            yield return new WaitForSeconds(interval);

            Asteroid asteroid = obj.GetComponent<Asteroid>();
            if (asteroid != null)
            {
                // ��� destPosition �� ���� ���⺤�͸� ����
                asteroid.direction = (destPosition - asteroid.transform.position).normalized;
            }


        }
    }

    // ���߿� ������ �׻� �׸��� �Լ�
    protected override void OnDrawGizmos()
    {
        //Gizmos.color = new Color(1,0,0);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY) + 2, 1));

        if(destination == null)
        {
            destination = transform.GetChild(0);
        }
        if(destination != null)
        {
            Gizmos.DrawWireCube(destination.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY) + 2, 1));
        }
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

