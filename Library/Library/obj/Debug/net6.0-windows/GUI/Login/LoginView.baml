   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Library.GUI.LoginLibrary.GUI.Login  5      5clr-namespace:Library.GUI.LoginLibrary.GUI.Login  5      !    Library.GUI.Login.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Library.GUI.Login     5      5	viewmodelclr-namespace:Library.GUI.Login     5      .��5      � 
�������  � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Center=�6   $��0,30,0,0q�61   $��3��6C   $
��Wrap=�6P   $	��Top=�6d   $	��198��6|   $��Arial Rounded MT Bold)�6�   $$��             PRIJAVA KORISNIKA��6�   �� 5   
   -   5         ��Name$ koeisnicko_ime��5      $��3��6*   $	��200��67   $��30��6C   $��99,63,101,25q�6O   $��0,0,0,2q�6e    �� TextAlignment$ Center=�6   ��6�   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��3��6   $	��200��6   $��30��6+   $��100,119,100,-31q�67   $��0,0,0,2q�6P   $ Center=�6j   ��6�   �� *
Password+$ PropertyChanged=��� 5   
   $��3��6   $	��100��6   $��30��6*   $��150,171,150,-83q�66   $��PRIJAVA��6O   $��Arial Rounded MT Bold)�6a   ��6�   �� *SubmitCommand+5      5      