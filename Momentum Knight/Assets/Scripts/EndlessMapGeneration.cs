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
    public float positionleftX;
    public float positionleftY;
    public float positionUpX;
    public float positionUpY;
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
            generatedRooms++;
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
                        generatedRooms++;
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
                point.position += new Vector3(positionUpX, positionUpY, 0);
                break;
            case 1:
                // down
                point.position -= new Vector3(positionUpX, positionUpY, 0);
                break;
            case 2:
                // left
                point.position -= new Vector3(positionleftX, positionleftY, 0);
                break;
            case 3:
                // right
                point.position += new Vector3(positionleftX, positionleftY, 0);
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
