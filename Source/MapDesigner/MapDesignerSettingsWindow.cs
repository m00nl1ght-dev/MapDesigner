﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;

namespace MapDesigner
{
    public class MapDesigner_Mod : Mod
    {
        private enum InfoCardTab : byte
        {
            General,
            Mountains,
            Things,
            Rocks,
            Feature,
        }
        private MapDesigner_Mod.InfoCardTab tab;

        MapDesignerSettings settings;

        public MapDesigner_Mod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<MapDesignerSettings>();
        }

        public override string SettingsCategory()
        {
            return "ZMD_ModName".Translate();
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            HelperMethods.ApplyBiomeSettings();
        }


        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);

            Rect rect3 = new Rect(inRect);

            List<TabRecord> list = new List<TabRecord>();

            //TabRecord generalTab = new TabRecord("ZMD_generalTab".Translate(), delegate
            //{
            //    this.tab = MapDesigner_Mod.InfoCardTab.General;
            //}, this.tab == MapDesigner_Mod.InfoCardTab.General);
            //list.Add(generalTab);

            TabRecord mountainTab = new TabRecord("ZMD_mountainTab".Translate(), delegate
            {
                this.tab = MapDesigner_Mod.InfoCardTab.Mountains;
            }, this.tab == MapDesigner_Mod.InfoCardTab.Mountains);
            list.Add(mountainTab);

            TabRecord ThingsTab = new TabRecord("ZMD_thingsTab".Translate(), delegate
            {
                this.tab = MapDesigner_Mod.InfoCardTab.Things;
            }, this.tab == MapDesigner_Mod.InfoCardTab.Things);
            list.Add(ThingsTab);

            TabRecord rockTab = new TabRecord("ZMD_rocksTab".Translate(), delegate
            {
                this.tab = MapDesigner_Mod.InfoCardTab.Rocks;
            }, this.tab == MapDesigner_Mod.InfoCardTab.Rocks);
            list.Add(rockTab);

            TabRecord featureTab = new TabRecord("ZMD_featureTab".Translate(), delegate
            {
                this.tab = MapDesigner_Mod.InfoCardTab.Feature;
            }, this.tab == MapDesigner_Mod.InfoCardTab.Feature);
            list.Add(featureTab);

            TabDrawer.DrawTabs(rect3, list, 200f);
            this.FillCard(rect3.ContractedBy(18f));

            listingStandard.End();

        }


        protected void FillCard(Rect cardRect)
        {
            switch(tab)
            {
                case MapDesigner_Mod.InfoCardTab.Mountains:
                    (new UI.MountainCardUtility()).DrawMountainCard(cardRect);
                    break;
                case MapDesigner_Mod.InfoCardTab.Things:
                    (new UI.ThingsCardUtility()).DrawThingsCard(cardRect);
                    break;
                case MapDesigner_Mod.InfoCardTab.Rocks:
                    (new UI.RocksCardUtility()).DrawRocksCard(cardRect);
                    break;
                case MapDesigner_Mod.InfoCardTab.Feature:
                    (new UI.FeatureCardUtility()).DrawFeaturesCard(cardRect);
                    break;
                default:
                    (new UI.GeneralCardUtility()).DrawGeneralCard(cardRect);
                    break;
            }
        }

    }

}
