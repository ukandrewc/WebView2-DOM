# WebView2-DOM
DOM implementation for Michael Russin's [Webview2 Winforms Control](https://github.com/michael-russin/webview2-control)

A test implementation for a WebView2 DOM, that can be accessed from .NET

It implements Window, Document, Element, Attribute, Style and Node.

You can perform most operations on the DOM, e.g:

`Document.GetElementById("elem_id").InsertAdjacentHTML("afterbegin", "<div>Content</div>")`

Added sync event, so that raised events can be cancelled, e.g.

`
''' <summary>
''' Raised synchronously from JS, so that EvalJS code can injected to cancel the event
''' </summary>
''' <param name="sender">WebView2</param>
''' <param name="Name">Name of the event e.g. mouseover, click, etc.</param>
''' <param name="EvalJS">Passed to eval() in JS, eval()==false to cancel event</param>
Private Sub WebView2_DOMBeforeEvent(sender As Object, Name As String, ByRef EvalJS As String) Handles WebView2.DOMBeforeEvent
  'Cancel if it's a click on a IMG
	If Name = "click" Then
		EvalJS = "e.target.tagName!='IMG'"
	End If
End Sub
`
