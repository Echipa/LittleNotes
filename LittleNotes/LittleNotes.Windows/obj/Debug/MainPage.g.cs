﻿

#pragma checksum "C:\Users\Andrei\Desktop\LittleNotes-master\LittleNotes\LittleNotes.Windows\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FD53A227855DA0AA7C49653EE82EE225"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LittleNotes
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SaveClose_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 14 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.AppBarButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 15 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Save_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 16 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Close_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 23 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.NotesGrid_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 24 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.NewNoteBtn_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


