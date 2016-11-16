using System;
using System.Collections.Generic;
using System.IO;
using static Tort.Util;

namespace Tort.BaseNormalForm
{
	public enum eFormType
	{
		DNF, KNF
	}

	public abstract class BaseNormalForm
	{
		protected HashSet<string> varsName;
		protected List<ExpresionValue> truethTable;

		public BaseNormalForm(Expresion ex)
		{
			this.varsName = ex.getUnicVar();
			int coutnRow = (int)Math.Pow(2, varsName.Count);

			truethTable = new List<ExpresionValue>();
			for (int i = 0; i < coutnRow; i++)
			{
				ExpresionValue item = new ExpresionValue();
				item.input = numToBinary(i, varsName.Count);
				item.result = ex.calculate(mergeInputWithName(varsName, item.input));
				truethTable.Add(item);
			}

		}

		public BaseNormalForm(String filePath)
		{
			System.IO.StreamReader file = new System.IO.StreamReader(filePath);
			string buf;
			List<bool> source = new List<bool>();
			while ((buf = file.ReadLine()) != null)
				source.Add(buf.Trim() == "1");
			file.Close();
			int size = (int)(Math.Log(source.Count) / Math.Log(2));
			varsName = new HashSet<string>();
			truethTable = new List<ExpresionValue>();
			for (int i = 0; i < size; i++)
				varsName.Add("x" + (i + 1).ToString());
			for (int i = 0; i < Math.Pow(2, size); i++)
			{
				ExpresionValue ex = new ExpresionValue();
				ex.result = source[i];
				ex.input = numToBinary(i, varsName.Count);
				truethTable.Add(ex);
			}
		}

		protected struct ExpresionValue
		{
			public List<bool> input;
			public bool result;
		}

		protected void checkForTaftology()
		{
			int countNegative = 0;
			int countPositive = 0;
			foreach (var e in truethTable)
				if (e.result)
					countPositive++;
				else
					countNegative++;
			if (countPositive == 0)
				throw new IndentifityFalseException();
			else if (countNegative == 0)
				throw new TautologyException();
		}

		/// <exception cref="TautologyException">Calls when expresion is tautology.</exception>
		/// <exception cref="IndentifityFalseException">Calls when expresion is indentifity false.</exception>
		public abstract string generateNormalForm();


	}


	public static class FormFactory
	{
		public static BaseNormalForm getNormalForm(Expresion expression, eFormType type)
		{
			if (type == eFormType.DNF)
				return new DNF(expression);
			else
				return new KNF(expression);
		}

		public static BaseNormalForm getNormalForm(string filePath, eFormType type)
		{
			if (type == eFormType.DNF)
				return new DNF(filePath);
			else 
				return new KNF(filePath);

		}
	}

	public class TautologyException : Exception
	{

	}


	public class IndentifityFalseException : Exception
	{
	}
}