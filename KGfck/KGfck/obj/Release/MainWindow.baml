   M S B A M L   `   `   `  ���� @  <KGfck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KGfckKGfck      KGfck.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:KGfck       � Title$  	Dipyramid��$��1178.25��$��1421.924�� � Icon$b \C:\Users\Лиза\Documents\Visual Studio 2017\Projects\KGF\KGfck\KGfck\Resources\Zircon.ico��.��� -    �Name$	 gr1�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T�  � ColumnDefinitions �� $
��150* ��� $	��23* �.+��� -   $��	OX_rotate��$��1��$
��Left=�$��	48,73,0,0q�$	��Top=� � Maximum$	 360Q�$	��109��$��18���� -    ��Name$ 	OY_rotate��$��1��$
��Left=�$��
48,118,0,0q�$	��Top=�$	 360Q�$	��109��$��18���� -   $ 	OZ_rotate��$��1��$
��Left=�$��
48,163,0,0q�$	��Top=�$	 360Q�$	��109��$��18���� -   $ OX_delatate��$��1��$
��Left=�$��
48,254,0,0q�$	��Top=� � Value$ 1Q�$ 2Q�$	��109��$��18���� -   $ OY_delatate��$��1��$
��Left=�$��
48,294,0,0q�$	��Top=�$ 1Q�$ 2Q�$	��109��$��18���� -   $ OZ_delatate��$��1��$
��Left=�$��
48,335,0,0q�$	��Top=�$ 1Q�$ 2Q�$	��109��$��18���� -   $ OX_translate��$��1��$
��Left=�$��
48,420,0,0q�$	��Top=�$	��109�� � Minimum$	 -10Q�	 � SmallChange$
	 0.01Q�$��18���� -	   $ OY_translate��$��1��$
��Left=�$��
48,460,0,0q�$	��Top=�$	��109��$	 -10Q�$��18���� -
   $ OZ_translate��$��1��$
��Left=�$��
48,500,0,0q�$	��Top=�$	��109��$	 -10Q�$��18���� -   $��Default��$��1��$
��Left=�$��
10,611,0,0q�$	��Top=�$��75��$��20���� -   
 ��Name$
 MirrorOX��$��	Mirror OX��$��1��$
��Left=�$��
15,543,0,0q�$	��Top=�$��15��$��73���� -   $
 MirrorOY��$��	Mirror OY��$��1��$
��Left=�$��
15,561,0,0q�$	��Top=�$��15��$��72���� -   $
 MirrorOZ��$��	Mirror OZ��$��1��$
��Left=�$��
15,578,0,0q�$	��Top=�$��15��$��72���� -    ��Name$
 rotX�� �� ContentStringFormat$ F��$��1��$
��Left=�$��22��$��	48,91,0,0q�$	��Top=�$��77��$��11(�����  �� ElementName$ 	OX_rotate�� �� Path$ Value��� -   $
 rotY��$ F��$��1��$
��Left=�$��22��$��
48,136,0,0q�$	��Top=�$��77��$��11(����� $ 	OY_rotate��$ Value��� -   $
 rotZ��$ F��$��1��$
��Left=�$��22��$��
48,181,0,0q�$	��Top=�$��94��$��11(����� $ 	OZ_rotate��$ Value��� -   $ 	label_rot��$��Rotation��$��1��$
��Left=�$��35��$��	10,19,0,0q�$	��Top=�$	��109��$��18(��� -   $ label_OX��$��OX��$��1��$
��Left=�$��25��$��	10,68,0,0q�$	��Top=�$��33��$ 0.495,0.187&��� -   $ label_OY��$��OY��$��1��$
��Left=�$��25��$��
10,111,0,0q�$	��Top=�$��33���� -   $ label_OZ��$��OZ��$��1��$
��Left=�$��25��$��
10,156,0,0q�$	��Top=�$��33���� -   $ label_delatation��$��
Delatation��$��1��$
��Left=�$��35��$��
10,208,0,0q�$	��Top=�$	��109��$��18(��� -   $ label_translation��$��Translation��$��1��$
��Left=�$��35��$��
10,380,0,0q�$	��Top=�$	��109��$��18(��� -   $ label_OX_Copy��$��OX��$��1��$
��Left=�$��25��$��
10,247,0,0q�$	��Top=�$��33��$ 0.495,0.187&��� -   $ label_OY_Copy��$��OY��$��1��$
��Left=�$��25��$��
10,290,0,0q�$	��Top=�$��33���� -   $ label_OZ_Copy��$��OZ��$��1��$
��Left=�$��25��$��
10,335,0,0q�$	��Top=�$��33���� -   $ label_OX_Copy1��$��OX��$��1��$
��Left=�$��25��$��
10,414,0,0q�$	��Top=�$��33��$ 0.495,0.187&��� -   $ label_OY_Copy1��$��OY��$��1��$
��Left=�$��25��$��
10,457,0,0q�$	��Top=�$��33���� -   $ label_OZ_Copy1��$��OZ��$��1��$
��Left=�$��25��$��
10,502,0,0q�$	��Top=�$��33���� -   $
 delX��$ F��$��1��$
��Left=�$��22��$��
48,272,0,0q�$	��Top=�$��77��$��11(����� *Value+$ OX_delatate���� -   $
 delY��$ F��$��1��$
��Left=�$��22��$��
48,312,0,0q�$	��Top=�$��77��$��11(����� *Value+$ OY_delatate���� -    $
 delZ��$ F��$��1��$
��Left=�$��22��$��
48,353,0,0q�$	��Top=�$��77��$��11(����� *Value+$ OZ_delatate���� -!   $ transX��$ F��$��1��$
��Left=�$��22��$��
48,438,0,0q�$	��Top=�$��77��$��11(����� *Value+$ OX_translate���� -"   $ transY��$ F��$��1��$
��Left=�$��22��$��
48,478,0,0q�$	��Top=�$��77��$��11(����� *Value+$ OY_translate���� -#   $ transZ��$ F��$��1��$
��Left=�$��22��$��
48,518,0,0q�$	��Top=�$��77��$��11(����� *Value+$ OZ_translate��