using UnityEngine;
using System.Collections; 

public enum LapseState {
	RightWay,
	LeftWay,
	RightReturnWay,
	LeftReturnWay,
}

public class FictionLapseMovie {
	public LapseState state = LapseState.RightWay;
	public bool onInput = false;

	private int imageNumber = 0;
	static private int startNumber = 0;
	static private int firstNumber = 10;
	static private int secondNumber = 20;
	static private int endNumber = 30;

	static string lapseImageDir = "LapseImages";

	public FictionLapseMovie() {

	}
	
	public string update () {
		string imagepath = lapseImageDir + "/" + imageNumber;
		Texture lapseImage = (Texture)Resources.Load (imagepath, typeof(Texture));

		switch (state) {
		case LapseState.RightWay:
			if (imageNumber == secondNumber) {
				imageNumber = onInput ? ++imageNumber : --imageNumber;
				state = onInput ? LapseState.LeftReturnWay : LapseState.LeftWay;
			} else {
				imageNumber++;
			}
			break;
		case LapseState.RightReturnWay:

			break;
		case LapseState.LeftWay:
			break;
		case LapseState.LeftReturnWay:

			break;
		}

		return imagepath;
	}

	public void changeLapseState() {
		onInput = onInput ? false : true;
	}
}
