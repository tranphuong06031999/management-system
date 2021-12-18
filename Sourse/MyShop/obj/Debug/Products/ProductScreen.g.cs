﻿#pragma checksum "..\..\..\Products\ProductScreen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7DE7A4DC7889B7DCDB8C82BE86EA674E0252F26C50684B1CE8FD75C5C0D243A4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using MyShop;
using MyShop.Products;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MyShop.Products {
    
    
    /// <summary>
    /// ProductScreen
    /// </summary>
    public partial class ProductScreen : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid homeProduct;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label contentBack;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addProductButton;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel filterPanel;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider priceRangeSlider;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock leftPriceBoundaryTextBlock;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock rightPriceBoundaryTextBlock;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock currentPriceBoundaryTextBlock;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton filterToggle;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox categoriesComboBox;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 271 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView productsListView;
        
        #line default
        #line hidden
        
        
        #line 366 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxPaging;
        
        #line default
        #line hidden
        
        
        #line 401 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar status;
        
        #line default
        #line hidden
        
        
        #line 402 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statusLabel;
        
        #line default
        #line hidden
        
        
        #line 410 "..\..\..\Products\ProductScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressBar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyShop;component/products/productscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Products\ProductScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\Products\ProductScreen.xaml"
            ((MyShop.Products.ProductScreen)(target)).Initialized += new System.EventHandler(this.UserControl_Initialized);
            
            #line default
            #line hidden
            return;
            case 2:
            this.homeProduct = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            
            #line 97 "..\..\..\Products\ProductScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backWard_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.contentBack = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.addProductButton = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\..\Products\ProductScreen.xaml"
            this.addProductButton.Click += new System.Windows.RoutedEventHandler(this.AddProductItem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.filterPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.priceRangeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 162 "..\..\..\Products\ProductScreen.xaml"
            this.priceRangeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.priceRangeSlider_ValueChanged);
            
            #line default
            #line hidden
            
            #line 163 "..\..\..\Products\ProductScreen.xaml"
            this.priceRangeSlider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.Slider_DragCompleted));
            
            #line default
            #line hidden
            return;
            case 8:
            this.leftPriceBoundaryTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.rightPriceBoundaryTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.currentPriceBoundaryTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.filterToggle = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 205 "..\..\..\Products\ProductScreen.xaml"
            this.filterToggle.Click += new System.Windows.RoutedEventHandler(this.filterToggle_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.categoriesComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 219 "..\..\..\Products\ProductScreen.xaml"
            this.categoriesComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.categoriesComboBox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 220 "..\..\..\Products\ProductScreen.xaml"
            this.categoriesComboBox.DropDownOpened += new System.EventHandler(this.ComboProductTypes_DropDownOpened);
            
            #line default
            #line hidden
            
            #line 221 "..\..\..\Products\ProductScreen.xaml"
            this.categoriesComboBox.DropDownClosed += new System.EventHandler(this.ComboProductTypes_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 13:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 249 "..\..\..\Products\ProductScreen.xaml"
            this.searchTextBox.SelectionChanged += new System.Windows.RoutedEventHandler(this.searchTextBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.productsListView = ((System.Windows.Controls.ListView)(target));
            
            #line 274 "..\..\..\Products\ProductScreen.xaml"
            this.productsListView.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.productsListView_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 358 "..\..\..\Products\ProductScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PreviousPaging_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.comboBoxPaging = ((System.Windows.Controls.ComboBox)(target));
            
            #line 378 "..\..\..\Products\ProductScreen.xaml"
            this.comboBoxPaging.DropDownOpened += new System.EventHandler(this.ComboProductTypes_DropDownOpened);
            
            #line default
            #line hidden
            
            #line 379 "..\..\..\Products\ProductScreen.xaml"
            this.comboBoxPaging.DropDownClosed += new System.EventHandler(this.ComboProductTypes_DropDownClosed);
            
            #line default
            #line hidden
            
            #line 380 "..\..\..\Products\ProductScreen.xaml"
            this.comboBoxPaging.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboPageIndex_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 389 "..\..\..\Products\ProductScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextPaging_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.status = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            case 19:
            this.statusLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 20:
            this.progressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
