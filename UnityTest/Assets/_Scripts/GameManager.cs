using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    public Transform spawnPoint;

    public GameObject chickenPrefab;

    public int maxChickenCount = 10;

    public int currentChickenCount = 0;

    public float spawnRateInSeconds = 5f;

    private void OnEnable()
    {
        Chicken.OnChickenKilled += OnChickenKilled;
    }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnChickensOvertime());

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnChickensOvertime()
    {
        while (true)
        {
            if (currentChickenCount <= maxChickenCount)
            {
                Instantiate(chickenPrefab, RandomCircle(spawnPoint.position, 10.0f), chickenPrefab.transform.rotation);
                currentChickenCount++;

            }
            yield return new WaitForSeconds(spawnRateInSeconds);
        }
    }

    Vector3 RandomCircle(Vector3 center, float maxRadius)
    {

        float groundLevel = 0f;
        float ang = Random.value * 360;

        float randomRadius = Random.Range(0, maxRadius);

        Vector3 pos;
        pos.x = center.x + randomRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = groundLevel;
        pos.z = center.z + randomRadius * Mathf.Cos(ang * Mathf.Deg2Rad); ;
        return pos;
    }

    public void OnChickenKilled()
    {
        currentChickenCount--;
    }
}
