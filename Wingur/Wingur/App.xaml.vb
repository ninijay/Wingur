' Die Vorlage "Leere App" ist unter http://go.microsoft.com/fwlink/?LinkID=391641 dokumentiert.

''' <summary>
''' Stellt das anwendungsspezifische Verhalten bereit, um die Standardanwendungsklasse zu ergänzen.
''' </summary>
NotInheritable Class App
    Inherits Application

    Private _transitions As TransitionCollection

    ''' <summary>
    ''' Initialisiert das Singletonanwendungsobjekt. Dies ist die erste ausgeführte Zeile von erstelltem Code
    ''' und daher das logische Äquivalent von main() bzw. WinMain().
    ''' </summary>
    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn die Anwendung durch den Endbenutzer normal gestartet wird. Weitere Einstiegspunkte
    ''' werden verwendet, wenn die Anwendung zum Öffnen einer bestimmten Datei, zum Anzeigen
    ''' von Suchergebnissen usw. gestartet wird.
    ''' </summary>
    ''' <param name="e">Details über Startanforderung und -prozess.</param>
    Protected Overrides Sub OnLaunched(e As LaunchActivatedEventArgs)
#If DEBUG Then
        If System.Diagnostics.Debugger.IsAttached Then
            DebugSettings.EnableFrameRateCounter = True
        End If
#End If

        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

        ' App-Initialisierung nicht wiederholen, wenn das Fenster bereits Inhalte enthält.
        ' Nur sicherstellen, dass das Fenster aktiv ist.
        If rootFrame Is Nothing Then
            ' Frame erstellen, der als Navigationskontext fungiert und zum Parameter der ersten Seite navigieren
            rootFrame = New Frame()

            ' TODO: diesen Wert auf eine Cachegröße ändern, die für Ihre Anwendung geeignet ist
            rootFrame.CacheSize = 1

            ' Standardsprache festlegen
            rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages(0)

            If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                ' TODO: Zustand von zuvor angehaltener Anwendung laden
            End If

            ' Den Frame im aktuellen Fenster platzieren
            Window.Current.Content = rootFrame
        End If

        If rootFrame.Content Is Nothing Then
            ' Entfernt die Drehkreuznavigation für den Start.
            If rootFrame.ContentTransitions IsNot Nothing Then
                _transitions = New TransitionCollection()
                For Each transition As Transition In rootFrame.ContentTransitions
                    _transitions.Add(transition)
                Next
            End If

            rootFrame.ContentTransitions = Nothing
            AddHandler rootFrame.Navigated, AddressOf RootFrame_FirstNavigated

            ' Wenn der Navigationsstapel nicht wiederhergestellt wird, zur ersten Seite navigieren
            ' und die neue Seite konfigurieren, indem die erforderlichen Informationen als Navigationsparameter
            ' übergeben werden
            If Not rootFrame.Navigate(GetType(MainPage), e.Arguments) Then
                Throw New Exception("Failed to create initial page")
            End If
        End If

        ' Sicherstellen, dass das aktuelle Fenster aktiv ist
        Window.Current.Activate()
    End Sub

    ''' <summary>
    ''' Stellt die Inhaltsübergänge nach dem Start der App wieder her.
    ''' </summary>
    Private Sub RootFrame_FirstNavigated(sender As Object, e As NavigationEventArgs)
        Dim newTransitions As TransitionCollection
        If _transitions Is Nothing Then
            newTransitions = New TransitionCollection()
            newTransitions.Add(New NavigationThemeTransition())
        Else
            newTransitions = _transitions
        End If

        Dim rootFrame As Frame = DirectCast(sender, Frame)
        rootFrame.ContentTransitions = newTransitions
        RemoveHandler rootFrame.Navigated, AddressOf RootFrame_FirstNavigated
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn die Ausführung der Anwendung angehalten wird. Der Anwendungszustand wird gespeichert
    ''' ohne zu wissen, ob die Anwendung beendet oder fortgesetzt wird und die Speicherinhalte dabei
    ''' unbeschädigt bleiben.
    ''' </summary>
    Private Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()

        ' TODO: Anwendungszustand speichern und alle Hintergrundaktivitäten beenden
        deferral.Complete()
    End Sub

End Class
