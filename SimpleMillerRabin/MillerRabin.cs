using System;

namespace SimpleMillerRabin
{
	public class MillerRabin
	{
    public static bool MRPrimeTest(int n)
    {
      if (n % 2 == 0)
        return false;

      int[] testValues = new int[] { };

      if (n < 1373653)
        testValues = new int[] { 2, 3 };
      else if (n < 9080191)
        testValues = new int[] { 31, 73 };
      else if (n < int.MaxValue)
        testValues = new int[] { 2, 7, 61 };

      bool pass = true;

      foreach (int a in testValues)
        if (!MRPass(n, a))
          return false;

      return pass;
    }

    private static bool MRPass(int n, int a)
    {
      if(n == 1)
        return false;
      if(n == 2)
        return true;
      if(n == 3)
        return true;

      int s = 0;
      int d = n - 1;

      while (d % 2 == 0)
      {
        s++;
        d /= 2;
      }

      int x = modExp(a, d, n);

      if (x == 1)
        return true;

      for (int r = 0; r < s; r++)
        if (x == n - 1)
          return true;
        else
          x = modExp(x, 2, n);

      if (x == n - 1)
        return true;

      return false;
    }

    private static int modExp(int b, int e, int m)
    {
      long lb = b;
      long le = e;
      long lm = m;

      long result = 1;

      while (le > 0)
      {
        if ((le & 1) == 1)
          result = ((result % lm) * (lb % lm)) % lm;
        le = le >> 1;
        lb = ((lb % lm) * (lb % lm)) % lm;
      }

      return (int)result;
    }
	}
}

