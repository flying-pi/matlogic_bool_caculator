using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tort
{
	[TestFixture()]
	public class ExpresionTest
	{
		public void TestCase()
		{
		}

		[TestCase("", 0)]
		[TestCase("A", 1)]
		[TestCase((Const.unnSymbol + "A"), 1)]
		[TestCase(("skdsjskdjksjdskdj"), 1)]
		[TestCase(("A" + Const.conunctionSymbol + "A" + Const.disunctionSymbol +
				   "A" + Const.implicationSymbol + Const.unnSymbol + "A"), 1)]

		[TestCase(("A" + Const.conunctionSymbol + "B" + Const.disunctionSymbol +
				   "C" + Const.implicationSymbol + Const.unnSymbol + "D"), 4)]

		[TestCase(("(A" + Const.conunctionSymbol + "B)" + Const.disunctionSymbol +
				   "(F" + Const.conunctionSymbol + "A)" + Const.disunctionSymbol +
				   "C" + Const.implicationSymbol + Const.unnSymbol + "D"), 5)]
		public void ArgCountTest(string input, int result)
		{
			Assert.AreEqual((new Expresion(input)).getUnicVar().Count, result);
		}


		const string conuntion2Test = "A" + Const.conunctionSymbol + "B";
		const string disunction2Test = "A" + Const.disunctionSymbol + "B";
		const string equals2Test = "A" + Const.equalsSymbol + "B";
		const string implication2Test = "A" + Const.implicationSymbol + "B";
		const string brackets3Test = "A" + Const.conunctionSymbol + "(B" + Const.disunctionSymbol + "C)";
		const string bracketsWithUn3Test = "A" + Const.conunctionSymbol+ Const.unnSymbol + "(B" + Const.disunctionSymbol + "C)";


		[TestCase("A", true, true)]
		[TestCase("A", false, false)]
		[TestCase(Const.unnSymbol + "A", true, false)]
		[TestCase(Const.unnSymbol + "A", false, true)]

		[TestCase(conuntion2Test, true, true, true)]
		[TestCase(conuntion2Test, false, true, false)]
		[TestCase(conuntion2Test, false, false, true)]
		[TestCase(conuntion2Test, false, false, false)]

		[TestCase(equals2Test, true, true, true)]
		[TestCase(equals2Test, false, true, false)]
		[TestCase(equals2Test, false, false, true)]
		[TestCase(equals2Test, true, false, false)]

		[TestCase(implication2Test, true, true, true)]
		[TestCase(implication2Test, false, true, false)]
		[TestCase(implication2Test, true, false, true)]
		[TestCase(implication2Test, true, false, false)]

		[TestCase(brackets3Test, false, false, false, false)]
		[TestCase(brackets3Test, false, false, false, true)]
		[TestCase(brackets3Test, false, false, true, false)]
		[TestCase(brackets3Test, false, false, true, true)]
		[TestCase(brackets3Test, false, true, false, false)]
		[TestCase(brackets3Test, true, true, false, true)]
		[TestCase(brackets3Test, true, true, true, false)]
		[TestCase(brackets3Test, true, true, true, true)]

		[TestCase(bracketsWithUn3Test, false, false, false, false)]
		[TestCase(bracketsWithUn3Test, false, false, false, true)]
		[TestCase(bracketsWithUn3Test, false, false, true, false)]
		[TestCase(bracketsWithUn3Test, false, false, true, true)]
		[TestCase(bracketsWithUn3Test, true, true, false, false)]
		[TestCase(bracketsWithUn3Test, false, true, false, true)]
		[TestCase(bracketsWithUn3Test, false, true, true, false)]
		[TestCase(bracketsWithUn3Test, false, true, true, true)]
		public void CalculationTest(String input, bool result, params bool[] args)
		{
			Expresion ex = new Expresion(input);
			var names = ex.getUnicVar();
			int i = 0;
			Dictionary<string, bool> inputParams = new Dictionary<string, bool>();
			foreach (String s in names)
				inputParams.Add(s, args[i++]);
			bool exResult = ex.calculate(inputParams);
			Assert.AreEqual(result, exResult);
		}
	}
}
