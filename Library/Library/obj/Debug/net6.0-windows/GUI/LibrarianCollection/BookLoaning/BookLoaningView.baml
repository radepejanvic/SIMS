   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Library.GUI.LibrarianCollection.BookLoaning+Library.GUI.LibrarianCollection.BookLoaning  5   	   }Cclr-namespace:Library.GUI.LibrarianCollection.BookLoaning.ViewModel5Library.GUI.LibrarianCollection.BookLoaning.ViewModel  5   	   A    ;Library.GUI.LibrarianCollection.BookLoaning.BookLoaningView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:Library.GUI.LibrarianCollection.BookLoaning     5   	   Y	viewmodelCclr-namespace:Library.GUI.LibrarianCollection.BookLoaning.ViewModel     5   	     � Title$  BookLoaning��5
   	   $	��450��6   $	��800��6*   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��5   	   $��Pozajmljivanje knjige��5   	   $��15q�5   	   $��Center=�5   	    
  Header#��[  5   	   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5       5      �� 5      $
��auto �6    �� 5       $��* �6    .+�5#      � $��0��6   $��0��6     5$      �� 5%      �� 5&      .+�5(      �� $��0��5)      $��Dostupni primerci��5*      $��15q�5+      $��Center=�5,        	SubHeader#��[ 5-      �� 5.      $��1��5/      $��10q�50      $��Center=�51      ��52      �� *SearchBookCopies+ �� UpdateSourceTrigger$ PropertyChanged=�53      � 55      $��0��6   $��1��6     56      �� 57      �� 58      .+�5:      �� $��0��5;      $��Članovi biblioteke��5<      $��15q�5=      $��Center=�5>      #��[ 5?      �� 5@      $��1��5A      $��10q�5B      $��Center=�5C      ��5D      �� *SearchMembers+$ PropertyChanged=�5E      �� 5G      $��0��6   $��1��6'   $��10 0 5 0q�64   ��6F   �� *
BookCopies+ �� SelectedItem 6i   �� *SelectedBookCopy+��5H      �� 5I       �� 
TargetType" ��6   .�5J      ��  �� Property � �� �� Value$ Stretch=�6G   5K       �� View 5M      �� 5N      .P�5P      �� $��ID��6)   	 �� Width$
	 auto��65   
 �� CellTemplate
 5Q      �� 5R   "   .R�5S   &   �� $��Center=�6D    �� Padding$ 5q�6a   ��60   �� *Id+6a   5T   #   5V      �� 5X      $
��ISBN��6)   
 5Y      �� 5Z   "   .R�5[   &   �� $��Center=�6F   $ 5q�6c   ��60   �� *ISBN+6c   5\   #   5^      �� 5`      $��Inventarni broj��6)   
 5a      �� 5b   "   .R�5c   &   �� $��Center=�6Q   $ 5q�6n   ��60   �� *InventoryNumber+6n   5d   #   5f      �� 5h      $
��Cena��6)   
 5i      �� 5j   "   .R�5k   &   �� $��Center=�6G   $ 5q�6d   ��60   �� *Price+6d   5l   #   5n      5p      5r      �� 5t      $��1��6   $��1��6(   $��5 0 10 0q�65   ��6G   �� *	Members+ 6g   �� *SelectedMember+��5u      �� 5v      " ��6   .�5w      ��  � ��$ Stretch=�6G   5x       5z      �� 5{      .P�5}      �� $��ID��6)   $
	 auto��65   
 5~      �� 5   "   .R�5�   &   �� $��Center=�6R   $ 5q�6o   ��60   �� *MembershipCardId+6o   5�   #   5�      �� 5�      $	��Ime��6)   
 5�      �� 5�   "   .R�5�   &   �� $��Center=�6F   $ 5q�6c   ��60   �� *Name+6c   5�   #   5�      �� 5�      $��Prezime��6)   
 5�      �� 5�   "   .R�5�   &   �� $��Center=�6I   $ 5q�6f   ��60   �� *	Surname+6f   5�   #   5�      �� 5�      $
��JMBG��6)   
 5�      �� 5�   "   .R�5�   &   �� $��Center=�6F   $ 5q�6c   ��60   �� *JMBG+6c   5�   #   5�      5�      5�      5�      �� 5�   
   $��2��6    �� Orientation$ 
Horizontal=�6#   $��10q�6<   $��Right=�6H   $��Center=�6d   .+�5�      �� $��Kreiraj pozajmicu��6   $��10 0 0 0q�61   ��6C   �� *
CreateLoan+5�      5�      5�      