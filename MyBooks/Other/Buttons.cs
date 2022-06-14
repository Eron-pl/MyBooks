using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyBooks.Other
{
    public class Buttons
    {
        public static StackPanel Source;

        public static IEnumerable<T> FindVisualChilds<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChilds<T>(ithChild)) yield return childOfChild;
            }
        }

        public static void ChangeButtonStyles(string buttonsName)
        {
            foreach (Button btn in Buttons.FindVisualChilds<Button>(Source))
            {
                if (btn.Name == buttonsName)
                    btn.SetResourceReference(Button.StyleProperty, "CurrentNavigationTabStyle");
                else
                    btn.SetResourceReference(Button.StyleProperty, "NavigationButtons");
            }
        }
    }
}
