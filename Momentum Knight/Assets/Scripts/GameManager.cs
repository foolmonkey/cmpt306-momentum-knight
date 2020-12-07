using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Things like starting, ending, and restarting the game will go in the game manager. It is responsible for changing game states

    //Creates static globally accessable variable 
    public static GameManager gameManager;
    public static int score;
    public static int totalScore;

    public static int prevMapIndex;

    void Awake()
    {
        //Check to see if gameManager exists. If it does not then create one
        if (!gameManager)
            gameManager = this;
        else
            Destroy(this);

    }

    public void setScore(int newScore)
    {
        score = newScore;
        totalScore += newScore;
    }

    public int getScore()
    {
        return score;
    }

    public void setTotalScore(int newScore)
    {
        totalScore = newScore;
    }

    public int getTotalScore()
    {
        return totalScore;
    }

    public void setPrevMapIndex(int newIndex)
    {
        prevMapIndex = newIndex;
    }

    public int getPrevMapIndex()
    {
        return prevMapIndex;
    }
}
