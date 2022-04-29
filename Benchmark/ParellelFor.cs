using System.Diagnostics;

namespace Benchmark
{
	internal class ParellelFor
	{
		static void Main2(string[] args)
		{
			int[] durchgänge = { 1_000, 10_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000, 100_000_000 };
			for (int i = 0; i < durchgänge.Length; i++)
			{
				Stopwatch sw = Stopwatch.StartNew();
				RegularFor(durchgänge[i]);
				sw.Stop();
				Console.WriteLine($"For {durchgänge[i]}: {sw.ElapsedMilliseconds}");

				Stopwatch sw2 = Stopwatch.StartNew();
				ParallelForMethod(durchgänge[i]);
				sw2.Stop();
				Console.WriteLine($"Parallel For {durchgänge[i]}: {sw2.ElapsedMilliseconds}");
			}
		}

		public static void RegularFor(int iterations)
		{
			double[] erg = new double[iterations];
			for (int i = 0; i < iterations; i++)
			{
				erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
			}
		}

		public static void ParallelForMethod(int iterations)
		{
			double[] erg = new double[iterations];
			Parallel.For(0, iterations, i =>
			{
				erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
			});
		}

	}
}
