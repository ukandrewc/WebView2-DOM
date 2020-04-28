Imports Edge_Chrome
Imports MtrDev.WebView2.Wrapper

Friend Class Form1
	Friend NewWindow As WebView2Deferral
	Friend WindowArgs As NewWindowRequestedEventArgs

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
		If WindowArgs Is Nothing Then
			WebView2.Navigate("https:/google.co.uk")
		End If
	End Sub

	Private Sub WebView2_NewWindowRequested(sender As Object, e As NewWindowRequestedEventArgs) Handles WebView2.NewWindowRequested
		Dim Frm As New Form1
		Frm.NewWindow = e.GetDeferral()
		Frm.WindowArgs = e
		Frm.Show()
	End Sub

	Private Sub WebView2_BrowserCreated(sender As Object, e As EventArgs) Handles WebView2.BrowserCreated
		If NewWindow IsNot Nothing Then
			WindowArgs.NewWindow = WebView2.InnerWebView2WebView
			NewWindow.Complete()
			WindowArgs = Nothing
			NewWindow = Nothing
		End If
	End Sub

	Private Sub WebView2_NavigationCompleted(sender As Object, e As NavigationCompletedEventArgs) Handles WebView2.NavigationCompleted
		TxtAddress.Text = WebView2.Url
	End Sub

	Private Sub WebView2_DocumentTitleChanged(sender As Object, e As DocumentTitleChangedEventArgs) Handles WebView2.DocumentTitleChanged
		Text = e.Title
	End Sub

	Private Sub WebView2_DOMMouseEvent(sender As Object, e As WVEvent) Handles WebView2.DOMMouseEvent
		LblMessage.Text = $"{e.Target?.TagName}: {e.Type}"
	End Sub

	Private Sub WebView2_DOMContextMenu(sender As Object, e As WVEvent) Handles WebView2.DOMContextMenu
		MessageBox.Show($"Context Menu Location: {e.PageX} {e.PageY}")
	End Sub
End Class
