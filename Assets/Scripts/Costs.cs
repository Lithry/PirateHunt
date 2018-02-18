using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HonorFear{
	public const float pluss = 0.35f; // barFillAmount = amount * 0.01f / pluss
}

public static class Food{
	public const float foodPerWorker = 0.15f;
	public const float goldCost = 0.09f;
}

public static class Gold{
	public const float goldPerWorker = 0.12f;
}

public static class Wood{
	public const float woodPerWorker = 0.10f;
	public const float goldCost = 0.05f;
}

public static class Ships{
	public const float shipsPerWorker = 0.025f;
	public const float woodCost = 0.2f;
	public const float goldCost = 0.08f;
	public const int troopsPerShip = 15;
}

public static class Troops{
	public const float troopsPerWorker = 0.08f;
	public const float foodCost = 0.04f;
	public const float goldCost = 0.16f;
	public const int lossesFromLackFood = 5; // Divided by amount of troops
}