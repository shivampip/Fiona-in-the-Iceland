using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class myAdSri : MonoBehaviour {

	private RewardBasedVideoAd rewardVideoAd;
	public Text msgTv;

	public GameObject watchB;
	public BankSri bankS;
	public GameObject rewardPanel;
	public Text rewardTv;


	// Use this for initialization
	void Start () {
		//watchB.SetActive (false);
		rewardPanel.SetActive (false);
		rewardVideoAd = RewardBasedVideoAd.Instance;

		rewardVideoAd.OnAdClosed += HandleOnAdClosed;
		rewardVideoAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		rewardVideoAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;
		rewardVideoAd.OnAdLoaded += HandleOnAdLoaded;
		rewardVideoAd.OnAdOpening += HandleOnAdOpening;
		rewardVideoAd.OnAdRewarded += HandleOnAdRewarded;
		rewardVideoAd.OnAdStarted += HandleOnAdStarted;

		LoadVideo ();
	}
	
	// Update is called once per frame
	void Update () {
		if (readyToShow) {
			watchB.SetActive (true);
		} else {
			watchB.SetActive (false);
		}
	}



	public void LoadVideo(){
		Debug.Log ("Loading...");
		//msgTv.text= "Loading..";
		LoadRewardBasedVideoAd ();
	}

	public void ShowVideo(){
		Debug.Log ("Showing...");
		//msgTv.text = "Showing..";
		ShowRewardBasedVideoAd ();
	}

	//string adUnitId= "ca-app-pub-3940256099942544/5224354917";

	void LoadRewardBasedVideoAd(){
		#if UNITY_EDITOR
		string adUnitId= "unused";
		#elif UNITY_ANDROID 
		string adUnitId= "ca-app-pub-6385771930770544/5342563235";
		#else
		string adUnitId= "unexpected platform";
		#endif

		rewardVideoAd.LoadAd (new AdRequest.Builder ().Build (), adUnitId);
	}

	void ShowRewardBasedVideoAd(){
		if (rewardVideoAd.IsLoaded ()) {
			rewardVideoAd.Show ();
		} else {
			Debug.Log ("SHIVam, Ad not loaded");
			msgTv.text = "Video not loaded.";
		}
	}

		bool isRewarded= false;
		public bool readyToShow= false;

		// These are the ad callback events that can be hooked into.
		public event EventHandler<EventArgs> OnAdLoaded;

		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		public event EventHandler<EventArgs> OnAdOpening;

		public event EventHandler<EventArgs> OnAdStarted;

		public event EventHandler<EventArgs> OnAdClosed;

		public event EventHandler<Reward> OnAdRewarded;

		public event EventHandler<EventArgs> OnAdLeavingApplication;


		public void HandleOnAdLoaded(object sender, EventArgs args){
		Debug.Log ("Video Loaded ");
		msgTv.text = "Video Loaded";
		readyToShow = true;
		}
		public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args){
			//Try to reload
		Debug.Log ("Loading Failed " + args.Message);
		//msgTv.text = "Loading failed " + args.Message;
		//readyToShow = false;
		}
		public void HandleOnAdOpening(object sender, EventArgs args){
			//Pause the action
		//msgTv.text = "Opeining...";
		}
		public void HandleOnAdStarted(object sender, EventArgs args){
			//Mute audio
		}
		public void HandleOnAdClosed(object sender, EventArgs args){
			//Crank the party backup
		Debug.Log ("Closed..");
		//readyToShow = false;
		if (isRewarded) {
			rewardPanel.SetActive (true);
		}
		}

		public void HandleOnAdRewarded(object sender, Reward args){
			Debug.Log ("You got " + args.Amount + " "+ args.Type);
			msgTv.text = "You got " + ((int)(args.Amount / 2)) + " Lifes ";
			bankS.AddLifes ((int)(args.Amount / 2));
			rewardTv.text = "Congratulation..\nYou got " + ((int)(args.Amount / 2)) + " Lifes";
			rewardPanel.SetActive (true);
			isRewarded = true;
		}

		public void HandleOnAdLeavingApplication(object sender, EventArgs args){
		//readyToShow = false;
		}

		public void CloseRewardPanel(){
		rewardPanel.SetActive (false);
		}




}//classEND
