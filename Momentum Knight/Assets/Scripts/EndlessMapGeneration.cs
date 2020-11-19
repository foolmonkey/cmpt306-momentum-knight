using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class EndlessMapGeneration : MonoBehaviour
{
    public int direction;
    private int prevDirection;

    private bool isCreatingRooms;
    [Header("Room Information")]
    public GameObject roomPrefab;
    public int roomNumber;
    public int generatedRooms;
    public Color startColor, endColor;

    private Transform ealiestRoom;
    private Transform latestRoom;


    [Header("Position Setting")]
    public Transform point;

    public float positionRight;
    public float positionUp;

    private Vector3 currentDirectionVector;
    public LayerMask roomLayer;

    // Use this for initializations
    public List<GameObject> rooms = new List<GameObject>();

    [Header("Player")]
    public Transform playerTransform;

    void Start()
    {
        // get player
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // track generated rooms
        generatedRooms = 0;

        isCreatingRooms = true;
        for (int i = 0; i < 5; i++)
        {
            GameObject newRoom = Instantiate(roomPrefab, point.position, Quaternion.identity);

            rooms.Add(newRoom);
            MoveToCurrentPosition();
            prevDirection = 0;
            direction = 0;

            deleteWalls(newRoom);

            generatedRooms++;

            prevDirection = direction;
        }
        isCreatingRooms = false;

        ealiestRoom = rooms[0].transform;
        latestRoom = rooms[rooms.Count - 1].transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceFromEarliestRoom = Vector3.Distance(playerTransform.position, ealiestRoom.position);
        float distanceFromLatestRoom = Vector3.Distance(playerTransform.position, latestRoom.position);

        if (distanceFromLatestRoom < 20)
        {
            if (generatedRooms < roomNumber)
            {
                if (!isCreatingRooms)
                {
                    isCreatingRooms = true;
                    int hall = Mathf.RoundToInt(Random.Range(3, 10));
                    if (hall > roomNumber - generatedRooms)
                    {
                        hall = roomNumber - generatedRooms;
                    }

                    for (int i = 0; i < hall; i++)
                    {
                        GameObject newRoom = Instantiate(roomPrefab, point.position, Quaternion.identity);
                        rooms.Add(newRoom);
                        MoveToCurrentPosition();

                        // delete walls depending on direction
                        if (i < hall)
                        {
                            deleteWalls(newRoom);
                        }

                        generatedRooms++;

                        prevDirection = direction;
                    }
                    ChangeRandomPos();

                    isCreatingRooms = false;
                }
            }
        }

        if (distanceFromEarliestRoom > 20)
        {
            Destroy(rooms[0]);
            rooms.Remove(rooms[0]);
        }

        ealiestRoom = rooms[0].transform;
        latestRoom = rooms[rooms.Count - 1].transform;
    }

    public void MoveToCurrentPosition()
    {
        switch (direction)
        {
            case 0:
                // up
                point.position += new Vector3(positionRight, positionUp, 0);
                break;
            case 1:
                // down
                point.position += new Vector3(-positionRight, -positionUp, 0);
                break;
            case 2:
                // left
                point.position += new Vector3(-positionRight, positionUp, 0);
                break;
            case 3:
                // right
                point.position += new Vector3(positionRight, -positionUp, 0);
                break;
        }
    }

    public void deleteWalls(GameObject newRoom)
    {
        switch (direction)
        {
            // up
            case 0:
                if (prevDirection == 2)
                {
                    Destroy(newRoom.transform.Find("SE").gameObject);
                }
                else if (prevDirection == 3)
                {
                    Destroy(newRoom.transform.Find("NW").gameObject);
                }
                Destroy(newRoom.transform.Find("NE").gameObject);
                Destroy(newRoom.transform.Find("SW").gameObject);
                break;
            // down
            case 1:
                if (prevDirection == 2)
                {
                    Destroy(newRoom.transform.Find("NW").gameObject);
                }
                else if (prevDirection == 3)
                {
                    Destroy(newRoom.transform.Find("SE").gameObject);
                }
                Destroy(newRoom.transform.Find("NE").gameObject);
                Destroy(newRoom.transform.Find("SW").gameObject);
                break;
            // left
            case 2:
                if (prevDirection == 0)
                {
                    Destroy(newRoom.transform.Find("SW").gameObject);
                }
                else if (prevDirection == 1)
                {
                    Destroy(newRoom.transform.Find("NE").gameObject);
                }
                Destroy(newRoom.transform.Find("NW").gameObject);
                Destroy(newRoom.transform.Find("SE").gameObject);
                break;
            // right
            case 3:
                if (prevDirection == 0)
                {
                    Destroy(newRoom.transform.Find("SW").gameObject);
                }
                else if (prevDirection == 1)
                {
                    Destroy(newRoom.transform.Find("NE").gameObject);
                }
                Destroy(newRoom.transform.Find("NE").gameObject);
                Destroy(newRoom.transform.Find("SW").gameObject);
                break;
        }
    }

    public void ChangeRandomPos()
    {
        do
        {
            prevDirection = direction;

            if (prevDirection == 0 || prevDirection == 1)
            {
                direction = Mathf.RoundToInt(Random.Range(2, 3));
            }
            else if (prevDirection == 2 || prevDirection == 3)
            {
                direction = Mathf.RoundToInt(Random.Range(0, 1));

            }

        } while (Physics2D.OverlapCircle(point.position, 0.2f, roomLayer));
    }
}
