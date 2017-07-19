using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	//to check if all cards in the holding panel are of same shape
	public static bool IsAllCardsOfSameShape(string card1, string card2, string card3, string card4, string joker, char firstLetterOfCard){

		if ((card1[0]==firstLetterOfCard || card1==joker) 
			&& (card2[0]==firstLetterOfCard || card2==joker) 
			&& (card3[0]==firstLetterOfCard || card3==joker) 
			&& (card4[0]==firstLetterOfCard || card4==joker)) {
			return true;
		}

		return false;
	}

	//to check if two cards in the holding panel are of same shape and in deck2 ie, face up deck
	public static bool IsTwoCardsOfSameShape(string card1, string card2, string card3, string card4, string joker, char firstLetterOfCard, string tempFaceUpCard){

		if ((card1[0]==firstLetterOfCard || card1==joker) && (card2[0]==firstLetterOfCard || card2==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)
			|| (card1[0]==firstLetterOfCard || card1==joker) && (card3[0]==firstLetterOfCard || card3==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)
			|| (card1[0]==firstLetterOfCard || card1==joker) && (card4[0]==firstLetterOfCard || card4==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)
			|| (card2[0]==firstLetterOfCard || card2==joker) && (card3[0]==firstLetterOfCard || card3==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)
			|| (card2[0]==firstLetterOfCard || card2==joker) && (card4[0]==firstLetterOfCard || card4==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)
			|| (card3[0]==firstLetterOfCard || card3==joker) && (card4[0]==firstLetterOfCard || card4==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)) {
			return true;
		}

		return false;
	}


	//to check if 3 cards in the holding panel are of same shape and in deck2 ie, face up deck
	public static bool IsThreeCardsOfSameShape(string card1, string card2, string card3, string card4, string joker, char firstLetterOfCard, string tempFaceUpCard){

		if ((card1[0]==firstLetterOfCard || card1==joker) && (card2[0]==firstLetterOfCard || card2==joker) && (card3[0]==firstLetterOfCard || card3==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)
			|| (card1[0]==firstLetterOfCard || card1==joker) && (card3[0]==firstLetterOfCard || card3==joker) && (card4[0]==firstLetterOfCard || card4==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)
			|| (card1[0]==firstLetterOfCard || card1==joker) && (card2[0]==firstLetterOfCard || card2==joker) && (card4[0]==firstLetterOfCard || card4==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)
			|| (card2[0]==firstLetterOfCard || card2==joker) && (card3[0]==firstLetterOfCard || card3==joker) && (card4[0]==firstLetterOfCard || card4==joker) && (tempFaceUpCard[0] == firstLetterOfCard || tempFaceUpCard == joker)) {
			return true;
		}

		return false;
	}

	//to be used in IsAllDifferentCards to check if all cards are different
	public static bool IsAllDifferentCardsHelper(string card1, string card2, string card3, string card4, string joker, char firstLetterOfCard){

		if ((card1[0]==firstLetterOfCard || card1==joker) && (card2[0]==firstLetterOfCard || card2==joker)
			|| (card1[0]==firstLetterOfCard || card1==joker) && (card3[0]==firstLetterOfCard || card3==joker)
			|| (card1[0]==firstLetterOfCard || card1==joker) && (card4[0]==firstLetterOfCard || card4==joker)
			|| (card2[0]==firstLetterOfCard || card2==joker) && (card3[0]==firstLetterOfCard || card3==joker)
			|| (card2[0]==firstLetterOfCard || card2==joker) && (card4[0]==firstLetterOfCard || card4==joker)
			|| (card3[0]==firstLetterOfCard || card3==joker) && (card4[0]==firstLetterOfCard || card4==joker)) {
			print("Two Cards Same");
			return true;
		}else if ((card1[0]==firstLetterOfCard || card1==joker) && (card2[0]==firstLetterOfCard || card2==joker) && (card3[0]==firstLetterOfCard || card3==joker)
			|| (card1[0]==firstLetterOfCard || card1==joker) && (card3[0]==firstLetterOfCard || card3==joker) && (card4[0]==firstLetterOfCard || card4==joker)
			|| (card1[0]==firstLetterOfCard || card1==joker) && (card2[0]==firstLetterOfCard || card2==joker) && (card4[0]==firstLetterOfCard || card4==joker)
			|| (card2[0]==firstLetterOfCard || card2==joker) && (card3[0]==firstLetterOfCard || card3==joker) && (card4[0]==firstLetterOfCard || card4==joker)) {
			print("Three Cards Same");
			return true;
		}

		return false;
	}

	//to check if all cards in the holding panel are diferent and in deck2 ie, face up deck
	public static bool IsAllDifferentCards(string card1, string card2, string card3, string card4, string tempFaceUpCard){

		if (IsAllDifferentCardsHelper (card1, card2, card3, card4, "joker1", 'C')) {			
			return false;
		}

		else if (IsAllDifferentCardsHelper (card1, card2, card3, card4, "joker1", 'R'))
		{			
			return false;
		}
		else if (IsAllDifferentCardsHelper (card1, card2, card3, card4, "joker2", 'T'))
		{			
			return false;
		}
		else if (IsAllDifferentCardsHelper (card1, card2, card3, card4, "joker2", 'P'))
		{			
			return false;
		}
		else if (IsAllDifferentCardsHelper (card1, card2, card3, card4, "joker3", 'S'))
		{			
			return false;
		}
		else if (IsAllDifferentCardsHelper (card1, card2, card3, card4, "joker3", 'H'))
		{			
			return false;
		}


		if (tempFaceUpCard [0] == 'C' || tempFaceUpCard [0] == 'R' || tempFaceUpCard == "joker1") {
			if ((card1 [0] == tempFaceUpCard [0] || card1 == "joker1")
				|| (card2 [0] == tempFaceUpCard [0] || card2 == "joker1")
				|| (card3 [0] == tempFaceUpCard [0] || card3 == "joker1")
				|| (card4 [0] == tempFaceUpCard [0] || card4 == "joker1")) {
				return true;
			}else if (tempFaceUpCard == "joker1") {
				if ((card1 [0] == 'C' || card1 [0] == 'R' || card1 == "joker1")
					|| (card1 [0] == 'C' || card1 [0] == 'R' || card2 == "joker1")
					|| (card1 [0] == 'C' || card1 [0] == 'R' || card3 == "joker1")
					|| (card1 [0] == 'C' || card1 [0] == 'R' || card4 == "joker1")) {
					return true;
				}
			}
		} else if (tempFaceUpCard [0] == 'T' || tempFaceUpCard [0] == 'P' || tempFaceUpCard == "joker2") {
			if ((card1 [0] == tempFaceUpCard [0] || card1 == "joker2")
				|| (card2 [0] == tempFaceUpCard [0] || card2 == "joker2")
				|| (card3 [0] == tempFaceUpCard [0] || card3 == "joker2")
				|| (card4 [0] == tempFaceUpCard [0] || card4 == "joker2")) {
				return true;
			}else if (tempFaceUpCard == "joker2") {
				if ((card1 [0] == 'T' || card1 [0] == 'P' || card1 == "joker2")
					|| (card1 [0] == 'T' || card1 [0] == 'P' || card2 == "joker2")
					|| (card1 [0] == 'T' || card1 [0] == 'P' || card3 == "joker2")
					|| (card1 [0] == 'T' || card1 [0] == 'P' || card4 == "joker2")) {
					return true;
				}
			}
		} else if (tempFaceUpCard [0] == 'S' || tempFaceUpCard [0] == 'H' || tempFaceUpCard == "joker3") {
			if ((card1 [0] == tempFaceUpCard [0] || card1 == "joker3")
				|| (card2 [0] == tempFaceUpCard [0] || card2 == "joker3")
				|| (card3 [0] == tempFaceUpCard [0] || card3 == "joker3")
				|| (card4 [0] == tempFaceUpCard [0] || card4 == "joker3")) {
				return true;
			} else if (tempFaceUpCard == "joker3") {
				if ((card1 [0] == 'S' || card1 [0] == 'H' || card1 == "joker3")
					|| (card1 [0] == 'S' || card1 [0] == 'H' || card2 == "joker3")
					|| (card1 [0] == 'S' || card1 [0] == 'H' || card3 == "joker3")
					|| (card1 [0] == 'S' || card1 [0] == 'H' || card4 == "joker3")) {
					return true;
				}
			}
		}
		return false;

	}



	// change the score of the player
	public static void ChangeScore(int num, int weight){
		GameObject temp = GameObject.Find ("VarAttached");

		if (num == 1) {
			if (int.Parse (temp.GetComponent<SomeVarUsed> ().ScoreValue.GetComponent<Text> ().text) - weight >= 0) {
				temp.GetComponent<SomeVarUsed> ().ScoreValue.GetComponent<Text> ().text = (int.Parse (temp.GetComponent<SomeVarUsed> ().ScoreValue.GetComponent<Text> ().text) - weight).ToString ();
			} else {
				temp.GetComponent<SomeVarUsed> ().ScoreValue.GetComponent<Text> ().text = "0";
			}

		}
						
	}

	//when done button clicked
	public static void clickOnDone(){
		GameObject temp = GameObject.Find ("VarAttached");
		string[] tempCards = new string[4] {"null", "null", "null", "null"};
		string tempFaceUpCard = "null";
		int allCardsOfSameShape=0; //to check if all cards in the holding panel are of same shape
		int twoCardsOfSameShape=0; //to check if two cards in the holding panel are of same shape and in deck2 ie, face up deck
		int threeCardsOfSameShape=0; //to check if two cards in the holding panel are of same shape and in deck2 ie, face up deck
		int allDifferentCards=0; //to check if all cards in the holding panel are diff

		if (temp.GetComponent<SomeVarUsed> ().Deck2.transform.childCount > 0) {
			tempFaceUpCard = temp.GetComponent<SomeVarUsed> ().Deck2.transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.name;
		}

		// find all the cards in the holding panel
		if (temp.GetComponent<SomeVarUsed> ().Card1.transform.childCount > 0) {
			tempCards[0] = temp.GetComponent<SomeVarUsed> ().Card1.transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.name;
		}
		if (temp.GetComponent<SomeVarUsed> ().Card2.transform.childCount > 0) {
			tempCards[1] = temp.GetComponent<SomeVarUsed> ().Card2.transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.name;
		}
		if (temp.GetComponent<SomeVarUsed> ().Card3.transform.childCount > 0) {
			tempCards[2] = temp.GetComponent<SomeVarUsed> ().Card3.transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.name;
		}
		if (temp.GetComponent<SomeVarUsed> ().Card4.transform.childCount > 0) {
			tempCards[3] = temp.GetComponent<SomeVarUsed> ().Card4.transform.GetChild (0).gameObject.GetComponent<Image> ().sprite.name;
		}

		//check if all four cards are in the holding panel
		if(IsAllCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker1", 'C')) allCardsOfSameShape=1;
		else if(IsAllCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker1", 'R')) allCardsOfSameShape=1;	
		else if(IsAllCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker2", 'T')) allCardsOfSameShape=1;
		else if(IsAllCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker2", 'P')) allCardsOfSameShape=1;
		else if(IsAllCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker3", 'S')) allCardsOfSameShape=1;
		else if(IsAllCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker3", 'H')) allCardsOfSameShape=1;

		//check if three cards in the holding panel and one in deck2 same ie, face up deck
		else if(IsThreeCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker1", 'C', tempFaceUpCard)) threeCardsOfSameShape =1;
		else if(IsThreeCardsOfSameShape(tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker1", 'R', tempFaceUpCard)) threeCardsOfSameShape =1;
		else if(IsThreeCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker2", 'T', tempFaceUpCard)) threeCardsOfSameShape =1;
		else if(IsThreeCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker2", 'P', tempFaceUpCard)) threeCardsOfSameShape =1;
		else if(IsThreeCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker3", 'S', tempFaceUpCard)) threeCardsOfSameShape =1;
		else if(IsThreeCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker3", 'H', tempFaceUpCard)) threeCardsOfSameShape =1;

		//check if two cards in the holding panel and one in deck2 same ie, face up deck
		else if(IsTwoCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker1", 'C', tempFaceUpCard)) twoCardsOfSameShape =1;
		else if(IsTwoCardsOfSameShape(tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker1", 'R', tempFaceUpCard)) twoCardsOfSameShape =1;
		else if(IsTwoCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker2", 'T', tempFaceUpCard)) twoCardsOfSameShape =1;
		else if(IsTwoCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker2", 'P', tempFaceUpCard)) twoCardsOfSameShape =1;
		else if(IsTwoCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker3", 'S', tempFaceUpCard)) twoCardsOfSameShape =1;
		else if(IsTwoCardsOfSameShape (tempCards [0], tempCards [1], tempCards [2], tempCards [3], "joker3", 'H', tempFaceUpCard)) twoCardsOfSameShape =1;


		else if(IsAllDifferentCards(tempCards [0], tempCards [1], tempCards [2], tempCards [3],tempFaceUpCard)) allDifferentCards=1;

		// change the score of the player
		ChangeScore(allCardsOfSameShape, 4);

		// change the score of the player
		ChangeScore(twoCardsOfSameShape,2);

		// change the score of the player
		ChangeScore(threeCardsOfSameShape,3);	

		// change the score of the player
		ChangeScore(allDifferentCards,1);

		if(allCardsOfSameShape==0 && twoCardsOfSameShape==0 &&threeCardsOfSameShape==0 &&allDifferentCards==0) ChangeScore(1,-5);
	}

}
