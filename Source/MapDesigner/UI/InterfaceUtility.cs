﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;

namespace MapDesigner.UI
{
    public static class InterfaceUtility
    {
        public static float LabeledSlider(Listing_Standard listing, float val, float min, float max, string label, string leftLabel = null, string rightLabel = null, string tooltip = null)
        {
            Rect rect = new Rect(listing.GetRect(44f));
            Widgets.DrawHighlightIfMouseover(rect);

            Rect leftSide = rect;
            Rect rightSide = rect;
            leftSide.xMax -= 0.76f * rect.width;
            rightSide.xMin += 0.26f * rect.width;
            float result = val;

            Widgets.Label(leftSide, label);
            if(string.IsNullOrEmpty(leftLabel) && string.IsNullOrEmpty(rightLabel))
            {
                rightSide.yMin += 16f;
                result = Widgets.HorizontalSlider(rightSide, val, min, max);
            }

            else
            {
                result = Widgets.HorizontalSlider(rightSide, val, min, max, false, " ", leftLabel, rightLabel);
            }

            if (tooltip != null)
            {
                TooltipHandler.TipRegion(rect, tooltip);
            }
            return result;
        }


        public static void LabeledIntRange(Listing_Standard listing, ref IntRange range, int min, int max, string label, string tooltip = null)
        {
            Rect rect = new Rect(listing.GetRect(44f));
            Widgets.DrawHighlightIfMouseover(rect);

            Rect innerRect = rect;
            innerRect.yMin += 8f;
            innerRect.yMax -= 8f;


            Rect leftSide = innerRect;
            Rect rightSide = innerRect;
            leftSide.xMax -= 0.76f * innerRect.width;
            rightSide.xMin += 0.26f * innerRect.width;

            Widgets.Label(leftSide, label);

            Widgets.IntRange(rightSide, (int)listing.CurHeight, ref range, min, max, null, 0);

            if (tooltip != null)
            {
                TooltipHandler.TipRegion(rect, tooltip);
            }
        }


        public static string FormatLabel(string label, string desc)
        {
            return String.Format("{0}: {1}", label.Translate(), desc.Translate());
        }

    }
}
