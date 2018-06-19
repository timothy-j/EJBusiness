Imports System.Data.Entity
Imports System.Globalization
Imports System.Windows.Controls

Class MainWindow
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Internationalization fix - from the WPF Binding Cheat Sheet (http//www.nbdtech.com/Free/WpfBinding.pdf)
        ' This defines default currency symbol (etc.)
        FrameworkElement.LanguageProperty.OverrideMetadata(
            GetType(FrameworkElement), New FrameworkPropertyMetadata(
            Markup.XmlLanguage.GetLanguage(Globalization.CultureInfo.CurrentCulture.IetfLanguageTag)))

    End Sub
End Class
