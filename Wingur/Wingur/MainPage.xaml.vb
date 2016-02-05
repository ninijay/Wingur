' Die Vorlage "Leere App" ist unter http://go.microsoft.com/fwlink/?LinkID=391641 dokumentiert.

''' <summary>
''' Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    ''' <summary>
    ''' Wird aufgerufen, wenn diese Seite in einem Rahmen angezeigt werden soll.
    ''' </summary>
    ''' <param name="e">Ereignisdaten, die beschreiben, wie diese Seite erreicht wurde.
    ''' Dieser Parameter wird normalerweise zum Konfigurieren der Seite verwendet.</param>
    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        ' TODO: Seite vorbereiten, um sie hier anzuzeigen.

        ' TODO: Wenn Ihre Anwendung mehrere Seiten enthält, stellen Sie sicher, dass
        ' die Hardware-Zurück-Taste behandelt wird, indem Sie das
        ' Windows.Phone.UI.Input.HardwareButtons.BackPressed-Ereignis registrieren.
        ' Wenn Sie den NavigationHelper verwenden, der bei einigen Vorlagen zur Verfügung steht,
        ' wird dieses Ereignis für Sie behandelt.
    End Sub

End Class
