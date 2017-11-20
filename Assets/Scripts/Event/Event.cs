using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Event {
	protected int count = 0;
	public Event(){}

	abstract public Event CheckEvent();

	abstract public void PlayEvent(Text t, Text d, Text b1d, Button b1, Text b1text, Text b2d, Button b2, Text b2text);

	abstract protected void Button1(Button b1, Button b2);

	abstract protected void Button2(Button b1, Button b2);

	public int Count(){
		return count;
	}
}
