namespace LoUOptimize2
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnTileWoodcuttershut = new System.Windows.Forms.Button();
			this.btnTileWood = new System.Windows.Forms.Button();
			this.btnTileQuarry = new System.Windows.Forms.Button();
			this.btnTileStone = new System.Windows.Forms.Button();
			this.btnTileFarm = new System.Windows.Forms.Button();
			this.btnTileLake = new System.Windows.Forms.Button();
			this.btnTileIronmine = new System.Windows.Forms.Button();
			this.btnTileIron = new System.Windows.Forms.Button();
			this.btnTileTownhouse = new System.Windows.Forms.Button();
			this.btnTileMarketplace = new System.Windows.Forms.Button();
			this.btnTileHarbor = new System.Windows.Forms.Button();
			this.btnTileSawmill = new System.Windows.Forms.Button();
			this.btnTileStonemason = new System.Windows.Forms.Button();
			this.btnTileMill = new System.Windows.Forms.Button();
			this.btnTileFoundry = new System.Windows.Forms.Button();
			this.btnTileWarehouse = new System.Windows.Forms.Button();
			this.btnTileEmpty = new System.Windows.Forms.Button();
			this.btnPaste = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.propertyGridOptimization = new System.Windows.Forms.PropertyGrid();
			this.btnLockNW = new System.Windows.Forms.Button();
			this.btnLockCenter = new System.Windows.Forms.Button();
			this.btnLockSW = new System.Windows.Forms.Button();
			this.btnLockNE = new System.Windows.Forms.Button();
			this.btnLockSE = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCityGuardHouse = new System.Windows.Forms.Button();
			this.btnCastle = new System.Windows.Forms.Button();
			this.btnTileBarracks = new System.Windows.Forms.Button();
			this.btnTileCottage = new System.Windows.Forms.Button();
			this.btnTileOldFarm = new System.Windows.Forms.Button();
			this.btnTileOldQuarry = new System.Windows.Forms.Button();
			this.btnTileOldIronMine = new System.Windows.Forms.Button();
			this.btnshipyard = new System.Windows.Forms.Button();
			this.btnTrinsicTemple = new System.Windows.Forms.Button();
			this.btnMoonglowTower = new System.Windows.Forms.Button();
			this.btnTileOldWoodcuttersHut = new System.Windows.Forms.Button();
			this.btnWorkshop = new System.Windows.Forms.Button();
			this.btnStable = new System.Windows.Forms.Button();
			this.btnTrainingGround = new System.Windows.Forms.Button();
			this.btnTileHideout = new System.Windows.Forms.Button();
			this.pnlCity = new LoUOptimize2.DoubleBufferedPanel();
			this.pnlProgress = new System.Windows.Forms.Panel();
			this.lblInitialScore = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pbarGenerations = new System.Windows.Forms.ProgressBar();
			this.txtBestScore = new System.Windows.Forms.TextBox();
			this.propertyGridCity = new System.Windows.Forms.PropertyGrid();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.lblGeneration = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.pnlCity.SuspendLayout();
			this.pnlProgress.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnTileWoodcuttershut
			// 
			this.btnTileWoodcuttershut.Image = global::LoUOptimize2.Properties.Resources.building_hut;
			this.btnTileWoodcuttershut.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileWoodcuttershut.Location = new System.Drawing.Point(-1, 63);
			this.btnTileWoodcuttershut.Name = "btnTileWoodcuttershut";
			this.btnTileWoodcuttershut.Size = new System.Drawing.Size(58, 58);
			this.btnTileWoodcuttershut.TabIndex = 1;
			this.btnTileWoodcuttershut.Tag = "woodcuttershut";
			this.btnTileWoodcuttershut.UseVisualStyleBackColor = true;
			this.btnTileWoodcuttershut.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileWood
			// 
			this.btnTileWood.Image = global::LoUOptimize2.Properties.Resources.forest;
			this.btnTileWood.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileWood.Location = new System.Drawing.Point(63, 63);
			this.btnTileWood.Name = "btnTileWood";
			this.btnTileWood.Size = new System.Drawing.Size(58, 58);
			this.btnTileWood.TabIndex = 1;
			this.btnTileWood.Tag = "wood";
			this.btnTileWood.UseVisualStyleBackColor = true;
			this.btnTileWood.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileQuarry
			// 
			this.btnTileQuarry.Image = global::LoUOptimize2.Properties.Resources.building_stone_quarry;
			this.btnTileQuarry.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileQuarry.Location = new System.Drawing.Point(-1, 127);
			this.btnTileQuarry.Name = "btnTileQuarry";
			this.btnTileQuarry.Size = new System.Drawing.Size(58, 58);
			this.btnTileQuarry.TabIndex = 1;
			this.btnTileQuarry.Tag = "quarry";
			this.btnTileQuarry.UseVisualStyleBackColor = true;
			this.btnTileQuarry.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileStone
			// 
			this.btnTileStone.Image = global::LoUOptimize2.Properties.Resources.stone;
			this.btnTileStone.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileStone.Location = new System.Drawing.Point(63, 127);
			this.btnTileStone.Name = "btnTileStone";
			this.btnTileStone.Size = new System.Drawing.Size(58, 58);
			this.btnTileStone.TabIndex = 1;
			this.btnTileStone.Tag = "stone";
			this.btnTileStone.UseVisualStyleBackColor = true;
			this.btnTileStone.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileFarm
			// 
			this.btnTileFarm.Image = global::LoUOptimize2.Properties.Resources.building_farm;
			this.btnTileFarm.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileFarm.Location = new System.Drawing.Point(-1, 191);
			this.btnTileFarm.Name = "btnTileFarm";
			this.btnTileFarm.Size = new System.Drawing.Size(58, 58);
			this.btnTileFarm.TabIndex = 1;
			this.btnTileFarm.Tag = "farm";
			this.btnTileFarm.UseVisualStyleBackColor = true;
			this.btnTileFarm.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileLake
			// 
			this.btnTileLake.Image = global::LoUOptimize2.Properties.Resources.lake;
			this.btnTileLake.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileLake.Location = new System.Drawing.Point(63, 191);
			this.btnTileLake.Name = "btnTileLake";
			this.btnTileLake.Size = new System.Drawing.Size(58, 58);
			this.btnTileLake.TabIndex = 1;
			this.btnTileLake.Tag = "lake";
			this.btnTileLake.UseVisualStyleBackColor = true;
			this.btnTileLake.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileIronmine
			// 
			this.btnTileIronmine.Image = global::LoUOptimize2.Properties.Resources.building_mine;
			this.btnTileIronmine.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileIronmine.Location = new System.Drawing.Point(-1, 255);
			this.btnTileIronmine.Name = "btnTileIronmine";
			this.btnTileIronmine.Size = new System.Drawing.Size(58, 58);
			this.btnTileIronmine.TabIndex = 1;
			this.btnTileIronmine.Tag = "ironmine";
			this.btnTileIronmine.UseVisualStyleBackColor = true;
			this.btnTileIronmine.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileIron
			// 
			this.btnTileIron.Image = global::LoUOptimize2.Properties.Resources.iron;
			this.btnTileIron.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileIron.Location = new System.Drawing.Point(63, 255);
			this.btnTileIron.Name = "btnTileIron";
			this.btnTileIron.Size = new System.Drawing.Size(58, 58);
			this.btnTileIron.TabIndex = 1;
			this.btnTileIron.Tag = "iron";
			this.btnTileIron.UseVisualStyleBackColor = true;
			this.btnTileIron.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileTownhouse
			// 
			this.btnTileTownhouse.Image = global::LoUOptimize2.Properties.Resources.building_townhouse;
			this.btnTileTownhouse.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileTownhouse.Location = new System.Drawing.Point(-1, 319);
			this.btnTileTownhouse.Name = "btnTileTownhouse";
			this.btnTileTownhouse.Size = new System.Drawing.Size(58, 58);
			this.btnTileTownhouse.TabIndex = 1;
			this.btnTileTownhouse.Tag = "townhouse";
			this.btnTileTownhouse.UseVisualStyleBackColor = true;
			this.btnTileTownhouse.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileMarketplace
			// 
			this.btnTileMarketplace.Image = global::LoUOptimize2.Properties.Resources.building_market_place;
			this.btnTileMarketplace.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileMarketplace.Location = new System.Drawing.Point(63, 319);
			this.btnTileMarketplace.Name = "btnTileMarketplace";
			this.btnTileMarketplace.Size = new System.Drawing.Size(58, 58);
			this.btnTileMarketplace.TabIndex = 1;
			this.btnTileMarketplace.Tag = "marketplace";
			this.btnTileMarketplace.UseVisualStyleBackColor = true;
			this.btnTileMarketplace.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileHarbor
			// 
			this.btnTileHarbor.Image = global::LoUOptimize2.Properties.Resources.building_harbour;
			this.btnTileHarbor.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileHarbor.Location = new System.Drawing.Point(127, 319);
			this.btnTileHarbor.Name = "btnTileHarbor";
			this.btnTileHarbor.Size = new System.Drawing.Size(58, 58);
			this.btnTileHarbor.TabIndex = 1;
			this.btnTileHarbor.Tag = "harbor";
			this.btnTileHarbor.UseVisualStyleBackColor = true;
			this.btnTileHarbor.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileSawmill
			// 
			this.btnTileSawmill.Image = global::LoUOptimize2.Properties.Resources.building_lumber_mill;
			this.btnTileSawmill.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileSawmill.Location = new System.Drawing.Point(127, 63);
			this.btnTileSawmill.Name = "btnTileSawmill";
			this.btnTileSawmill.Size = new System.Drawing.Size(58, 58);
			this.btnTileSawmill.TabIndex = 1;
			this.btnTileSawmill.Tag = "sawmill";
			this.btnTileSawmill.UseVisualStyleBackColor = true;
			this.btnTileSawmill.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileStonemason
			// 
			this.btnTileStonemason.Image = global::LoUOptimize2.Properties.Resources.building_stonecutter;
			this.btnTileStonemason.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileStonemason.Location = new System.Drawing.Point(127, 127);
			this.btnTileStonemason.Name = "btnTileStonemason";
			this.btnTileStonemason.Size = new System.Drawing.Size(58, 58);
			this.btnTileStonemason.TabIndex = 1;
			this.btnTileStonemason.Tag = "stonemason";
			this.btnTileStonemason.UseVisualStyleBackColor = true;
			this.btnTileStonemason.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileMill
			// 
			this.btnTileMill.Image = global::LoUOptimize2.Properties.Resources.building_mill;
			this.btnTileMill.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileMill.Location = new System.Drawing.Point(127, 191);
			this.btnTileMill.Name = "btnTileMill";
			this.btnTileMill.Size = new System.Drawing.Size(58, 58);
			this.btnTileMill.TabIndex = 1;
			this.btnTileMill.Tag = "mill";
			this.btnTileMill.UseVisualStyleBackColor = true;
			this.btnTileMill.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileFoundry
			// 
			this.btnTileFoundry.Image = global::LoUOptimize2.Properties.Resources.building_iron_furnace;
			this.btnTileFoundry.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileFoundry.Location = new System.Drawing.Point(127, 255);
			this.btnTileFoundry.Name = "btnTileFoundry";
			this.btnTileFoundry.Size = new System.Drawing.Size(58, 58);
			this.btnTileFoundry.TabIndex = 1;
			this.btnTileFoundry.Tag = "foundry";
			this.btnTileFoundry.UseVisualStyleBackColor = true;
			this.btnTileFoundry.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileWarehouse
			// 
			this.btnTileWarehouse.Image = global::LoUOptimize2.Properties.Resources.building_storage;
			this.btnTileWarehouse.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileWarehouse.Location = new System.Drawing.Point(127, -1);
			this.btnTileWarehouse.Name = "btnTileWarehouse";
			this.btnTileWarehouse.Size = new System.Drawing.Size(58, 58);
			this.btnTileWarehouse.TabIndex = 1;
			this.btnTileWarehouse.Tag = "warehouse";
			this.btnTileWarehouse.UseVisualStyleBackColor = true;
			this.btnTileWarehouse.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileEmpty
			// 
			this.btnTileEmpty.Image = global::LoUOptimize2.Properties.Resources.town_bg;
			this.btnTileEmpty.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileEmpty.Location = new System.Drawing.Point(0, -1);
			this.btnTileEmpty.Name = "btnTileEmpty";
			this.btnTileEmpty.Size = new System.Drawing.Size(58, 58);
			this.btnTileEmpty.TabIndex = 1;
			this.btnTileEmpty.Tag = "empty";
			this.btnTileEmpty.UseVisualStyleBackColor = true;
			this.btnTileEmpty.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnPaste
			// 
			this.btnPaste.Location = new System.Drawing.Point(1176, 576);
			this.btnPaste.Name = "btnPaste";
			this.btnPaste.Size = new System.Drawing.Size(60, 23);
			this.btnPaste.TabIndex = 2;
			this.btnPaste.Text = "Paste";
			this.btnPaste.UseVisualStyleBackColor = true;
			this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(1110, 576);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(60, 23);
			this.btnCopy.TabIndex = 2;
			this.btnCopy.Text = "Copy";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(1030, 576);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(74, 23);
			this.btnRun.TabIndex = 2;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// propertyGridOptimization
			// 
			this.propertyGridOptimization.HelpVisible = false;
			this.propertyGridOptimization.Location = new System.Drawing.Point(0, 0);
			this.propertyGridOptimization.Name = "propertyGridOptimization";
			this.propertyGridOptimization.Size = new System.Drawing.Size(199, 154);
			this.propertyGridOptimization.TabIndex = 0;
			this.propertyGridOptimization.ToolbarVisible = false;
			// 
			// btnLockNW
			// 
			this.btnLockNW.Location = new System.Drawing.Point(1030, 338);
			this.btnLockNW.Name = "btnLockNW";
			this.btnLockNW.Size = new System.Drawing.Size(65, 20);
			this.btnLockNW.TabIndex = 3;
			this.btnLockNW.Text = "Lock NW";
			this.btnLockNW.UseVisualStyleBackColor = true;
			this.btnLockNW.Click += new System.EventHandler(this.btnLockNW_Click);
			// 
			// btnLockCenter
			// 
			this.btnLockCenter.Location = new System.Drawing.Point(1095, 338);
			this.btnLockCenter.Name = "btnLockCenter";
			this.btnLockCenter.Size = new System.Drawing.Size(77, 46);
			this.btnLockCenter.TabIndex = 3;
			this.btnLockCenter.Text = "Lock center zone";
			this.btnLockCenter.UseVisualStyleBackColor = true;
			this.btnLockCenter.Click += new System.EventHandler(this.btnLockCenter_Click);
			// 
			// btnLockSW
			// 
			this.btnLockSW.Location = new System.Drawing.Point(1031, 364);
			this.btnLockSW.Name = "btnLockSW";
			this.btnLockSW.Size = new System.Drawing.Size(64, 20);
			this.btnLockSW.TabIndex = 3;
			this.btnLockSW.Text = "Lock SW";
			this.btnLockSW.UseVisualStyleBackColor = true;
			this.btnLockSW.Click += new System.EventHandler(this.btnLockSW_Click);
			// 
			// btnLockNE
			// 
			this.btnLockNE.Location = new System.Drawing.Point(1172, 338);
			this.btnLockNE.Name = "btnLockNE";
			this.btnLockNE.Size = new System.Drawing.Size(65, 20);
			this.btnLockNE.TabIndex = 3;
			this.btnLockNE.Text = "Lock NE";
			this.btnLockNE.UseVisualStyleBackColor = true;
			this.btnLockNE.Click += new System.EventHandler(this.btnLockNE_Click);
			// 
			// btnLockSE
			// 
			this.btnLockSE.Location = new System.Drawing.Point(1172, 364);
			this.btnLockSE.Name = "btnLockSE";
			this.btnLockSE.Size = new System.Drawing.Size(65, 20);
			this.btnLockSE.TabIndex = 3;
			this.btnLockSE.Text = "Lock SE";
			this.btnLockSE.UseVisualStyleBackColor = true;
			this.btnLockSE.Click += new System.EventHandler(this.btnLockSE_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(1110, 605);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(60, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(1176, 605);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(60, 23);
			this.btnLoad.TabIndex = 2;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(1030, 605);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(74, 23);
			this.btnNew.TabIndex = 2;
			this.btnNew.Text = "New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnTileWoodcuttershut);
			this.panel1.Controls.Add(this.btnTileWood);
			this.panel1.Controls.Add(this.btnTileSawmill);
			this.panel1.Controls.Add(this.btnTileQuarry);
			this.panel1.Controls.Add(this.btnTileStone);
			this.panel1.Controls.Add(this.btnTileStonemason);
			this.panel1.Controls.Add(this.btnCityGuardHouse);
			this.panel1.Controls.Add(this.btnTileFarm);
			this.panel1.Controls.Add(this.btnTileLake);
			this.panel1.Controls.Add(this.btnCastle);
			this.panel1.Controls.Add(this.btnTileBarracks);
			this.panel1.Controls.Add(this.btnTileMill);
			this.panel1.Controls.Add(this.btnTileIronmine);
			this.panel1.Controls.Add(this.btnTileIron);
			this.panel1.Controls.Add(this.btnTileFoundry);
			this.panel1.Controls.Add(this.btnTileCottage);
			this.panel1.Controls.Add(this.btnTileEmpty);
			this.panel1.Controls.Add(this.btnTileOldFarm);
			this.panel1.Controls.Add(this.btnTileOldQuarry);
			this.panel1.Controls.Add(this.btnTileOldIronMine);
			this.panel1.Controls.Add(this.btnshipyard);
			this.panel1.Controls.Add(this.btnTrinsicTemple);
			this.panel1.Controls.Add(this.btnMoonglowTower);
			this.panel1.Controls.Add(this.btnTileOldWoodcuttersHut);
			this.panel1.Controls.Add(this.btnWorkshop);
			this.panel1.Controls.Add(this.btnStable);
			this.panel1.Controls.Add(this.btnTrainingGround);
			this.panel1.Controls.Add(this.btnTileHideout);
			this.panel1.Controls.Add(this.btnTileTownhouse);
			this.panel1.Controls.Add(this.btnTileWarehouse);
			this.panel1.Controls.Add(this.btnTileMarketplace);
			this.panel1.Controls.Add(this.btnTileHarbor);
			this.panel1.Location = new System.Drawing.Point(1030, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(207, 320);
			this.panel1.TabIndex = 0;
			// 
			// btnCityGuardHouse
			// 
			this.btnCityGuardHouse.Image = global::LoUOptimize2.Properties.Resources.building_cityguard_house;
			this.btnCityGuardHouse.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnCityGuardHouse.Location = new System.Drawing.Point(63, 511);
			this.btnCityGuardHouse.Name = "btnCityGuardHouse";
			this.btnCityGuardHouse.Size = new System.Drawing.Size(58, 58);
			this.btnCityGuardHouse.TabIndex = 1;
			this.btnCityGuardHouse.Tag = "cityguardhouse";
			this.btnCityGuardHouse.UseVisualStyleBackColor = true;
			this.btnCityGuardHouse.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnCastle
			// 
			this.btnCastle.Image = global::LoUOptimize2.Properties.Resources.building_stronghold;
			this.btnCastle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnCastle.Location = new System.Drawing.Point(127, 511);
			this.btnCastle.Name = "btnCastle";
			this.btnCastle.Size = new System.Drawing.Size(58, 58);
			this.btnCastle.TabIndex = 1;
			this.btnCastle.Tag = "castle";
			this.btnCastle.UseVisualStyleBackColor = true;
			this.btnCastle.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileBarracks
			// 
			this.btnTileBarracks.Image = global::LoUOptimize2.Properties.Resources.building_barracks;
			this.btnTileBarracks.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileBarracks.Location = new System.Drawing.Point(-1, 511);
			this.btnTileBarracks.Name = "btnTileBarracks";
			this.btnTileBarracks.Size = new System.Drawing.Size(58, 58);
			this.btnTileBarracks.TabIndex = 1;
			this.btnTileBarracks.Tag = "barracks";
			this.btnTileBarracks.UseVisualStyleBackColor = true;
			this.btnTileBarracks.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileCottage
			// 
			this.btnTileCottage.Image = global::LoUOptimize2.Properties.Resources.building_cottage;
			this.btnTileCottage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileCottage.Location = new System.Drawing.Point(63, -1);
			this.btnTileCottage.Name = "btnTileCottage";
			this.btnTileCottage.Size = new System.Drawing.Size(58, 58);
			this.btnTileCottage.TabIndex = 1;
			this.btnTileCottage.Tag = "cottage";
			this.btnTileCottage.UseVisualStyleBackColor = true;
			this.btnTileCottage.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileOldFarm
			// 
			this.btnTileOldFarm.Image = global::LoUOptimize2.Properties.Resources.building_farm_old;
			this.btnTileOldFarm.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileOldFarm.Location = new System.Drawing.Point(127, 447);
			this.btnTileOldFarm.Name = "btnTileOldFarm";
			this.btnTileOldFarm.Size = new System.Drawing.Size(58, 58);
			this.btnTileOldFarm.TabIndex = 1;
			this.btnTileOldFarm.Tag = "oldfarm";
			this.btnTileOldFarm.UseVisualStyleBackColor = true;
			this.btnTileOldFarm.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileOldQuarry
			// 
			this.btnTileOldQuarry.Image = global::LoUOptimize2.Properties.Resources.building_stone_quarry_old;
			this.btnTileOldQuarry.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileOldQuarry.Location = new System.Drawing.Point(127, 383);
			this.btnTileOldQuarry.Name = "btnTileOldQuarry";
			this.btnTileOldQuarry.Size = new System.Drawing.Size(58, 58);
			this.btnTileOldQuarry.TabIndex = 1;
			this.btnTileOldQuarry.Tag = "oldquarry";
			this.btnTileOldQuarry.UseVisualStyleBackColor = true;
			this.btnTileOldQuarry.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileOldIronMine
			// 
			this.btnTileOldIronMine.Image = global::LoUOptimize2.Properties.Resources.building_mine_old;
			this.btnTileOldIronMine.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileOldIronMine.Location = new System.Drawing.Point(63, 447);
			this.btnTileOldIronMine.Name = "btnTileOldIronMine";
			this.btnTileOldIronMine.Size = new System.Drawing.Size(58, 58);
			this.btnTileOldIronMine.TabIndex = 1;
			this.btnTileOldIronMine.Tag = "oldironmine";
			this.btnTileOldIronMine.UseVisualStyleBackColor = true;
			this.btnTileOldIronMine.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnshipyard
			// 
			this.btnshipyard.Image = global::LoUOptimize2.Properties.Resources.building_shipyard;
			this.btnshipyard.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnshipyard.Location = new System.Drawing.Point(127, 639);
			this.btnshipyard.Name = "btnshipyard";
			this.btnshipyard.Size = new System.Drawing.Size(58, 58);
			this.btnshipyard.TabIndex = 1;
			this.btnshipyard.Tag = "shipyard";
			this.btnshipyard.UseVisualStyleBackColor = true;
			this.btnshipyard.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTrinsicTemple
			// 
			this.btnTrinsicTemple.Image = global::LoUOptimize2.Properties.Resources.building_temple;
			this.btnTrinsicTemple.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTrinsicTemple.Location = new System.Drawing.Point(-1, 639);
			this.btnTrinsicTemple.Name = "btnTrinsicTemple";
			this.btnTrinsicTemple.Size = new System.Drawing.Size(58, 58);
			this.btnTrinsicTemple.TabIndex = 1;
			this.btnTrinsicTemple.Tag = "trinsictemple";
			this.btnTrinsicTemple.UseVisualStyleBackColor = true;
			this.btnTrinsicTemple.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnMoonglowTower
			// 
			this.btnMoonglowTower.Image = global::LoUOptimize2.Properties.Resources.building_mage_tower;
			this.btnMoonglowTower.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnMoonglowTower.Location = new System.Drawing.Point(63, 639);
			this.btnMoonglowTower.Name = "btnMoonglowTower";
			this.btnMoonglowTower.Size = new System.Drawing.Size(58, 58);
			this.btnMoonglowTower.TabIndex = 1;
			this.btnMoonglowTower.Tag = "moonglowtower";
			this.btnMoonglowTower.UseVisualStyleBackColor = true;
			this.btnMoonglowTower.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileOldWoodcuttersHut
			// 
			this.btnTileOldWoodcuttersHut.Image = global::LoUOptimize2.Properties.Resources.building_hut_old;
			this.btnTileOldWoodcuttersHut.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileOldWoodcuttersHut.Location = new System.Drawing.Point(63, 383);
			this.btnTileOldWoodcuttersHut.Name = "btnTileOldWoodcuttersHut";
			this.btnTileOldWoodcuttersHut.Size = new System.Drawing.Size(58, 58);
			this.btnTileOldWoodcuttersHut.TabIndex = 1;
			this.btnTileOldWoodcuttersHut.Tag = "oldwoodcuttershut";
			this.btnTileOldWoodcuttersHut.UseVisualStyleBackColor = true;
			this.btnTileOldWoodcuttersHut.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnWorkshop
			// 
			this.btnWorkshop.Image = global::LoUOptimize2.Properties.Resources.building_weapon_factory;
			this.btnWorkshop.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnWorkshop.Location = new System.Drawing.Point(127, 575);
			this.btnWorkshop.Name = "btnWorkshop";
			this.btnWorkshop.Size = new System.Drawing.Size(58, 58);
			this.btnWorkshop.TabIndex = 1;
			this.btnWorkshop.Tag = "workshop";
			this.btnWorkshop.UseVisualStyleBackColor = true;
			this.btnWorkshop.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnStable
			// 
			this.btnStable.Image = global::LoUOptimize2.Properties.Resources.building_stables;
			this.btnStable.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnStable.Location = new System.Drawing.Point(63, 575);
			this.btnStable.Name = "btnStable";
			this.btnStable.Size = new System.Drawing.Size(58, 58);
			this.btnStable.TabIndex = 1;
			this.btnStable.Tag = "stable";
			this.btnStable.UseVisualStyleBackColor = true;
			this.btnStable.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTrainingGround
			// 
			this.btnTrainingGround.Image = global::LoUOptimize2.Properties.Resources.building_casern;
			this.btnTrainingGround.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTrainingGround.Location = new System.Drawing.Point(-1, 575);
			this.btnTrainingGround.Name = "btnTrainingGround";
			this.btnTrainingGround.Size = new System.Drawing.Size(58, 58);
			this.btnTrainingGround.TabIndex = 1;
			this.btnTrainingGround.Tag = "trainingground";
			this.btnTrainingGround.UseVisualStyleBackColor = true;
			this.btnTrainingGround.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// btnTileHideout
			// 
			this.btnTileHideout.Image = global::LoUOptimize2.Properties.Resources.building_hideout;
			this.btnTileHideout.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnTileHideout.Location = new System.Drawing.Point(-1, 383);
			this.btnTileHideout.Name = "btnTileHideout";
			this.btnTileHideout.Size = new System.Drawing.Size(58, 58);
			this.btnTileHideout.TabIndex = 1;
			this.btnTileHideout.Tag = "hideout";
			this.btnTileHideout.UseVisualStyleBackColor = true;
			this.btnTileHideout.Click += new System.EventHandler(this.tileButton_Click);
			// 
			// pnlCity
			// 
			this.pnlCity.Controls.Add(this.pnlProgress);
			this.pnlCity.Location = new System.Drawing.Point(0, 0);
			this.pnlCity.Name = "pnlCity";
			this.pnlCity.Size = new System.Drawing.Size(1024, 640);
			this.pnlCity.TabIndex = 0;
			this.pnlCity.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCity_Paint);
			this.pnlCity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlCity_MouseClick);
			// 
			// pnlProgress
			// 
			this.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlProgress.Controls.Add(this.lblGeneration);
			this.pnlProgress.Controls.Add(this.lblInitialScore);
			this.pnlProgress.Controls.Add(this.label1);
			this.pnlProgress.Controls.Add(this.pbarGenerations);
			this.pnlProgress.Controls.Add(this.txtBestScore);
			this.pnlProgress.Location = new System.Drawing.Point(12, 12);
			this.pnlProgress.Name = "pnlProgress";
			this.pnlProgress.Size = new System.Drawing.Size(300, 61);
			this.pnlProgress.TabIndex = 0;
			// 
			// lblInitialScore
			// 
			this.lblInitialScore.AutoSize = true;
			this.lblInitialScore.Location = new System.Drawing.Point(214, 9);
			this.lblInitialScore.Name = "lblInitialScore";
			this.lblInitialScore.Size = new System.Drawing.Size(19, 13);
			this.lblInitialScore.TabIndex = 2;
			this.lblInitialScore.Text = "(0)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Best Score:";
			// 
			// pbarGenerations
			// 
			this.pbarGenerations.Location = new System.Drawing.Point(3, 32);
			this.pbarGenerations.Name = "pbarGenerations";
			this.pbarGenerations.Size = new System.Drawing.Size(205, 23);
			this.pbarGenerations.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pbarGenerations.TabIndex = 1;
			// 
			// txtBestScore
			// 
			this.txtBestScore.Location = new System.Drawing.Point(71, 6);
			this.txtBestScore.Name = "txtBestScore";
			this.txtBestScore.ReadOnly = true;
			this.txtBestScore.Size = new System.Drawing.Size(137, 20);
			this.txtBestScore.TabIndex = 0;
			this.txtBestScore.Text = "0";
			this.txtBestScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// propertyGridCity
			// 
			this.propertyGridCity.HelpVisible = false;
			this.propertyGridCity.Location = new System.Drawing.Point(0, 0);
			this.propertyGridCity.Name = "propertyGridCity";
			this.propertyGridCity.Size = new System.Drawing.Size(199, 154);
			this.propertyGridCity.TabIndex = 1;
			this.propertyGridCity.ToolbarVisible = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(1030, 390);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(207, 180);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.propertyGridOptimization);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(199, 154);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Optimization";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.propertyGridCity);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(199, 154);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "City";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// lblGeneration
			// 
			this.lblGeneration.AutoSize = true;
			this.lblGeneration.Location = new System.Drawing.Point(214, 36);
			this.lblGeneration.Name = "lblGeneration";
			this.lblGeneration.Size = new System.Drawing.Size(13, 13);
			this.lblGeneration.TabIndex = 2;
			this.lblGeneration.Text = "0";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1240, 640);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnLockSE);
			this.Controls.Add(this.btnLockSW);
			this.Controls.Add(this.btnLockCenter);
			this.Controls.Add(this.btnLockNE);
			this.Controls.Add(this.btnLockNW);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.btnPaste);
			this.Controls.Add(this.pnlCity);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Lord of Ultima Planner and Optimizer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.panel1.ResumeLayout(false);
			this.pnlCity.ResumeLayout(false);
			this.pnlProgress.ResumeLayout(false);
			this.pnlProgress.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DoubleBufferedPanel pnlCity;
		private System.Windows.Forms.Button btnTileWoodcuttershut;
		private System.Windows.Forms.Button btnTileWood;
		private System.Windows.Forms.Button btnTileQuarry;
		private System.Windows.Forms.Button btnTileStone;
		private System.Windows.Forms.Button btnTileFarm;
		private System.Windows.Forms.Button btnTileLake;
		private System.Windows.Forms.Button btnTileIronmine;
		private System.Windows.Forms.Button btnTileIron;
		private System.Windows.Forms.Button btnTileTownhouse;
		private System.Windows.Forms.Button btnTileMarketplace;
		private System.Windows.Forms.Button btnTileHarbor;
		private System.Windows.Forms.Button btnTileSawmill;
		private System.Windows.Forms.Button btnTileStonemason;
		private System.Windows.Forms.Button btnTileMill;
		private System.Windows.Forms.Button btnTileFoundry;
		private System.Windows.Forms.Button btnTileWarehouse;
		private System.Windows.Forms.Button btnTileEmpty;
		private System.Windows.Forms.Button btnPaste;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.PropertyGrid propertyGridOptimization;
		private System.Windows.Forms.Button btnLockNW;
		private System.Windows.Forms.Button btnLockCenter;
		private System.Windows.Forms.Button btnLockSW;
		private System.Windows.Forms.Button btnLockNE;
		private System.Windows.Forms.Button btnLockSE;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnTileCottage;
		private System.Windows.Forms.Button btnTileHideout;
		private System.Windows.Forms.Button btnTileOldWoodcuttersHut;
		private System.Windows.Forms.Button btnCityGuardHouse;
		private System.Windows.Forms.Button btnTileBarracks;
		private System.Windows.Forms.Button btnTileOldFarm;
		private System.Windows.Forms.Button btnTileOldQuarry;
		private System.Windows.Forms.Button btnTileOldIronMine;
		private System.Windows.Forms.Button btnTrinsicTemple;
		private System.Windows.Forms.Button btnTrainingGround;
		private System.Windows.Forms.Button btnshipyard;
		private System.Windows.Forms.Button btnMoonglowTower;
		private System.Windows.Forms.Button btnCastle;
		private System.Windows.Forms.Button btnWorkshop;
		private System.Windows.Forms.Button btnStable;
		private System.Windows.Forms.PropertyGrid propertyGridCity;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel pnlProgress;
		private System.Windows.Forms.ProgressBar pbarGenerations;
		private System.Windows.Forms.TextBox txtBestScore;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblInitialScore;
		private System.Windows.Forms.Label lblGeneration;

	}
}

