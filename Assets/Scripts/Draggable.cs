//attached to every gameobject which needs to be dragged
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged; //item which will be dragged
	Vector3 startPosition; //start position of the item being dragged
	public static Transform startParent; // start parent of the item being dragged

	//comes into effect as soon as the item is dragged
	public void OnBeginDrag(PointerEventData eventData) {
		//Debug.Log ("OnBeginDrag");
		itemBeingDragged = gameObject;
		startPosition = transform.position; //start position of the item being dragged
		startParent = transform.parent; // start parent of the item being dragged
		this.transform.SetParent( this.transform.parent.parent.parent);//change parent of gameobject to CANVAS
		GetComponent<CanvasGroup>().blocksRaycasts = false; //gameobject will not block the rays while being dragged
	}

	//comes into effect when the item is being dragged
	public void OnDrag(PointerEventData eventData) {
		//Debug.Log ("OnDrag");
		this.transform.position = eventData.position;//change the position of game object with mouse
	}

	////comes into effect when the item is stopped being dragged
	public void OnEndDrag(PointerEventData eventData) {
		//Debug.Log ("OnEndDrag");
		//if the gameobject's parent is same as before, put the game object where it was
		if(transform.parent == startParent){			
			transform.position = startPosition;
		}
		//if the gameobject's parent is CANVAS, change its parent to startParent
		if(transform.parent == startParent.parent.parent){
			this.transform.SetParent( startParent);
		}

		GetComponent<CanvasGroup>().blocksRaycasts = true;// block the rays so we can not know the gameobject below the card
	}



}
