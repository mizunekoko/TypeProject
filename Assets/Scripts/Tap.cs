using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tap : MonoBehaviour {
	public GameObject keyAlpha1;
	public GameObject keyAlpha2;
	public GameObject keyAlpha3;
	public GameObject keyAlpha4;

	private Color _color;
	private int _num;

	private GameObject[] _key = new GameObject[4];
	private string[] _str_key = new String[4];
	private bool[] _push_down_flag = new bool[4];


	// Use this for initialization
	void Start () {
		_color = new Color(255,255,255,50);
		_key = new GameObject[]{ keyAlpha1, keyAlpha2, keyAlpha3, keyAlpha4 };
		_str_key = new String[]{"keyAlpha1", "keyAlpha2", "keyAlpha3", "keyAlpha4"};
		_push_down_flag = new bool[]{false, false, false, false};
	}
	
	// Update is called once per frame
	void Update () {
		this.PushKey();
	}


	void PushKey(){

		if(Input.anyKeyDown){
			foreach(KeyCode code in Enum.GetValues(typeof(KeyCode))){  //入力したコードを識別

				if(Input.GetKeyDown(code)){
					
					for(int i = 0; i < _key.Length; i++){
						string pushObjName =  _str_key[i].Replace("key","");

						if(code.ToString() == pushObjName){
							_num = i;
							_push_down_flag[_num] = true;
							_color = new Color(0, 255, 255, 255);
							_key[_num].GetComponent<SpriteRenderer>().color = _color;
							return;
						}

					}

				}
		
			}

		}

		if(_push_down_flag[_num]){

			foreach(KeyCode code in Enum.GetValues(typeof(KeyCode))){

				if(Input.GetKeyUp(code)){

					for(int i = 0; i < _key.Length; i++){
						string pushObjName =  _str_key[i].Replace("key","");

						if(code.ToString() == pushObjName){
							_num = i;
							_push_down_flag[_num] = false;
							_color = new Color(255, 255, 255, 255);
							_key[_num].GetComponent<SpriteRenderer>().color = _color;
							return;
						}

					}

				}

			}

		}
	}
}
