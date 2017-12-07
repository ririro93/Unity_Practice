using UnityEngine;
using System.Collections;
using Drone.Hardware;

public class InputControl : MonoBehaviour
{
	
	public MainBoard MainBoard;
	
	void FixedUpdate ()
	{
		ControlSignal signal = new ControlSignal ();
		if(Input.GetKey(KeyCode.W)){
			signal.Throttle += 1f;
		}
		if(Input.GetKey(KeyCode.S)){
			signal.Rudder += 1f;
		}
		if(Input.GetKey(KeyCode.I)){
			signal.Elevator += 1f;
		}
		if(Input.GetKey(KeyCode.K)){
			signal.Aileron += 1f;
		}		
		// signal.Throttle = Input.GetAxis("Vertical");
		// signal.Rudder = Input.GetAxis ("Horizontal");
		// signal.Elevator = Input.GetAxis ("Mouse X");
		// signal.Aileron = Input.GetAxis ("Mouse Y");	
		MainBoard.SendControlSignal (signal);
	}
	
}