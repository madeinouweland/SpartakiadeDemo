﻿using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SolidNavigation.Sdk;

namespace SpartakiadeDemo.Navigation
{
    public class NavigateService : NavigationServiceBase
    {
        private static NavigateService _current;
        public static NavigateService Current { get { return _current ?? (_current = new NavigateService()); } }

        public Frame ContentFrame
        {
            get { return (Frame)Window.Current.Content; }
        }

     
        protected override void Navigate(Route route, NavigationTarget target, string uri)
        {
            ContentFrame.Navigate(route.PageType, uri);
        }
    }
}
