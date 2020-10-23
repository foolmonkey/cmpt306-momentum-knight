using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RoomGen : MonoBehaviour {

	Vector2 worldSize = new Vector2(4,4);

	Room[,] rooms;

	List<Vector2> takenPosition = new List<Vector2>();

	int gridSizeX,gridSizeY, numberOfrooms = 20;

	public GameObject roomWhiteObj;

	void CreateRooms(){
		rooms = new Room [gridSizeX * 2, gridSizeY * 2];
		rooms [gridSizeX, gridSizeY] = new Room (Vector2.zero, 1);
		takenPosition.Insert (0, Vector2.zero);
		Vector2 CheckPos = Vector2.zero;
		float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.2f;
		for (int i = 0; i<numberOfrooms ; i++) {
			float randomPerc = ((float)i) / (((float)numberOfrooms - 1));
			randomCompare = Mathf.Lerp (randomCompareStart, randomCompareEnd, randomPerc);
			CheckPos = NewPosition ();
		}

		if (numberOfNeighboors (CheckPos, takenPosition) > 1 && Random.value > randomCompare) {
			int iterations = 0;
			do {
				CheckPos = SelectiveNewPosition ();
				iterations++;
			} while(numberOfNeighboors (CheckPos, takenPosition) > 1 && iterations < 100);

			rooms [(int)CheckPos.x + gridSizeX, (int)CheckPos.y + gridSizeY] = new Room (CheckPos, 0);
			takenPosition.Insert (0, CheckPos);
				
				
			}
		}
	Vector2 NewPosition() {
		int x = 0, y = 0;
		Vector2 CheckPos = Vector2.zero;
		do {
			int index = Mathf.RoundToInt (Random.value * (takenPosition.Count - 1));
			x = (int)takenPosition [index].x;
			x = (int)takenPosition [index].y;
			bool UpDown = (Random.value < 0.5f);
			bool positive = (Random.value < 0.5f);
			if (UpDown) {
				if (positive) {
					y += 1;
				} else {
					y -= 1;
				
				}
			} else {
				if (positive) {
					x += 1;
				} else {
					x -= 1;
				}
			}
			CheckPos = new Vector2 (x, y);

		} while(takenPosition.Contains (CheckPos) || x >= gridSizeX || y >= gridSizeY || x < -gridSizeX || y < -gridSizeY);
		return CheckPos;
	}

	Vector2 SelectiveNewPosition() {
		int index = 0, inc = 0;
		int x = 0, y = 0;
		Vector2 CheckPos = Vector2.zero;
		do {
			inc = 0;
			do{
				index = Mathf.RoundToInt (Random.value * (takenPosition.Count - 1));
				inc++ ;
			}while (numberOfNeighboors(takenPosition[index], takenPosition)>1 && inc < 100);
			x = (int)takenPosition [index].x;
			x = (int)takenPosition [index].y;
			bool UpDown = (Random.value < 0.5f);
			bool positive = (Random.value < 0.5f);
			if (UpDown) {
				if (positive) {
					y += 1;
				} else {
					y -= 1;

				}
			} else {
				if (positive) {
					x += 1;
				} else {
					x -= 1;
				}
			}
			CheckPos = new Vector2 (x, y);

		} while(takenPosition.Contains (CheckPos) || x >= gridSizeX || y >= gridSizeY || x < -gridSizeX || y < -gridSizeY);
		return CheckPos;
	}
	int numberOfNeighboors(Vector2 CheckPos, List<Vector2>usedPositions ){
		int ret = 0;
		if (usedPositions.Contains(CheckPos + Vector2.left)){
			ret++;
		}
		if (usedPositions.Contains(CheckPos + Vector2.right)){
			ret++;
		}
		if (usedPositions.Contains(CheckPos + Vector2.up)){
			ret++;
		}
		if (usedPositions.Contains(CheckPos + Vector2.down)){
			ret++;
		}
		return ret;
	}


	void SetRoomDoors(){
		for (int x = 0; x < ((gridSizeX * 2)); x++) {
			for (int y = 0; y <((gridSizeY * 2)); y++){
				if (rooms[x,y] == null){
					continue;
				}
				Vector2 gridPosition = new Vector2 (x, y);
				if (y - 1 < 0) {
					rooms [x, y].doorBot = false;
				} else {
					rooms [x, y].doorBot = rooms [x, y - 1] != null;
				}
				if (y + 1 >= gridSizeY * 2) {
					rooms [x, y].doorTop = false;
				} else {
					rooms [x, y].doorTop = rooms [x, y + 1] != null;
				}
				if (x - 1 < 0) {
					rooms [x, y].doorLeft= false;
				} else {
					rooms [x, y].doorLeft = rooms [x - 1, y ] != null;
				}
				if (x + 1 >= gridSizeX * 2) {
					rooms [x, y].doorRight = false;
				} else {
					rooms [x, y].doorRight = rooms [x + 1, y] != null;
				}
			}
		}

	}



	void DrawMap(){
		foreach (Room room in rooms){
			if (room == null) {
				continue;
			}
			Vector2 drawPos = room.gridPos;
			drawPos.x *= 16;
			drawPos.y *= 8;
			mapSprit mapper = Object.Instantiate (roomWhiteObj, drawPos, Quaternion.identity).GetComponent<mapSprit>();
			mapper.type = room.type;
			mapper.up = room.doorTop;
			mapper.down = room.doorBot;
			mapper.left = room.doorLeft;
			mapper.right = room.doorRight;
		}

	}

	// Use this for initialization
	void Start () {
		if (numberOfrooms >= (worldSize.x * 2) * (worldSize.y * 2)) {
			numberOfrooms = Mathf.RoundToInt ((worldSize.x * 2) * (worldSize.y * 2));
		}
		gridSizeX = Mathf.RoundToInt (worldSize.x);
		gridSizeY = Mathf.RoundToInt (worldSize.y);
		CreateRooms ();
		SetRoomDoors ();
		DrawMap ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
