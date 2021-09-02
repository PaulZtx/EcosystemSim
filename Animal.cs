using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Animal : MonoBehaviour
{
    public static int countEatRabbits = 0;
    public static int countDeadRabbits = 0;
    public static int countDeadRabbitAge = 0;
    public static int countDeadWolfs = 0;
    public static int countRabbitsAlive = 0;
    public static int countWolfsAlive = 0;
    public static int countNewRabbits = 0;
    public static int countNewWolfs = 0;
    public static int middleAgeRabbits = 0;
    public static int middleAgeWolfs = 0;
    public static int countDeadWolfAge = 0;

    private protected int drink;
    private protected int hunger;
    private protected int age;
    private protected int power;
    private protected int sex;
    private protected int ageCount = 0;
    public int maxAge;
    public int maxPower;
    public int maxHunger;
    public int maxDrink;
    public int criticalHunger = 30;
    public int criticalDrink = 20;
    public float radius;
    public float speed;
    public float timerRotate;
    private float currentTimeRotate = 0;
    public float timerWaiter;
    private float currentTimerWaiter = 0;
    public bool isDrink = false;
    public bool isHunger = false;
    public bool isWaiter = false;
    public bool isReprodaction = false;
    private protected  GameObject Target;
    public int libido = 0;
    public int minLibido;
    public Rigidbody body;
    protected enum Sex
    {
        Boy = 0, 
        Girl = 1
    }
    
    public bool Finder(string target)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        Target = MinDistance(hitColliders, target);
        if (Target == null) return false;
        return true;
    }

    private protected GameObject MinDistance(Collider[] hitColliders, string target)
    {
        float minDistance = 1000f;
        GameObject PreTarget = null;
        float distance = 1001f;
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.transform.tag == target && hitCollider.gameObject != this.gameObject)
            {
                distance = Vector3.Distance(transform.position, hitCollider.gameObject.transform.position);
                if (distance <= minDistance)
                {
                    minDistance = distance;
                    PreTarget = hitCollider.gameObject;
                }
            }
        }
        return PreTarget;
    }

    public void MoveToTarget()
    {
        if (Target != null)
        {
            transform.LookAt(Target.transform.position);
            float speed1 = speed * Time.fixedDeltaTime;
            body.MovePosition(transform.position + transform.forward * speed1);
        }
    }

    public void Checker()
    {
        if (power > maxPower) power = maxPower;
        if (power < 0)
        {
            power = 0;
            isWaiter = true;
        }
        if (drink > maxDrink) drink = maxDrink;
        if (drink < 0) drink = 0;
        if (hunger > maxHunger) hunger = maxHunger;
        if (hunger < 0) hunger = 0;
    }

    public bool CheckReprodaction()
    {
        if (libido >= minLibido) return true;
        return false;
    }

    public void RandomMove()
    {
        if (!isHunger && !isDrink && !isWaiter && !isReprodaction)
        {
            float speed1 = speed * Time.fixedDeltaTime;
            body.MovePosition(transform.position + transform.forward * speed1);
        }
    }
    public void Rotate()
    {
        if (currentTimeRotate >= timerRotate && !isDrink && !isHunger && !isWaiter && !isReprodaction)
        {
            int choose = Random.Range(0, 2);
            if (choose == 0) transform.Rotate(Vector3.up, Random.Range(0, 120));
            else transform.Rotate(Vector3.up, Random.Range(-120, -1));
            currentTimeRotate = 0;
        }
        else currentTimeRotate += Time.fixedDeltaTime;
    }

    public void SetStartParams()
    {
        sex = Random.Range(0, 2) == 0 
            ? (int) Sex.Boy 
            : (int) Sex.Girl;
        age = Random.Range(0, 2) == 0 
            ? maxAge + maxAge % Random.Range(1, 6) 
            : maxAge - maxAge % Random.Range(1, 6);
        speed = Random.Range(0, 2) == 0 
                ? speed + speed % Random.Range(1, 4)
                : speed - speed % Random.Range(1, 4);
        hunger = Random.Range(maxHunger / 2, maxHunger + 1); 
        drink = Random.Range(maxDrink / 2, maxDrink + 1); 
        power = Random.Range(maxPower / 2, maxPower + 1); 
    }

    public void IsAlive(string Animal)
    {
        if (ageCount >= age)
        {
            if (Animal == "Rabbit")
            {
                middleAgeRabbits += age;
                countDeadRabbitAge++;
                countRabbitsAlive--;
            }
            else if (Animal == "Wolf")
            {
                middleAgeWolfs += age;
                countDeadWolfAge++;
                countWolfsAlive--;
            }
            Destroy(gameObject);
        }
        else if (drink == 0 || hunger == 0)
        {
            if (Animal == "Rabbit")
            {
                middleAgeRabbits += age;
                countDeadRabbits++;
                countRabbitsAlive--;
            }
            else if (Animal == "Wolf")
            {
                middleAgeWolfs += age;
                countDeadWolfs++;
                countWolfsAlive--;
            }
            Destroy(gameObject);
        }
    }

    public void WaitSomething()
    {
        if (isWaiter)
        {
            if (currentTimerWaiter >= timerWaiter)
            {
                isWaiter = false;
                currentTimerWaiter = 0;
                power += Random.Range(25, 46);
            }
            currentTimerWaiter += Time.fixedDeltaTime;
        }
    }

    public void AgeStep() => ageCount++;
    public void EditHunger() => hunger -= Random.Range(4, 8);
    public void EditPower() => power -= Random.Range(3, 8);
    public void EditDrink() => drink -= Random.Range(2, 5);
    public void EditLibido() => libido += (hunger >= maxHunger / 2 && drink >= maxDrink / 2) ? 5 : 0;
}
