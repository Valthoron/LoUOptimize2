using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LoUOptimize2.Properties;

namespace LoUOptimize2
{
	public partial class MainForm : Form
	{
		City city;
		Button activeButton;
		bool keepWorking;

		public MainForm()
		{
			InitializeComponent();

			propertyGridOptimization.SelectedObject = OptimizationSettings.Instance;

			activeButton = null;

			city = new City(false);
			propertyGridCity.SelectedObject = city;

			city.CalculateScore();
			Icon = Resources.Icon;
			pnlProgress.Visible = false;
		}

		private void pnlCity_Paint(object sender, PaintEventArgs e)
		{
			if (city.WaterCity)
				e.Graphics.DrawImage(Resources.town_bg_water, pnlCity.ClientRectangle);
			else
				e.Graphics.DrawImage(Resources.town_bg, pnlCity.ClientRectangle);

			Image tile;
			Rectangle rect = new Rectangle();

			for (int y = 0; y < 21; y++)
			{
				for (int x = 0; x < 21; x++)
				{
					tile = null;

					switch (city.Tile[x, y])
					{
						case TileType.Stone: tile = Resources.stone; break;
						case TileType.Wood: tile = Resources.forest; break;
						case TileType.Iron: tile = Resources.iron; break;
						case TileType.Lake: tile = Resources.lake; break;
						case TileType.WoodcuttersHut: tile = Resources.building_hut; break;
						case TileType.Quarry: tile = Resources.building_stone_quarry; break;
						case TileType.Farm: tile = Resources.building_farm; break;
						case TileType.Cottage: tile = Resources.building_cottage; break;
						case TileType.Marketplace: tile = Resources.building_market_place; break;
						case TileType.IronMine: tile = Resources.building_mine; break;
						case TileType.Sawmill: tile = Resources.building_lumber_mill; break;
						case TileType.Mill: tile = Resources.building_mill; break;
						case TileType.Hideout: tile = Resources.building_hideout; break;
						case TileType.Stonemason: tile = Resources.building_stonecutter; break;
						case TileType.Foundry: tile = Resources.building_iron_furnace; break;
						case TileType.TownHall: tile = Resources.building_townhall; break;
						case TileType.Townhouse: tile = Resources.building_townhouse; break;
						case TileType.Barracks: tile = Resources.building_barracks; break;
						case TileType.CityGuardHouse: tile = Resources.building_cityguard_house; break;
						case TileType.TrainingGround: tile = Resources.building_casern; break;
						case TileType.Stable: tile = Resources.building_stables; break;
						case TileType.Workshop: tile = Resources.building_weapon_factory; break;
						case TileType.Shipyard: tile = Resources.building_shipyard; break;
						case TileType.Warehouse: tile = Resources.building_storage; break;
						case TileType.Castle: tile = Resources.building_stronghold; break;
						case TileType.Harbor: tile = Resources.building_harbour; break;
						case TileType.MoonglowTower: tile = Resources.building_mage_tower; break;
						case TileType.TrinsicTemple: tile = Resources.building_temple; break;
						case TileType.OldWoodcuttersHut: tile = Resources.building_hut_old; break;
						case TileType.OldQuarry: tile = Resources.building_stone_quarry_old; break;
						case TileType.OldIronMine: tile = Resources.building_mine_old; break;
						case TileType.OldFarm: tile = Resources.building_farm_old; break;
						case TileType.Empty:
							{
								bool haveFarm = false;

								for (int v = -1; v <= 1; v++)
								{
									for (int u = -1; u <= 1; u++)
									{
										if ((x + u < 0) || (x + u >= 21) || (y + v < 0) || (y + v >= 21))
											continue;

										if ((city.Tile[x + u, y + v] == TileType.Farm) || (city.Tile[x + u, y + v] == TileType.OldFarm))
										{
											haveFarm = true;
											break;
										}
									}

									if (haveFarm)
									{
										tile = Resources.farmland;
										break;
									}
								}
							}
							break;
					}

					if (tile != null)
					{
						rect.X = x * 45 + 40;
						rect.Y = y * 28 + 10;
						rect.Width = 64;
						rect.Height = 64;
						e.Graphics.DrawImage(tile, rect);
					}

					if (city.TileLocked[x, y])
					{
						rect.X = x * 45 + 50;
						rect.Y = y * 28 + 25;
						rect.Width = 12;
						rect.Height = 16;
						e.Graphics.DrawImage(Resources.padlock, rect);
					}
				}
			}

		}

		private void tileButton_Click(object sender, EventArgs e)
		{
			if (activeButton != null)
				activeButton.FlatStyle = FlatStyle.Standard;

			activeButton = sender as Button;
			activeButton.FlatStyle = FlatStyle.Flat;
		}

		private void pnlCity_MouseClick(object sender, MouseEventArgs e)
		{
			Point location = new Point(
				(e.X - 40) / 45,
				(e.Y - 20) / 28
				);

			if ((location.X < 0) || (location.X >= 21) || (location.Y < 0) || (location.Y >= 21))
				return;

			bool checkZone = false;
			for (int i = 0; i < 5; i++)
			{
				if (city.CheckZone(location.X, location.Y, i))
				{
					checkZone = true;
					break;
				}
			}

			if (!checkZone)
				return;

			switch (city.Tile[location.X, location.Y])
			{
				case TileType.Wall:
				case TileType.TownHall:
					return;
			}

			if (e.Button == MouseButtons.Left)
			{
				if (activeButton == null)
					return;

				TileType tileType = (TileType)Enum.Parse(typeof(TileType), activeButton.Tag as string, true);

				switch (tileType)
				{
					case TileType.Harbor:
					case TileType.Shipyard:
						switch (city.Tile[location.X, location.Y])
						{
							case TileType.Harbor:
							case TileType.Shipyard:
							case TileType.WaterEmpty:
								break;

							default:
								return;
						}
						break;

					case TileType.Empty:
						switch (city.Tile[location.X, location.Y])
						{
							case TileType.Harbor:
							case TileType.Shipyard:
							case TileType.WaterEmpty:
								tileType = TileType.WaterEmpty;
								break;

							default:
								break;
						}
						break;

					default:
						switch (city.Tile[location.X, location.Y])
						{
							case TileType.Harbor:
							case TileType.Shipyard:
							case TileType.WaterEmpty:
								return;
						}
						break;
				}

				city.Tile[location.X, location.Y] = tileType;
			}
			else if (e.Button == MouseButtons.Right)
			{
				city.TileLocked[location.X, location.Y] ^= true;
			}

			Rectangle dirtyRect = new Rectangle(
				location.X * 45 + 35 - 64,
				location.Y * 28 + 10 - 64,
				64 * 3,
				64 * 3
				);

			city.CalculateScore();
			pnlCity.Invalidate(dirtyRect);
			propertyGridCity.SelectedObject = city;
		}

