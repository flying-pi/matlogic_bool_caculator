using System;
namespace Tort.BaseNormalForm
{
  class KNF:BaseNormalForm
	{
		public KNF(Expresion ex):base(ex)
		{

		}

		public KNF(String filePath):base(filePath)
		{
		}

		public override string generateNormalForm()
		{
			checkForTaftology();
			string result = "";
			string put = "";
			for (int e = 0; e < truethTable.Count; e++)
			{

				if (truethTable[e].result)
					continue;
				put = "";
				int i = 0;
				foreach (var name in varsName)
				{
					if (put != "")
						put += Const.disunctionSymbol;
					if (truethTable[e].input[i])
						put += Const.unnSymbol;
					put += name;
					i++;
				}
				if (result != "")
					result += Const.conunctionSymbol;
				result += ("(" + put + ")");

			}
			return result;
		}
	}
}
