PoC.CaliburnSharedViews
=======================

I've run across an issue using Caliburn.Micro when sharing a `Screen` between multiple parent `Screen`s. In this example I have 2 tabs inside a shell. Each tab shares a single instance of `SharedViewModel` (essentially a singleton).

```c#
var shared = new SharedViewModel();

Items.AddRange(new []
{
    new TabViewModel { Shared = shared },
    new TabViewModel { Shared = shared },
});
```
And each tab's view has a `ContentControl` bound to the `Shared` property which is `SharedViewModel`:

```XML
<ContentControl cal:View.Model="{Binding Shared}"/>
```

Here's the order of events:

1. Start the app. See the shared view.
2. Switch to second tab. See the shared view.
3. Switch back to first tab. __Shared view is gone.__
4. Switch to second tab again. The shared view is there.
5. Proceed to pull hair out.
