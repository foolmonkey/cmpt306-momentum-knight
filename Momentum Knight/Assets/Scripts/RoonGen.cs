using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class RoonGen : MonoBehaviour {

	public int direction;

	[Header("Room Infromation")]
	public GameObject roomPrefab;
	public int roomNumber;
	public Color startColor,endColor;

	[Header ("Position Setting")]
	public Transform point;
	public float positionleftX;
	public float positionleftY;
	public float positionUpX;
	public float positionUpY;
	public LayerMask roomLayer;
	// Use this for initialization

	public List<GameObject> rooms = new List<GameObject>();


	void Start () {
		for (int i = 0; i < roomNumber; i++){


			GameObject newRoom =Instantiate(roomPrefab, point.position, Quaternion.identity);

			rooms.Add (newRoom);
	

			ChangePos();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ChangePos(){
		

		do{

		direction = Random.Range (0, 4);
			switch (Mathf.RoundToInt(Random.Range(0,4))) {
		case 0:
			point.position += new Vector3 (positionUpX, positionUpY, 0);
			break;
		case 1:
			point.position -= new Vector3 (positionUpX, positionUpY, 0);
			break;
		case  2:
				point.position -= new Vector3 (positionleftX, positionleftY, 0);
			break;
		case 4:
				point.position += new Vector3 (positionleftX, positionleftY, 0);
			break;


		}
		}while(Physics2D.OverlapCircle(point.position,0.2f,roomLayer));
	}
}
 