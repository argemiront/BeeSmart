   M S B A M L   `   `   `  ���� Z  VVIBlend.WPF.Editors, Version=4.0.0.0, Culture=neutral, PublicKeyToken=5f568d4f9cd901f1X?clr-namespace:VIBlend.WPF.Controls;assembly=VIBlend.WPF.EditorsVIBlend.WPF.Controls  \ XWPFDeveloperTools.Controls, Version=1.0.2919.30774, Culture=neutral, PublicKeyToken=null�cclr-namespace:WPFDeveloperTools.Controls.RealTimeClockTextBlock;assembly=WPFDeveloperTools.Controls1WPFDeveloperTools.Controls.RealTimeClockTextBlock  core   core.AutomacaoBase   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ZviblendEditors?clr-namespace:VIBlend.WPF.Controls;assembly=VIBlend.WPF.Editors     �1WPFDeveloperTools_Controls_RealTimeClockTextBlockcclr-namespace:WPFDeveloperTools.Controls.RealTimeClockTextBlock;assembly=WPFDeveloperTools.Controls     -     >�Name$  UserControl�� � 	Resources    TabItemFocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  TabControlNormalBorderBrush �� Color  ButtonNormalBackground �� EndPoint �� 
StartPoint	 � Color
 � Offset  TabItemStyle1 �� 
TargetType��%�  &	        &	 T     &	 g     &	 �     7   7  7  �� .���  � �� �� .R��� $��3,3,3,1q� . #��� ��$��1��$	 1 2R��� $ #8C8E94���� $	 0,1&�$	 0,0&�.��� $	 #F3F3F3��$
 0Q�� $	 #EBEBEB��$	
 0.5Q�� $	 #DDDDDD��$	
 0.5Q�� $	 #CDCDCD��$
 1Q��� " ��.���  �@�FocusVisualStyle8   ��  � ��
 �   ���  � ��$ 6,1,6,1q���  � ��8  ��  � ��8  ��  � ��$ Stretch=���  � ��$ Stretch=�.��� -    �Name$ 
LayoutRoot��.+��� -    ��Name$ 	Automacao��$��0,0,0.001,0q� J� RenderTransformOrigin$ 0.5,0.5&����	#00F9F9F9���	#FF595959$��1q�
 � Tag$ 1��z�V� .~���  �� ScaleY$ 1Q� �� ScaleX$ 1Q���  �� AngleY$ 0Q� �� AngleX$ 0Q���  �� Angle$ 0Q�T� .@��� -    ��Name$ tbiTimer��$��Tempo��$ 0.5,0.5&����	#4C8C8E94���� $	 0,1&�$	 0,0&�.��� $	 	#4CF3F3F3��$
 0Q�� $	 	#4CEBEBEB��$	
 0.5Q�� $	 	#4CDDDDDD��$	
 0.5Q�� $	 	#4CCDCDCD��$
 1Q�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .��� ���	#00E5E5E5$ 0.5,0.5&�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .+�c� -    c�Name$ 
dowToolBar�� c� IsOverflowOpen . $��0,184.08,0,220q�$��Center=�.@��� -    ��Name$ chbSeg��$��Segunda��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -   $ chbTer��$��Terça��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -   $ chbQua��$��Quarta��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -	   $ chbQui��$��Quinta��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -
   $ chbSex��$��Sexta��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -   $ chbSab��$��Sábado��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -   $ chbDom��$��Domingo��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -    ��Name$ btnDoW��$��Todos / Nenhum��$
��Left=�$��380.404,0,0,180q�$	��106��$��36��$��Bottom=�$ 	dowSelect���� $��Começa na data:��$
��Left=�$��23,0,0,99.54q����	#00F4F4F4���	#FFF4F4F4$��Bottom=�(  "System.Windows.Controls.DatePicker  -     Name$ dtpInic��$
��Left=�$��125.308,0,0,99.54q�$��Bottom=�$��24��$	��105��d� -    d�Name$ tgbEnableTimer��$��
Habilitado��$��Right=�$��0,0,21.405,8q�$��Bottom=�$��36��$��103.59��$	��100�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 18Q�   Color$ White��   	Direction$ 0Q�    ShadowDepth$  0Q�!   Opacity! �� *	IsChecked+" �� ElementName$" tgbEnableTimer���� $��e termina na data:��$��0,0,134.669,99.54q����	#00F4F4F4���	#FFF4F4F4$��Right=�$��Bottom=�  -   $ dtpFim��$��0,0,19.667,99.54q�$��Right=�$��Bottom=�$��24��$	��105���� $��Nos horários:��$
��Left=�$��23,21.58,0,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=�$��13.333(��� $��começa às:��$
��Left=�$��115.366,21.58,0,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� $��e termina às:��$��Right=�$��0,21.58,162.669,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� $��começa às:��$
��Left=�$��115.366,56.58,0,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� $��e termina às:��$��Right=�$��0,56.58,162.669,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� $��começa às:��$
��Left=�$��115.366,91.58,0,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� $��e termina às:��$��Right=�$��0,91.58,162.669,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� -   $ btnClearDTE0��$��Limpar��$��Right=�$��24��$��0,22.56,19.667,0q�$	��Top=�$��62��$ clear0���� -   $ btnClearDTE1��$��Limpar��$��Right=�$��24��$��0,57.56,19.667,0q�$	��Top=�$��62��$ clear1���� -   $ btnClearDTE2��$��Limpar��$��Right=�$��0,91.52,19.667,0q�$��62��$��24��$	��Top=�$ clear2���� $��Nos dias da semana:��$
��Left=�$��23,154.58,0,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=�$��13.333(��� $��Entre as datas:��$
��Left=�$��23,0,0,131.54q����	#00F4F4F4���	#FFF4F4F4$��Bottom=�$��13.333(�)   #VIBlend.WPF.Controls.DateTimeEditor  -   #  Name$# dteInic1��$��24��$
��Left=�$��187.289,57.58,0,0q�$	��Top=�$��50.667��$   DefaultDateTimeFormat$$ ShortTimePattern=�%   Culture$% 	(Default)��$��Center=�  -   $# dteInic2��$��24��$
��Left=�$��187.289,92.58,0,0q�$	��Top=�$��50.667��$$ ShortTimePattern=�$% 	(Default)��$��Center=�  -   $# dteFim0��$��24��$��Right=�$��0,22.58,108.002,0q�$	��Top=�$��50.667��$$ ShortTimePattern=�$% 	(Default)��$��Center=�  -   $# dteFim1��$��24��$��Right=�$��0,56.79,108.002,0q�$	��Top=�$��50.667��$$ ShortTimePattern=�$% 	(Default)��$��Center=�  -   $# dteFim2��$��24��$��Right=�$��0,92.58,108.002,0q�$	��Top=�$��50.667��$$ ShortTimePattern=�$% 	(Default)��$��Center=�  -   $# dteInic0��$��187.334,22.08,0,0q�& �� TextWrapping$
& Wrap=�$	��Top=�$$ ShortTimePattern=�$��Center=�$
��Left=�$��50��$��24���� -   $ tbiInterruptor��$��Interruptor��$ 0.5,0.5&����	#4C8C8E94#���  ���� $	 0,1&�$	 0,0&�.��� $	 	#4CF3F3F3��$
 0Q�� $	 	#4CEBEBEB��$	
 0.5Q�� $	 	#4CDDDDDD��$	
 0.5Q�� $	 	#4CCDCDCD��$
 1Q�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .��� ���	#00E5E5E5$ 0.5,0.5&�$��440.08��$��507.809��z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .+�d� -   $ tgbEnableInterruptor��$��
Habilitado��$��Right=�$��0,0,21.405,8q�$��Bottom=�$��36��$��103.59��$ 0.5,0.5&�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T�    $ 18Q�$ White��$ 0Q�$  0Q�! �� *	IsChecked+$" tgbEnableInterruptor���� $
��Left=�$��60.179,73.361,0,0q�$��83��$��141.5��$	��Top=�$��Resources/interruptor.jpg���� -   ' ��Name$' cbxInterrup0��$
��Left=�$��59.81,217.08,0,201.04q�$��84���� $��216.179,73.361,208.63,0q�$��141.5��$	��Top=�$��Resources/interruptor.jpg���� -   $' cbxInterrup1��$"��215.81,217.08,207.999,201.04q��� $��0,73.361,52.63,0q�$��141.5��$	��Top=�$��Resources/interruptor.jpg��$��Right=�$��83���� -   $' cbxInterrup2��$��0,217.08,51.999,201.04q�$��Right=�$��84���� -   $ 	tbiSensor��$��Sensor��$ 0.5,0.5&����	#4C8C8E94#���  ���� $	 0,1&�$	 0,0&�.��� $	 	#4CF3F3F3��$
 0Q�� $	 	#4CEBEBEB��$	
 0.5Q�� $	 	#4CDDDDDD��$	
 0.5Q�� $	 	#4CCDCDCD��$
 1Q�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .��� ���	#00E5E5E5$ 0.5,0.5&�$��440.08��$��507.809��z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .+��� $��92.5,83.08,0,190q�$$��Resources/sensor presença.jpg��$ 0.5,0.5&�$
��Left=�$	��128��z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� �� -    $' 
cbxSensor0��$��92,0,0,153.04q�$��Bottom=�$
��Left=�$	��129���� $��0,83.08,76.309,190q�$$��Resources/sensor presença.jpg��$ 0.5,0.5&�$��Right=�$	��128��z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� �� -!   $' 
cbxSensor1��$��0,0,75.809,153.04q�$��Bottom=�$��Right=�$	��129��d� -"   $ tgbEnableSensor��$��
Habilitado��$��Right=�$��0,0,21.405,8q�$��Bottom=�$��36��$��103.59��$ 0.5,0.5&�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T�    $ 18Q�$ White��$ 0Q�$  0Q�! �� *	IsChecked+$" tgbEnableSensor���� -#   $ tbiMotor��$��Motor��$ 0.5,0.5&����	#4C8C8E94#���  ���� $	 0,1&�$	 0,0&�.��� $	 	#4CF3F3F3��$
 0Q�� $	 	#4CEBEBEB��$	
 0.5Q�� $	 	#4CDDDDDD��$	
 0.5Q�� $	 	#4CCDCDCD��$
 1Q�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .��� ���	#00E5E5E5$ 0.5,0.5&�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .+�d� -$   $ tgbEnableMotor��$��
Habilitado��$��Right=�$��0,0,21.405,8q�$��Bottom=�$��36��$��103.59��$ 0.5,0.5&�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T�    $ 18Q�$ White��$ 0Q�$  0Q�! �� *	IsChecked+$" tgbEnableMotor���� $
��Left=�$��97.809,115.08,0,179q�$	��120��$$��Resources/controle portão.jpg���� -%   $' cbxControleMtr0��$
��Left=�$��97.809,0,0,149.04q�$��Bottom=�$	��120���� $��0,115.08,95,179q�$$��Resources/controle portão.jpg��$��Right=�$	��120���� -&   $' cbxControleMtr1��$��0,0,95,149.04q�$��Bottom=�$��Right=�$	��120���� -'   $ 	tbiDimmer��$��Dimmer��$ 0.5,0.5&����	#4C8C8E94#���  ���� $	 0,1&�$	 0,0&�.��� $	 	#4CF3F3F3��$
 0Q�� $	 	#4CEBEBEB��$	
 0.5Q�� $	 	#4CDDDDDD��$	
 0.5Q�� $	 	#4CCDCDCD��$
 1Q�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .��� ���	#00E5E5E5$ 0.5,0.5&�$��440.08��$��507.809��z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .+�d� -(   $ tgbEnableDimmer��$��
Habilitado��$��Right=�$��0,0,21.405,8q�$��Bottom=�$��36��$��103.59��$ 0.5,0.5&�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T�    $ 18Q�$ White��$ 0Q�$  0Q�! �� *	IsChecked+$" tgbEnableDimmer���� $$��217.179,106.361,207.63,192.219q�$��Resources/interruptor.jpg���� -)   $' 	cbxDimmer��$��217.179,0,207.999,155.04q�$��Bottom=�$��83���� -*   $ 	tbiAlarme��$��Alarme��$ 0.5,0.5&����	#4C8C8E94���� $	 0,1&�$	 0,0&�.��� $	 	#4CF3F3F3��$
 0Q�� $	 	#4CEBEBEB��$	
 0.5Q�� $	 	#4CDDDDDD��$	
 0.5Q�� $	 	#4CCDCDCD��$
 1Q�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .��� ���	#00E5E5E5$ 0.5,0.5&�z�V� .~��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� .+�c� -+   $ dowToolBar1�� . $��0,145.08,0,0q�$��Center=�$��36��$	��Top=�.@��� -,   $ chbSeg1��$��Segunda��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� --   $ chbTer1��$��Terça��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -.   $ chbQua1��$��Quarta��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -/   $ chbQui1��$��Quinta��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -0   $ chbSex1��$��Sexta��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -1   $ chbSab1��$��Sábado��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -2   $ chbDom1��$��Domingo��$��Stretch=�$��Stretch=�$��63����.  $ 	diaSemana���� -3   $ btnDoW1��$��Todos / Nenhum��$
��Left=�$��380.404,185.08,0,219q�$	��106��$ dowSelectAlarm��d� -4   $ tgbEnableAlarme��$��
Habilitado��$��Right=�$��0,0,21.405,8q�$��Bottom=�$��36��$��103.59��$	��100��   $ 18Q�$ White��$ 0Q�$  0Q�! �� *	IsChecked+$" tgbEnableAlarme���� $��Nos horários:��$
��Left=�$��23,21.58,0,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=�$��13.333(��� $��começa às:��$
��Left=�$��115.366,21.58,0,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� $��e termina às:��$��Right=�$��0,21.58,162.669,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� $��começa às:��$
��Left=�$��115.366,56.58,0,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� $��e termina às:��$��Right=�$��0,56.58,162.669,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=��� -5   $ btnClearDTEAlarm0��$��Limpar��$��Right=�$��24��$��0,22.56,19.667,0q�$	��Top=�$��62��$ clearA0���� -6   $ btnClearDTEAlarm1��$��Limpar��$��Right=�$��24��$��0,57.56,19.667,0q�$	��Top=�$��62��$ clearA1���� $��Nos dias da semana:��$
��Left=�$��23,115.58,0,0q����	#00F4F4F4���	#FFF4F4F4$	��Top=�$��13.333(�  -7   $# dteAlarmInic1��$
��Left=�$��185.955,57.913,0,0q�$	��Top=�$$ ShortTimePattern=�$% 	(Default)��$��Center=�$��50��$��24��  -8   $# dteAlarmFim0��$��24��$��Right=�$��0,22.58,108.002,0q�$	��Top=�$��50.667��$$ ShortTimePattern=�$% 	(Default)��$��Center=�  -9   $# dteAlarmFim1��$��24��$��Right=�$��0,56.79,108.002,0q�$	��Top=�$��50.667��$$ ShortTimePattern=�$% 	(Default)��$��Center=�  -:   $# dteAlarmInic0��$��185.667,24.04,0,0q�$
& Wrap=�$	��Top=�$$ ShortTimePattern=�$��Center=�$
��Left=�$��50��$��24���� $��Com os sensores:��$
��Left=�$��23,0,0,177.766q����	#00F4F4F4���	#FFF4F4F4$��13.333(�$��Bottom=��� $
��Left=�$��86��$��30,0,0,77.04q�$��Bottom=�$��67��$$��Resources/sensor presença.jpg���� -;   $' cbxAlarmSensor0��$��30,0,0,45.04q�$��Bottom=�$
��Left=�$��67���� $
��Left=�$��86��$��130,0,0,77.04q�$��Bottom=�$��67��$$��Resources/sensor presença.jpg���� -<   $' cbxAlarmSensor1��$��130,0,0,45.04q�$��Bottom=�$
��Left=�$��67���� $��86��$��229,0,211.808,77.04q�$��Bottom=�$$��Resources/sensor presença.jpg���� -=   $' cbxAlarmSensor2��$��229,0,211.808,45.04q�$��Bottom=