		private void btnPaste_Click(object sender, EventArgs e)
		{
			City oldCity = city.Clone();
			city.PutShareString(Clipboard.GetText());
			city.CalculateScore();

			Array.Copy(oldCity.TileLocked, city.TileLocked, oldCity.TileLocked.Length);

			pnlCity.Invalidate();
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(city.GetShareString());
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			if (pnlCity.Enabled)
			{
				pnlCity.Enabled = false;
				btnPaste.Enabled = false;
				btnRun.Text = "Stop";
				btnCopy.Enabled = false;
				btnNew.Enabled = false;
				btnSave.Enabled = false;
				btnLoad.Enabled = false;
				btnLockCenter.Enabled = false;
				btnLockNW.Enabled = false;
				btnLockNE.Enabled = false;
				btnLockSW.Enabled = false;
				btnLockSE.Enabled = false;
				propertyGridOptimization.Enabled = false;

				if (!OptimizationSettings.Instance.PrepareUsableTiles())
				{
					MessageBox.Show(
						"The optimizer has no tiles it can use. Please specify at least one resource to maximize or ensure minimum production or storage for.",
						this.Text,
						MessageBoxButtons.OK,
						MessageBoxIcon.Asterisk
						);

					pnlCity.Enabled = true;
					btnPaste.Enabled = true;
					btnRun.Text = "Run";
					btnCopy.Enabled = true;
					btnNew.Enabled = true;
					btnSave.Enabled = true;
					btnLoad.Enabled = true;
					btnLockCenter.Enabled = true;
					btnLockNW.Enabled = true;
					btnLockNE.Enabled = true;
					btnLockSW.Enabled = true;
					btnLockSE.Enabled = true;
					propertyGridOptimization.Enabled = true;

					return;
				}

				city.CalculateScore();
				float initialScore = city.Score;
				float settledScore = city.Score;
				int settledGenerations = -1;
				int generation = 0;

				txtBestScore.Text = "0";
				lblInitialScore.Text = initialScore.ToString();
				pbarGenerations.Maximum = OptimizationSettings.Instance.MaxGenerations;
				pbarGenerations.Value = 0;

				pnlProgress.Visible = true;

				List<City> population = new List<City>();

				for (int i = 0; i < OptimizationSettings.Instance.PopulationSize / 5; i++)
					population.Add(city.Clone());

				while (population.Count < OptimizationSettings.Instance.PopulationSize)
					population.Add(city.Mutate());

				keepWorking = true;

				while ((generation < OptimizationSettings.Instance.MaxGenerations) && keepWorking)
				{
					population.Sort();

					population.RemoveRange(
						OptimizationSettings.Instance.PopulationSize,
						population.Count - OptimizationSettings.Instance.PopulationSize
						);

					City fittest = population[0];

					txtBestScore.Text = fittest.Score.ToString();
					pbarGenerations.Value = generation;
					lblGeneration.Text = generation.ToString();

					if (OptimizationSettings.Instance.AllowScoreSettling)
					{
						if (fittest.Score > settledScore)
						{
							settledScore = fittest.Score;
							settledGenerations = -1;
						}
						else
						{
							settledGenerations++;

							if (settledGenerations >= 1000)
								break;
						}
					}

					List<City> breedPool = new List<City>();
					for (int i = 0; i < OptimizationSettings.Instance.PopulationSize / 10; i++)
					{
						breedPool.Add(population[0]);
						population.RemoveAt(0);
					}

					float[] accumulatedScores = new float[population.Count];

					accumulatedScores[0] = population[0].Score;
					for (int i = 1; i < population.Count; i++)
						accumulatedScores[i] = population[i].Score + accumulatedScores[i - 1];

					float maxAccuScore = accumulatedScores[population.Count - 1];

					while (breedPool.Count < (OptimizationSettings.Instance.PopulationSize / 2))
					{
						float picker = (float)OptimizationSettings.Random.NextDouble() * maxAccuScore;

						for (int i = 0; i < population.Count; i++)
						{
							if (accumulatedScores[i] >= picker)
							{
								breedPool.Add(population[i]);
								population.RemoveAt(i);
								break;
							}
						}
					}

					population.Clear();

					while (breedPool.Count > 1)
					{
						int pick;
						City parent1, parent2;

						pick = OptimizationSettings.Random.Next(breedPool.Count);
						parent1 = breedPool[pick];
						breedPool.RemoveAt(pick);

						pick = OptimizationSettings.Random.Next(breedPool.Count);
						parent2 = breedPool[pick];
						breedPool.RemoveAt(pick);

						City[] children = parent1.Crossover(parent2);
						population.Add(children[0]);
						population.Add(children[1]);
						population.Add(parent1);
						population.Add(parent2);
					}

					population.AddRange(breedPool);

					if (!population.Contains(fittest))
						population.Add(fittest);

					generation++;
					Application.DoEvents();
				}

				if (keepWorking)
				{
					population.Sort();

					#region Restore unnecessarily destroyed resources

					for (int y = 0; y < City.CityHeight; y++)
					{
						for (int x = 0; x < City.CityWidth; x++)
						{
							if (population[0].Tile[x, y] == TileType.Empty)
							{
								bool haveFarm = false;

								for (int v = -1; v <= 1; v++)
								{
									for (int u = -1; u <= 1; u++)
									{
										if ((x + u < 0) || (x + u >= City.CityWidth) || (y + v < 0) || (y + v >= City.CityHeight))
											continue;

										if ((population[0].Tile[x + u, y + v] == TileType.Farm) || (population[0].Tile[x + u, y + v] == TileType.OldFarm))
										{
											haveFarm = true;
											break;
										}
									}

									if (haveFarm)
										break;
								}

								if (!haveFarm)
								{
									switch (city.Tile[x, y])
									{
										case TileType.Wood:
										case TileType.Stone:
										case TileType.Iron:
										case TileType.Lake:
											population[0].Tile[x, y] = city.Tile[x, y];
											break;

										default:
											break;
									}
								}
							}
						}
					}

					#endregion

					city = population[0];
					propertyGridCity.SelectedObject = city;
					pnlCity.Invalidate();
				}

				pnlCity.Enabled = true;
				btnPaste.Enabled = true;
				btnRun.Text = "Run";
				btnCopy.Enabled = true;
				btnNew.Enabled = true;
				btnSave.Enabled = true;
				btnLoad.Enabled = true;
				btnLockCenter.Enabled = true;
				btnLockNW.Enabled = true;
				btnLockNE.Enabled = true;
				btnLockSW.Enabled = true;
				btnLockSE.Enabled = true;
				propertyGridOptimization.Enabled = true;

				pnlProgress.Visible = false;

				keepWorking = false;
			}
			else
				keepWorking = false;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void btnLockNW_Click(object sender, EventArgs e)
		{
			for (int y = 0; y < 21; y++)
			{
				for (int x = 0; x < 21; x++)
				{
					if (city.CheckZone(x, y, 1))
						city.TileLocked[x, y] ^= true;
				}
			}

			pnlCity.Invalidate();
		}

		private void btnLockNE_Click(object sender, EventArgs e)
		{
			for (int y = 0; y < 21; y++)
			{
				for (int x = 0; x < 21; x++)
				{
					if (city.CheckZone(x, y, 2))
						city.TileLocked[x, y] ^= true;
				}
			}

			pnlCity.Invalidate();
		}

		private void btnLockCenter_Click(object sender, EventArgs e)
		{
			for (int y = 0; y < 21; y++)
			{
				for (int x = 0; x < 21; x++)
				{
					if (city.CheckZone(x, y, 0))
						city.TileLocked[x, y] ^= true;
				}
			}

			pnlCity.Invalidate();
		}

		private void btnLockSW_Click(object sender, EventArgs e)
		{
			for (int y = 0; y < 21; y++)
			{
				for (int x = 0; x < 21; x++)
				{
					if (city.CheckZone(x, y, 3))
						city.TileLocked[x, y] ^= true;
				}
			}

			pnlCity.Invalidate();
		}

		private void btnLockSE_Click(object sender, EventArgs e)
		{
			for (int y = 0; y < 21; y++)
			{
				for (int x = 0; x < 21; x++)
				{
					if (city.CheckZone(x, y, 4))
						city.TileLocked[x, y] ^= true;
				}
			}

			pnlCity.Invalidate();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.DefaultExt = "*.txt";
			sfd.Filter = "Text File (*.txt)|*.txt";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				SaveFile(sfd.FileName);
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.DefaultExt = "*.txt";
			ofd.Filter = "Text File (*.txt)|*.txt";

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				LoadFile(ofd.FileName);
			}
		}

