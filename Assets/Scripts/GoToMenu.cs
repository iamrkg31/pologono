using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMenu : MonoBehaviour {

	// Use this for initialization
	public void StartAgain () {
		PhotonNetwork.LeaveRoom();
		PhotonNetwork.LoadLevel("Menu");
	}

}
