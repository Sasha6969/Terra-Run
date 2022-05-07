using System.Data.Common;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{



    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;


    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMosnters());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnMosnters()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            //left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-2f, 2f, 2f);

            }
            //right side
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
            }
        }

    }
















}//class
