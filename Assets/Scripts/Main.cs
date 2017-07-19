// main script used in the game, attached to GameObject
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System;
using System.Net;

public class Main : MonoBehaviour{
	public static GameObject[] players=new GameObject[4];//to be accessed in Score.cs
	GameObject[] cards=new GameObject[4];//in Cards panel
	GameObject[] jokerCards=new GameObject[6];//in JokerCards panel for adding buttonclick.cs
	public static int playerId=0;//player id
	public static int clickNum;//for restricting the player from clicking the deck more than once and not clicking at all
	public static int turn;
	public static int finalScore;
	public string postDataURL = "https://www.pologono.com/save_data.php?"; //add a ? to your url

	//load new scene
	[PunRPC]
	void loadNewScene(){
		GameObject temp = GameObject.Find ("VarAttached");
		finalScore = int.Parse(temp.GetComponent<SomeVarUsed> ().ScoreValue.GetComponent<Text> ().text);
		Application.LoadLevel("End");
	}

	// being called in whoWon function
	int gameOver(string s1, string s2, string s3, string s4, string sprite1, string sprite2, string sprite3, string sprite4, string jokersprite){

		if (s1 == sprite1 && s2 == sprite2 && s3 == sprite3 && s4 == sprite4 || 
			s1 == jokersprite && s2 == sprite2 && s3 == sprite3 && s4 == sprite4 || 
			s1 == sprite1 && s2 == jokersprite && s3 == sprite3 && s4 == sprite4 || 
			s1 == sprite1 && s2 == sprite2 && s3 == jokersprite && s4 == sprite4 || 
			s1 == sprite1 && s2 == sprite2 && s3 == sprite3 && s4 == jokersprite ||
			s1 == jokersprite && s2 == jokersprite && s3 == sprite3 && s4 == sprite4 ||
			s1 == jokersprite && s2 == jokersprite && s3 == sprite3 && s4 == sprite4 ||
			s1 == jokersprite && s2 == sprite2 && s3 == jokersprite && s4 == sprite4 ||
			s1 == jokersprite && s2 == sprite2 && s3 == sprite3 && s4 == jokersprite ||
			s1 == sprite1 && s2 == jokersprite && s3 == jokersprite && s4 == sprite4 ||
			s1 == sprite1 && s2 == jokersprite && s3 == sprite3 && s4 == jokersprite ||
			s1 == sprite1 && s2 == sprite2 && s3 == jokersprite && s4 == jokersprite
		) {
			return 1;
		}

		return 0;
	}

	// who won
	void whoWon(){
		GameObject temp = GameObject.Find ("VarAttached");
		string tempCard1="null";
		string tempCard2="null";
		string tempCard3="null";
		string tempCard4="null";
		if (temp.GetComponent<SomeVarUsed> ().Card1.transform.childCount > 0) {
			tempCard1 = temp.GetComponent<SomeVarUsed> ().Card1.transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.name;
		}
		if (temp.GetComponent<SomeVarUsed> ().Card2.transform.childCount > 0) {
			tempCard2 = temp.GetComponent<SomeVarUsed> ().Card2.transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.name;
		}
		if (temp.GetComponent<SomeVarUsed> ().Card3.transform.childCount > 0) {
			tempCard3 = temp.GetComponent<SomeVarUsed> ().Card3.transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.name;
		}
		if (temp.GetComponent<SomeVarUsed> ().Card4.transform.childCount > 0) {
			tempCard4 = temp.GetComponent<SomeVarUsed> ().Card4.transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.name;
		}

		if (gameOver (tempCard1, tempCard2, tempCard3, tempCard4, "Cir 1", "Cir 2", "Cir 3", "Cir 4", "joker1") == 1) {
			Score.ChangeScore (1,-104);
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("loadNewScene", PhotonTargets.All);
		}

		else if (gameOver (tempCard1, tempCard2, tempCard3, tempCard4, "Hex 1", "Hex 2", "Hex 3", "Hex 4", "joker3") == 1) {
			Score.ChangeScore (1,-104);
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("loadNewScene", PhotonTargets.All);
		}
		else if (gameOver (tempCard1, tempCard2, tempCard3, tempCard4, "Pent 1", "Pent 2", "Pent 3", "Pent 4", "joker2") == 1) {
			Score.ChangeScore (1,-104);
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("loadNewScene", PhotonTargets.All);
		}
		else if (gameOver (tempCard1, tempCard2, tempCard3, tempCard4, "Rec 1", "Rec 2", "Rec 3", "Rec 4", "joker1") == 1) {
			Score.ChangeScore (1,-104);
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("loadNewScene", PhotonTargets.All);
		}
		else if (gameOver (tempCard1, tempCard2, tempCard3, tempCard4, "Sq 1", "Sq 2", "Sq 3", "Sq 4", "joker3") == 1) {
			Score.ChangeScore (1,-104);
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("loadNewScene", PhotonTargets.All);
		}
		else if (gameOver (tempCard1, tempCard2, tempCard3, tempCard4, "Tri 1", "Tri 2", "Tri 3", "Tri 4", "joker2") == 1) {
			Score.ChangeScore (1,-104);
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("loadNewScene", PhotonTargets.All);
		}


	}

