using UnityEngine;
using System.Collections;

public class movieController : MonoBehaviour {
	string movieName1 = "lab1";
	string movieName2 = "lab2"; 
	string lapseImageDir = "LapseImages";
	MovieTexture movieTexture1; 
	MovieTexture movieTexture2;
	public AudioClip sound1;
	public AudioClip sound2;
	AudioSource[] audioSources;
	MeshRenderer ren; 

	bool isLapse = false;
	int lapseCount = 0;

	int movieStatus = 0;

	void Start () {
		MovieTexture mainMovieTexture = (MovieTexture)GetComponent<Renderer> ().material.mainTexture;
		mainMovieTexture.loop = true;
		audioSources = gameObject.GetComponents<AudioSource> ();
		audioSources[0].clip = sound1;
		audioSources[1].clip = sound2;
		audioSources[0].Play ();
		mainMovieTexture.Play ();
//		audio.Play ();

		ren = gameObject.GetComponent<MeshRenderer> ();
		movieTexture1 = (MovieTexture)Resources.Load (movieName1, typeof(MovieTexture)); 
		movieTexture1.loop = true;
		movieTexture2 = (MovieTexture)Resources.Load (movieName2, typeof(MovieTexture));
		movieTexture2.loop = true; 

	}

	void Update () {
		if (isLapse) {
			UpdateLapseImage();
		}

		if (Input.GetKey (KeyCode.A)) {
			stopMovieImage();
			movieStatus = 0;
			ren.material.mainTexture = movieTexture1;
			movieTexture1.Play();
		} else if (Input.GetKey (KeyCode.S)) {
			stopMovieImage();
			movieStatus = 1;
			ren.material.mainTexture = movieTexture2;
			movieTexture2.Play();
		} else if (Input.GetKey (KeyCode.D)) { 
			stopMovieImage();
			movieStatus = 2;
			isLapse = true;
		} else if (Input.GetKey (KeyCode.F)) {  
			audioSources[0].Stop();
			audioSources[1].Play ();
		}
	}

	void stopMovieImage() {
		switch (movieStatus) {
		case 0:
			movieTexture1.Stop();
			break;
		case 1:
			movieTexture2.Stop ();
			break;
		case 2:
			isLapse = false;
			lapseCount = 0;
			break;
		}
	}

	void UpdateLapseImage() { 
		if (lapseCount % 2 == 0) { 
			string imagepath = lapseImageDir + "/0";
//			string imagepath = lapseImageDir + "/" + lapseCount;
			Texture lapseImage = (Texture)Resources.Load (imagepath, typeof(Texture));
			ren.material.mainTexture = lapseImage;
		}
	}
}
