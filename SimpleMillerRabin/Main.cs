using System;

namespace SimpleMillerRabin
{
	class MainClass
	{
		public static void Main( string[] args )
		{
			for(int i = 10000000; i < 11000000; i++)
				if(MillerRabin.MRPrimeTest(i))
					Console.WriteLine("Prime: {0}", i);
		}
	}
}
