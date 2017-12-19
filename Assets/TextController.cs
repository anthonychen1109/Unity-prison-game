using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print(myState);
		if (myState == States.cell){
			state_cell();
		} else if (myState == States.sheets_0) {
			state_sheets_0();
		} else if (myState == States.lock_0) {
			state_lock_0();
		} else if (myState == States.mirror) {
			state_mirror();
		} else if (myState == States.cell_mirror) {
			state_cell_mirror();
		} else if (myState == States.sheets_1) {
			state_sheets_1();
		} else if (myState == States.lock_1) {
			state_lock_1();
		} else if (myState == States.freedom) {
			state_freedom();
		}
	}

	void state_cell () {
		text.text = "You are in a prison cell, and you want to escape. " +
					"There are some dirty sheets on the bed, a mirror " +
					"on the wall, and the door is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror, L to view Lock.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.freedom;
		}
	}

	void state_sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely " +
					"it's time somebody changed them. The pleasure of prison " +
					"life I guess!\n\n" +
					"Press R to return to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_lock_0 () {
		text.text = "You check the lock on prison room door. It's obviously locked.. " +
					"That's why it's called prison!\n\n" +
					"Press R to return to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}

	void state_mirror () {
		text.text = "You look at the mirror in your cell. You ponder for a second " +
					"and you think about your life. You have 2 choices... To grab " +
					"the mirror or return to your cell.\n\n" +
					"Press R to return to roaming your cell\n\n" +
					"Press T to take the mirror.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		} else if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}

	void state_cell_mirror() {
		text.text = "You have taken the cell mirror off the wall. Now what..?\n\n" +
					"Press S to cover the mirror so you don't have to look at it anymore.\n\n" +
					"Press L to smash the lock with the mirror frame";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}

	void state_sheets_1() {
		text.text = "You cover the mirror with your dirty sheets to hide the pain.\n\n" +
					"Press R to return to roaming your cell.\n\n";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void state_lock_1 () {
		text.text = "You smash the lock with the mirror frame and the door handle falls off! " +
					"Your moral conscience kicks in!\n\n" +
					"Press R to return to roaming your cell and pretend you didn't break the handle\n\n" +
					"Press O to open the door and walk out!"; 
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.freedom;
		}
	}

	void state_freedom() {
		text.text = "You have successfully ESCAPED! WELCOME TO FREEDOM!!"; 
	}
}
