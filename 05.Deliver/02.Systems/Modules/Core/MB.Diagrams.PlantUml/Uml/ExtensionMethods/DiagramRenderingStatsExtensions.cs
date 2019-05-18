using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using App.Diagrams.PlantUml;
using App.Diagrams.PlantUml.Models;
using App.Diagrams.PlantUml.Uml;

namespace App.Diagrams.PlantUml.Uml
{
    public static class DiagramRenderingStatsExtensions
    {
        public static string CreateSafeUrl(this DiagramRenderingStats diagramRenderingStats, string fullName)
        {
            string tmp = fullName;
            if (tmp.Contains("<"))
            {
                tmp = Regex.Replace(tmp, "<.*>", "<>");
            }

            string url = string.Format(diagramRenderingStats.LinkBaseUrl, Uri.EscapeUriString(tmp));

            return url;
        }




        /// <summary>
        /// Create a StringBuilder, styled, and marked for SVG/PNG
        /// </summary>
        /// <param name="renderingStats"></param>
        /// <returns></returns>
        public static StringBuilder InitializeStringBuilder(this DiagramRenderingStats renderingStats)
        {
            StringBuilder stringBuilder = new StringBuilder();

            // Prepare the resulting stringBuilder with common skinParams:
            renderingStats.IncludePlantUmlSvgSkinParams(stringBuilder);
            renderingStats.IncludePlantUmlDefaultStyleSkinParams(stringBuilder);

            return stringBuilder;
        }




        private static void IncludePlantUmlSvgSkinParams(this DiagramRenderingStats diagramRenderingStats,
            StringBuilder stringBuilder)
        {
            if (diagramRenderingStats.ImageOutputType != DiagramRenderingRequestImageType.Svg)
            {
                return;
            }

            stringBuilder.AppendLine("'-----------------------");
            stringBuilder.AppendLine("'## Enabled SVG output:");
            stringBuilder.AppendLine("skinparam svgLinkTarget _parent");
            stringBuilder.AppendLine("skinparam pathHoverColor green");
            stringBuilder.AppendLine("");
        }



