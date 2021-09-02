using System;
using UnityEngine;
using UnityEngine.UI;

public class AnimalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static Text CountRabbitEaten;
    public static Text CountRabbitDead;
    public static Text CountWolfDead;
    public static Text CountRabbitAlive;
    public static Text CountWolfAlive;
    public static GameObject Rabbit;
    public static GameObject Woolf;
    public GameObject wolf;
    public GameObject rabbit;
    public Text CRE;
    public Text CRD;
    public Text CWD;
    public Text CRA;
    public Text CWA;
    void Start()
    {
        Rabbit = rabbit;
        Woolf = wolf;
        CountRabbitEaten = CRE;
        CountRabbitDead = CRD;
        CountWolfDead = CWD;
        CountRabbitAlive = CRA;
        CountWolfAlive = CWA;
    }

    private void FixedUpdate()
    {
        EditText();
    }

    public static void EditText()
    {
        CountRabbitDead.text = Convert.ToString(Animal.countDeadRabbits + Animal.countDeadRabbitAge);
        CountRabbitEaten.text = Convert.ToString(Animal.countEatRabbits);
        CountWolfDead.text = Convert.ToString(Animal.countDeadWolfs + Animal.countDeadWolfAge);
        CountRabbitAlive.text = Convert.ToString(Animal.countRabbitsAlive);
        CountWolfAlive.text = Convert.ToString(Animal.countWolfsAlive);
    }
    
}
