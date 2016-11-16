
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed2;

	private global::Gtk.Button conuctionBtn;

	private global::Gtk.Button disunctionBtn;

	private global::Gtk.Button euqalseBtn;

	private global::Gtk.Button ImplekationBtn;

	private global::Gtk.Button unBtn;

	private global::Gtk.Entry inputField;

	private global::Gtk.Button calculate;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView resultTree;

	private global::Gtk.Button dnfByExpression;

	private global::Gtk.Button dnfFromFile;

	private global::Gtk.Button KNFFromExpression;

	private global::Gtk.Button KNFFromFile;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.WidthRequest = 600;
		this.HeightRequest = 500;
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.Resizable = false;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed2 = new global::Gtk.Fixed();
		this.fixed2.Name = "fixed2";
		this.fixed2.HasWindow = false;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.conuctionBtn = new global::Gtk.Button();
		this.conuctionBtn.CanFocus = true;
		this.conuctionBtn.Name = "conuctionBtn";
		this.conuctionBtn.UseUnderline = true;
		this.conuctionBtn.Label = global::Mono.Unix.Catalog.GetString("Кон'юнкція(∧)");
		this.fixed2.Add(this.conuctionBtn);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.conuctionBtn]));
		w1.X = 5;
		w1.Y = 95;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.disunctionBtn = new global::Gtk.Button();
		this.disunctionBtn.CanFocus = true;
		this.disunctionBtn.Name = "disunctionBtn";
		this.disunctionBtn.UseUnderline = true;
		this.disunctionBtn.Label = global::Mono.Unix.Catalog.GetString("Діз'юнкція (∨)");
		this.fixed2.Add(this.disunctionBtn);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.disunctionBtn]));
		w2.X = 100;
		w2.Y = 95;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.euqalseBtn = new global::Gtk.Button();
		this.euqalseBtn.CanFocus = true;
		this.euqalseBtn.Name = "euqalseBtn";
		this.euqalseBtn.UseUnderline = true;
		this.euqalseBtn.Label = global::Mono.Unix.Catalog.GetString("Еквівалнтність(~)");
		this.fixed2.Add(this.euqalseBtn);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.euqalseBtn]));
		w3.X = 291;
		w3.Y = 95;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.ImplekationBtn = new global::Gtk.Button();
		this.ImplekationBtn.CanFocus = true;
		this.ImplekationBtn.Name = "ImplekationBtn";
		this.ImplekationBtn.UseUnderline = true;
		this.ImplekationBtn.Label = global::Mono.Unix.Catalog.GetString("Імплікація(→ )");
		this.fixed2.Add(this.ImplekationBtn);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.ImplekationBtn]));
		w4.X = 195;
		w4.Y = 95;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.unBtn = new global::Gtk.Button();
		this.unBtn.CanFocus = true;
		this.unBtn.Name = "unBtn";
		this.unBtn.UseUnderline = true;
		this.unBtn.Label = global::Mono.Unix.Catalog.GetString("Заперечення(¬)");
		this.fixed2.Add(this.unBtn);
		global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.unBtn]));
		w5.X = 410;
		w5.Y = 95;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.inputField = new global::Gtk.Entry();
		this.inputField.WidthRequest = 590;
		this.inputField.CanFocus = true;
		this.inputField.Name = "inputField";
		this.inputField.Text = global::Mono.Unix.Catalog.GetString("A∨¬(A~B)");
		this.inputField.IsEditable = true;
		this.inputField.InvisibleChar = '●';
		this.fixed2.Add(this.inputField);
		global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.inputField]));
		w6.X = 5;
		w6.Y = 5;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.calculate = new global::Gtk.Button();
		this.calculate.CanFocus = true;
		this.calculate.Name = "calculate";
		this.calculate.UseUnderline = true;
		this.calculate.Label = global::Mono.Unix.Catalog.GetString("Розрахувати");
		this.fixed2.Add(this.calculate);
		global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.calculate]));
		w7.X = 515;
		w7.Y = 95;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.WidthRequest = 590;
		this.GtkScrolledWindow.HeightRequest = 300;
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.resultTree = new global::Gtk.TreeView();
		this.resultTree.CanFocus = true;
		this.resultTree.Name = "resultTree";
		this.GtkScrolledWindow.Add(this.resultTree);
		this.fixed2.Add(this.GtkScrolledWindow);
		global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.GtkScrolledWindow]));
		w9.X = 5;
		w9.Y = 125;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.dnfByExpression = new global::Gtk.Button();
		this.dnfByExpression.CanFocus = true;
		this.dnfByExpression.Name = "dnfByExpression";
		this.dnfByExpression.UseUnderline = true;
		this.dnfByExpression.Label = global::Mono.Unix.Catalog.GetString("Обчислити ДНФ по формулі");
		this.fixed2.Add(this.dnfByExpression);
		global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.dnfByExpression]));
		w10.X = 5;
		w10.Y = 425;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.dnfFromFile = new global::Gtk.Button();
		this.dnfFromFile.CanFocus = true;
		this.dnfFromFile.Name = "dnfFromFile";
		this.dnfFromFile.UseUnderline = true;
		this.dnfFromFile.Label = global::Mono.Unix.Catalog.GetString("Обчислити ДНФ з файлу");
		this.fixed2.Add(this.dnfFromFile);
		global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.dnfFromFile]));
		w11.X = 185;
		w11.Y = 425;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.KNFFromExpression = new global::Gtk.Button();
		this.KNFFromExpression.CanFocus = true;
		this.KNFFromExpression.Name = "KNFFromExpression";
		this.KNFFromExpression.UseUnderline = true;
		this.KNFFromExpression.Label = global::Mono.Unix.Catalog.GetString("КНФ по формулі");
		this.fixed2.Add(this.KNFFromExpression);
		global::Gtk.Fixed.FixedChild w12 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.KNFFromExpression]));
		w12.X = 345;
		w12.Y = 425;
		// Container child fixed2.Gtk.Fixed+FixedChild
		this.KNFFromFile = new global::Gtk.Button();
		this.KNFFromFile.CanFocus = true;
		this.KNFFromFile.Name = "KNFFromFile";
		this.KNFFromFile.UseUnderline = true;
		this.KNFFromFile.Label = global::Mono.Unix.Catalog.GetString("КНФ з файлу");
		this.fixed2.Add(this.KNFFromFile);
		global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[this.KNFFromFile]));
		w13.X = 455;
		w13.Y = 425;
		this.Add(this.fixed2);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 642;
		this.DefaultHeight = 846;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
	}
}