        private static void IncludePlantUmlDefaultStyleSkinParams(this DiagramRenderingStats diagramRenderingStats, StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("'");
            stringBuilder.AppendLine("'-----------------------");
            stringBuilder.AppendLine("'## Common Styling:");
            stringBuilder.AppendLine(@"
skinparam {

    
    artifact {
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }

    activity {
      ArrowColor grey
      ArrowFontSize 10
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      FontSize 10
      FontStyle plain
	  startColor grey
	  endColor grey
    }
	
	activityDiamond {
      ArrowColor grey
      ArrowFontSize 10
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      FontSize 10
      FontStyle plain
	}
	

    actor {
      ArrowColor grey
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }

    box {
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }

    card {
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }

    class {
      ArrowColor grey
      ArrowFontSize 10
      AttributeFontSize 10
      AttributeIconSize 10
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      StereotypeFontSize 10
      FontSize 10
      FontStyle plain
    }
    
    circledCharacter {
      FontSize 8
      FontStyle plain
    }
    
    cloud {
      BackgroundColor white
      BorderColor grey
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }

    component {
      ArrowFontSize 10
      ArrowColor grey
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      InterfaceBackgroundColor white
      InterfaceBorderColor Black
      StereotypeFontSize 10
      FontSize 10
      FontStyle plain
    }

    database {
      BackgroundColor white
      BorderColor grey
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }
    device {
      BackgroundColor white
      BorderColor grey
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }
    folder {
      BackgroundColor white
      BorderColor grey
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }
    
    footer {
      FontSize 10
      FontStyle plain
    }
    
    frame {
      FontSize 10
      BackgroundColor white
      BorderColor grey
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }

    interface {
      BackgroundColor white
      BorderColor black
      FontSize 10
      FontStyle plain
    }
    legend {
      BackgroundColor white
      BorderColor grey
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }

    node {
      BackgroundColor white
      BorderColor grey
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }
    note {
      ArrowColor grey
      BackgroundColor white
      BorderColor grey
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }

    object {
      StereoFontSize 10
      ArrowColor grey
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }

    package {
      ArrowColor grey
      BackgroundColor white
      BorderColor grey
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }
    
    rectangle {
      ArrowColor grey
      ArrowFontSize 10
      AttributeFontSize 10
      AttributeIconSize 10
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      StereotypeFontSize 10
      FontSize 10
      FontStyle plain
    }

    state {
      ArrowColor grey
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }


    sequence {
      StereotypeFontSize 10
      ActorFontSize 10
      DividerFontSize 10
      ArrowFontSize 10
      
      FontSize 10
      FontStyle plain
      GroupFontSize 10
      GroupBorderThickness 1
      GroupBorderColor grey
      GroupHeaderFontSize 10
      ParticipantFontSize 10
      TitleFontSize 10
      TitleFontStyle default
      

      ArrowColor                    grey
      DividerBackgroundColor    white
      GroupBackgroundColor            white
      LifeLineBackgroundColor    white
      LifeLineBorderColor            grey
      ParticipantBackgroundColor    white
      ParticipantBorderColor        grey
      BoxLineColor                  grey
      BoxBackgroundColor            white
      BoxBorderThickness 1
      ParticipantBorderColor    gray
    }

    stereotype {
      CBackgroundColor lightgrey
      ABackgroundColor lightgrey
      IBackgroundColor lightgrey
      EBackgroundColor lightgrey
      FontSize 10
      FontStyle plain
    }
    
    title {
      FontSize 10
      FontStyle plain
    }

    usecase {
      ActorFontSize 10
      ArrowFontSize 10
      
      ArrowColor grey
      BackgroundColor white
      BorderColor black
      BorderThickness 1
      FontSize 10
      FontStyle plain
    }
}

skinparam package<<Layout>> {
  borderColor Transparent
  backgroundColor Transparent
  fontColor Transparent
  stereotypeFontColor Transparent
}





skinparam artifactBorderColor<<Grey>> #D0D0D0
skinparam artifactFontColor<<Grey>> #A0A0A0
skinparam artifactBorderColor<<Faded>> #D0D0D0
skinparam artifactFontColor<<Faded>> #A0A0A0
skinparam artifactBackgroundColor<<Focused>> #E0E0E0
skinparam artifactBorderColor<<GreyBorder>> #C0C0C0
skinparam artifactBackgroundColor<<GreyBackground>> #E0E0E0


skinparam actorBorderColor<<Grey>> #D0D0D0
skinparam actorFontColor<<Grey>> #A0A0A0
skinparam actorBorderColor<<Faded>> #D0D0D0
skinparam actorFontColor<<Faded>> #A0A0A0
skinparam actorBackgroundColor<<Focused>> #E0E0E0
skinparam actorBorderColor<<GreyBorder>> #C0C0C0
skinparam actorBackgroundColor<<GreyBackground>> #E0E0E0

skinparam boxBorderColor<<Grey>> #D0D0D0
skinparam boxFontColor<<Grey>> #A0A0A0
skinparam boxBorderColor<<Faded>> #D0D0D0
skinparam boxFontColor<<Faded>> #A0A0A0
skinparam boxBackgroundColor<<Focused>> #E0E0E0
skinparam boxBorderColor<<GreyBorder>> #C0C0C0
skinparam boxBackgroundColor<<GreyBackground>> #E0E0E0

skinparam cardBorderColor<<Grey>> #D0D0D0
skinparam cardFontColor<<Grey>> #A0A0A0
skinparam cardBorderColor<<Faded>> #D0D0D0
skinparam cardFontColor<<Faded>> #A0A0A0
skinparam cardBackgroundColor<<Focused>> #E0E0E0
skinparam cardBorderColor<<GreyBorder>> #C0C0C0
skinparam cardBackgroundColor<<GreyBackground>> #E0E0E0

skinparam classBorderColor<<Grey>> #D0D0D0
skinparam classFontColor<<Grey>> #A0A0A0
skinparam classBorderColor<<Faded>> #D0D0D0
skinparam classFontColor<<Faded>> #A0A0A0
skinparam classBackgroundColor<<Focused>> #E0E0E0
skinparam classBorderColor<<GreyBorder>> #C0C0C0
skinparam classBackgroundColor<<GreyBackground>> #E0E0E0

skinparam cloudBorderColor<<Grey>> #D0D0D0
skinparam cloudFontColor<<Grey>> #A0A0A0
skinparam cloudBorderColor<<Faded>> #D0D0D0
skinparam cloudFontColor<<Faded>> #A0A0A0
skinparam cloudBackgroundColor<<Focused>> #E0E0E0
skinparam cloudBorderColor<<GreyBorder>> #C0C0C0
skinparam cloudBackgroundColor<<GreyBackground>> #E0E0E0

skinparam componentBorderColor<<Grey>> #D0D0D0
skinparam componentFontColor<<Grey>> #A0A0A0
skinparam componentBorderColor<<Faded>> #D0D0D0
skinparam componentFontColor<<Faded>> #A0A0A0
skinparam componentBackgroundColor<<Focused>> #E0E0E0
skinparam componentBorderColor<<GreyBorder>> #C0C0C0
skinparam componentBackgroundColor<<GreyBackground>> #E0E0E0

skinparam databaseBorderColor<<Grey>> #D0D0D0
skinparam databaseFontColor<<Grey>> #A0A0A0
skinparam databaseBorderColor<<Faded>> #D0D0D0
skinparam databaseFontColor<<Faded>> #A0A0A0
skinparam databaseBackgroundColor<<Focused>> #E0E0E0
skinparam databaseBorderColor<<GreyBorder>> #C0C0C0
skinparam databaseBackgroundColor<<GreyBackground>> #E0E0E0

skinparam deviceBorderColor<<Grey>> #D0D0D0
skinparam deviceFontColor<<Grey>> #A0A0A0
skinparam deviceBorderColor<<Faded>> #D0D0D0
skinparam deviceFontColor<<Faded>> #A0A0A0
skinparam deviceBackgroundColor<<Focused>> #E0E0E0
skinparam deviceBorderColor<<GreyBorder>> #C0C0C0
skinparam deviceBackgroundColor<<GreyBackground>> #E0E0E0

skinparam frameBorderColor<<Grey>> #D0D0D0
skinparam frameFontColor<<Grey>> #A0A0A0
skinparam frameBorderColor<<Faded>> #D0D0D0
skinparam frameFontColor<<Faded>> #A0A0A0
skinparam frameBackgroundColor<<Focused>> #E0E0E0
skinparam frameBorderColor<<GreyBorder>> #C0C0C0
skinparam frameBackgroundColor<<GreyBackground>> #E0E0E0

skinparam nodeBorderColor<<Grey>> #D0D0D0
skinparam nodeFontColor<<Grey>> #A0A0A0
skinparam nodeBorderColor<<Faded>> #D0D0D0
skinparam nodeFontColor<<Faded>> #A0A0A0
skinparam nodeBackgroundColor<<Focused>> #E0E0E0
skinparam nodeBorderColor<<GreyBorder>> #C0C0C0
skinparam nodeBackgroundColor<<GreyBackground>> #E0E0E0

skinparam noteBorderColor<<Grey>> #D0D0D0
skinparam noteFontColor<<Grey>> #A0A0A0
skinparam noteBorderColor<<Faded>> #D0D0D0
skinparam noteFontColor<<Faded>> #A0A0A0
skinparam noteBackgroundColor<<Focused>> #E0E0E0
skinparam noteBorderColor<<GreyBorder>> #C0C0C0
skinparam noteBackgroundColor<<GreyBackground>> #E0E0E0

skinparam objectBorderColor<<Grey>> #D0D0D0
skinparam objectFontColor<<Grey>> #A0A0A0
skinparam objectBorderColor<<Faded>> #D0D0D0
skinparam objectFontColor<<Faded>> #A0A0A0
skinparam objectBackgroundColor<<Focused>> #E0E0E0
skinparam objectBorderColor<<GreyBorder>> #C0C0C0
skinparam objectBackgroundColor<<GreyBackground>> #E0E0E0

skinparam packageBorderColor<<Grey>> #D0D0D0
skinparam packageFontColor<<Grey>> #A0A0A0
skinparam packageBorderColor<<Faded>> #D0D0D0
skinparam packageFontColor<<Faded>> #A0A0A0
skinparam packageBackgroundColor<<Focused>> #E0E0E0
skinparam packageBorderColor<<GreyBorder>> #C0C0C0
skinparam packageBackgroundColor<<GreyBackground>> #E0E0E0

skinparam rectangleBorderColor<<Grey>> #D0D0D0
skinparam rectangleFontColor<<Grey>> #A0A0A0
skinparam rectangleBorderColor<<Faded>> #D0D0D0
skinparam rectangleFontColor<<Faded>> #A0A0A0
skinparam rectangleBackgroundColor<<Focused>> #E0E0E0
skinparam rectangleBorderColor<<GreyBorder>> #C0C0C0
skinparam rectangleBackgroundColor<<GreyBackground>> #E0E0E0

skinparam stateBorderColor<<Grey>> #D0D0D0
skinparam stateFontColor<<Grey>> #A0A0A0
skinparam stateBorderColor<<Faded>> #D0D0D0
skinparam stateFontColor<<Faded>> #A0A0A0
skinparam stateBackgroundColor<<Focused>> #E0E0E0
skinparam stateBorderColor<<GreyBorder>> #C0C0C0
skinparam stateBackgroundColor<<GreyBackground>> #E0E0E0

skinparam usecaseBorderColor<<Grey>> #D0D0D0
skinparam usecaseFontColor<<Grey>> #A0A0A0
skinparam usecaseBorderColor<<Faded>> #D0D0D0
skinparam usecaseFontColor<<Faded>> #A0A0A0
skinparam usecaseBackgroundColor<<Focused>> #E0E0E0
skinparam usecaseBorderColor<<GreyBorder>> #C0C0C0
skinparam usecaseBackgroundColor<<GreyBackground>> #E0E0E0


skinparam legendBorderColor<<Grey>> #D0D0D0
skinparam legendFontColor<<Grey>> #A0A0A0
skinparam legendBorderColor<<Faded>> #D0D0D0
skinparam legendFontColor<<Faded>> #A0A0A0
skinparam legendBackgroundColor<<Focused>> #E0E0E0
skinparam legendBorderColor<<GreyBorder>> #C0C0C0
skinparam legendBackgroundColor<<GreyBackground>> #E0E0E0



hide stereotype
hide empty members
hide footbox

skinparam sameClassWidth true
skinparam nodesep 50
skinparam ranksep 50
skinparam backgroundColor white
skinparam shadowing false 
skinparam classAttributeIconSize 0
skinparam dpi 100
scale 1.0



");
        }

    }
}
