using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. EnemySpawner.cs를 수정하여 Enemy 프리팹을 지속적으로 생성하게 만들어보기.
//  1.1.반드시 코루틴으로 작성해야 한다.

public class AsteroidSpawner : EnemySpawner
{

    private Transform destination;

    private void Awake() // 오브젝트 생성된 직후 Awake 실행됨
    {
        // destination = transform.Find("DestinationArea"); 되긴 되는데 성능 떨어짐
        destination = transform.GetChild(0); //첫번째 자식 찾기
    }

    private void Start() // 업데이트 실행 직전 호출. 나와 다른 오브젝트를 가져와야 할 때 사용
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
                // 운석이 destPosition 로 가는 방향벡터를 구함
                asteroid.direction = (destPosition - asteroid.transform.position).normalized;
            }


        }
    }

    // 개발용 정보를 항상 그리는 함수
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
    //    GameObject obj = Instantiate(Enemy, transform); //생성하고 부모를 이 오브젝트로 설정
    //    obj.transform.Translate(0, Random.Range(minY, maxY), 0); //스폰생성 범위 안에서 랜덤높이 설정
    //    yield return new WaitForSeconds(SpawnInterval); // interval 만큼 대기
    //    }



    //        //yield return new WaitForSeconds(SpawnInterval);
    //        //GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(13f, 13), Random.Range(-5f, 5), 0), Quaternion.identity);
    //        //StartCoroutine(EnemySpawn(SpawnInterval, Enemy));
    //}

}

