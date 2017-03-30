using System;

public static class RNG
{
	private static System.Random RandomNumberGenerator = new Random();

	public static float NextFloat()
	{
		return (float)RandomNumberGenerator.NextDouble ();
	}

	public static float NextFloat(float min, float max)
	{
        return (float)(RandomNumberGenerator.NextDouble() * (max - min)) + min;
	}

	public static int Next()
	{
		return RandomNumberGenerator.Next();
	}

	public static int Next(int min, int max)
	{
		return RandomNumberGenerator.Next(min, max);
	}


	public static double NextDouble()
	{
		return RandomNumberGenerator.NextDouble();
	}

	public static bool RandomBoolean()
	{
		if ((RandomNumberGenerator.Next () % 2) == 0) {
			return false;
		}
		return true;
	}
}