using UnityEngine;

public class WoolfSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WoolfPrefab;
    private int countWoolfs;
    void Start()
    {
        countWoolfs = UIManager.countWoolfs;
        Animal.countWolfsAlive = countWoolfs;
        CreateWoolf();
    }

    void CreateWoolf()
    {
        for (int i = 0; i < countWoolfs; ++i)
        {
            Instantiate(WoolfPrefab,
                new Vector3(Random.Range(-200, 200), 1, Random.Range(-200, 200)),
                Quaternion.identity);
        }
    }
}
