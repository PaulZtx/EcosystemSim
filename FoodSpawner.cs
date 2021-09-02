using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    private float delaySpawn;
    private int countFood;
    private float reCount;
    private float delayTimer = 0;
    private float reTimer = 0;
    void Start()
    {
        GiveCountFood();
        for (int i = 0; i < countFood; ++i) CreateFood();
    }
    
    void FixedUpdate()
    {
        if(countFood > 0) CreateFood();
        
        else if (countFood == 0)
        {
            reTimer += Time.fixedDeltaTime;
            if (reTimer >= reCount)
            {
                GiveCountFood();
                reTimer = 0;
            }
        }
    }

    void CreateFood()
    {
        Instantiate(foodPrefab, new Vector3(Random.Range(-200, 200), 0.1f,
                Random.Range(-200, 200)), Quaternion.identity);
        --countFood;
    }

    void GiveCountFood()
    {
        countFood = Random.Range(500, 1000);
        reCount = Random.Range(10f, 30.0f);
    }
}
