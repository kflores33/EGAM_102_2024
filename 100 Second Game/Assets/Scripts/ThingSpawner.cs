using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public GameObject spawnPrefab2;

    public GameObject gameOver;
    public PlayerHealth healthManager;

    public Coroutine spawnSquareCoroutine;
    public Coroutine spawnTriangleCoroutine;

    public Transform spawnOrigin;
    public Vector2 spawnArea;

    public int spawnAmount;
    public Vector2 boxSize;

    public List<GameObject> shapePrefabList;

    public bool triangleSpawnStarted;

    //public float thing;

    // Start is called before the first frame update

    void Start()
    {
        spawnSquareCoroutine = StartCoroutine(SpawnCoroutine());
        triangleSpawnStarted = false;
    }

    IEnumerator SpawnCoroutine()
    {
        Vector2 originPoint = spawnOrigin.position;

        for (int i = 0; i < spawnAmount; i++)
        {
            Vector2 newPosition = Vector2.zero;

            bool isPositionOverlap = true;

            int attempts = 100;

            while (isPositionOverlap)
            {
                Vector2 randomOffset = Vector2.zero;
                randomOffset.x = Random.Range(-spawnArea.x, spawnArea.x);
                randomOffset.y = Random.Range(-spawnArea.y, spawnArea.y);

                newPosition = originPoint + randomOffset;

                isPositionOverlap = Physics2D.BoxCast(newPosition, boxSize, 0, Vector2.zero);

                attempts--;
                
                if (attempts <= 0)
                {
                    break;
                }
            }

            //int randomShapeIndex = Random.Range(0, shapePrefabList.Count);
            //GameObject spawnPrefab = shapePrefabList[randomShapeIndex];

            if (spawnPrefab.GetComponent<ThingScript>() == null)
            {
                spawnPrefab.GetComponent<DangerThingScript>().healthManager = healthManager;
            }
            else if (spawnPrefab.GetComponent<ThingScript>() != null)
            {
                spawnPrefab.GetComponent<ThingScript>().healthManager = healthManager;
            }
            
            GameObject newObject = Instantiate(spawnPrefab);
            newObject.transform.position = newPosition;

            if (i == spawnAmount -1)
            {
                Debug.Log("the coroutine should start now");
                if (spawnTriangleCoroutine == null && triangleSpawnStarted == false)
                {
                    spawnTriangleCoroutine = StartCoroutine(SpawnTriangleCoroutine());
                    triangleSpawnStarted = true;
                }
            }

            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator SpawnTriangleCoroutine()
    {
        Vector2 originPoint = spawnOrigin.position;

        for (int i = 0; i < 100; i++)
        {
            Vector2 newPosition = Vector2.zero;

            bool isPositionOverlap = true;

            int attempts = 100;

            // check if the spawn position collides with objects in scene
            while (isPositionOverlap)
            {
                Vector2 randomOffset = Vector2.zero;
                randomOffset.x = Random.Range(-spawnArea.x, spawnArea.x);
                randomOffset.y = Random.Range(-spawnArea.y, spawnArea.y);

                newPosition = originPoint + randomOffset;

                isPositionOverlap = Physics2D.BoxCast(newPosition, boxSize, 0, Vector2.zero);

                attempts--;
                if (attempts <= 0)
                {
                    break;
                }
            }

            // give the prefab its component
            if (spawnPrefab.GetComponent<DangerThingScript>() == null)
            {
                spawnPrefab.GetComponent<ThingScript>().healthManager = healthManager;
            }
            else if (spawnPrefab.GetComponent<DangerThingScript>() != null)
            {
                spawnPrefab.GetComponent<DangerThingScript>().healthManager = healthManager;
            }

            GameObject newObject = Instantiate(spawnPrefab2);
            newObject.transform.position = newPosition;

            yield return new WaitForSeconds(2.5f);
        }
    }


}