	// color player button
	[PunRPC]
	void colorPlayerButton1(int lastTurn){
		GameObject temp = GameObject.Find ("VarAttached");
		if (lastTurn == 0) {
			temp.GetComponent<SomeVarUsed> ().Player1Button.GetComponent<Image> ().color = Color.red;
		}else if(lastTurn==1){
			temp.GetComponent<SomeVarUsed> ().Player2Button.GetComponent<Image> ().color = Color.red;
		}else if(lastTurn==2){
			temp.GetComponent<SomeVarUsed> ().Player3Button.GetComponent<Image> ().color = Color.red;
		}else if(lastTurn==3){
			temp.GetComponent<SomeVarUsed> ().Player4Button.GetComponent<Image> ().color = Color.red;
		}else if(lastTurn==4){
			temp.GetComponent<SomeVarUsed> ().Player5Button.GetComponent<Image> ().color = Color.red;
		}
	}

	// color player button
	[PunRPC]
	void colorPlayerButton2(){
		GameObject temp = GameObject.Find ("VarAttached");
		if (turn == 0) {
			temp.GetComponent<SomeVarUsed> ().Player1Button.GetComponent<Image> ().color = Color.green;
		}else if(turn==1){
			temp.GetComponent<SomeVarUsed> ().Player2Button.GetComponent<Image> ().color = Color.green;
		}else if(turn==2){
			temp.GetComponent<SomeVarUsed> ().Player3Button.GetComponent<Image> ().color = Color.green;
		}else if(turn==3){
			temp.GetComponent<SomeVarUsed> ().Player4Button.GetComponent<Image> ().color = Color.green;
		}else if(turn==4){
			temp.GetComponent<SomeVarUsed> ().Player5Button.GetComponent<Image> ().color = Color.green;
		}
	}

	// change the player turn ie, which player's turn
	[PunRPC]
	void whoseTurnHelper(int turnGet) {
		if (turnGet == (PhotonNetwork.playerList.Length-1)) turn = 0;
		else if (turnGet == 0) turn = 1;
		else if (turnGet == 1) turn = 2;
		else if (turnGet == 2) turn = 3;
		else if (turnGet == 3) turn = 4;

		clickNum = 0;
	}

