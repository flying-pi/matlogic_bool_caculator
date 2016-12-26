using System;
using Gtk;
using Tort;
using System.Collections.Generic;
using static Tort.Util;
using Tort.BaseNormalForm;


public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		InitListeners();
	}

	void InitListeners()
	{
		this.disunctionBtn.Clicked += this.onDisunctClick;
		this.conuctionBtn.Clicked += this.onConunctionClick;
		this.ImplekationBtn.Clicked += this.onImplicationClick;
		this.unBtn.Clicked += this.onUnClick;
		this.euqalseBtn.Clicked += this.onEqualseClick;

		this.inputField.Changed += this.onTextChanged;

		this.calculate.Clicked += this.onCalculateClicked;

		this.dnfByExpression.Clicked += this.onDNFFromExpression;
		this.dnfFromFile.Clicked += this.onDNFFromFile;


		this.KNFFromFile.Clicked += this.onKNFFromFile;
		this.KNFFromExpression.Clicked += this.onKNFFromExpression;

	}

	void test()
	{
		string[] input = new string[] { "A", "B", "C" };
		List<List<string>> result = GetCombinations(input);
		foreach (var i in result)
		{
			foreach (var j in i)
				Console.Write(j);
			Console.WriteLine("");
		}

	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void insertSumbol(String symbol)
	{
		int cursorPos = this.inputField.CursorPosition;
		this.inputField.Text = this.inputField.Text.Insert(cursorPos, symbol);
		this.inputField.GrabFocus();
		this.inputField.Position = cursorPos + 1;
	}

	protected void onTextChanged(object obj, EventArgs args)
	{
		int cursorPos = this.inputField.CursorPosition;
		this.inputField.Text = this.inputField.Text
			.Replace("!", Const.unnSymbol)
			.Replace("=", Const.equalsSymbol)
			.Replace(">", Const.implicationSymbol)
			.Replace("|", Const.disunctionSymbol)
			.Replace("&", Const.conunctionSymbol);
		this.inputField.GrabFocus();
		this.inputField.Position = cursorPos;
	}

	protected void onDisunctClick(object obj, EventArgs args)
	{
		insertSumbol(Const.disunctionSymbol);
	}

	protected void onConunctionClick(object obj, EventArgs args)
	{
		insertSumbol(Const.conunctionSymbol);
	}

	protected void onImplicationClick(object obj, EventArgs args)
	{
		insertSumbol(Const.implicationSymbol);
	}

	protected void onUnClick(object obj, EventArgs args)
	{
		insertSumbol(Const.unnSymbol);
	}

	protected void onEqualseClick(object obj, EventArgs args)
	{
		insertSumbol(Const.equalsSymbol);
	}

	protected void onDNFFromFile(object obj, EventArgs args)
	{
		Gtk.FileChooserDialog filechooser =
		new Gtk.FileChooserDialog("Вибіріть файл з останнім стовпцем таблиці істиності",
			this,
			FileChooserAction.Open,
			"Відміна", ResponseType.Cancel,
			"Відкрити", ResponseType.Accept);

		if (filechooser.Run() == (int)ResponseType.Accept)
			showFormResult(FormFactory.getNormalForm(filechooser.Filename, eFormType.DNF), "ДНФ");
		filechooser.Destroy();
	}


	protected void onDNFFromExpression(object obj, EventArgs args)
	{
		Expresion ex = new Expresion(inputField.Text.Trim().Replace(" ", ""));
		showFormResult(FormFactory.getNormalForm(ex, eFormType.DNF), "ДНФ");
	}


	protected void onKNFFromFile(object obj, EventArgs args)
	{
		Gtk.FileChooserDialog filechooser =
		new Gtk.FileChooserDialog("Вибіріть файл з останнім стовпцем таблиці істиності",
			this,
			FileChooserAction.Open,
			"Відміна", ResponseType.Cancel,
			"Відкрити", ResponseType.Accept);

		if (filechooser.Run() == (int)ResponseType.Accept)
			showFormResult(FormFactory.getNormalForm(filechooser.Filename, eFormType.KNF), "КНФ");
		filechooser.Destroy();
	}


	protected void onKNFFromExpression(object obj, EventArgs args)
	{
		Expresion ex = new Expresion(inputField.Text.Trim().Replace(" ", ""));
		showFormResult(FormFactory.getNormalForm(ex, eFormType.KNF), "КНФ");
	}

	private void showFormResult(BaseNormalForm normalForm, string title)
	{
		string message;
		MessageType type = MessageType.Info;
		try
		{
			message = normalForm.generateNormalForm();
		}
		catch (TautologyException)
		{
			type = MessageType.Error;
			message = "Тавтологія";
		}
		catch (IndentifityFalseException)
		{
			type = MessageType.Error;
			message = "Тотожно хибний вираз";
		}
		MessageDialog md = new MessageDialog(null, DialogFlags.Modal, type, ButtonsType.Ok,
											 message);
		md.Title = title;
		md.Run();
		md.Destroy();
	}


	protected void onCalculateClicked(object obj, EventArgs args)
	{
		string[] inputLines = inputField.Text.Trim().Replace(" ", "").Split(new char[] { ';' });
		Expresion[] ex = new Expresion[inputLines.Length];
		for (int i = 0; i < inputLines.Length; i++)
		{
			ex[i] = new Expresion(inputLines[i]);
			ex[i].Name = "F" + i.ToString();
		}
		HashSet<string> vars = new HashSet<string>();
		foreach (var e in ex)
			vars.UnionWith(e.getUnicVar());
		while (resultTree.Columns.Length > 0)
			resultTree.RemoveColumn(resultTree.Columns[0]);
		Type[] types = new Type[vars.Count + ex.Length];
		for (int i = 0; i < vars.Count + ex.Length; i++)
			types[i] = typeof(string);

		foreach (string s in vars)
		{
			Gtk.TreeViewColumn newColumn = new Gtk.TreeViewColumn();
			newColumn.Title = s;
			resultTree.AppendColumn(newColumn);
		}
		for (int i = 0; i < ex.Length; i++)
		{
			Gtk.TreeViewColumn resultColumn = new Gtk.TreeViewColumn();
			resultColumn.Title = "F" + i.ToString() + " = " + ex[i].ToString();
			resultTree.AppendColumn(resultColumn);
		}
		ListStore data = new ListStore(types);

		for (int i = 0; i < vars.Count + ex.Length; i++)
		{
			Gtk.CellRendererText currentCell = new Gtk.CellRendererText();
			resultTree.Columns[i].PackEnd(currentCell, true);
			resultTree.Columns[i].AddAttribute(currentCell, "text", i);
			resultTree.Columns[i].Resizable = true;
			resultTree.Columns[i].Spacing = 1;
		}


		int coutnRow = (int)Math.Pow(2, vars.Count);
		List<bool> input;
		for (int i = 0; i < coutnRow; i++)
		{
			input = numToBinary(i, vars.Count);
			foreach (Expresion e in ex)
				input.Add(e.calculate(mergeInputWithName(vars, input)));
			string[] rowsData = (boolArrToString(input.ToArray()));
			data.AppendValues(rowsData);

		}
		resultTree.Model = data;
		findImplication(ex);
	}

	protected void findImplication(Expresion[] ex)
	{
		if (ex.Length < 2) return;
		List<List<Expresion>> result = GetCombinations(ex);
		List<Expresion> exCombination = new List<Expresion>();
		int countRow = 0;
		HashSet<String> vars = new HashSet<String>();
		foreach (var v in ex)
			foreach (var s in v.getUnicVar())
				vars.Add(s);
		countRow = (int)Math.Pow(2, vars.Count);
		List<bool> input;
		foreach (List<Expresion> currentCombination in result)
		{
			bool isImplication = true;
			bool firstF, secondF;
			for (int i = 1; i < currentCombination.Count && isImplication; i++)
			{
				for (int a = 0; a < countRow; a++)
				{
					input = numToBinary(a, vars.Count);
					firstF = currentCombination[i - 1].calculate(mergeInputWithName(vars, input));
					secondF = currentCombination[i].calculate(mergeInputWithName(vars, input));
					Console.WriteLine(currentCombination[i - 1].ToString() +" :: "+ currentCombination[i].ToString() +" ==> "
					                  + firstF.ToString() + " :: " + secondF.ToString());
					if (firstF && (!secondF))
					{
						isImplication = false;
						break;
					}
				}
			}
			if (isImplication)
			{
				Expresion newExpression = currentCombination[0];
				for (int i = 1; i < currentCombination.Count; i++)
				{
					newExpression = new Expresion(newExpression, currentCombination[i], Const.implicationSymbol);
				}
				exCombination.Add(newExpression);
			}

		}

		string message = "";
		foreach (var i in exCombination)
		{
			message += i.ToString();
			message += "\n";

		}
		if (message.Length < 2)
			message = "не вдалось знайти жодної послідовності формул,  так аби попередня і наступня утворювали б імплікацію";
		MessageType type = MessageType.Info;
		MessageDialog md = new MessageDialog(null, DialogFlags.NoSeparator, type, ButtonsType.Ok,
											 message);
		md.Title = "Список можливих імплікацій формул";
		md.Run();
		md.Destroy();
	}

}