		private void LoadFile(string fileName)
		{
			StreamReader reader = new StreamReader(fileName);

			OptimizationSettings.Instance.WoodProductionMaximize = bool.Parse(reader.ReadLine());
			OptimizationSettings.Instance.WoodProductionTarget = float.Parse(reader.ReadLine());
			OptimizationSettings.Instance.WoodStorageTarget = int.Parse(reader.ReadLine());

			OptimizationSettings.Instance.StoneProductionMaximize = bool.Parse(reader.ReadLine());
			OptimizationSettings.Instance.StoneProductionTarget = float.Parse(reader.ReadLine());
			OptimizationSettings.Instance.StoneStorageTarget = int.Parse(reader.ReadLine());

			OptimizationSettings.Instance.IronProductionMaximize = bool.Parse(reader.ReadLine());
			OptimizationSettings.Instance.IronProductionTarget = float.Parse(reader.ReadLine());
			OptimizationSettings.Instance.IronStorageTarget = int.Parse(reader.ReadLine());

			OptimizationSettings.Instance.FoodProductionMaximize = bool.Parse(reader.ReadLine());
			OptimizationSettings.Instance.FoodProductionTarget = float.Parse(reader.ReadLine());
			OptimizationSettings.Instance.FoodStorageTarget = int.Parse(reader.ReadLine());

			OptimizationSettings.Instance.ProductionTargetPenalty = float.Parse(reader.ReadLine());
			OptimizationSettings.Instance.StorageTargetPenalty = float.Parse(reader.ReadLine());
			OptimizationSettings.Instance.EqualizationPenalty = float.Parse(reader.ReadLine());

			OptimizationSettings.Instance.PopulationSize = int.Parse(reader.ReadLine());
			OptimizationSettings.Instance.MaxGenerations = int.Parse(reader.ReadLine());

			OptimizationSettings.Instance.AllowScoreSettling = bool.Parse(reader.ReadLine());

			city.PutShareString(reader.ReadLine());

			for (int y = 0; y < 21; y++)
			{
				for (int x = 0; x < 21; x++)
				{
					city.TileLocked[x, y] = bool.Parse(reader.ReadLine());
				}
			}

			reader.Close();

			city.CalculateScore();
			propertyGridCity.SelectedObject = city;
			pnlCity.Invalidate();
		}

		private void SaveFile(string fileName)
		{
			StreamWriter writer = new StreamWriter(fileName, false);

			writer.WriteLine(OptimizationSettings.Instance.WoodProductionMaximize);
			writer.WriteLine(OptimizationSettings.Instance.WoodProductionTarget);
			writer.WriteLine(OptimizationSettings.Instance.WoodStorageTarget);

			writer.WriteLine(OptimizationSettings.Instance.StoneProductionMaximize);
			writer.WriteLine(OptimizationSettings.Instance.StoneProductionTarget);
			writer.WriteLine(OptimizationSettings.Instance.StoneStorageTarget);

			writer.WriteLine(OptimizationSettings.Instance.IronProductionMaximize);
			writer.WriteLine(OptimizationSettings.Instance.IronProductionTarget);
			writer.WriteLine(OptimizationSettings.Instance.IronStorageTarget);

			writer.WriteLine(OptimizationSettings.Instance.FoodProductionMaximize);
			writer.WriteLine(OptimizationSettings.Instance.FoodProductionTarget);
			writer.WriteLine(OptimizationSettings.Instance.FoodStorageTarget);

			writer.WriteLine(OptimizationSettings.Instance.ProductionTargetPenalty);
			writer.WriteLine(OptimizationSettings.Instance.StorageTargetPenalty);
			writer.WriteLine(OptimizationSettings.Instance.EqualizationPenalty);

			writer.WriteLine(OptimizationSettings.Instance.PopulationSize);
			writer.WriteLine(OptimizationSettings.Instance.MaxGenerations);

			writer.WriteLine(OptimizationSettings.Instance.AllowScoreSettling);

			writer.WriteLine(city.GetShareString());

			for (int y = 0; y < 21; y++)
			{
				for (int x = 0; x < 21; x++)
				{
					writer.WriteLine(city.TileLocked[x, y]);
				}
			}

			writer.Close();
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("Water city?", "New City", MessageBoxButtons.YesNoCancel))
			{
				case DialogResult.Yes:
					city = new City(true);
					break;

				case DialogResult.No:
					city = new City(false);
					break;

				default:
					break;
			}

