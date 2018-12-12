using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public Text dialogue;
    public GameObject pistolPickup;
    public GameObject zombie;
    public GameObject gate;

    void Start ()
    {
        dialogue.text = "Welcome player! This game is all about survival. But first!";
        Invoke("RevealPistol", 2);
	}

    void RevealPistol()
    {
        pistolPickup.SetActive(true);
        dialogue.text = "Pick this guy up!";
    }

    public void SpawnZombie()
    {
        dialogue.text = "Kill the zombie!";
        Invoke("DoSpawn", 2);
    }

    void DoSpawn()
    {
        zombie.SetActive(true);
        //Invoke("Shootgate", 2);
    }

    public void Shootgate()
    {
        dialogue.text = "Well Done! You have completed the level! To continue, shoot the gate";
        Invoke("Continue", 2);
    }

    public void Continue()
    {

    }


}
