using System;
using static DoctestSharp.Doctest;

namespace DoctestSharp
{
	class Program
	{
		public static void TestMethod()
		{
			Console.WriteLine("root");
			Subcase("1", () =>
			{
				Console.WriteLine("1");
				Subcase("1.1", () => Console.WriteLine("1.1"));
				Subcase("1.2", () => Console.WriteLine("1.2"));
			});
			Subcase("2", () =>
			{
				Console.WriteLine("2");
				Subcase("2.1", () => Console.WriteLine("2.1"));
				Subcase("2.2", () =>
				{
					Console.WriteLine("2.2.1");
					Subcase("2.2.1.1", () => Console.WriteLine("2.2.1.1"));
					Subcase("2.2.1.2", () => Console.WriteLine("2.2.1.2"));
				});

				Subcase("2.3", () => Console.WriteLine("2.3"));
				Subcase("2.4", () => Console.WriteLine("2.4"));
			});
		}
		static void Main(string[] args)
		{
			RunTest(TestMethod);
		}
	}
}