	// change the player turn ie, which player's turn, accessed by done button
	public void whoseTurn(){		
		GameObject temp = GameObject.Find ("VarAttached");	
		if ("#0"+(turn+1).ToString ()+" " == PhotonNetwork.player.ToString()&& clickNum != 1) {
			temp.GetComponent<SomeVarUsed> ().NotPlayedTurn.SetActive (true);
		}else if("#0"+(turn+1).ToString ()+" (master)" == PhotonNetwork.player.ToString() && clickNum != 1){
			temp.GetComponent<SomeVarUsed> ().NotPlayedTurn.SetActive (true);
		}
		if ("#0"+(turn+1).ToString ()+" " == PhotonNetwork.player.ToString() && clickNum == 1) {
			Score.clickOnDone ();
			int lastTurn = turn;
			temp.GetComponent<SomeVarUsed> ().NotPlayedTurn.SetActive (false);
			temp.GetComponent<SomeVarUsed> ().TextPlayedTurn.SetActive (false);
			whoWon();
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("whoseTurnHelper", PhotonTargets.All,turn);
			photonView.RPC("colorPlayerButton1", PhotonTargets.All,lastTurn);
			photonView.RPC("colorPlayerButton2", PhotonTargets.All);
		}else if("#0"+(turn+1).ToString ()+" (master)" == PhotonNetwork.player.ToString() && clickNum == 1){
			Score.clickOnDone ();
			int lastTurn = turn;
			temp.GetComponent<SomeVarUsed> ().NotPlayedTurn.SetActive (false);
			temp.GetComponent<SomeVarUsed> ().TextPlayedTurn.SetActive (false);
			whoWon();
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("whoseTurnHelper", PhotonTargets.All,turn);
			photonView.RPC("colorPlayerButton1", PhotonTargets.All,lastTurn);
			photonView.RPC("colorPlayerButton2", PhotonTargets.All);
		}
	}

