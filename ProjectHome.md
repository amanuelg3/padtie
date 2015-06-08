Hello and welcome to early testers!

Pad Tie is an open source "game pad to keyboard/mouse" application which has advanced gesture features, allowing specific actions like tap, double tap, and hold to be mapped to different actions in addition to the standard "link" behavior (where a button press = a key press, etc).

**News**

**August 25th**
After a short hiatus, I'm excited to announce the immediate release of Pad Tie 0.1b1-2! This is the first release since I transitioned from my old XP laptop to my new Windows 7 laptop for university, and I've been quite busy, but I hope that this release upholds and improves the quality of the previous release (0.1a5). The user interface has been improved, more actions have been added, and much more! Download today to check it out!

**August 15th**
Pad Tie 0.1a5 is released, which now uses SlimDX instead of Microsoft's Managed DirectX. The big installer for 0.1a5 now contains the SlimDX redistributable. A big reason we switched to SlimDX is for functional 64-bit support. You should be able to install Pad Tie 0.1a5 and later on both 32-bit and 64-bit Windows without problems (not the case with earlier builds).

**More about Pad Tie**
Pad Tie features a simple, but powerful configuration interface which allows the user to maintain multiple distinct configurations for different applications or games. We intend to provide a library of pre-made configurations for various purposes.

To do this in a game-pad-neutral fashion is difficult, this is a big reason why it's not easy to find pre-made configurations for other Windows solutions such as Joy2Key. To handle this we have decided to introduce a second layer to our device handling system which maps raw device buttons and axes to a standardized virtual controller layout based on Microsoft's Xbox 360 layout. We intend to provide a database of mappings for the most popular controllers, which we will do by placement on the controller as opposed to actual button names or numbers. Users can create their own mappings and submit them for inclusion as well. This will allow all pre-made configurations to retain a standard feel on all game-pad controllers. The exception to the rule is the digital pad and the left analog stick, which we will map to the actual components since the locations of these two are often swapped in non-360 peripherals, and the functionality of them is often tied to their ease of use for various situations.

Naturally, joysticks and other controller types will take more effort to correctly map to the 360 layout, so we are limiting our solution to game-pads for now.

Currently the software works only on Windows operating systems with .NET Framework 4, but we fully intend to bring the functionality to Linux and OS X, once we find the best APIs and techniques to use for those operating systems. Linux particularly is extremely lacking in a simple, useful solution for mapping joystick buttons to generic actions, so we are excited to head in this direction once the Windows code is stable.