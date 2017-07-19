using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour {

	int newTurn;
	// Use this for initialization

	[PunRPC]
	void displayScore(string str, int finalScore){
		GameObject temp = GameObject.Find ("VarAttachedEnd");
		if (str == "#01 (master)") {
			temp.GetComponent<SomeVarUsedEnd> ().player1Text.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player1Score.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player1Score.GetComponent<Text> ().text = finalScore.ToString();
		}else if(str == "#02 "){
			temp.GetComponent<SomeVarUsedEnd> ().player2Text.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player2Score.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player2Score.GetComponent<Text> ().text = finalScore.ToString();
		}else if(str == "#03 "){
			temp.GetComponent<SomeVarUsedEnd> ().player3Text.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player3Score.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player3Score.GetComponent<Text> ().text = finalScore.ToString();
		}else if(str == "#04 "){
			temp.GetComponent<SomeVarUsedEnd> ().player4Text.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player4Score.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player4Score.GetComponent<Text> ().text = finalScore.ToString();
		}else if(str == "#05 "){
			temp.GetComponent<SomeVarUsedEnd> ().player5Text.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player5Score.SetActive (true);
			temp.GetComponent<SomeVarUsedEnd> ().player5Score.GetComponent<Text> ().text = finalScore.ToString();
		}
	}

	void Start () {
		PhotonView photonView = PhotonView.Get(this);
		photonView.RPC("displayScore", PhotonTargets.All,PhotonNetwork.player.ToString(),Main.finalScore);

		GameObject temp = GameObject.Find ("VarAttachedEnd");
		if(Main.turn==0){
			newTurn = PhotonNetwork.playerList.Length-1;
		}else{
			newTurn = Main.turn - 1;
		}

		// which player won the game
		if (newTurn == 0) {
			temp.GetComponent<SomeVarUsedEnd> ().playerWon.GetComponent<Text> ().text = "Player1";
		}else if(newTurn==1){
			temp.GetComponent<SomeVarUsedEnd> ().playerWon.GetComponent<Text> ().text = "Player2";
		}else if(newTurn==2){
			temp.GetComponent<SomeVarUsedEnd> ().playerWon.GetComponent<Text> ().text = "Player3";
		}else if(newTurn==3){
			temp.GetComponent<SomeVarUsedEnd> ().playerWon.GetComponent<Text> ().text = "Player4";
		}else if(newTurn==4){
			temp.GetComponent<SomeVarUsedEnd> ().playerWon.GetComponent<Text> ().text = "Player5";
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
