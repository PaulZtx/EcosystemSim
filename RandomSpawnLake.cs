using UnityEngine;

public class RandomSpawnLake : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Lake;
    public int count;
    void Start()
    {
        for(int i = 0; i < count; ++i) Instantiate(Lake, RandomField(), Quaternion.identity);
    }
    
    private Vector3 RandomField()
    {
        return new Vector3(Random.Range(-150, 150), 0.1f, Random.Range(-150, 150));
    }
}
