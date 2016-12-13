using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static Tort.Util;

namespace Tort
{
	public class Expresion
	{
		enum EOperation {underfind, conunction, disunction, implication, equalse }
		private Expresion left = null;
		private Expresion right = null;
		private string itemValue = "";
		private bool isNegative = false;
		private EOperation operation;
		private string strValue = "";
		public string Name = "";

		public Expresion(Expresion left, Expresion right, string operatorName)
		{
			this.left = left;
			this.right = right;
			operation = fromString(operatorName);
			strValue = "(" + left.ToString() + ")" + operatorName + "(" + right.ToString() + ")";
		}

		public Expresion(string str)
		{
			strValue = str;
			if (!(str.Contains(Const.conunctionSymbol) ||
				 str.Contains(Const.disunctionSymbol) ||
				 str.Contains(Const.equalsSymbol) ||
				 str.Contains(Const.implicationSymbol)))
			{
				isNegative = (Regex.Matches(str, Const.unnSymbol).Count % 2) == 1;
				itemValue = str.Trim().Replace("(", "").Replace(")", "").Replace(Const.unnSymbol, "");
				return;
			}

			int countBrackets = 0;
			string currentStr;
			for (int i = 0; i <str.Length ; i++)
			{
				currentStr = str[i].ToString();
				if (currentStr == ")")
				{
					countBrackets++;
					continue;
				}
				if (currentStr == "(")
				{
					if (i == 0 && countBrackets == 1)
					{
						str = str.Substring(1, str.Length - 2);
						i = str.Length;
					}
					countBrackets--;
					continue;
				}
				if (countBrackets > 0)
					continue;
				if (currentStr == Const.conunctionSymbol)
				{
					operation = EOperation.conunction;
					splitExpressionBetweenChild(str, i);
					break;
				}

				if (currentStr == Const.disunctionSymbol)
				{
					operation = EOperation.disunction;
					splitExpressionBetweenChild(str, i);
					break;
				}

				if (currentStr == Const.implicationSymbol)
				{
					operation = EOperation.implication;
					splitExpressionBetweenChild(str, i);
					break;
				}

				if (currentStr == Const.equalsSymbol)
				{
					operation = EOperation.equalse;
					splitExpressionBetweenChild(str, i);
					break;
				}
				if (i == str.Length-1 && currentStr == Const.unnSymbol)
				{
					while (str.StartsWith(Const.unnSymbol))
					{
						isNegative = !isNegative;
						str = str.Substring(1, str.Length - 1);
					}
					i = str.Length;
				}
			}

		}

		private EOperation fromString(string operation)
		{
			if (operation == Const.conunctionSymbol)
			{
				return EOperation.conunction;
			}

			if (operation == Const.disunctionSymbol)
			{
				return EOperation.disunction;
			}

			if (operation == Const.implicationSymbol)
			{
				return EOperation.implication;
			}

			if (operation == Const.equalsSymbol)
			{
				return EOperation.equalse;
			}
			return EOperation.underfind;
		}

		private void splitExpressionBetweenChild(string source, int splitPosition)
		{
			string leftSide = source.Substring(0, splitPosition);
			string rightSide = source.Substring(splitPosition + 1, source.Length - splitPosition - 1);
			right = new Expresion(rightSide);
			left = new Expresion(leftSide);
		}

		public HashSet<string> getUnicVar()
		{
			return getUnicVar(new HashSet<string>());
		}

		private HashSet<string> getUnicVar(HashSet<string> existVars)
		{
			if (itemValue.Length > 0)
				existVars.Add(itemValue);
			if (left != null)
				left.getUnicVar(existVars);
			if (right != null)
				right.getUnicVar(existVars);
			return existVars;
		}

		public bool calculate(Dictionary<string, bool> input)
		{
			if (itemValue.Length > 0)
			{

				if (input.ContainsKey(itemValue))
				{
					return isNegative ? !input[itemValue] : input[itemValue];
				}
				else
					return false;

			}
			if (left != null && right != null)
			{
				bool a = left.calculate(input);
				bool b = right.calculate(input);
				bool result = false;
				switch (operation)
				{
					case EOperation.conunction:
						result = (a && b);
						break;
					case EOperation.disunction:
						result = (a || b);
						break;
					case EOperation.equalse:
						result = (a == b);
						break;
					case EOperation.implication:
						result = (!(!b && a));
						break;
				}
				if (isNegative)
					result = (!result);
				return result;
			}
			return false;
		}
		public override string ToString()
		{
			return strValue;
		}

		public bool isTavtolohyya()
		{
			HashSet<string> vars = getUnicVar();
			int coutnRow = (int)Math.Pow(2, vars.Count);
			List<bool> input;
			for (int i = 0; i < coutnRow; i++)
			{
				input = numToBinary(i, vars.Count);
				if (!calculate(mergeInputWithName(vars, input)))
					return false;
			}
			return true;
		}

	}

}
