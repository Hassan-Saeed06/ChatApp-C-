   M S B A M L   `   `   `  ����C  ?Sample01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Sample01Sample01  5   	   7 clr-namespace:Sample01.ViewModelSample01.ViewModel  5	   	       Sample01.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Sample01     5   	   /vm clr-namespace:Sample01.ViewModel     5	   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5      *  $Sample01.ViewModel.ViewModelClassMsg  5   
   .��5      � .+�5   
   �� -   5         ��Name$ lblName��5      $��302,33,334,339q�6!   $��20(�69   �� 5   
   $
��Left=�6   $��19��6-   $��278,132,0,0q�69    �� TextWrapping$
 Wrap=�6w   $	��Top=�6�   $	��191��6�   ��6N   ��  �� Path$ MessageArgument�6�   �� 5   
   $
��Send��6   $
��Left=�6    $��17��6;   $��342,184,0,0q�6G   $	��Top=�6\   $��58��6t   ��6   �� *AddNew+�� 5   
   $
��Left=�6   $��18��6-   $��276,235,0,0q�69   $
 Wrap=�6t   $	��Top=�6�   $	��190��6�   ��6N   �� $ AddedArgument�6�   �� 5   
   $��214,289,280,10q�6   ��6,   �� *AddedArgument+ �� View 5      �� 5      .P�5      �� $��Message��6%   5      5      5      5      