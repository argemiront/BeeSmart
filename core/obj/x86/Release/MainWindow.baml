   M S B A M L   `   `   `  ���� ?  ;core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:core.Resourcescore.Resources  Z VVIBlend.WPF.Editors, Version=4.0.0.0, Culture=neutral, PublicKeyToken=5f568d4f9cd901f1X?clr-namespace:VIBlend.WPF.Controls;assembly=VIBlend.WPF.EditorsVIBlend.WPF.Controls clr-namespace:corecore  /clr-namespace:core.Utilitiescore.Utilities      core.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7core_Resourcesclr-namespace:core.Resources     ZviblendEditors?clr-namespace:VIBlend.WPF.Controls;assembly=VIBlend.WPF.Editors     $localclr-namespace:core     c _Microsoft.Expression.Effects, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35?ee4http://schemas.microsoft.com/expression/2010/effects   3core_Utilitiesclr-namespace:core.Utilities   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  Bei9http://schemas.microsoft.com/expression/2010/interactions  -     � Title$  BeeSmart��$	��640��$	��960��$	��960��$	��640�� � WindowStartupLocation$ CenterScreen=�
������  � Icon$ Resources/ufersa_icon.png��$	��960��$	��640�� � 	Resources *  $core.Utilities.PWMToOpacityConverter   PWMToOpacityConverter   BooleanToVisibilityConverter  core.Resources.Resource1  Resource1DataSource  TabItemFocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  TabControlNormalBorderBrush �� Color  ButtonNormalBackground	 �� EndPoint
 �� 
StartPoint � Color � Offset  TabItemHotBackground  TabItemSelectedBackground  TabItemHotBorderBrush 	 TabItemDisabledBackground 
 TabItemDisabledBorderBrush  TabItemStyle1 �� 
TargetType  SliderStyle2  
LightBrush  NormalBorderBrush �� 
TargetType �Name � RowDefinitions m�Name m� 	Placement  
GlyphBrush m� Fill ��Name �� CornerRadius ]�Name ]� Thumb  SimpleSliderThumb ]� IncreaseRepeatButton ! SimpleScrollRepeatButtonStyle ]� DecreaseRepeatButton �� Triggers P� Property P� Value �� 
TargetName  DisabledBackgroundBrush  DisabledBorderBrush �� Angle  ProgressBarStyle1  SolidBorderBrush  PressedBorderBrush��%�  &	        &	      &	 
     &	      &	 c     &	 v     &	     &	 �    &	 �    &		 �    &	
 �    &	 �    7  7  7  &	 �    &	 �      ��   �� .���  � �� �� .R��� $��3,3,3,1q� . #��� ��$��1��$	 1 2R��� $ #8C8E94���� $		 0,1&�$	
 0,0&�.��� $ #F3F3F3��$ 0Q�� $ #EBEBEB��$	 0.5Q�� $ #DDDDDD��$	 0.5Q�� $ #CDCDCD��$ 1Q��� $		 0,1&�$	
 0,0&�.��� $ #EAF6FD��$
 0.15Q�� $ #D9F0FC��$ .5Q�� $ #BEE6FD��$ .5Q�� $ #A7D9F5��$ 1Q��� $ #F9F9F9���� $ #3C7FB1���� $ #F4F4F4���� $ 	#FFC9C7BA���� " ��.���  �@�FocusVisualStyle8   ��  � ��
 �   ���  � ��$ 6,1,6,1q���  � ��8  ��  � ��8  ��  � ��$ Stretch=���  � ��$ Stretch=��� " ��.���  � ��# �  ��  � ��# �  ��  � �� �� " ��.R�� $ GridRoot�� �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $ TopTick��$y�	Collapsed=�$��4�� . $	 Top=�# �  �� $ Border��$��1��$��0q�$��4��#��z��#��z��#��z��$ 2��$y�Hidden=�]� $ 
PART_Track��$��1�� n� #���   �� #���  $��Slider.IncreaseLarge��$y�Visible=� �� #���  $��Slider.DecreaseLarge��m� $ 
BottomTick��$y�	Collapsed=�$��2��$��4�� . $ Bottom=�# z�� P�  �@��TickPlacement$ TopLeft=�. ��� $ TopTick�� � y�$ Visible=�P�  �@��TickPlacement$ BottomRight=�. ��� $ 
BottomTick�� � y�$ Visible=�P�  �@��TickPlacement$
 Both=�. ��� $ TopTick�� � y�$ Visible=��� $ 
BottomTick�� � y�$ Visible=�P�  � {� .  . ��� # �  $ Border�� � ���� # �  $ Border�� � ��P�  �@��Orientation$ Vertical=�. ��� $ GridRoot�� �@�LayoutTransform �� $	 -90Q��� $ 
PART_Track�� � ��$ 
Horizontal=��� " �.���  � �� �� " �.R�� .+��� $ 
PART_Track��#���  $��1q�$	 3.5������ $		 0,1&�$	
 0,0&�.��� $
 #777��$ 1Q�� $
 #000���� $ PART_Indicator��$
��Left=�#���  $��1q�$	 3.5������ $		 0,1&�$	
 0,0&�.��� $ 	#FF6ACCFD��$	 0.0Q�� $ 	#FF0041C2��$	 1.0Q� � Triggers :�   :� RoutedEvent$  FrameworkElement.Loaded��.��� ! � DataContext! �� " �� Source#" [ .+�� $��0,80,0,0q����	#FF444444�� $��0,56,0,0q�# J� RenderTransformOrigin$# 0.5,0.5&����	#00F9F9F9���	#008C8E94$ �� SelectedIndex$$ 0��z�V� .~��� % �� ScaleY$% 1Q�& �� ScaleX$& 1Q��� ' �� AngleY$' 0Q�( �� AngleX$( 0Q��� $ 0Q�T� .@��� $��Ao vivo��$# 0.5,0.5&����	#4C8C8E94���� $		 0,1&�$	
 0,0&�.��� $ 	#4CF3F3F3��$ 0Q�� $ 	#4CEBEBEB��$	 0.5Q�� $ 	#4CDDDDDD��$	 0.5Q�� $ 	#4CCDCDCD��$ 1Q�z�V� .~��� $% 1Q�$& 1Q��� $' 0Q�$( 0Q��� $ 0Q�T� .��� ���	#00E5E5E5$# 0.5,0.5&�}�. $��514.04��$	��934��z�V� .~��� $% 1Q�$& 1Q��� $' 0Q�$( 0Q��� $ 0Q�T� .+��� $��122,11.04,5,6q�$��Resources/casa.png���� -   ) ��Name$) imgServ��$��0,181.206,150.334,296.833q�$5��/Resources/placasinalizacaobanheiromasculino.gif��$��Right=�$��36��$��36���� -   $) imgPExt��$��302.333,153.54,0,324.5q�$5��/Resources/placasinalizacaobanheiromasculino.gif��$
��Left=�$��36��$��36���� -   * ��Name$* 	btnPortao��$
��Left=�$��158.333,85.04,0,0q�$��36��$��41��$	��Top=�.���� $$��Resources/controle portão.jpg��$��1q�A� $%��465.999,255.369,401.001,181.671q����	#00000000$# 0.5,0.5&�+ J� Opacity+ �� *Value+, �� 	Converter#, [  - �� ElementName$- sldSala����
� .��� $ White��� $ 1Q�. J� Effect. 3  -System.Windows.Media.Effects.DropShadowEffect  /   Color$/ White��0   ShadowDepth$0 0Q�1   	Direction$1 0Q�2   
BlurRadius$2 62Q�3   RenderingBias$3 Quality=��� $��36.501��$��0,0,421.604,193.667q�$��Bottom=�$��Resources/lampada.png��$��Right=�$��27.563��.   $1 0Q�$/ White��$2 40Q�$0 0Q�$3 Quality=�4   Opacity4 �� *Value+#, [  $- sldSala��� $��440.215,0,0,210.193q�#���  5 � Maximum$
5 1023Q�6 � LargeChange$	6 100Q�$��7��$��57.966��$
��Left=�$��Bottom=�$# 0.5,0.5&�7 � SmallChange$7 5Q�8 � Value8 �� *Value+$- sldSala��z�V� .~��� �� �� $	 -90Q�T� �� -   9 ��Name$9 sldSala��$��440.698,0,0,205.681q�#���  $
5 1023Q�$	6 100Q�$7 5Q�$��59��$
��Left=�$��15.334��$��Bottom=�$# 0.5,0.5&�z�V� .~��� �� �� $	 -90Q�T� ���� $		 0,1&�$	
 0,0&�.��� $ 	#FFCCCCCC��$ 1Q�� $ 	#FF444444��A� -   : A�Name$: 
lightPoste��$
��Left=�$��177.332,213.036,0,224.004q����	#00000000$��67��$# 0.5,0.5&���
� .��� $ White��� $ 1Q�.   $/ White��$0 0Q�$1 0Q�$2 62Q�$3 Quality=��� $
��Left=�$��196.166,241.539,0,236q�$��27.563��$��Resources/lampada.png��A� -   $: lightGaragem��$��435.332,105.702,431.668,0q����	#00000000$# 0.5,0.5&�$��77��$	��Top=���
� .��� $ White��� $ 1Q�.   $/ White��$0 0Q�$1 0Q�$2 62Q�$3 Quality=��� $��36.501��$��454.166,134.205,452.271,0q�$	��Top=�$��Resources/lampada.png��A� -   $: 	lightServ��$��Right=�$��0,195.702,168.668,241.338q����	#00000000$��67��$# 0.5,0.5&���
� .��� $ White��� $ 1Q�.   $/ White��$0 0Q�$1 0Q�$2 62Q�$3 Quality=��� $��Right=�$��0,224.205,189.271,253.334q�$��27.563��$��Resources/lampada.png��A� -	   $: 	lightExt1��$��0,6.369,6.834,0q����	#00000000$# 0.5,0.5&�$��77��$	��Top=�$��Right=�$��67��z�V� .~��� �� �� $	 -90Q�T� ��
� .��� $ White��� $ 1Q�.   $/ White��$0 0Q�$1 0Q�$2 62Q�$3 Quality=��� $��0,26.872,26.552,0q�$��Resources/lampada.png��$��36.501��$	��Top=�$# 0.5,0.5&�$��Right=�$��27.564��z�V� .~��� �� �� $	 -90Q�T� �� $
��Left=�$��28.167��$��147.833,192.707,0,0q�$	��Top=�$��22.833��$!��Resources/motor portão.png��� $	��220��$��0,0,71,9.525q�$��Bottom=����	#E5444444$��Right=�$	��201��.   $/ 	#FF444444��$	1 315Q�$2 12Q�$0 10Q�.+��� $��0q�$��Resources/quarto.png��A� $��74,58,60,85q����	#00000000$# 0.5,0.5&�+ �� *Value+#, [  $- 	sldQuarto����
� .��� $ White��� $ 1Q�.   $/ White��$0 0Q�$1 0Q�$2 62Q�$3 Quality=��� $!��93.718,78.249,79.718,105.25q�$��Resources/lampada.png��.   $1 0Q�$/ White��$2 40Q�$0 0Q�$3 Quality=�4 �� *Value+#, [  $- 	sldQuarto��� $��	42,96,0,0q�#���  $
5 1023Q�$	6 100Q�$��57.966��$
��Left=�$# 0.5,0.5&�$��7��$	��Top=�$7 5Q�8 �� *Value+$- 	sldQuarto��z�V� .~��� �� �� $	 -90Q�T� �� -
   $9 	sldQuarto��$��43,90.666,99,0q�#���  $
5 1023Q�$	6 100Q�$7 5Q�$# 0.5,0.5&�$��15.334��$	��Top=�z�V� .~��� �� �� $	 -90Q�T� ���� $		 0,1&�$	
 0,0&�.��� $ 	#FFCCCCCC��$ 1Q�� $ 	#FF444444���� $��QUARTO��$��82.23,5.5,61.23,0q����	#FFF4F4F4$��Center=�$��Center=�$��27��$	��Top=�A� -   $: 	lightExt2��$��0,0,4.834,1.999q����	#00000000$# 0.5,0.5&�$��77��$��Bottom=�$��Right=�$��67��z�V� .~��� �� �� $	 -90Q�T� ��
� .��� $ White��� $ 1Q�.   $/ White��$0 0Q�$1 0Q�$2 62Q�$3 Quality=��� $��0,0,24.552,18.995q�$��Resources/lampada.png��$��36.501��$��Bottom=�$��Right=�$��27.564��$# 0.5,0.5&�z�V� .~��� �� �� $	 -90Q�T� �� $
��SALA��$��0,220.5,416.23,0q����	#FFF4F4F4$��Center=�$��Center=�$��27��$	��Top=�$��Right=��� $��GARAGEM��$��431.23,84.5,430.23,0q����	#FFF4F4F4$��Center=�$��Center=�$��27��$	��Top=��� $��SERVIÇO��$��0,153.5,178.23,0q����	#FFF4F4F4$��Center=�$��Center=�$��Right=�$��27��$	��Top=�F� -   ; F�Name$; portao��������� I� ���r�	$
��Left=�$��128.25��$��138,79.29,0,0q�< �� Stretch$
< Fill=����	#FFF4F4F4$	��Top=�$��4��$��4����
� .��� $ White��� $ 1Q�$ 	#FFF4F4F4��d� -   = d�Name$= tgbIntServico��$��Right=�$��0,217.207,227.833,252.166q�$
��29.5��.���� $��1,0,0,0q�$
��32.7��$��19��$��Resources/interruptor.jpg��$��Center=�$��Center=�d� -   $= tgbIntGaragem��$
��Left=�$��405.667,125.207,0,0q�$
��29.5��$��44.667��$	��Top=�.���� $��1,0,0,0q�$
��32.7��$��19��$��Resources/interruptor.jpg��$��Center=�$��Center=�d� -   $= tgbIntPoste��$��156.667,244.207,0,225.166q�$
��Left=�$
��29.5����.  .���� $��1,0,0,0q�$
��32.7��$��19��$��Resources/interruptor.jpg��$��Center=�$��Center=�d� -   $= 	tgbIntExt��$��Right=�$��0,78.207,21.833,0q�$
��29.5��$��44.667��$	��Top=�.���� $��1,0,0,0q�$
��32.7��$��19��$��Resources/interruptor.jpg��$��Center=�$��Center=��� $��Configuração��$# 0.5,0.5&����	#4C8C8E94#���  ���� $		 0,1&�$	
 0,0&�.��� $ 	#4CF3F3F3��$ 0Q�� $ 	#4CEBEBEB��$	 0.5Q�� $ 	#4CDDDDDD��$	 0.5Q�� $ 	#4CCDCDCD��$ 1Q�z�V� .~��� $% 1Q�$& 1Q��� $' 0Q�$( 0Q��� $ 0Q�T� .��� ���	#00E5E5E5$# 0.5,0.5&�z�V� .~��� $% 1Q�$& 1Q��� $' 0Q�$( 0Q��� $ 0Q�T� .+��� -   > ��Name$> 	TabModulo��$��8q�$# 0.5,0.5&����	#00F9F9F9���	#FFF9F9F9? �� TabStripPlacement$? Right=�$��1q�z�V� .~��� $% 1Q�$& -1Q��� $' 0Q�$( 0Q��� $ 0Q�T� .@��� -   @ ��Name$
@ tbM1��$��	Módulo 1��$# 0.5,0.5&����	#4C8C8E94���� $		 0,1&�$	
 0,0&�.��� $ 	#4CF3F3F3��$ 0Q�� $ 	#4CEBEBEB��$	 0.5Q�� $ 	#4CDDDDDD��$	 0.5Q�� $ 	#4CCDCDCD��$ 1Q�z�V� .~��� $% 1Q�$& -1Q��� $' 0Q�$( 0Q��� $ 0Q�T� �� -   $
@ tbM2��$��	Módulo 2��$# 0.5,0.5&����	#4C8C8E94#���  ���� $		 0,1&�$	
 0,0&�.��� $ 	#4CF3F3F3��$ 0Q�� $ 	#4CEBEBEB��$	 0.5Q�� $ 	#4CDDDDDD��$	 0.5Q�� $ 	#4CCDCDCD��$ 1Q�z�V� .~��� $% 1Q�$& -1Q��� $' 0Q�$( 0Q��� $ 0Q�T� �� $
��Left=�$��46��$��1,3,0,0q�$	��Top=�$	��157��$��Resources/UFERSA_LOGO.png���� $/��)Universidade Federal Rural do Semi-árido��$��28��$��160.331,-5.667,399.002,0q�$	��Top=�$��14.667(����	#FFF3F3F3$��2q�$��Center=�$# -1.29,0.405&��� $>��8Trabalho de Conclusão de Curso - Argemiro S. de A. Neto��$��28��$��160.331,11.333,346.002,0q�$	��Top=�$��14.667(����	#FFF3F3F3$��2q�$��Center=�$# -1.29,0.405&��� $6��0Projeto de um Sistema de Automação Residencial��$��28��$��160.331,29.333,346.002,0q�$	��Top=�$��14.667(����	#FFF3F3F3$��2q�$��Center=�$# -1.29,0.405&��� $��Orientadores:��$��28��$��0,-5.667,9.002,0q�$	��Top=�$��14.667(����	#FFF3F3F3$��2q�$��Center=�$# -1.29,0.405&�$��Right=�$��Right=��� $%��Prof.ª Dra.ª Danielle Casillo��$��28��$��0,11.333,9.002,0q�$	��Top=�$��14.667(����	#FFF3F3F3$��2q�$��Center=�$# -1.29,0.405&�$��Right=�$��Right=��� $"��Prof. M.sc. Silvio Fernandes��$��28��$��0,29.333,9.002,0q�$	��Top=�$��14.667(����	#FFF3F3F3$��2q�$��Center=�$# -1.29,0.405&�$��Right=�$��Right=