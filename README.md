# WebView2-DOM
DOM implementation for Michael Russin's [Webview2 Winforms Control](https://github.com/michael-russin/webview2-control)

A test implementation for a WebView2 DOM, that can be accessed from .NET

It implements Window, Document, Element, Attribute, Style and Node.

You can perform most operations on the DOM, e.g:

`Document.GetElementById("elem_id").InsertAdjacentHTML("afterbegin", "<div>Content</>")`

Events are raised from the underlying DOM asynchronously, so cannot be cancelled or modified from .NET.

Events can be cancelled by adding JS code to be evaluated after the events are raised.
