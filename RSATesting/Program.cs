using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSATesting
{
  class Program
  {
	static void Main(string[] args)
	{
	  Console.WriteLine("Go Big");

	  var test = new RsaTester();

	  test.Setup();

	  for (var ix = 0; ix < 10000; ix++)
	  {
			Console.WriteLine($"Test {ix}");

			test.TesRSAPadding();
	  }

	  Console.WriteLine("Go Home");

	  var x = Console.ReadKey();
	}
  }
}
