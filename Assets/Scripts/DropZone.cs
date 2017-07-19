//attached to every gameobject on which draggable gameobject to be dropped
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler {
	GameObject itemBeingDroppedOn; //get the gameobject on which the draggable gameobject is being dropped on
	Transform parentOfitemBeingDragged; //get the parent of gameobject on which the draggable gameobject is being dropped on

	// swap the card in faceup deck ie, Deck2 with the cards being dragged
	[PunRPC]
	void swap(string s, string playerID){
		
		GameObject temp = GameObject.Find ("VarAttached");
		print ("gygjhkjhk swap"+s + Main.clickNum);
		if (playerID == "#01 (master)") {
			if (temp.GetComponent<SomeVarUsed> ().Player1.transform.childCount > 0) {
				print (temp.GetComponent<SomeVarUsed> ().Player1.transform.childCount);
				for (int i = 0; i < 4; i++) {
					if (temp.GetComponent<SomeVarUsed> ().Player1.transform.GetChild (i).GetComponent<Image> ().sprite.name == s) {	
						print ("found");
						temp.GetComponent<SomeVarUsed> ().Player1.transform.GetChild (i).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Deck2.transform);
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.position = temp.GetComponent<SomeVarUsed> ().Player1.transform.position;
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Player1.transform);
						break;
					} 
				}
			}
		} else if(playerID == "#02 ") {
			if (temp.GetComponent<SomeVarUsed> ().Player2.transform.childCount > 0) {
				print (temp.GetComponent<SomeVarUsed> ().Player2.transform.childCount);
				for (int i = 0; i < 4; i++) {
					if (temp.GetComponent<SomeVarUsed> ().Player2.transform.GetChild (i).GetComponent<Image> ().sprite.name == s) {		
						print ("found");
						temp.GetComponent<SomeVarUsed> ().Player2.transform.GetChild (i).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Deck2.transform);
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.position = temp.GetComponent<SomeVarUsed> ().Player2.transform.position;
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Player2.transform);
						break;
					} 
				}
			}
		}else if(playerID == "#03 ") {
			if (temp.GetComponent<SomeVarUsed> ().Player3.transform.childCount > 0) {
				print (temp.GetComponent<SomeVarUsed> ().Player3.transform.childCount);
				for (int i = 0; i < 4; i++) {
					if (temp.GetComponent<SomeVarUsed> ().Player3.transform.GetChild (i).GetComponent<Image> ().sprite.name == s) {		
						print ("found");
						temp.GetComponent<SomeVarUsed> ().Player3.transform.GetChild (i).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Deck2.transform);
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.position = temp.GetComponent<SomeVarUsed> ().Player3.transform.position;
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Player3.transform);
						break;
					} 
				}
			}
		}else if(playerID == "#04 ") {
			if (temp.GetComponent<SomeVarUsed> ().Player4.transform.childCount > 0) {
				print (temp.GetComponent<SomeVarUsed> ().Player4.transform.childCount);
				for (int i = 0; i < 4; i++) {
					if (temp.GetComponent<SomeVarUsed> ().Player4.transform.GetChild (i).GetComponent<Image> ().sprite.name == s) {		
						print ("found");
						temp.GetComponent<SomeVarUsed> ().Player4.transform.GetChild (i).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Deck2.transform);
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.position = temp.GetComponent<SomeVarUsed> ().Player4.transform.position;
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Player4.transform);
						break;
					} 
				}
			}
		}else if(playerID == "#05 ") {
			if (temp.GetComponent<SomeVarUsed> ().Player5.transform.childCount > 0) {
				print (temp.GetComponent<SomeVarUsed> ().Player5.transform.childCount);
				for (int i = 0; i < 4; i++) {
					if (temp.GetComponent<SomeVarUsed> ().Player5.transform.GetChild (i).GetComponent<Image> ().sprite.name == s) {		
						print ("found");
						temp.GetComponent<SomeVarUsed> ().Player5.transform.GetChild (i).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Deck2.transform);
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.position = temp.GetComponent<SomeVarUsed> ().Player5.transform.position;
						temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).transform.SetParent (temp.GetComponent<SomeVarUsed> ().Player5.transform);
						break;
					} 
				}
			}
		}

	}

	//will only work on the gameobject to which it is attached
	public void OnDrop (PointerEventData eventData)
	{	
		parentOfitemBeingDragged = Draggable.startParent;
		string temp = Draggable.itemBeingDragged.GetComponent<Image> ().sprite.name;

		//  if parent of draggable gameobject is not same as the gameobject being dropped 
		if (this.gameObject.name == "Deck2" && ("#0"+(Main.turn+1).ToString()+" " == PhotonNetwork.player.ToString() || "#0"+(Main.turn+1).ToString()+" (master)" == PhotonNetwork.player.ToString())&& 
			(parentOfitemBeingDragged.gameObject.name == "Card1"
				|| parentOfitemBeingDragged.gameObject.name == "Card2"
				|| parentOfitemBeingDragged.gameObject.name == "Card3"
				|| parentOfitemBeingDragged.gameObject.name == "Card4"
			)) {

			Main.clickNum = 1;
			print (this.gameObject.name + "1clickNUM" +Main.clickNum+ "turn: "+ Main.turn.ToString() + "playerid: " +  PhotonNetwork.player.ToString());
			itemBeingDroppedOn = this.transform.GetChild (0).gameObject;
			Draggable.itemBeingDragged.transform.SetParent (this.transform);
			itemBeingDroppedOn.transform.SetParent (parentOfitemBeingDragged);
			PhotonView photonView = PhotonView.Get(this);
			photonView.RPC("swap", PhotonTargets.All,temp,PhotonNetwork.player.ToString());
			//GetComponent<NetworkView>().RPC("swap", RPCMode.All,temp,Network.player.ToString());

		}else if (parentOfitemBeingDragged != this.transform && parentOfitemBeingDragged.gameObject.name != "Deck2" &&
			(this.gameObject.name == "Card1"
				|| this.gameObject.name == "Card2"
				|| this.gameObject.name == "Card3"
				|| this.gameObject.name == "Card4"
			)) {
			itemBeingDroppedOn = this.transform.GetChild (0).gameObject;
			Draggable.itemBeingDragged.transform.SetParent (this.transform);
			itemBeingDroppedOn.transform.SetParent (parentOfitemBeingDragged);
		}
	}

}
