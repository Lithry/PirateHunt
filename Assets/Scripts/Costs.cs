using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TroopsCost
{
	public const int Gold 		= 10;
	public const int Honor 		= 1;
	public const int Fear 		= 5; 
	public const int Idle		= 1;
}

public static class TroopsSlots{
	public const int TroopsForShip = 15;
}

public static class ShipsCost{
	public const int ResourcesCost = 50;
	public const int DiscountForMassProduct = 10;
	public const int HonorIfPay = 5;
	public const int FearIfForce = 20;
}

public static class ResourceCost{
	public const int ResourcesCost100 = 40;
	public const int DiscountForMassProduct = 5;
	public const int HonorIfPay = 3;
	public const int FearIfForce = 30;
}

public static class Taxes{
	public const int Gold = 100;
	public const int HonorIfCollected = 2;
	public const int TimeToWait = 8;
	public const int FearIfForced = 10;
}