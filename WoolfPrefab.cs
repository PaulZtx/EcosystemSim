using UnityEngine;
using Random = UnityEngine.Random;

public class WoolfPrefab : Animal
{

    void Start()
    {
        body = GetComponent<Rigidbody>();
        SetStartParams();
        InvokeRepeating("AgeStep", 0, 50f);
        InvokeRepeating("EditDrink", 0, 2.5f);
        InvokeRepeating("EditHunger", 0, 3f);
        InvokeRepeating("EditPower", 0, 1.2f);
        InvokeRepeating("EditLibido", 0, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsAlive("Wolf");
        RandomMove();
        Rotate();
        WaitSomething();
        Checker();
        if (hunger <= criticalHunger) isHunger = Finder("Rabbit");
        else if (drink <= criticalDrink) isDrink = Finder("Water");
        else if (CheckReprodaction())
        {
            isReprodaction = Finder("Woolf");
            if (sex == (int) Sex.Girl) isWaiter = true;
        }
        MoveToTarget();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isHunger && other.gameObject.tag == "Rabbit")
        {
            Target = null;
            Destroy(other.gameObject);
            countEatRabbits++;
            countRabbitsAlive--;
            hunger += Random.Range(45, 66);
            isHunger = false;
            isWaiter = true;
        }
        else if (isReprodaction && other.gameObject.tag == "Woolf")
        {
            WoolfPrefab wolf = other.gameObject.GetComponent<WoolfPrefab>();
            isReprodaction = false;
            Target = null;
            libido = 0;
            if (wolf.sex != this.sex)
            {
                isWaiter = true;
                hunger = criticalHunger;
                if (sex == (int) Sex.Girl)
                {
                    Instantiate(AnimalControl.Woolf, transform.position, Quaternion.identity);
                    countWolfsAlive++;
                    countNewWolfs++;
                }
            }
        }
        if(other.gameObject.tag == "Wall") transform.Rotate(0, 90, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDrink && other.transform.tag == "Water")
        {
            drink += Random.Range(40, 50);
            transform.Rotate(Vector3.up, 90f);
            Target = null;
            isDrink = false;
            isWaiter = true;
        }
    }
    
}
