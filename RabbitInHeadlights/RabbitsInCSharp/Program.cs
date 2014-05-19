

using System;

namespace RabbitsInCSharp
{
	class Program
	{
		static void Main(string[] args)
		{
			var vector2Data = new TypesExamples.Vector2Data(2, 2.3d);
			Console.WriteLine("Data is x={0} y={1}",vector2Data.x, vector2Data.y);
			Console.ReadLine();
		}
	}
}
