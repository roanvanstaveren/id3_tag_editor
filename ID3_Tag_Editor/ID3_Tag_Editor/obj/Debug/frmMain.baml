   M S B A M L   `   `   `  ����I  EID3_Tag_Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ID3_Tag_EditorID3_Tag_Editor  5   	       ID3_Tag_Editor.frmMain   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ID3_Tag_Editor     5   	     � Title$
  Main��5   	   $��418.5��6   $��707.758��6%   .��5	      � .+�5
   
   ]� .+�5      o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� -   5        $��_Add...��5      60   m� 5      -   5        $��_Load List...��5      66   m� 5      -   5        $��_Save List...��5      66   �� 5      m� 5      -   5        $��_Exit��5      6.   5      m� 5      $��_View��6   .@�5      m� $��
_File List��6    m� IsCheckable .  m� 	IsChecked . 6F   m� 5      $��_Error List��6    .  .  6G   5      m� 5      $
��_All��6   .@�5      m� $��_Renaming...��6   m� 5      $��_Set Track Number��6   5      m� 5      $��_Window��6   .@�5      m� $��_Cascade Windows��6   m� 5      $ ��_Tile Windows Horizontally��6   m� 5      $��_Tile Windows Vertically��6   �� 5      m� 5       $��_1 Files��6    .  . 6D   5!      m� 5"      $��_Help��6   .@�5#      m� $��_Help��6   �� 5$      m� 5%      $��_About��6   5&      5'      5(      �� 5)   
   -   5         ��Name$ btDelete��5)      $��
Delete Row��6#   $��34��68   $��92��6D   $��598,354,13,3q�6O   6e   &   System.Windows.Controls.DataGrid  5*   
   -   5          Name$ dataGrid��5*         AutoGenerateColumns .  $
��Left=�6j   $	��261��6�   $��	10,88,0,0q�6�   $	��Top=�6�   $	��680��6�    �� SelectedIndex 6%   �� *SelectedIndex+   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ 	File Name��6%   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 140 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   ��  �� Path$ FileName�6z     5-      $ File Size (kB)��6%   	 . $
 80 6r    6P   �� $ FileSize�6     5.      $ ID3 Size (B)��6%   	 . $
 80 6n    6M   �� $ ID3Size�6{     5/      $
 Path��6%   	 . $	
 500 6h    6F   �� $ FilePath�6v   51      52      53      