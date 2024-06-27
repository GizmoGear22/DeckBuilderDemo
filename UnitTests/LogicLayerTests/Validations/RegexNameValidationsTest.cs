using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.LogicLayerTests.Validations
{
	public class RegexNameValidationsTest
	{
		[Theory]
		[InlineData("Machine Rifle", true)]
		[InlineData("12 Monkeys", true)]
		[InlineData("@Run", false)]
		[InlineData("Heaven's Gate", true)]
		[InlineData("Run 4 Life", true)]
		[InlineData("Deep@you", false)]
		public void MatchName(string name, bool expected)
		{
			//arrange
			string pattern = @"^[A-Z0-9][A-Za-z0-9' ]*$";

			//act
			var result = Regex.IsMatch(name, pattern);

			//assert
			Assert.Equal(expected, result);
		}
	}
}
