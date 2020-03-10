using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetic : MonoBehaviour
{
	float force=10;
	public GameObject Magnet;
    // Start is called before the first frame update
    void Start()
    {
    }
	public enum State
	{
		Negative,
		Positive,
	}
	public State state;
   public void pos()
   {
	state= State.Positive;
   }
   public void neg()
   {
	   state= State.Negative;
   }
    // Update is called once per frame
    void Update()
    {
		switch (state){
			case State.Positive:
			Debug.Log("Pozitif Seçildi!");
		 GetComponent<Rigidbody>().AddForce((Magnet.transform.position+transform.position)*force*Time.smoothDeltaTime);
			break;
			case State.Negative:
			Debug.Log("Negatif Seçildi");
		 GetComponent<Rigidbody>().AddForce((Magnet.transform.position-transform.position)*force*Time.smoothDeltaTime);
			break;
		}
        if(PlayerController.sifirlama==0)
		{
				transform.position = Vector3.one;
		}
    }
}
