using UnityEngine;
using System.Collections;
using Drone.Hardware;

public class InputControl : MonoBehaviour
{
	
	public MainBoard MainBoard;
	
	void FixedUpdate ()
	{
		ControlSignal signal = new ControlSignal ();
		
		signal.Throttle = Input.GetAxis ("Throttle");
		signal.Rudder = Input.GetAxis ("Rudder");
		signal.Elevator = Input.GetAxis ("Elevator");
		signal.Aileron = Input.GetAxis ("Aileron");
		
		MainBoard.SendControlSignal (signal);
	}
	
}