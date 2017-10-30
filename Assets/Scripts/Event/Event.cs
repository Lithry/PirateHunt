using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Event {
	public Event(){}

	abstract public Event CheckEvent();

	abstract public void PlayEvent(Text t, Button b1, Text b1text, Button b2, Text b2text);

	abstract protected void Button1(Button b1, Button b2);

	abstract protected void Button2(Button b1, Button b2);
}
