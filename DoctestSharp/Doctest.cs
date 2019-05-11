using System;
using System.Collections.Generic;
using System.Threading;

namespace DoctestSharp
{
	public class Doctest
	{
		private static ThreadLocal<DoctestContext> ctx = new ThreadLocal<DoctestContext>(() => new DoctestContext());
		private static List<int> IndexStack => ctx.Value.IndexStack;
		private static ref int SubcaseIndex => ref ctx.Value.SubcaseIndex;
		private static ref int Depth => ref ctx.Value.Depth;
		private static ref bool DoNext => ref ctx.Value.DoNext;

		public static void RunTest(Action method)
		{
			do
			{
				SubcaseIndex = 0;
				DoNext = false;
				DoNext = false;
				method();
				Console.WriteLine();
			} while (DoNext);
		}

		public static void Subcase(string name, Action subcase)
		{
			if (DoNext)
				return;

			if (Depth < IndexStack.Count &&
				SubcaseIndex == IndexStack[Depth] + 1)
			{
				IndexStack[Depth]++;
				DoNext = true;
				DoNext = true;
				return;
			}

			if (Depth == IndexStack.Count)
			{
				// discovery of new part of subtree
				IndexStack.Add(SubcaseIndex);
			}

			if (SubcaseIndex == IndexStack[Depth])
			{ // visit this subcase tree
				Depth++;
				SubcaseIndex = 0;
				subcase();
				if (!DoNext && IndexStack.Count > Depth)
				{
					// remove grandchildren nodes, if not more subcases available
					IndexStack.RemoveAt(IndexStack.Count - 1);
				}
				Depth--;
				SubcaseIndex = IndexStack[Depth];
			}

			SubcaseIndex++;
		}
	}
}
