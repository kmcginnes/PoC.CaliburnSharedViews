PoC.CaliburnSharedViews
=======================

Demonstrates issue sharing views between multiple Caliburn screens

When the app is run, you will see two tabs each containing a shared view/view model. The view models are constructed like this:

```c#
var shared = new SharedViewModel();

Items.AddRange(new []
{
    new TabViewModel
    {
        DisplayName = "Tab 1",
        Shared = shared,
    }, 
    new TabViewModel
    {
        DisplayName = "Tab 2",
        Shared = shared,
    },
});
```
And each tab's view binds to the `Shared` property:

```XML
<ContentControl cal:View.Model="{Binding Shared}"/>
```

Here's the order of events:

1. Start the app. See the shared view.
2. Switch to second tab. See the shared view.
3. Switch back to first tab. __Shared view is gone.__
4. Switch to second tab again. The shared view is there.
