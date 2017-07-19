using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLogging : MonoBehaviour {

	public string postDataURL = "save_data.php"; //add a ? to your url

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
}
