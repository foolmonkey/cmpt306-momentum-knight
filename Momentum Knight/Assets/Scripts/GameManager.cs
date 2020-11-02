using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Things like starting, ending, and restarting the game will go in the game manager. It is responsible for changing game states

    //Creates static globally accessable variable 
    public static GameManager gameManager;


    void Awake()
    {
        //Check to see if gameManager exists. If it does not then create one
        if (!gameManager)
            gameManager = this;
        else
            Destroy(this);
    }
}
