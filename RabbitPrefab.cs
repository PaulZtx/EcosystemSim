using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RabbitPrefab : Animal
{
    void Start()
    {
        body = GetComponent<Rigidbody>();
        SetStartParams();
        InvokeRepeating("AgeStep", 0, 50f);
        InvokeRepeating("EditDrink", 0, 2.5f);
        InvokeRepeating("EditHunger", 0, 3f);
        InvokeRepeating("EditPower", 0, 1.2f);
        InvokeRepeating("EditLibido", 0, 1);
    }

    void FixedUpdate()
    {
        IsAlive("Rabbit");
        RandomMove();
        Rotate();
        WaitSomething();
        Checker();
        if (hunger <= criticalHunger) isHunger = Finder("FoodForRabbit");
        else if (drink <= criticalDrink) isDrink = Finder("Water");
        else if (CheckReprodaction())
        {
            isReprodaction = Finder("Rabbit");
            if (sex == (int) Sex.Girl) isWaiter = true;
        }
        MoveToTarget();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (isHunger && other.transform.tag == "FoodForRabbit")
        {
            Destroy(other.gameObject);
            Target = null;
            isHunger = false;
            hunger += Random.Range(20, 40);
            isWaiter = true;
        }
        else if (isDrink && other.transform.tag == "Water")
        {
            drink += Random.Range(40, 50);
            transform.Rotate(Vector3.up, 90f);
            Target = null;
            isDrink = false;
            isWaiter = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall") transform.Rotate(0, 90, 0);
        else if (isReprodaction && other.gameObject.tag == "Rabbit")
        {
            isReprodaction = false;
            Target = null;
            libido = 0;
            RabbitPrefab bunny = other.gameObject.GetComponent<RabbitPrefab>();
            if (bunny.sex != sex)
            {
                            isWaiter = true;
                            hunger = criticalHunger;
                            if (sex == (int) Sex.Girl)
                            {
                                Instantiate(AnimalControl.Rabbit, transform.position, Quaternion.identity);
                                countRabbitsAlive++;
                                countNewRabbits++;
                            }
            }
        }
    }
}