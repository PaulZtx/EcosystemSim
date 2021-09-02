using UnityEngine;

public class FoodWatterChecker : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "FoodForRabbit")
        {
            Destroy(other.gameObject);
        }
    }
}
