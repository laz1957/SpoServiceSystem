using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using SpoServiceSystem.DataModels;

namespace SpoServiceSystem.Classes
{
    public class PrepodsListTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement elemnt = container as FrameworkElement;
            PrepodFullItog dataPrepod = item as PrepodFullItog;
            if(dataPrepod.FullSumma > 0)
            {
                return elemnt.FindResource("YesPlanTemplate") as DataTemplate;
            }
            else
            {
                return elemnt.FindResource("NoPlanTemplate") as DataTemplate;
            }
        }
    }

    public class GroupsListTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement elemnt = container as FrameworkElement;
            Group dataGroup= item as Group;
            if (dataGroup.groupPlanInfo.Count > 0)
            {
                return elemnt.FindResource("YesGroupPlanTemplate") as DataTemplate;
            }
            else
            {
                return elemnt.FindResource("NoGroupPlanTemplate") as DataTemplate;
            }
        }
    }
}
