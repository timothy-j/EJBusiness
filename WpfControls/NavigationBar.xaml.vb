Public Class NavigationBar

    Public Shared NextRoutedCommand As New RoutedUICommand("Next", "Next", GetType(NavigationBar))
    Public Shared PreviousRoutedCommand As New RoutedUICommand("Previous", "Previous", GetType(NavigationBar))
    Public Shared LastRoutedCommand As New RoutedUICommand("Last", "Last", GetType(NavigationBar))
    Public Shared FirstRoutedCommand As New RoutedUICommand("First", "First", GetType(NavigationBar))
    Public Shared NewRoutedCommand As New RoutedUICommand("New", "New", GetType(NavigationBar))

End Class
