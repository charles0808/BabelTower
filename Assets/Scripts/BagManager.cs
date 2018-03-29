﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DuloGames.UI;


public class BagManager : MonoBehaviour {
	//public List<Item> baglist;
	//public int maxValue;
	//window
	public GameObject bagObject;
	public Character player;
	public UIItemSlot[] slots = new UIItemSlot[42];
	[SerializeField] private GameObject Content;
	//only for testing
	[SerializeField] private Sprite Shoes;
	int lastCount;



	void Awake(){
		int i = 0;
		foreach (Transform child in Content.transform)  
		{  
			//Debug.Log ("Child name is" + child.name);
			slots [i++] = child.gameObject.GetComponent<UIItemSlot>();  
		}
	}

	// Use this for initialization
	void Start () {
		 

		//only for testing
		//testing();
	}
	
	// Update is called once per frame
	void Update () {
		//check if we need open or close the gui of bag
		if (Input.GetButtonDown("Inventory") && bagObject.activeSelf) {
			Debug.Log ("close the gui!!!");
			closeGui ();
		} else if (Input.GetButtonDown("Inventory") && !bagObject.activeSelf) {
			Debug.Log ("open the gui!!!");
			openGui ();
		}
			
		
	}

	//add items to bag
	public void addItem(Item item){
		if (player.inventory.list.Count < player.inventory.capacity) {
			player.inventory.list.Add (item);
			//if the window is open, update immediately
			if (bagObject.activeSelf) {
				updateGui ();
			}

		} else {
			Debug.Log ("Exceeds the capacity");
		}
	}

	/* Delete items by it own */
	public void deleteItem(Item obj){
		if (player.inventory.list.Contains (obj)) {
			//delete
			Debug.Log("Delete..." + obj.Name);
			player.inventory.list.Remove (obj);
			//if the window is open, update immediately
			if (bagObject.activeSelf) {
				//when delete, we need to unassign the last item
				slots[player.inventory.list.Count].Unassign();
				updateGui ();
			}

			//TODO: when a character throw out a item, drop it into the environment.

		} else {
			Debug.Log ("not correct item!");
		}
	}

	/* Delete items by its index */
	public void deleteByID(int i){
		if (i < player.inventory.list.Count) {
			player.inventory.list.RemoveAt (i);
			if (bagObject.activeSelf) {
				//when delete, we need to unassign the last item
				slots [player.inventory.list.Count].Unassign ();
				updateGui ();
			}
		}
	}


	//we need to update the gui everytime when we open
	public void updateGui(){
		int i;
		Debug.Log ("count = " + player.inventory.list.Count);
		for(i = 0; i < player.inventory.list.Count; i++){
			//TODO: to show the items in the bag
			Debug.Log("Add the " + i + " item.");
			if (player.inventory.list [i] == null) {
				Debug.Log ("Error: NULL!");
			} else {
				slots [i].newAssign (player.inventory.list [i], null);
			}
		}
	}

	//function that contorls gui to show/hide
	void openGui(){
		updateGui ();
		bagObject.SetActive (true);
	}

	void closeGui(){
		bagObject.SetActive (false);
	}

	void equipped(Item item){
		//TODO: delete the item from bag then update the character part
	}

//	void testing(){
//		Item testItem = new Item ("1 shoes", 100);
//		testItem.Icon = Shoes;
//		testItem.ID = 0;
//		testItem.Type = Item.ItemType.Shoes;
//		Item testItem2 = new Item ("2 shoes", 200);
//		testItem2.Icon = Shoes;
//		testItem2.ID = 2;
//		testItem2.Type = Item.ItemType.Shoes;
//		Item testItem1 = new Item ("3 shoes", 300);
//		testItem1.Icon = Shoes;
//		testItem1.ID = 1;
//		testItem1.Type = Item.ItemType.Shoes;
//		player.inventory.list.Add(testItem);
//		player.inventory.list.Add(testItem2);
//		player.inventory.list.Add(testItem1);
//		Debug.Log (player.inventory.list.Count);
//	}

}
