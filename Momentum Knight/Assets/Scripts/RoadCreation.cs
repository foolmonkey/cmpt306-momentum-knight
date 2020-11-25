using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class RoadCreation : MonoBehaviour
{

    public int direction;

    [Header("Room Infromation")]
    public GameObject roomPrefab;


    [Header("Position Setting")]
    public Transform point;
    public Transform Player;
    public float positionX;
    public float positionY;

    public int roadNumber;

    public List<GameObject> roads = new List<GameObject>();
    // Use this for initialization




    void Start()
    {
        GameObject newRoad = Instantiate(roomPrefab, point.position, Quaternion.identity);
    }




    // Update is called once per frame
    void Update()
    {

        if (Player.position.x > point.position.x / 2 && Player.position.y > point.position.y / 2)
        {


            GameObject newRoad = Instantiate(roomPrefab, point.position, Quaternion.identity);

            roads.Add(newRoad);




            ChangePos();
            if (roadNumber > 2)
            {
                for (int i = 0; i < roadNumber; i++)
                {
                    Destroy(roads[i]);
                    roads.RemoveAt(i);
                    roadNumber = 0;
                }



            }


            void ChangePos()
            {
                point.position += new Vector3(positionX, positionY, 0);

                roadNumber += 1;
            }
        }
    }
}