	//when deck1 is clicked
	[PunRPC]
	public void clickOnDeckHelper(int randomChildNumber){
		GameObject temp = GameObject.Find ("VarAttached");
		if (temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.childCount > 0 ) {
			temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).gameObject.transform.SetParent (temp.GetComponent<SomeVarUsed> ().HiddenDeck2.transform);
			temp.GetComponent<SomeVarUsed> ().HiddenDeck2.transform.GetChild (temp.GetComponent<SomeVarUsed> ().HiddenDeck2.transform.childCount - 1).gameObject.transform.position = temp.GetComponent<SomeVarUsed> ().HiddenDeck2.transform.position;
			temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.GetChild (randomChildNumber).gameObject.transform.SetParent (temp.GetComponent<SomeVarUsed> ().Deck2.transform);

			// when hiddendeck1 is empty
			if (temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.childCount == 0) {
				int childInHiddenDeck2 = temp.GetComponent<SomeVarUsed> ().HiddenDeck2.transform.childCount;
				for (int i = 0; i < childInHiddenDeck2; i++) {
					temp.GetComponent<SomeVarUsed> ().HiddenDeck2.transform.GetChild (0).gameObject.transform.SetParent (temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform);
				}
			}
		}
	}

	//when deck1 is clicked
	public void clickOnDeck(){
		
		GameObject temp = GameObject.Find ("VarAttached");
		if ("#0"+(turn+1).ToString ()+" " == PhotonNetwork.player.ToString() && clickNum != 0) {
			temp.GetComponent<SomeVarUsed> ().TextPlayedTurn.SetActive (true);
		}else if("#0"+(turn+1).ToString ()+" (master)" == PhotonNetwork.player.ToString() && clickNum != 0){
			temp.GetComponent<SomeVarUsed> ().TextPlayedTurn.SetActive (true);
		}
		if ("#0"+(turn+1).ToString ()+" " == PhotonNetwork.player.ToString() && clickNum ==0) {
			Score.clickOnDone ();
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("clickOnDeckHelper", PhotonTargets.All,UnityEngine.Random.Range (0, temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.childCount) );
			clickNum++;

		}else if("#0"+(turn+1).ToString ()+" (master)" == PhotonNetwork.player.ToString() && clickNum ==0){
			Score.clickOnDone ();
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("clickOnDeckHelper", PhotonTargets.All,UnityEngine.Random.Range (0, temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.childCount) );
			clickNum++;

		}

	}

	//add one child from hiddendeck1 to Deck2
	[PunRPC]
	public void addChild(int randomChildNumber){
		GameObject temp = GameObject.Find ("VarAttached");
		temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.GetChild (randomChildNumber).gameObject.transform.SetParent (temp.GetComponent<SomeVarUsed> ().Deck2.transform);
	}

	//distribute cards to players
	[PunRPC]
	void giveCardsToPlayers(int randomChildNumber,int i){
		GameObject temp = GameObject.Find ("VarAttached");
		GameObject go = temp.GetComponent<SomeVarUsed> ().Player1;

		if (i == 1) {
			go = temp.GetComponent<SomeVarUsed> ().Player2;
		} else if (i == 2) {
			go = temp.GetComponent<SomeVarUsed> ().Player3;
		} else if (i == 3) {
			go = temp.GetComponent<SomeVarUsed> ().Player4;
		}else if (i == 4) {
			go = temp.GetComponent<SomeVarUsed> ().Player5;
		}			
				
		temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.GetChild (randomChildNumber).gameObject.transform.SetParent (go.transform);
	}

	//Load cards of the player in the cards panel visible
	[PunRPC]
	void loadCards() {	
		GameObject temp = GameObject.Find ("VarAttached");
		if (PhotonNetwork.player.ToString() == "#01 (master)") {
			for (int j = 0; j < 4; j++) {	
				print (temp.GetComponent<SomeVarUsed> ().Player1.transform.childCount);	
				if (temp.GetComponent<SomeVarUsed> ().Player1.transform.childCount > 0) {
					temp.GetComponent<SomeVarUsed> ().Player1.transform.GetChild (0).SetParent (cards[j].transform);
				}
			}
		} else if (PhotonNetwork.player.ToString() == "#02 ") {
			for (int j = 0; j < 4; j++) {	
				print (temp.GetComponent<SomeVarUsed> ().Player2.transform.childCount);	
				if (temp.GetComponent<SomeVarUsed> ().Player2.transform.childCount > 0) {
					temp.GetComponent<SomeVarUsed> ().Player2.transform.GetChild (0).SetParent (cards[j].transform);
				}
			}
		} else if (PhotonNetwork.player.ToString() == "#03 ") {
			for (int j = 0; j < 4; j++) {	
				print (temp.GetComponent<SomeVarUsed> ().Player3.transform.childCount);	
				if (temp.GetComponent<SomeVarUsed> ().Player3.transform.childCount > 0) {
					temp.GetComponent<SomeVarUsed> ().Player3.transform.GetChild (0).SetParent (cards[j].transform);
				}
			}
		} else if (PhotonNetwork.player.ToString() == "#04 ") {
			for (int j = 0; j < 4; j++) {	
				print (temp.GetComponent<SomeVarUsed> ().Player4.transform.childCount);	
				if (temp.GetComponent<SomeVarUsed> ().Player4.transform.childCount > 0) {
					temp.GetComponent<SomeVarUsed> ().Player4.transform.GetChild (0).SetParent (cards[j].transform);
				}
			}
		} else if (PhotonNetwork.player.ToString() == "#05 ") {
			for (int j = 0; j < 4; j++) {	
				print (temp.GetComponent<SomeVarUsed> ().Player5.transform.childCount);	
				if (temp.GetComponent<SomeVarUsed> ().Player5.transform.childCount > 0) {
					temp.GetComponent<SomeVarUsed> ().Player5.transform.GetChild (0).SetParent (cards[j].transform);
				}
			}
		} 

	}

	// set active the buttons indicating which player's turn
	[PunRPC]
	void setActiveButtons(){
		GameObject temp = GameObject.Find ("VarAttached");
		for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
			if(i==0) temp.GetComponent<SomeVarUsed> ().Player1Button.SetActive (true);
			else if(i==1) temp.GetComponent<SomeVarUsed> ().Player2Button.SetActive (true);
			else if(i==2) temp.GetComponent<SomeVarUsed> ().Player3Button.SetActive (true);
			else if(i==3) temp.GetComponent<SomeVarUsed> ().Player4Button.SetActive (true);
			else if(i==4) temp.GetComponent<SomeVarUsed> ().Player5Button.SetActive (true);
		}
		
	}

	[PunRPC]
	void initializeVariable(){
		turn = 0;
		clickNum = 0;
	}

	//save to text file player data
	public void SaveToFile(string output){		
		StartCoroutine(PostData("allow",output));
	}

	IEnumerator PostData(string access_code, string data)
	{
		
		//This connects to a server side php script that will write the data
		string post_url = postDataURL + "data=" + data + "&access_code=" + access_code;

		// Post the URL to the site and create a download object to get the result.
		WWW data_post = new WWW(post_url);
		yield return data_post; // Wait until the download is done

		if (data_post.error != null)
		{
			print("There was an error saving data: " + data_post.error);
		}
	}
	// Use this for initialization
	void Start () {

			GameObject temp = GameObject.Find ("VarAttached");
			cards [0] = temp.GetComponent<SomeVarUsed> ().Card1;
			cards [1] = temp.GetComponent<SomeVarUsed> ().Card2;
			cards [2] = temp.GetComponent<SomeVarUsed> ().Card3;
			cards [3] = temp.GetComponent<SomeVarUsed> ().Card4;

			temp.GetComponent<SomeVarUsed> ().Player1Button.GetComponent<Image> ().color = Color.red;	
			temp.GetComponent<SomeVarUsed> ().Player2Button.GetComponent<Image> ().color = Color.red;	
			temp.GetComponent<SomeVarUsed> ().Player3Button.GetComponent<Image> ().color = Color.red;	
			temp.GetComponent<SomeVarUsed> ().Player4Button.GetComponent<Image> ().color = Color.red;	
			temp.GetComponent<SomeVarUsed> ().Player5Button.GetComponent<Image> ().color = Color.red;

			//attach draggable and canvasgroup to hiddendeck1 cards to make them draggable
			for (int i = 0; i < temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.childCount; i++) {
				temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.GetChild (i).gameObject.AddComponent<Draggable> ();
				temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.GetChild (i).gameObject.AddComponent<CanvasGroup> ();				
			}

			//attach dropzone script to cards and deck2 to enable dropping of cards on them
			for (int i = 0; i < 4; i++) {
				cards[i].AddComponent<DropZone> ();
			}
			temp.GetComponent<SomeVarUsed> ().Deck2.AddComponent<DropZone> ();	

		// perform only on the client who created the room
		if (PhotonNetwork.isMasterClient) {			


			// distribute cards to each player and add one card to face up deck ie, Deck2
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("initializeVariable", PhotonTargets.All);
			photonView.RPC("addChild", PhotonTargets.All, UnityEngine.Random.Range (0, temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.childCount));

			for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
				for (int j = 0; j < 4; j++) {		
				     photonView.RPC("giveCardsToPlayers", PhotonTargets.All,UnityEngine.Random.Range (0, temp.GetComponent<SomeVarUsed> ().HiddenDeck1.transform.childCount),i);
				}
			}

			// color the button to show which player's turn
			photonView.RPC("colorPlayerButton2", PhotonTargets.All);

			// load cards to holding cards from respective panel of each player ie, Player1, Player2, ..., Player5
			photonView.RPC("loadCards", PhotonTargets.All);

			//setActive the buttons according to the number of players playing
			photonView.RPC("setActiveButtons", PhotonTargets.All);



		}
			
		// Display Player Name
		if (PhotonNetwork.player.ToString() == "#01 (master)") {
			temp.GetComponent<SomeVarUsed> ().PlayerName.GetComponent<Text> ().text = "Player1";
		}else if(PhotonNetwork.player.ToString() == "#02 "){
			temp.GetComponent<SomeVarUsed> ().PlayerName.GetComponent<Text> ().text = "Player2";
		}else if(PhotonNetwork.player.ToString() == "#03 "){
			temp.GetComponent<SomeVarUsed> ().PlayerName.GetComponent<Text> ().text = "Player3";
		}else if(PhotonNetwork.player.ToString() == "#04 "){
			temp.GetComponent<SomeVarUsed> ().PlayerName.GetComponent<Text> ().text = "Player4";
		}else if(PhotonNetwork.player.ToString() == "#05 "){
			temp.GetComponent<SomeVarUsed> ().PlayerName.GetComponent<Text> ().text = "Player5";
		}
	}

	// leave the game
	[PunRPC]
	void LeaveTheGame () {
		PhotonNetwork.LeaveRoom();
		PhotonNetwork.LoadLevel("Menu");
	}
	// Update is called once per frame
	void Update () {
		// if any player disconnects
		if(Menu.playersCount != PhotonNetwork.playerList.Length) {
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("LeaveTheGame", PhotonTargets.All);
		}
	}
}
