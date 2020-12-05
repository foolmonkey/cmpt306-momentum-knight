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

    public GameObject portalPrefab;
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

            handleCurrentDirection(newRoom, direction, prevDirection);

            generatedRooms++;

            prevDirection = direction;
        }
        isCreatingRooms = false;

        ealiestRoom = rooms[0].transform;
        latestRoom = rooms[rooms.Count - 1].transform;
    }

    // Update is called once per frame
    void Update()
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
                    int hall = Mathf.RoundToInt(Random.Range(3, 8));
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
                            handleCurrentDirection(newRoom, direction, prevDirection);
                        }

                        // generate portal on end
                        if (generatedRooms == (roomNumber - 2))
                        {
                            Instantiate(portalPrefab, point.position, Quaternion.identity);
                        }

                        generatedRooms++;

                        prevDirection = direction;
                    }

                    if (generatedRooms < (roomNumber - 8))
                    {
                        ChangeRandomPos();
                    }

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

    public void deleteCorners(GameObject newRoom)
    {
        Destroy(newRoom.transform.Find("NCorner").gameObject);
        Destroy(newRoom.transform.Find("ECorner").gameObject);
        Destroy(newRoom.transform.Find("SCorner").gameObject);
        Destroy(newRoom.transform.Find("WCorner").gameObject);
    }

    public void deleteCoins(GameObject newRoom)
    {
        Destroy(newRoom.transform.Find("NECoins").gameObject);
        Destroy(newRoom.transform.Find("NWCoins").gameObject);
        Destroy(newRoom.transform.Find("SWCoins").gameObject);
        Destroy(newRoom.transform.Find("SECoins").gameObject);
    }

    public void handleUp(GameObject newRoom, int aPrevDirection)
    {
        // prev direction was left
        if (aPrevDirection == 2)
        {
            Destroy(newRoom.transform.Find("NWCoins").gameObject);
            Destroy(newRoom.transform.Find("SWCoins").gameObject);
            Destroy(newRoom.transform.Find("NCorner").gameObject);
            Destroy(newRoom.transform.Find("ECorner").gameObject);
            Destroy(newRoom.transform.Find("NE").gameObject);
            Destroy(newRoom.transform.Find("SE").gameObject);
        }
        // prev direction was right
        else if (aPrevDirection == 3)
        {
            Destroy(newRoom.transform.Find("NWCoins").gameObject);
            Destroy(newRoom.transform.Find("SECoins").gameObject);
            Destroy(newRoom.transform.Find("NCorner").gameObject);
            Destroy(newRoom.transform.Find("ECorner").gameObject);
            Destroy(newRoom.transform.Find("NE").gameObject);
            Destroy(newRoom.transform.Find("NW").gameObject);
        }
        else
        {
            Destroy(newRoom.transform.Find("NWCoins").gameObject);
            Destroy(newRoom.transform.Find("SECoins").gameObject);
            Destroy(newRoom.transform.Find("NE").gameObject);
            Destroy(newRoom.transform.Find("SW").gameObject);
            deleteCorners(newRoom);
        }

    }

    public void handleDown(GameObject newRoom, int aPrevDirection)
    {
        // prev direction was left
        if (aPrevDirection == 2)
        {
            Destroy(newRoom.transform.Find("NCorner").gameObject);
            Destroy(newRoom.transform.Find("ECorner").gameObject);
            Destroy(newRoom.transform.Find("SW").gameObject);
            Destroy(newRoom.transform.Find("NW").gameObject);
        }
        // prev direction was right
        else if (aPrevDirection == 3)
        {
            Destroy(newRoom.transform.Find("NCorner").gameObject);
            Destroy(newRoom.transform.Find("ECorner").gameObject);
            Destroy(newRoom.transform.Find("NE").gameObject);
            Destroy(newRoom.transform.Find("SE").gameObject);
        }
        else
        {
            Destroy(newRoom.transform.Find("NWCoins").gameObject);
            Destroy(newRoom.transform.Find("SECoins").gameObject);
            Destroy(newRoom.transform.Find("NE").gameObject);
            Destroy(newRoom.transform.Find("SW").gameObject);
            deleteCorners(newRoom);
        }
    }

    public void handleLeft(GameObject newRoom, int aPrevDirection)
    {
        // prev direction was up
        if (aPrevDirection == 0)
        {
            Destroy(newRoom.transform.Find("NECoins").gameObject);
            Destroy(newRoom.transform.Find("SECoins").gameObject);
            Destroy(newRoom.transform.Find("NW").gameObject);
            Destroy(newRoom.transform.Find("SW").gameObject);
            Destroy(newRoom.transform.Find("SCorner").gameObject);
            Destroy(newRoom.transform.Find("WCorner").gameObject);
        }
        // prev direction was down
        else if (aPrevDirection == 1)
        {
            Destroy(newRoom.transform.Find("SWCoins").gameObject);
            Destroy(newRoom.transform.Find("SECoins").gameObject);
            Destroy(newRoom.transform.Find("NCorner").gameObject);
            Destroy(newRoom.transform.Find("ECorner").gameObject);
            Destroy(newRoom.transform.Find("SE").gameObject);
            Destroy(newRoom.transform.Find("NE").gameObject);
        }
        else
        {
            Destroy(newRoom.transform.Find("NECoins").gameObject);
            Destroy(newRoom.transform.Find("SWCoins").gameObject);
            Destroy(newRoom.transform.Find("NW").gameObject);
            Destroy(newRoom.transform.Find("SE").gameObject);
            deleteCorners(newRoom);
        }
    }

    public void handleRight(GameObject newRoom, int aPrevDirection)
    {
        // prev direction was up
        if (aPrevDirection == 0)
        {
            Destroy(newRoom.transform.Find("NWCoins").gameObject);
            Destroy(newRoom.transform.Find("NECoins").gameObject);
            Destroy(newRoom.transform.Find("NCorner").gameObject);
            Destroy(newRoom.transform.Find("WCorner").gameObject);
            Destroy(newRoom.transform.Find("NE").gameObject);
            Destroy(newRoom.transform.Find("SW").gameObject);
        }
        // prev direction was down
        else if (aPrevDirection == 1)
        {
            Destroy(newRoom.transform.Find("NWCoins").gameObject);
            Destroy(newRoom.transform.Find("SWCoins").gameObject);
            Destroy(newRoom.transform.Find("SCorner").gameObject);
            Destroy(newRoom.transform.Find("ECorner").gameObject);
            Destroy(newRoom.transform.Find("SW").gameObject);
            Destroy(newRoom.transform.Find("NE").gameObject);
        }
        else
        {
            Destroy(newRoom.transform.Find("NWCoins").gameObject);
            Destroy(newRoom.transform.Find("SECoins").gameObject);
            Destroy(newRoom.transform.Find("NE").gameObject);
            Destroy(newRoom.transform.Find("SW").gameObject);
            deleteCorners(newRoom);
        }
    }

    public void handleCurrentDirection(GameObject newRoom, int aDirection, int aPrevDirection)
    {
        // handle first room
        if (generatedRooms == 0)
        {
            deleteCoins(newRoom);
            Destroy(newRoom.transform.Find("NE").gameObject);
        }
        // handle last room
        else if (generatedRooms == roomNumber - 1)
        {
            deleteCoins(newRoom);

            switch (aDirection)
            {
                case 0:
                    Destroy(newRoom.transform.Find("SW").gameObject);
                    break;
                case 1:
                    Destroy(newRoom.transform.Find("NE").gameObject);
                    break;
                case 2:
                    Destroy(newRoom.transform.Find("SW").gameObject);
                    break;
                case 3:
                    Destroy(newRoom.transform.Find("NW").gameObject);
                    break;
            }
        }
        else
        {
            switch (aDirection)
            {
                case 0:
                    handleUp(newRoom, aPrevDirection);
                    break;
                case 1:
                    handleDown(newRoom, aPrevDirection);
                    break;
                case 2:
                    handleLeft(newRoom, aPrevDirection);
                    break;
                case 3:
                    handleRight(newRoom, aPrevDirection);

                    break;
            }
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
