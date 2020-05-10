# WebView2-DOM
DOM implementation for Michael Russin's [Webview2 Winforms Control](https://github.com/michael-russin/webview2-control)

A test implementation for a WebView2 DOM, that can be accessed from .Net

It implements Window, Document, Element, Attribute, Style and Node.
Also implements QuerySelecter/QuerySelectorAll and Evaluate/EvaluateAll (XPath)

You can perform most operations on the DOM, e.g:

`Document.GetElementById("elem_id").InsertAdjacentHTML("afterbegin", "<div>Content</div>")`

Changed Event handling to be able to cancel click and dblclick events from .Net

Added handlers for Click, Mouse, Keyboard, Input, ContextMenu and Custom events.

In JS, the click and dblclick events are cancelled by preventDefault and stopPropogation. After being raised in .Net, they are only dispatched if ReturnValue = True (default).



```
Private Sub WebView2_DOMClickEvent(sender As Object, e As WVEvent) Handles WebView2.DOMClickEvent
	'Click events can be cancelled using ReturnValue
	e.ReturnValue = e.Target.TextContent <> "About"
End Sub

```
