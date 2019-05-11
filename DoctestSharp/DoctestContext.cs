using System.Collections.Generic;

namespace DoctestSharp
{
	internal class DoctestContext
	{
		public List<int> IndexStack = new List<int>();
		public int SubcaseIndex;
		public int Depth;
		public bool DoNext;
	}
}