Testing background fetches
--------------------------

This can be tricky, since (at least for now), you can't request background fetches, you have to wait until iOS decides to do it.

This results in the following flow:

* Run app on device. A yellow screen should show up.
* Hit the home button (once) to close the app.
* Wait until the device goes to sleep (might be a good idea to set the AutoLock timer to 2 minutes in the device options).
* Awake the device.
* Look for the line 'BackgroundFetchApp[948] <Warning>: 18/03/2014 16:13:00 PerformFetch' (the date shown will be the current date and time) in the iOS Device Log.
* Wait 60 seconds (it's important to wait at least this amount of time before continuing to the next step, because iOS has a timeout that will kill the app in certain failure scenarios, and continuing too fast will not test those scenarios).
* Tap the app. A green screen should show up.
* Remember to return the Auto-Lock duration to its previous setting if it was modified.