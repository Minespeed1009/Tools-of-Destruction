using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using ToolsOfDestruction.Items;
using ToolsOfDestruction.Items.Throwing;
using ToolsOfDestruction.Accessories;

namespace ToolsOfDestruction.NPCs
{
    public class Marauder : ModNPC
    {
        public override bool Autoload(ref string name)
        {
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marauder");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 32;
            npc.height = 48;
            npc.aiStyle = 7;
            npc.damage = 75;
            npc.defense = 25;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 1f;
            Main.npcFrameCount[npc.type] = 25;
            animationType = NPCID.Guide;
        }
        
        public override string Texture
        {
            get
            {
                return "ToolsOfDestruction/NPCs/Marauder";
            }
        }

        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return true;
        }

        public override string TownNPCName()
        {
            return "Test";
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(17))
            {
                case 0:
                    if (npc.GivenName == "Mayhemm")
                    {
                        return "I consider myself somewhat of an artist.";
                    }
                    return "This place has so many things to shoot! I can't believe you don't even own a proper gun!";
                case 1:
                    if (npc.GivenName == "Mayhemm")
                    {
                        return "Don't challenge me, I'll draw something big enough to split this planet in two.";
                    }
                    return "This place has so many things to shoot! I can't believe you don't even own a proper gun!";
                case 2:
                    if (npc.GivenName == "Devourer")
                    {
                        return "What? What's a railgun?";
                    }
                    return "This place has so many things to shoot! I can't believe you don't even own a proper gun!";
                case 3:
                    if (npc.GivenName == "Ravager")
                    {
                        return "Calamity? Never heard of it. Sounds kind of terrible though.";
                    }
                    return "This place has so many things to shoot! I can't believe you don't even own a proper gun!";
                case 4:
                    if (NPC.downedBoss1)
                    {
                        return "If you want, I can tell you about the time I killed a giant eyeball! Wait, what do you mean you've done that too?";
                    }
                    return "This place has so many things to shoot! I can't believe you don't even own a proper gun!";
                case 5:
                    return "No I will not steal your stuff. It's already mine anyway.";
                case 6:
                    return "There is quite a lot of leftover chaos down in that dungeon place, you might want to check that out";
                case 7:
                    return "If you have any rare items, I'll happily duplicate them for you. Somehow.";
                case 8:
                    return "Hey, have you seen my- nevermind. What do you want";
                case 9:
                    return "I could easily kill you, but fortunately for you I don't feel like it right now.";
                case 10:
                    return "Goddamn flying fish constantly stealing my- Oh, hi, I didn't see you there";
                case 11:
                    return "Once upon a time, there was an annoying little shit named Ben.";
                case 12:
                    return "I'm going to lose my mind if I can't find my- uh sorry, need anything?";
                case 13:
                    return "About time that stupid star disappeared, my eyes hurt. Wait, what do you mean it comes back?";
                case 14:
                    return "Why is it so bright here? Can't we just shoot this damn ball of light?";
                case 15:
                    return "I believe all of life's problems can be solved with a generous helping of bullets";
                case 16:
                    if (Main.LocalPlayer.HasItem(ItemID.VortexBeater))
                    {
                        return "Woah, nice gun! Can I have one too?";
                    }
                    return "This place has so many things to shoot! I can't believe you don't even own a proper gun!";
                default:
                    return "This place has so many things to shoot! I can't believe you don't even own a proper gun!";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("ChaosEnergy"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RemnantOfChaos"));
            nextSlot++;
            if (Main.LocalPlayer.HasItem(mod.ItemType("MalCircuit")))
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("MalCircuit"));
                nextSlot++;
            }
        }
    }
}