			city.CalculateScore();
			propertyGridCity.SelectedObject = city;
			pnlCity.Invalidate();
		}
	}

	public class DoubleBufferedPanel : Panel
	{
		public DoubleBufferedPanel()
			: base()
		{
			DoubleBuffered = true;
		}
	}

	public enum TileType : int
	{
		None,
		Empty,
		WaterEmpty,
		Wall,
		TownHall,
		Cottage,
		WoodcuttersHut,
		Quarry,
		IronMine,
		Farm,
		Wood,
		Stone,
		Iron,
		Lake,
		Sawmill,
		Stonemason,
		Foundry,
		Mill,
		Warehouse,
		Marketplace,
		Hideout,
		Townhouse,
		Barracks,
		CityGuardHouse,
		TrainingGround,
		Stable,
		Workshop,
		Shipyard,
		Castle,
		Harbor,
		MoonglowTower,
		TrinsicTemple,
		OldWoodcuttersHut,
		OldQuarry,
		OldIronMine,
		OldFarm
	}

	public class City: IComparable<City>
	{
		TileType[,] tile;
		bool[,] tileLocked;

		float score;
		float woodProduction, stoneProduction, ironProduction, foodProduction, goldProduction;
		int woodStorage, stoneStorage, ironStorage, foodStorage;
		float woodStorageCapacity, stoneStorageCapacity, ironStorageCapacity, foodStorageCapacity;
		int buildings = 0;
		bool waterCity;
		int armySize;
		float cityGuardHouseRecruitment, workshopRecruitment, trainingGroundRecruitment, shipyardRecruitment, stableRecruitment, trinsicTempleRecruitment, moonglowTowerRecruitment;
		float hideoutCapacity;
		int carts, ships;
		float constructionSpeed;

		public const int CityWidth = 21;
		public const int CityHeight = 21;

		[Browsable(false)]
		public TileType[,] Tile { get { return tile; } }
		[Browsable(false)]
		public bool[,] TileLocked { get { return tileLocked; } }
		public float Score { get { return score; } }
		public float WoodProduction { get { return woodProduction; } }
		public float StoneProduction { get { return stoneProduction; } }
		public float IronProduction { get { return ironProduction; } }
		public float FoodProduction { get { return foodProduction; } }
		public float GoldProduction { get { return goldProduction; } }
		[Browsable(false)]
		public float WoodStorage { get { return woodStorage; } }
		[Browsable(false)]
		public float StoneStorage { get { return stoneStorage; } }
		[Browsable(false)]
		public float IronStorage { get { return ironStorage; } }
		[Browsable(false)]
		public float FoodStorage { get { return foodStorage; } }
		public float WoodStorageCapacity { get { return woodStorageCapacity; } }
		public float StoneStorageCapacity { get { return stoneStorageCapacity; } }
		public float IronStorageCapacity { get { return ironStorageCapacity; } }
		public float FoodStorageCapacity { get { return foodStorageCapacity; } }
		public int Buildings { get { return buildings; } }
		public bool WaterCity { get { return waterCity; } }
		public int ArmySize { get { return armySize; } }
		public float CityGuardHouseRecruitment { get { return cityGuardHouseRecruitment; } }
		public float WorkshopRecruitment { get { return workshopRecruitment; } }
		public float TrainingGroundRecruitment { get { return trainingGroundRecruitment; } }
		public float ShipyardRecruitment { get { return shipyardRecruitment; } }
		public float StableRecruitment { get { return stableRecruitment; } }
		public float TrinsicTempleRecruitment { get { return trinsicTempleRecruitment; } }
		public float MoonglowTowerRecruitment { get { return moonglowTowerRecruitment; } }
		public float HideoutCapacity { get { return hideoutCapacity; } }
		public int Carts { get { return carts; } }
		public int Ships { get { return ships; } }
		public float ConstructionSpeed { get { return constructionSpeed; } }

		public City(bool waterCity)
		{
			tile = new TileType[CityWidth, CityHeight];
			tileLocked = new bool[CityWidth, CityHeight];

			if (waterCity)
				PutShareString("[ShareString.1.3];########################-------#-------#####--------#--------###---------#---------##---------#---------##------#######------##-----##-----##-----##----##-------##----##----#---------#----##----#---------#----#######----T----#######----#---------#----##----#---------#----##----##-------##----##-----##-----##-----##------#######--__--##---------#----_##_-##---------#----_###_###--------#-----_#######-------#------_########################");
			else
				PutShareString("[ShareString.1.3]:########################-------#-------#####--------#--------###---------#---------##---------#---------##------#######------##-----##-----##-----##----##-------##----##----#---------#----##----#---------#----#######----T----#######----#---------#----##----#---------#----##----##-------##----##-----##-----##-----##------#######------##---------#---------##---------#---------###--------#--------#####-------#-------########################");

			this.waterCity = waterCity;
		}

		public City Clone()
		{
			City newCity = new City(this.waterCity);

			Array.Copy(this.tile, newCity.tile, this.tile.Length);
			Array.Copy(this.tileLocked, newCity.tileLocked, this.tileLocked.Length);

			newCity.score = this.score;
			newCity.woodProduction = this.woodProduction;
			newCity.woodStorage = this.woodStorage;
			newCity.stoneProduction = this.stoneProduction;
			newCity.stoneStorage = this.stoneStorage;
			newCity.ironProduction = this.ironProduction;
			newCity.ironStorage = this.ironStorage;
			newCity.foodProduction = this.foodProduction;
			newCity.foodStorage = this.foodStorage;
			newCity.goldProduction = this.goldProduction;
			newCity.buildings = this.buildings;

			return newCity;
		}

		public int CompareTo(City other)
		{
			return other.score.CompareTo(this.score);
		}

		public override string ToString()
		{
			return score.ToString() + 
				" / W: " + woodProduction.ToString() + " (" + woodStorage.ToString() + ")" +
				"  S: " + stoneProduction.ToString() + " (" + stoneStorage.ToString() + ")" +
				"  I: " + ironProduction.ToString() + " (" + ironStorage.ToString() + ")" +
				"  F: " + foodProduction.ToString() + " (" + foodStorage.ToString() + ")" +
				"  G: " + goldProduction.ToString() +
				" (" + buildings.ToString() + " buildings)";
		}

		private TileType[] GetNeighbors(int x, int y)
		{
			TileType[] neighbors = new TileType[8];
			int xu, yv;
			int n = 0;

			for (int v = -1; v <= 1; v++)
			{
				for (int u = -1; u <= 1; u++)
				{
					xu = x + u;
					yv = y + v;

					if ((xu < 0) || (xu >= CityWidth) || (yv < 0) || (yv >= CityHeight))
						continue;

					if ((u == 0) && (v == 0))
						continue;

					neighbors[n] = this.tile[xu, yv];
					n++;
				}
			}

			while (n < 8)
			{
				neighbors[n] = TileType.None;
				n++;
			}

			return neighbors;
		}

		public void CalculateScore()
		{
			score = 0;
			woodProduction = 300.0f;
			woodStorage = 0;
			woodStorageCapacity = 175000.0f;
			stoneProduction = 0;
			stoneStorage = 0;
			stoneStorageCapacity = 175000.0f;
			ironProduction = 0;
			ironStorage = 0;
			ironStorageCapacity = 175000.0f;
			foodProduction = 0;
			foodStorage = 0;
			foodStorageCapacity = 175000.0f;
			goldProduction = 0;
			buildings = 0;
			armySize = 0;
			cityGuardHouseRecruitment = 1.0f;
			workshopRecruitment = 1.0f;
			trainingGroundRecruitment = 1.0f;
			shipyardRecruitment = 1.0f;
			stableRecruitment = 1.0f;
			trinsicTempleRecruitment = 1.0f;
			moonglowTowerRecruitment = 1.0f;
			hideoutCapacity = 0.0f;
			carts = 0;
			ships = 0;

			#region Calculate production rates

			for (int y = 0; y < CityHeight; y++)
			{
				for (int x = 0; x < CityWidth; x++)
				{
					switch (tile[x, y])
					{
						case TileType.None:
						case TileType.Empty:
						case TileType.Wall:
						case TileType.WaterEmpty:
						case TileType.TownHall:
						case TileType.Wood:
						case TileType.Stone:
						case TileType.Iron:
						case TileType.Lake:
							break;

						default:
							buildings++;
							break;
					}

					switch (tile[x, y])
					{
						case TileType.WoodcuttersHut:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);
								float manpower = 1.0f;
								float resources = 1.0f;
								float processing = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Cottage:
											manpower += 0.3f;
											break;

										case TileType.Wood:
											if (resources == 1.0f)
												resources += 0.5f;
											else
												resources += 0.4f;
											break;

										case TileType.Sawmill:
											processing = 1.75f;
											break;
									}
								}
								#endregion

								woodProduction += 300.0f * (manpower * resources * processing);
							}
							break;

						case TileType.Quarry:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);
								float manpower = 1.0f;
								float resources = 1.0f;
								float processing = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Cottage:
											manpower += 0.3f;
											break;

										case TileType.Stone:
											if (resources == 1.0f)
												resources += 0.5f;
											else
												resources += 0.4f;
											break;

										case TileType.Stonemason:
											processing = 1.75f;
											break;
									}
								}
								#endregion

								stoneProduction += 300.0f * (manpower * resources * processing);
							}
							break;

						case TileType.IronMine:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);
								float manpower = 1.0f;
								float resources = 1.0f;
								float processing = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Cottage:
											manpower += 0.3f;
											break;

										case TileType.Iron:
											if (resources == 1.0f)
												resources += 0.5f;
											else
												resources += 0.4f;
											break;

										case TileType.Foundry:
											processing = 1.75f;
											break;
									}
								}
								#endregion

								ironProduction += 300.0f * (manpower * resources * processing);
							}
							break;

						case TileType.Farm:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);
								float manpower = 1.0f;
								float resources = 1.0f;
								float processing = 1.0f;
								float irrigation = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Cottage:
											manpower += 0.3f;
											break;

										case TileType.Empty:
											if (resources == 1.0f)
												resources += 0.5f;
											else
												resources += 0.4f;
											break;

										case TileType.Mill:
											processing = 1.75f;
											break;

										case TileType.Lake:
											irrigation += 0.5f;
											break;
									}
								}
								#endregion

								foodProduction += 300.0f * (manpower * resources * processing * irrigation);
							}
							break;

						case TileType.OldWoodcuttersHut:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);
								float manpower = 1.0f;
								float resources = 0.0f;
								float processing = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Cottage:
											manpower += 0.5f;
											break;

										case TileType.Wood:
											resources += 0.25f;
											break;

										case TileType.Sawmill:
											processing = 1.75f;
											break;
									}
								}
								#endregion

								woodProduction += 300.0f * ((manpower + resources) * processing);
							}
							break;

						case TileType.OldQuarry:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);
								float manpower = 1.0f;
								float resources = 0.0f;
								float processing = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Cottage:
											manpower += 0.5f;
											break;

										case TileType.Stone:
											resources += 0.25f;
											break;

										case TileType.Stonemason:
											processing = 1.75f;
											break;
									}
								}
								#endregion

								stoneProduction += 300.0f * ((manpower + resources) * processing);
							}
							break;

						case TileType.OldIronMine:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);
								float manpower = 1.0f;
								float resources = 0.0f;
								float processing = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Cottage:
											manpower += 0.5f;
											break;

										case TileType.Iron:
											resources += 0.25f;
											break;

										case TileType.Foundry:
											processing = 1.75f;
											break;
									}
								}
								#endregion

								ironProduction += 300.0f * ((manpower + resources) * processing);
							}
							break;

						case TileType.OldFarm:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);
								float manpower = 1.0f;
								float resources = 0.0f;
								float processing = 1.0f;
								float irrigation = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Cottage:
											manpower += 0.5f;
											break;

										case TileType.Empty:
											resources += 0.25f;
											break;

										case TileType.Mill:
											processing = 1.75f;
											break;

										case TileType.Lake:
											irrigation += 0.5f;
											break;
									}
								}
								#endregion

								foodProduction += 300.0f * ((manpower + resources) * processing * irrigation);
							}
							break;

						case TileType.Townhouse:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);
								float trade = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Marketplace:
											trade += 0.2f;
											break;

										case TileType.Harbor:
											trade += 0.5f;
											break;
									}
								}
								#endregion

								goldProduction += 400.0f * trade;
							}
							break;

						case TileType.Warehouse:
							{
								#region
								TileType[] neighbors = GetNeighbors(x, y);

								float wood = 1.0f;
								float stone = 1.0f;
								float iron = 1.0f;
								float food = 1.0f;

								for (int i = 0; i < neighbors.Length; i++)
								{
									switch (neighbors[i])
									{
										case TileType.Sawmill:
											woodStorage++;
											wood += 2.0f;
											break;

										case TileType.Stonemason:
											stoneStorage++;
											stone += 2.0f;
											break;

										case TileType.Foundry:
											ironStorage++;
											iron += 2.0f;
											break;

										case TileType.Mill:
											foodStorage++;
											food += 2.0f;
											break;
									}
								}

								woodStorageCapacity += 200000.0f * wood;
								stoneStorageCapacity += 200000.0f * stone;
								ironStorageCapacity += 200000.0f * iron;
								foodStorageCapacity += 200000.0f * food;

								#endregion
							}
							break;

						case TileType.Barracks:
							armySize += 1000;
							break;

						case TileType.CityGuardHouse:
							{
								cityGuardHouseRecruitment += 1.5f;

								TileType[] neighbors = GetNeighbors(x, y);

								for (int i = 0; i < neighbors.Length; i++)
								{
									if (neighbors[i] == TileType.Barracks)
										cityGuardHouseRecruitment += 0.25f;
								}
							}
							break;

						case TileType.Workshop:
							{
								workshopRecruitment += 1.5f;

								TileType[] neighbors = GetNeighbors(x, y);

								for (int i = 0; i < neighbors.Length; i++)
								{
									if (neighbors[i] == TileType.Barracks)
										workshopRecruitment += 0.25f;
								}
							}
							break;

						case TileType.TrainingGround:
							{
								trainingGroundRecruitment += 1.5f;

								TileType[] neighbors = GetNeighbors(x, y);

								for (int i = 0; i < neighbors.Length; i++)
								{
									if (neighbors[i] == TileType.Barracks)
										trainingGroundRecruitment += 0.25f;
								}
							}
							break;

						case TileType.Shipyard:
							{
								shipyardRecruitment += 1.5f;

								TileType[] neighbors = GetNeighbors(x, y);

								for (int i = 0; i < neighbors.Length; i++)
								{
									if (neighbors[i] == TileType.Barracks)
										shipyardRecruitment += 0.25f;
								}
							}
							break;

						case TileType.Stable:
							{
								stableRecruitment += 1.5f;

								TileType[] neighbors = GetNeighbors(x, y);

								for (int i = 0; i < neighbors.Length; i++)
								{
									if (neighbors[i] == TileType.Barracks)
										stableRecruitment += 0.25f;
								}
							}
							break;

						case TileType.TrinsicTemple:
							{
								trinsicTempleRecruitment += 1.5f;

								TileType[] neighbors = GetNeighbors(x, y);

								for (int i = 0; i < neighbors.Length; i++)
								{
									if (neighbors[i] == TileType.Barracks)
										trinsicTempleRecruitment += 0.25f;
								}
							}
							break;

						case TileType.MoonglowTower:
							{
								moonglowTowerRecruitment += 1.5f;

								TileType[] neighbors = GetNeighbors(x, y);

								for (int i = 0; i < neighbors.Length; i++)
								{
									if (neighbors[i] == TileType.Barracks)
										moonglowTowerRecruitment += 0.25f;
								}
							}
							break;

						case TileType.Hideout:
							{
								float location = 1.0f;

								TileType[] neighbors = GetNeighbors(x, y);

								for (int i = 0; i < neighbors.Length; i++)
								{
									if (neighbors[i] == TileType.Wood)
										location += 0.25f;
								}

								hideoutCapacity += 15000 * location;
							}
							break;

						case TileType.Marketplace:
							carts += 200;
							break;

						case TileType.Harbor:
							ships += 30;
							break;

						case TileType.Cottage:
							constructionSpeed += 1.0f;
							break;
					}
				}
			}

			#endregion

			#region Score calculation

			if (OptimizationSettings.Instance.WoodProductionMaximize)
			{
				score += woodProduction;
			}
			else if (OptimizationSettings.Instance.WoodProductionTarget > 0)
			{
				if (woodProduction < OptimizationSettings.Instance.WoodProductionTarget)
					score -= OptimizationSettings.Instance.ProductionTargetPenalty * (OptimizationSettings.Instance.WoodProductionTarget - woodProduction);
			}

			if (OptimizationSettings.Instance.StoneProductionMaximize)
			{
				score += stoneProduction;

				if (OptimizationSettings.Instance.WoodProductionMaximize)
					score -= OptimizationSettings.Instance.EqualizationPenalty * Math.Abs(stoneProduction - woodProduction);
			}
			else if (OptimizationSettings.Instance.StoneProductionTarget > 0)
			{
				if (stoneProduction < OptimizationSettings.Instance.StoneProductionTarget)
					score -= OptimizationSettings.Instance.ProductionTargetPenalty * (OptimizationSettings.Instance.StoneProductionTarget - stoneProduction);
			}

			if (OptimizationSettings.Instance.IronProductionMaximize)
			{
				score += ironProduction;

				if (OptimizationSettings.Instance.WoodProductionMaximize)
					score -= OptimizationSettings.Instance.EqualizationPenalty * Math.Abs(ironProduction - woodProduction);

				if (OptimizationSettings.Instance.StoneProductionMaximize)
					score -= OptimizationSettings.Instance.EqualizationPenalty * Math.Abs(ironProduction - stoneProduction);
			}
			else if (OptimizationSettings.Instance.IronProductionTarget > 0)
			{
				if (ironProduction < OptimizationSettings.Instance.IronProductionTarget)
					score -= OptimizationSettings.Instance.ProductionTargetPenalty * (OptimizationSettings.Instance.IronProductionTarget - ironProduction);
			}

			if (OptimizationSettings.Instance.FoodProductionMaximize)
			{
				score += foodProduction;

				if (OptimizationSettings.Instance.WoodProductionMaximize)
					score -= OptimizationSettings.Instance.EqualizationPenalty * Math.Abs(foodProduction - woodProduction);

				if (OptimizationSettings.Instance.StoneProductionMaximize)
					score -= OptimizationSettings.Instance.EqualizationPenalty * Math.Abs(foodProduction - stoneProduction);

				if (OptimizationSettings.Instance.IronProductionMaximize)
					score -= OptimizationSettings.Instance.EqualizationPenalty * Math.Abs(foodProduction - ironProduction);
			}
			else if (OptimizationSettings.Instance.FoodProductionTarget > 0)
			{
				if (foodProduction < OptimizationSettings.Instance.FoodProductionTarget)
					score -= OptimizationSettings.Instance.ProductionTargetPenalty * (OptimizationSettings.Instance.FoodProductionTarget - foodProduction);
			}
			

			#region Storage target penalties

			if (OptimizationSettings.Instance.WoodStorageTarget > 0)
			{
				if (woodStorage < OptimizationSettings.Instance.WoodStorageTarget)
					score -= OptimizationSettings.Instance.StorageTargetPenalty * (OptimizationSettings.Instance.WoodStorageTarget - woodStorage);
			}

			if (OptimizationSettings.Instance.StoneStorageTarget > 0)
			{
				if (stoneStorage < OptimizationSettings.Instance.StoneStorageTarget)
					score -= OptimizationSettings.Instance.StorageTargetPenalty * (OptimizationSettings.Instance.StoneStorageTarget - stoneStorage);
			}

			if (OptimizationSettings.Instance.IronStorageTarget > 0)
			{
				if (ironStorage < OptimizationSettings.Instance.IronStorageTarget)
					score -= OptimizationSettings.Instance.StorageTargetPenalty * (OptimizationSettings.Instance.IronStorageTarget - ironStorage);
			}

			if (OptimizationSettings.Instance.FoodStorageTarget > 0)
			{
				if (foodStorage < OptimizationSettings.Instance.FoodStorageTarget)
					score -= OptimizationSettings.Instance.StorageTargetPenalty * (OptimizationSettings.Instance.FoodStorageTarget - foodStorage);
			}

			#endregion

			if (buildings > 100)
				score /= 10.0f;

			if (score < 0.0f)
				score = 0.0f;

			#endregion
		}

		public City[] Crossover(City other)
		{
			City[] children = new City[2];
			children[0] = this.Clone();
			children[1] = other.Clone();

			int n = 0;

			for (int y = 0; y < CityHeight; y++)
			{
				for (int x = 0; x < CityWidth; x++)
				{
					if (!this.tileLocked[x, y])
					{
						if ((n % 2) == 0)
						{
							children[0].tile[x, y] = other.tile[x, y];
							children[1].tile[x, y] = this.tile[x, y];
						}

						n++;
					}
				}
			}

			children[0] = children[0].Mutate();
			children[1] = children[1].Mutate();

			return children;
		}

		private bool FindSpot(out int x, out int y, MutationSpotType type)
		{
			return FindSpot(out x, out y, type, -1, -1);
		}

		private bool FindSpot(out int x, out int y, MutationSpotType type, int exceptX, int exceptY)
		{
			List<int> xlist = new List<int>(CityWidth * CityHeight);
			List<int> ylist = new List<int>(xlist.Capacity);

			for (int v = 0; v < CityHeight; v++)
			{
				for (int u = 0; u < CityWidth; u++)
				{
					if (tileLocked[u, v])
						continue;

					if ((u == exceptX) && (v == exceptY))
						continue;

					switch (tile[u, v])
					{
						case TileType.None:
						case TileType.Wall:
						case TileType.TownHall:
						case TileType.WaterEmpty:
						case TileType.Shipyard:
						case TileType.Harbor:
							break;

						case TileType.Empty:
						case TileType.Wood:
						case TileType.Stone:
						case TileType.Iron:
						case TileType.Lake:
							if ((type == MutationSpotType.SwapTarget) || ((type == MutationSpotType.Replace) && (buildings < 100)))
							{
								xlist.Add(u);
								ylist.Add(v);
							}
							break;

						case TileType.OldWoodcuttersHut:
						case TileType.OldQuarry:
						case TileType.OldIronMine:
						case TileType.OldFarm:
							if ((type == MutationSpotType.SwapTarget) || (type == MutationSpotType.Replace))
							{
								xlist.Add(u);
								ylist.Add(v);
							}
							break;

						default:
							xlist.Add(u);
							ylist.Add(v);
							break;
					}
				}
			}

			if (xlist.Count == 0)
			{
				x = -1;
				y = -1;
				return false;
			}
			
			int n = OptimizationSettings.Random.Next(xlist.Count);

			x = xlist[n];
			y = ylist[n];

			return true;
		}

		private enum MutationSpotType
		{
			Replace,
			SwapSource,
			SwapTarget
		}

		public City Mutate()
		{
			City newCity = this.Clone();

			if (OptimizationSettings.Random.Next(100) < 50)
			{
				// replace a tile
				int x, y;
				if (newCity.FindSpot(out x, out y, MutationSpotType.Replace))
					newCity.tile[x, y] = OptimizationSettings.Instance.GetRandomUsableTile();
			}
			else
			{
				// swap two tiles
				int x1, y1;
				int x2, y2;
				if (!newCity.FindSpot(out x1, out y1, MutationSpotType.SwapSource))
					return newCity;

				if (!newCity.FindSpot(out x2, out y2, MutationSpotType.SwapTarget, x1, y1))
					return newCity;

				TileType temp;
				switch (newCity.tile[x2, y2])
				{
					case TileType.Wood:
					case TileType.Stone:
					case TileType.Iron:
					case TileType.Lake:
					case TileType.OldWoodcuttersHut:
					case TileType.OldQuarry:
					case TileType.OldIronMine:
					case TileType.OldFarm:
						temp = TileType.Empty;
						break;

					default:
						temp = newCity.tile[x2, y2];
						break;
				}

				newCity.tile[x2, y2] = newCity.tile[x1, y1];
				newCity.tile[x1, y1] = temp;
			}

			newCity.CalculateScore();

			return newCity;
		}

		public void PutShareString(string shareString)
		{
			if (shareString.Length != (17 + 1 + (21 * 21)))
			{
				MessageBox.Show("Invalid ShareString.");
				return;
			}

			if (!shareString.StartsWith("[ShareString.1.3]"))
			{
				MessageBox.Show("Invalid ShareString.");
				return;
			}

			waterCity = (shareString[17] == ';');
			shareString = shareString.Substring(17 + 1);

			int x = 0, y = 0;

			for (int i = 0; i < shareString.Length; i++)
			{
				switch (shareString[i])
				{
					case ':': Tile[x, y] = TileType.Stone; break;
					case '.': Tile[x, y] = TileType.Wood; break;
					case ',': Tile[x, y] = TileType.Iron; break;
					case ';': Tile[x, y] = TileType.Lake; break;
					case '2': Tile[x, y] = TileType.WoodcuttersHut; break;
					case '3': Tile[x, y] = TileType.Quarry; break;
					case '1': Tile[x, y] = TileType.Farm; break;
					case 'C': Tile[x, y] = TileType.Cottage; break;
					case 'P': Tile[x, y] = TileType.Marketplace; break;
					case '4': Tile[x, y] = TileType.IronMine; break;
					case 'L': Tile[x, y] = TileType.Sawmill; break;
					case 'M': Tile[x, y] = TileType.Mill; break;
					case 'H': Tile[x, y] = TileType.Hideout; break;
					case 'A': Tile[x, y] = TileType.Stonemason; break;
					case 'D': Tile[x, y] = TileType.Foundry; break;
					case 'T': Tile[x, y] = TileType.TownHall; break;
					case 'U': Tile[x, y] = TileType.Townhouse; break;
					case 'B': Tile[x, y] = TileType.Barracks; break;
					case 'K': Tile[x, y] = TileType.CityGuardHouse; break;
					case 'G': Tile[x, y] = TileType.TrainingGround; break;
					case 'E': Tile[x, y] = TileType.Stable; break;
					case 'Y': Tile[x, y] = TileType.Workshop; break;
					case 'V': Tile[x, y] = TileType.Shipyard; break;
					case 'S': Tile[x, y] = TileType.Warehouse; break;
					case 'X': Tile[x, y] = TileType.Castle; break;
					case 'R': Tile[x, y] = TileType.Harbor; break;
					case 'J': Tile[x, y] = TileType.MoonglowTower; break;
					case 'Z': Tile[x, y] = TileType.TrinsicTemple; break;
					case '#': Tile[x, y] = TileType.Wall; break;
					case '-': Tile[x, y] = TileType.Empty; break;
					case '_': Tile[x, y] = TileType.WaterEmpty; break;
					case 'W': Tile[x, y] = TileType.OldWoodcuttersHut; break;
					case 'Q': Tile[x, y] = TileType.OldQuarry; break;
					case 'I': Tile[x, y] = TileType.OldIronMine; break;
					case 'F': Tile[x, y] = TileType.OldFarm; break;
				}

				x++;
				if (x == 21)
				{
					x = 0;
					y++;
				}
			}
		}

		public string GetShareString()
		{
			string shareString = "[ShareString.1.3]";

			if (waterCity)
				shareString += ";";
			else
				shareString += ":";

			for (int y = 0; y < CityHeight; y++)
			{
				for (int x = 0; x < CityWidth; x++)
				{
					switch (Tile[x, y])
					{
						case TileType.Stone: shareString += ':'; break;
						case TileType.Wood: shareString += '.'; break;
						case TileType.Iron: shareString += ','; break;
						case TileType.Lake: shareString += ';'; break;
						case TileType.WoodcuttersHut: shareString += '2'; break;
						case TileType.Quarry: shareString += '3'; break;
						case TileType.Farm: shareString += '1'; break;
						case TileType.Cottage: shareString += 'C'; break;
						case TileType.Marketplace: shareString += 'P'; break;
						case TileType.IronMine: shareString += '4'; break;
						case TileType.Sawmill: shareString += 'L'; break;
						case TileType.Mill: shareString += 'M'; break;
						case TileType.Hideout: shareString += 'H'; break;
						case TileType.Stonemason: shareString += 'A'; break;
						case TileType.Foundry: shareString += 'D'; break;
						case TileType.TownHall: shareString += 'T'; break;
						case TileType.Townhouse: shareString += 'U'; break;
						case TileType.Barracks: shareString += 'B'; break;
						case TileType.CityGuardHouse: shareString += 'K'; break;
						case TileType.TrainingGround: shareString += 'G'; break;
						case TileType.Stable: shareString += 'E'; break;
						case TileType.Workshop: shareString += 'Y'; break;
						case TileType.Shipyard: shareString += 'V'; break;
						case TileType.Warehouse: shareString += 'S'; break;
						case TileType.Castle: shareString += 'X'; break;
						case TileType.Harbor: shareString += 'R'; break;
						case TileType.MoonglowTower: shareString += 'J'; break;
						case TileType.TrinsicTemple: shareString += 'Z'; break;
						case TileType.Wall: shareString += '#'; break;
						case TileType.Empty: shareString += '-'; break;
						case TileType.WaterEmpty: shareString += '_'; break;
						case TileType.OldWoodcuttersHut: shareString += 'W'; break;
						case TileType.OldQuarry: shareString += 'Q'; break;
						case TileType.OldIronMine: shareString += 'I'; break;
						case TileType.OldFarm: shareString += 'F'; break;
					}
				}
			}

			return shareString;
		}

		public bool CheckZone(int x, int y, int zone)
		{
			switch (zone)
			{
				case 0:
					{
						if ((x < 6) || (y < 6) || (x > 14) || (y > 14))
							return false;

						if (y == 6)
						{
							if ((x == 6) || (x == 7) || (x == 13) || (x == 14))
								return false;
						}
						else if (y == 7)
						{
							if ((x == 6) || (x == 14))
								return false;
						}
						else if (y == 13)
						{
							if ((x == 6) || (x == 14))
								return false;
						}
						else if (y == 14)
						{
							if ((x == 6) || (x == 7) || (x == 13) || (x == 14))
								return false;
						}
					}
					break;

				case 1:
					{
						if ((x < 1) || (y < 1) || (x > 9) || (y > 9))
							return false;

						if ((x >= 5) && (y >= 5))
						{
							if ((x == 5) && (y == 5))
								return true;
							else if ((x == 6) && (y == 5))
								return true;
							else if ((x == 5) && (y == 6))
								return true;
							else
								return false;
						}

						if ((x == 1) && (y == 1))
							return false;
						else if ((x == 2) && (y == 1))
							return false;
						else if ((x == 1) && (y == 2))
							return false;
					}
					break;

				case 2:
					{
						if ((x < 11) || (y < 1) || (x > 19) || (y > 9))
							return false;

						if ((x <= 15) && (y >= 5))
						{
							if ((x == 15) && (y == 5))
								return true;
							else if ((x == 14) && (y == 5))
								return true;
							else if ((x == 15) && (y == 6))
								return true;
							else
								return false;
						}

						if ((x == 19) && (y == 1))
							return false;
						else if ((x == 18) && (y == 1))
							return false;
						else if ((x == 19) && (y == 2))
							return false;
					}
					break;

				case 3:
					{
						if ((x < 1) || (y < 11) || (x > 9) || (y > 19))
							return false;

						if ((x >= 5) && (y <= 15))
						{
							if ((x == 5) && (y == 15))
								return true;
							else if ((x == 6) && (y == 15))
								return true;
							else if ((x == 5) && (y == 14))
								return true;
							else
								return false;
						}

						if ((x == 1) && (y == 19))
							return false;
						else if ((x == 2) && (y == 19))
							return false;
						else if ((x == 1) && (y == 18))
							return false;
					}
					break;

				case 4:
					{
						if ((x < 11) || (y < 11) || (x > 19) || (y > 19))
							return false;

						if ((x <= 15) && (y <= 15))
						{
							if ((x == 15) && (y == 15))
								return true;
							else if ((x == 14) && (y == 15))
								return true;
							else if ((x == 15) && (y == 14))
								return true;
							else
								return false;
						}

						if ((x == 19) && (y == 19))
							return false;
						else if ((x == 18) && (y == 19))
							return false;
						else if ((x == 19) && (y == 18))
							return false;

						if (waterCity)
						{
							if ((x == 18) && (y == 18))
								return false;
							else if ((x == 17) && (y == 18))
								return false;
							else if ((x == 18) && (y == 17))
								return false;
							else if ((x == 17) && (y == 17))
								return false;
							else if ((x == 16) && (y == 17))
								return false;
							else if ((x == 17) && (y == 16))
								return false;
							else if ((x == 16) && (y == 16))
								return false;
						}
					}
					break;

				default:
					return false;
			}

			return true;
		}
	}

	public class OptimizationSettings
	{
		static Random random;
		static OptimizationSettings instance;

		public static Random Random { get { return random; } }
		public static OptimizationSettings Instance { get { return instance; } }

		List<TileType> usableTiles;

		public bool WoodProductionMaximize { get; set; }
		public float WoodProductionTarget { get; set; }
		public int WoodStorageTarget { get; set; }
		public bool StoneProductionMaximize { get; set; }
		public float StoneProductionTarget { get; set; }
		public int StoneStorageTarget { get; set; }
		public bool IronProductionMaximize { get; set; }
		public float IronProductionTarget { get; set; }
		public int IronStorageTarget { get; set; }
		public bool FoodProductionMaximize { get; set; }
		public float FoodProductionTarget { get; set; }
		public int FoodStorageTarget { get; set; }
		public float ProductionTargetPenalty { get; set; }
		public float StorageTargetPenalty { get; set; }
		public float EqualizationPenalty { get; set; }
		public int PopulationSize { get; set; }
		public int MaxGenerations { get; set; }
		public bool AllowScoreSettling { get; set; }

		static OptimizationSettings()
		{
			random = new Random();
			instance = new OptimizationSettings();
		}

		public OptimizationSettings()
		{
			usableTiles = new List<TileType>();
			ProductionTargetPenalty = 1.0f;
			StorageTargetPenalty = 2000.0f;
			EqualizationPenalty = 1.0f;
			PopulationSize = 200;
			MaxGenerations = 10000;
			AllowScoreSettling = true;
		}

		public bool PrepareUsableTiles()
		{
			usableTiles.Clear();

			if (instance.WoodProductionMaximize || (instance.WoodProductionTarget > 0.0f))
			{
				usableTiles.Add(TileType.WoodcuttersHut);
				usableTiles.Add(TileType.Sawmill);
				usableTiles.Add(TileType.Cottage);
			}

			if (instance.WoodStorageTarget > 0)
			{
				usableTiles.Add(TileType.Warehouse);

				if (!usableTiles.Contains(TileType.Sawmill))
					usableTiles.Add(TileType.Sawmill);
			}

			if (instance.StoneProductionMaximize || (instance.StoneProductionTarget > 0.0f))
			{
				usableTiles.Add(TileType.Quarry);
				usableTiles.Add(TileType.Stonemason);

				if (!usableTiles.Contains(TileType.Cottage))
					usableTiles.Add(TileType.Cottage);
			}

			if (instance.StoneStorageTarget > 0)
			{
				if (!usableTiles.Contains(TileType.Warehouse))
					usableTiles.Add(TileType.Warehouse);

				if (!usableTiles.Contains(TileType.Stonemason))
					usableTiles.Add(TileType.Stonemason);
			}

			if (instance.IronProductionMaximize || (instance.IronProductionTarget > 0.0f))
			{
				usableTiles.Add(TileType.IronMine);
				usableTiles.Add(TileType.Foundry);

				if (!usableTiles.Contains(TileType.Cottage))
					usableTiles.Add(TileType.Cottage);
			}

			if (instance.IronStorageTarget > 0)
			{
				if (!usableTiles.Contains(TileType.Warehouse))
					usableTiles.Add(TileType.Warehouse);

				if (!usableTiles.Contains(TileType.Foundry))
					usableTiles.Add(TileType.Foundry);
			}

			if (instance.FoodProductionMaximize || (instance.FoodProductionTarget > 0.0f))
			{
				usableTiles.Add(TileType.Farm);
				usableTiles.Add(TileType.Mill);

				if (!usableTiles.Contains(TileType.Cottage))
					usableTiles.Add(TileType.Cottage);
			}

			if (instance.FoodStorageTarget > 0)
			{
				usableTiles.Add(TileType.Empty);

				if (!usableTiles.Contains(TileType.Warehouse))
					usableTiles.Add(TileType.Warehouse);

				if (!usableTiles.Contains(TileType.Mill))
					usableTiles.Add(TileType.Mill);
			}

			return (usableTiles.Count > 0);
		}

		public TileType GetRandomUsableTile()
		{
			int n = random.Next(usableTiles.Count);

			return usableTiles[n];
		}
	}
}