using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Tort
{
	public static class Util
	{
		public static List<bool> numToBinary(int num, int byteCount)
		{
			List<bool> result = new List<bool>();
			while (num > 0)
			{
				result.Insert(0, num % 2 == 1);
				num = num / 2;
			}
			while (result.Count < byteCount)
				result.Insert(0, false);
			return result;
		}

		public static string[] boolArrToString(bool[] input)
		{
			string[] result = new string[input.Length];
			for (int i = 0; i < input.Length; i++)
				result[i] = input[i] ? " 1 " : " 0 ";
			return result;
		}

		public static Dictionary<string, bool> mergeInputWithName(HashSet<string> names, List<bool> values)
		{
			Dictionary<string, bool> result = new Dictionary<string, bool>();
			int i = 0;
			foreach (string s in names)
				result.Add(s, values[i++]);
			return result;
		}

		public static List<List<T>> GetCombinations<T>(T[] input)
		{
			List<List<T>> result = new List<List<T>>();
			GetCombinations(ref result,null, ImmutableList.Create(input));
			return result;
		}

		public static void GetCombinations<T>(ref List<List<T>> result,ImmutableList<T> workerList,ImmutableList<T> input)
		{
			if (input.Count == 0)
			{
				if(workerList != null)
				result.Add(new List<T>(workerList));
				return;
			}
			if (workerList == null)
				workerList = ImmutableList.Create<T>();
			foreach (var i in input)
			{
				GetCombinations(ref result, workerList.Add(i), input.Remove(i));
			}
		}
	}
}
