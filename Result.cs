using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    
    public Text ER;
    public Text DR;
    public Text BR;
    public Text AR;
    public Text SR;
    public Text DHR;

    public Text BW;
    public Text DW;
    public Text AW;
    public Text SW;
    public Text DHW;
    void Start()
    {
        ER.text = Animal.countEatRabbits.ToString();
        DR.text = Animal.countDeadRabbitAge.ToString();
        BR.text = Animal.countNewRabbits.ToString();
        AR.text = (Animal.middleAgeRabbits / (Animal.countDeadRabbits + Animal.countEatRabbits)).ToString();
        SR.text = (Animal.countDeadRabbits + Animal.countDeadRabbitAge + Animal.countEatRabbits).ToString();
        BW.text = Animal.countNewWolfs.ToString();
        DW.text = Animal.countDeadWolfAge.ToString();
        AW.text = (Animal.middleAgeWolfs / Animal.countDeadWolfs).ToString();
        SW.text = (Animal.countDeadWolfs + Animal.countDeadWolfAge).ToString();
        DHR.text = Animal.countDeadRabbits.ToString();
        DHW.text = Animal.countDeadWolfs.ToString();
    }
}
