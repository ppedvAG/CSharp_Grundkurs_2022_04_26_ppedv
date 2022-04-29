using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;

namespace Benchmark
{
	public class BenchmarkDotNet
	{
		static void Main(string[] args)
		{
			Summary s = BenchmarkRunner.Run<FileStreamPerformance>();
		}
	}

	public class FileStreamPerformance
	{
		private int FileSize = 1_000_000;
		private Memory<byte> buffer = new byte[8_000];

		[GlobalSetup]
		public void Setup() => File.WriteAllBytes("file.txt", new byte[FileSize]);

		[GlobalCleanup]
		public void Cleanup() => File.Delete("file.txt");

		[Benchmark]
		public async ValueTask ReadAsync()
		{
			using FileStream fs = new FileStream("file.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
			while (await fs.ReadAsync(buffer) > 0) { }
		}

		[Benchmark]
		public async ValueTask WriteAsync()
		{
			using FileStream fs = new FileStream("file.txt", FileMode.Create, FileAccess.Write, FileShare.Read, 4096, true);
			for (int i = 0; i < FileSize / buffer.Length; i++)
				await fs.WriteAsync(buffer);
		}
	}
}
