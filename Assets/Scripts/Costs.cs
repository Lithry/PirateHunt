using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class Food{
	public const float foodPerWorker = 0.2f;
}

public static class Gold{
	public const float goldPerWorker = 0.15f;
}

public static class Wood{
	public const float woodPerWorker = 0.11f;
}

public static class Ships{
	public const float shipsPerWorker = 0.01f;
	public const float shipCost = 0.7f;
	public const int troopsPerShip = 15;
}

public static class Troops{
	public const float troopsPerWorker = 0.08f;
	public const float foodCost = 0.04f;
	public const float goldCost = 0.2f;
}