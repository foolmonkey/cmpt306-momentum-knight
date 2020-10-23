using UnityEngine;
using System.Collections;

public class Room  {
	public Vector2 gridPos;
	public int type;
	public bool doorTop,doorBot, doorLeft, doorRight;

	public Room(Vector2 _gridPos, int _type){
		gridPos = _gridPos;
		type = _type;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
