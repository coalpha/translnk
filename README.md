# translnkte

*Pronounced "translinktea"*

To start programming, I like to drag the repositories that I have on my desktop
to a vscode shortcut.

![](misc/drag.png)

When doing that, it executes something like this:

```
"C:/Program Files/vscode/Code.exe" C:/Users/Me/Desktop/coalpha
```

So this is fine for folders but it doesn't work really well for shortcut files
because vscode will open the shortcut file instead of it's destination. This is
correct behavior and I wouldn't want it to do anything else, but it's also not
my intention.

So what if we made a stub shortcut that targets something like this which was
able to resolve the `.lnk` targets before passing them onto the actual
application we want to run?

```
translnkte.exe C:/Program Files/vscode/Code.exe C:/Users/Me/Desktop/repo.lnk
```

Well, that's what this is. You still have to make the shortcuts yourself but at
least I provide the `translnkte.exe`. The code for this is awful and I don't
really care. All I need it to do is work.
