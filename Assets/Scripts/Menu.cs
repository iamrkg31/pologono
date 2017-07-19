using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Menu : Photon.PunBehaviour
{
	
	string gameVersion = "1.0";
	public GameObject textGameObject;
	public GameObject PanelMenu;
	public GameObject PanelConnect;
	public GameObject TryAgainButton;
	public GameObject Title;
	public GameObject StartGame;
	public Text roomNameInput;
	public Text noOfPlayers;
	public Text Output;
	public static int playersCount = 0;

	public void Awake()	{		
		PhotonNetwork.automaticallySyncScene = true;
		PanelConnect.SetActive (true);
		PanelMenu.SetActive (false);
		Title.SetActive (false);
		TryAgainButton.SetActive (false);
		StartGame.SetActive (false);
	}

	[PunRPC]
	void game(){
		if (PhotonNetwork.playerList.Length != 0) {
			playersCount = PhotonNetwork.playerList.Length;
			PhotonNetwork.LoadLevel ("Level");
		}
	}

	// accessed by start button
	public void startGameFunction () {		
		PhotonView photonView = PhotonView.Get(this);
		photonView.RPC("game", PhotonTargets.All);
	}


	void Start()
	{
		connect ();
	}

	public void connect (){
		TryAgainButton.SetActive (false);
		textGameObject.GetComponent<Text> ().text = "Connecting.......";
		if (!PhotonNetwork.connected)
		{				
			// Connect to the photon master-server
			PhotonNetwork.ConnectUsingSettings(gameVersion);
		}

	}

	public void createRoom(){
		//PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 5 }, null);
		if (roomNameInput.text.ToString () == "") {
			PhotonNetwork.CreateRoom (null, new RoomOptions () { MaxPlayers = 5 }, TypedLobby.Default);
			Output.text = "Creating room with RANDOM NAME . . .";
		} else {
			PhotonNetwork.CreateRoom (roomNameInput.text.ToString (), new RoomOptions () { MaxPlayers = 5 }, TypedLobby.Default);
			Output.text = "Creating room : " + roomNameInput.text.ToString () + " . . .";
		}

	}

	public void joinRoom(){
		//PhotonNetwork.JoinRoom(roomNameInput.text.ToString());
		if (roomNameInput.text.ToString () == "") {
			Output.text = "Enter ROOM NAME first !";
		} else {
			PhotonNetwork.JoinRoom (roomNameInput.text.ToString ());
			Output.text = "Connecting to room : " + roomNameInput.text.ToString () + " . . .";
		}
	}

	public void joinRandomRoom(){
		PhotonNetwork.JoinRandomRoom();
		Output.text = "joining RANDOM room . . .";
	}

	public override void OnConnectedToMaster()
	{
		PanelConnect.SetActive (false);
		Title.SetActive (true);
		PanelMenu.SetActive (true);	
		Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
	}


	public override void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");        
		textGameObject.GetComponent<Text> ().text = "Connection failed.";
		TryAgainButton.SetActive (true);
		PanelConnect.SetActive (true);
		PanelMenu.SetActive (false);
	}

	public void OnCreatedRoom()
	{
		Debug.Log("OnCreatedRoom");
		PanelMenu.SetActive (false);
		StartGame.SetActive (true);

	}

	public void OnJoinedRoom(){
		Debug.Log ("joined room");
		PanelMenu.SetActive (false);
		StartGame.SetActive (true);
	}

	public void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 5 }, null);
	}

	void Update(){
		noOfPlayers.GetComponent<Text> ().text = PhotonNetwork.playerList.Length.ToString();
	}


}
