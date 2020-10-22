using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace DacernSkyblock.Skyblock
{

    public class CultistsHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons the lunatic cultist.");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 30000;
            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.

        public override bool CanUseItem(Player player)
        {
            // "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
            return !NPC.AnyNPCs(NPCID.MoonLordCore) && !NPC.AnyNPCs(NPCID.CultistBoss) && !NPC.AnyNPCs(NPCID.LunarTowerSolar) && !NPC.AnyNPCs(NPCID.LunarTowerNebula) && !NPC.AnyNPCs(NPCID.LunarTowerStardust) && !NPC.AnyNPCs(NPCID.LunarTowerVortex);
        }
        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.

        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X - 400, (int)player.Center.Y, NPCID.CultistBoss, 0);
            //   Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

    }
    public class DungeonStation : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows you create the dungeon. Be warned that only naturally generating dungeon walls work though.");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.maxStack = 99;
            item.useTurn = true;
            item.rare = 3;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("BenchTile");
        }

    }
    public class FishingGuide : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Brings the angler into your world.");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 80000;
            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.

        public override bool CanUseItem(Player player)
        {
            // "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
            return !NPC.AnyNPCs(NPCID.SleepingAngler) && !NPC.AnyNPCs(NPCID.Angler);
        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 200, NPCID.SleepingAngler, 0);
            return true;
        }

    }
    public class BookOfHairStyles : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Brings the stylist into your world.");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 80000;
            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            // "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
            return !NPC.AnyNPCs(NPCID.WebbedStylist) && !NPC.AnyNPCs(NPCID.Stylist);
        }
        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.

        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 200, NPCID.WebbedStylist, 0);
            return true;
        }

    }
    public class BenchTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = new[] { 18 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Dungeon station");
            AddMapEntry(new Color(20, 20, 120), name);
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.WorkBenches };
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<DungeonStation>());
        }
    }
    public class ModGlobalNPCSkeletrondunegonstation : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
                if (npc.type == NPCID.SkeletronHead)
                {

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bone, 100);
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DungeonStation>());
                }
        }

	}
	public class NewStoneTile : GlobalTile
	{
		public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if (type == TileID.Stone)
			{
					if (Main.rand.Next(250) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Diamond);
					}

					if (Main.rand.Next(100) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Cobweb);
					}
					if (fail == false)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.StoneBlock);
					}
					if (Main.rand.Next(130) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amber);
					}

					if (Main.rand.Next(172) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Emerald);
					}

					if (Main.rand.Next(180) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Ruby);
					}

					if (Main.rand.Next(150) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Sapphire);
					}

					if (Main.rand.Next(100) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.PlatinumOre);
					}
					if (Main.rand.Next(100) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CrimsonSeeds);
					}
					if (Main.rand.Next(50) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.ClayBlock);
					}
					if (Main.rand.Next(100) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.GrassSeeds);
					}
					if (Main.rand.Next(100) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MushroomGrassSeeds);
					}
					if (Main.rand.Next(100) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.JungleGrassSeeds);
					}
					if (Main.rand.Next(50) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SandBlock);
					}
					if (Main.rand.Next(70) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SiltBlock);
					}
					if (Main.rand.Next(70) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.GraniteBlock);
					}
					if (Main.rand.Next(70) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MarbleBlock);
					}
					if (Main.rand.Next(70) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.AshBlock);
					}
					if (Main.rand.Next(70) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MudBlock);
					}
					if (Main.rand.Next(65) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.StoneBlock);
					}
					if (Main.rand.Next(30) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.DirtBlock);
					}
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CorruptSeeds);
					}
					if (Main.rand.Next(150) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.DemoniteOre);
					}
					if (Main.rand.Next(70) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.IronOre);
					}
					if (Main.rand.Next(70) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.LeadOre);
					}
					if (Main.rand.Next(150) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CrimtaneOre);
					}
					if (NPC.downedBoss2)

					{
						if (Main.rand.Next(35) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Obsidian);
						}
						if (Main.rand.Next(35) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Hellstone);
						}
						if (Main.rand.Next(35) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CrimstoneBlock);
						}
						if (Main.rand.Next(35) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.EbonstoneBlock);
						}
					}
					if (NPC.downedMechBoss3)

					{
						if (NPC.downedMechBoss2)

						{
							if (NPC.downedMechBoss1)

							{
								if (Main.rand.Next(35) == 0)
								{
									Item.NewItem(i * 16, j * 16, 16, 16, ItemID.LihzahrdBrick, 1);
								}
							}
						}
					}
					if (Main.rand.Next(135) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.GoldOre);
					}
					if (Main.rand.Next(89) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TungstenOre);
					}
					if (Main.rand.Next(89) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SilverOre);
					}
					if (Main.rand.Next(79) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TinOre);
					}
					if (Main.rand.Next(79) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CopperOre);
					}
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.IceBlock);
					}
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SnowBlock);
					}
					if (Main.rand.Next(150) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Topaz);
					}

					if (Main.rand.Next(150) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amethyst);
					}

					if (Main.rand.Next(70) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<SchroedingersBucket>(), 4);
					}


					if (Main.hardMode) //if it's hardmode the NPC will sell this
					{
						if (Main.rand.Next(50) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.PearlstoneBlock);
						}
						if (Main.rand.Next(50) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.HallowedSeeds);
						}
						if (Main.rand.Next(100) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.PalladiumOre);
						}
						if (Main.rand.Next(100) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CobaltOre);
						}
						if (Main.rand.Next(150) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MythrilOre);
						}
						if (Main.rand.Next(150) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.OrichalcumOre);
						}
						if (Main.rand.Next(200) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.AdamantiteOre);
						}
						if (Main.rand.Next(200) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TitaniumOre);
						}

						if (Main.rand.Next(300) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Diamond);
						}

						if (Main.rand.Next(150) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Cobweb);
						}
						if (fail == false)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.StoneBlock);
						}
						if (Main.rand.Next(180) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amber);
						}

						if (Main.rand.Next(222) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Emerald);
						}

						if (Main.rand.Next(230) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Ruby);
						}

						if (Main.rand.Next(200) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Sapphire);
						}

						if (Main.rand.Next(150) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.PlatinumOre);
						}
						if (Main.rand.Next(100) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.ClayBlock);
						}
						if (Main.rand.Next(100) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SandBlock);
						}
						if (Main.rand.Next(120) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SiltBlock);
						}
						if (Main.rand.Next(120) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.GraniteBlock);
						}
						if (Main.rand.Next(120) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MarbleBlock);
						}
						if (Main.rand.Next(120) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.AshBlock);
						}
						if (Main.rand.Next(120) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MudBlock);
						}
						if (Main.rand.Next(115) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.StoneBlock);
						}
						if (Main.rand.Next(80) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.DirtBlock);
						}
						if (Main.rand.Next(130) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CorruptSeeds);
						}
						if (Main.rand.Next(200) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.DemoniteOre);
						}
						if (Main.rand.Next(120) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.IronOre);
						}
						if (Main.rand.Next(120) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.LeadOre);
						}
						if (Main.rand.Next(200) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CrimtaneOre);
						}
						if (NPC.downedBoss3)

						{
							if (Main.rand.Next(85) == 0)
							{
								Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Obsidian);
							}
							if (Main.rand.Next(85) == 0)
							{
								Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Hellstone);
							}
							if (Main.rand.Next(85) == 0)
							{
								Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CrimstoneBlock);
							}
							if (Main.rand.Next(85) == 0)
							{
								Item.NewItem(i * 16, j * 16, 16, 16, ItemID.EbonstoneBlock);
							}
						}
						if (Main.rand.Next(185) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.GoldOre);
						}
						if (Main.rand.Next(140) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TungstenOre);
						}
						if (Main.rand.Next(140) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SilverOre);
						}
						if (Main.rand.Next(140) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TinOre);
						}
						if (Main.rand.Next(140) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CopperOre);
						}
						if (Main.rand.Next(160) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.IceBlock);
						}
						if (Main.rand.Next(160) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SnowBlock);
						}
						if (Main.rand.Next(300) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Topaz);
						}

						if (Main.rand.Next(300) == 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amethyst);
						}

					}
				}
			

		}
	}
	public class craftaltarslihzahr : GlobalItem
	{


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SchroedingersBucket>(), 1);
			recipe.SetResult(ItemID.WaterBucket);
			recipe.AddRecipe();
		}
	}
	public class craftaltarslihzah : GlobalItem
	{


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SchroedingersBucket>(), 1);
			recipe.SetResult(ItemID.LavaBucket);
			recipe.AddRecipe();
		}
	}
	public class ShadowOrb : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Placing will give you the items of a shadow orb.");
		}
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 10;
			item.useTime = 5;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = TileID.ShadowOrbs;
			item.width = 12;
			item.height = 12;
		}
		public override void AddRecipes()
		{

				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.DemoniteBar, 10);
				recipe.SetResult(this);
				recipe.AddRecipe();

			
		}

	}
	public class Pot : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 10;
			item.useTime = 5;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = TileID.Pots;
			item.width = 12;
			item.height = 12;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ClayBlock, 30);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();


		}

	}
	public class potacorn : GlobalTile
	{
		public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if (type == TileID.Pots)
			{
					if (Main.rand.Next(3) == 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Acorn);
					}


				
			}

		}
	}

	public class craftaltarslihzar : GlobalItem
	{


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SchroedingersBucket>(), 1);
			recipe.SetResult(ItemID.HoneyBucket);
			recipe.AddRecipe();
		}
	}
	public class SchroedingersBucket : ModItem
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Contains every type of liquid at once until you open it.");
		}

		public override void SetDefaults()
		{
			item.value = 0;
			item.rare = ItemRarityID.White;
			item.maxStack = 999;
		}

	}

	public class craftaltarslihzahrd : GlobalItem
    {


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 75);
            recipe.AddIngredient(ModContent.ItemType<DemonAltar>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.LihzahrdAltar);
            recipe.AddRecipe();
        }
    }
    public class SkyMerchant : GlobalNPC
    {
        public override void SetupShop(int type, Terraria.Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Merchant:  //change Dryad whith what NPC you want

                    if (Main.hardMode) //if it's hardmode the NPC will sell this
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<LargeSkull>());  //this is an example of how to add your item
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<BookOfHairStyles>());  //this is an example of how to add your item
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.MagicMirror);  //this is an example of how to add your item
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.LifeCrystal);  //this is an example of how to add your item
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<FishingGuide>());  //this is an example of how to add your item
                        nextSlot++;
                    }

                    if (NPC.downedGolemBoss)

                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<CultistsHood>());  //this is an example of how to add your item
                        nextSlot++;
                    }
                    //else
                    //{    //This make that the npc will always sell this
                    //	shop.item[nextSlot].SetDefaults(mod.ItemType("DualUseWeapon"));   //this is an example of how to add your item
                    //	nextSlot++;
                    //	shop.item[nextSlot].SetDefaults(mod.ItemType("ItemName"));   //this is an example of how to add your item
                    //	nextSlot++;
                    //	shop.item[nextSlot].SetDefaults(ItemID.IvyWhip);     //this is an example of how to add a terraria item
                    //	nextSlot++;
                    //}
                    //if (Main.player[Main.myPlayer].ZoneJungle)//if the player is in jungle the npc will sell whis.  Change ZoneJungle with what zone you want: ZoneCorrupt for Corupption, ZoneCrimson for Crimson, ZoneDesert for Desert, ZoneDungeon for Dungeon, ZoneGlowshroom for Glowing Mushroom biome, ZoneHoly for The Hallow, ZoneJungle for Jungle, ZoneMeteor for Meteorite biome, ZoneSnow for Snow biome.
                    //{
                    //	shop.item[nextSlot].SetDefaults(ItemID.Abeemination); //this is an example of how to add a terraria item
                    //	nextSlot++;
                    //}

                    break;
            }
        }
    }

    public class SkyMerchant2DontAsk : GlobalNPC
    {
        public override void SetupShop(int type, Terraria.Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Merchant:  //change Dryad whith what NPC you want

                    if (!Main.hardMode) //if it's hardmode the NPC will sell this
                    {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<LargeSkull>());  //this is an example of how to add your item
                            nextSlot++;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BookOfHairStyles>());  //this is an example of how to add your item
                            nextSlot++;
                            shop.item[nextSlot].SetDefaults(ItemID.MagicMirror);  //this is an example of how to add your item
                            nextSlot++;
                            shop.item[nextSlot].SetDefaults(ItemID.LifeCrystal);  //this is an example of how to add your item
                            nextSlot++;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<FishingGuide>());  //this is an example of how to add your item
                            nextSlot++;
                            //shop.item[nextSlot].SetDefaults(ItemID.LunarBar);    //this is an example of how to add a terraria item
                            //nextSlot++;
                    }
                    
                    //else
                    //{    //This make that the npc will always sell this
                    //	shop.item[nextSlot].SetDefaults(mod.ItemType("DualUseWeapon"));   //this is an example of how to add your item
                    //	nextSlot++;
                    //	shop.item[nextSlot].SetDefaults(mod.ItemType("ItemName"));   //this is an example of how to add your item
                    //	nextSlot++;
                    //	shop.item[nextSlot].SetDefaults(ItemID.IvyWhip);     //this is an example of how to add a terraria item
                    //	nextSlot++;
                    //}
                    //if (Main.player[Main.myPlayer].ZoneJungle)//if the player is in jungle the npc will sell whis.  Change ZoneJungle with what zone you want: ZoneCorrupt for Corupption, ZoneCrimson for Crimson, ZoneDesert for Desert, ZoneDungeon for Dungeon, ZoneGlowshroom for Glowing Mushroom biome, ZoneHoly for The Hallow, ZoneJungle for Jungle, ZoneMeteor for Meteorite biome, ZoneSnow for Snow biome.
                    //{
                    //	shop.item[nextSlot].SetDefaults(ItemID.Abeemination); //this is an example of how to add a terraria item
                    //	nextSlot++;
                    //}

                    break;
            }
        }
    }

    public class LargeSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons skeletron.");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 30000;
            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.

        public override bool CanUseItem(Player player)
        {
            // "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
            return !NPC.AnyNPCs(NPCID.SkeletronHead);
        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 200, NPCID.SkeletronHead, 0);
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

    }
    public class DemonAltar : ModItem
    {
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 10;
            item.useTime = 5;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = TileID.DemonAltar;
            item.width = 12;
            item.height = 12;
            item.value = 3000;
        }
        public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.DemoniteBar, 5);
                recipe.AddIngredient(ItemID.StoneBlock, 30);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CrimtaneBar, 5);
                recipe.AddIngredient(ItemID.StoneBlock, 30);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
        
    }
}