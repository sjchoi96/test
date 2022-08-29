using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    public float speed = 1.0f;

    public float SpawnInterval = 3.0f;

    float minY = -4.5f;
    float maxY = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }
        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator EnemySpawn()//float SpawnInterval, GameObject Enemy
        {
        while(true)
        {
            GameObject obj = Instantiate(Enemy, transform);
            obj.transform.Translate(0, Random.Range(minY, maxY), 0);
            yield return new WaitForSeconds(SpawnInterval);
        }
            
            

            //yield return new WaitForSeconds(SpawnInterval);
            //GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(13f, 13), Random.Range(-5f, 5), 0), Quaternion.identity);
            //StartCoroutine(EnemySpawn(SpawnInterval, Enemy));
        }
}

