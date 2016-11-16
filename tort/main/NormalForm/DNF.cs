using System;
namespace Tort.BaseNormalForm
{
	class DNF : BaseNormalForm
	{

		public DNF(Expresion ex):base(ex)
		{

		}

		public DNF(String filePath):base(filePath)
		{
		}

		public override string generateNormalForm()
		{
			checkForTaftology();
			string result = "";
			string put = "";
			for (int e = 0; e < truethTable.Count;e++)
			{

				if (!truethTable[e].result)
					continue;
				put = "";
				int i = 0;
				foreach (var name in varsName)
				{
					if (put != "")
						put += Const.conunctionSymbol;
					if (!truethTable[e].input[i])
						put += Const.unnSymbol;
					put += name;
					i++;
				}
				if (result != "")
					result += Const.disunctionSymbol;
				result += ("(" + put + ")");

			}
			return result;
		}
	}
}
