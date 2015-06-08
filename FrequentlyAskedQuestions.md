# Frequently Asked Questions #

Having problems with Pad Tie? This page provides a whole bunch of tips, tricks, and help with the most common issues experienced.

**Table of Contents**


## Why can't I use Pad Tie on my Mac or Linux box? ##

I do apologize that Pad Tie is Windows-only as I am a Linux user myself and it sucks being ignored. Luckily porting to Linux and OS X is high on the list of things to do, but it won't happen until Pad Tie for Windows is stable enough to let it float on it's own.

The code is well architected to deal with the other platforms. We will use Mono for both the Linux and the OS X versions. Pad Tie's user interface uses Windows Forms, which while not at all an ideal solution, is actually decently implemented in Mono. Undoubtedly more work will be required in this area. But the meat of the issue is porting the PadTie library (which handles all the real work like making gamepads trigger actions) to use the appropriate means for the platform. For input (reading your gamepads) both ports will likely use the same library (likely SDL or something similar). Synthesizing events is totally different on both platforms, though and will have to be developed separately.

As a full time university student I only get a chance to work on Pad Tie on the weekends and the evenings. I intend to develop and test the Linux port first. I don't have a Mac however, which will make development for the platform more difficult. Luckily Apple has some decent documentation for the needed frameworks and I think I wrangle a Mac for a weekend to get everything working properly.

So, yeah. Eventually.

As always, of course, I welcome any and all capable coders to dive in and improve or port the code.

## Is Pad Tie analogous to X360CE? ##

No. X360CE is an intermediate layer between Xinput (the system used by Xbox 360 compatible controllers) and DirectInput (the system used by most all controllers). Essentially it tricks games into thinking your controller is a bonafide Xbox 360 controller straight from Microsoft. This level of emulation is **much** nicer than what Pad Tie does, as the game will opt to present you with button names instead of keys, there will be almost no overhead lag, it requires no mapping, etc. If you are able to use X360CE, I entirely recommend it.

Some applications have trouble with X360CE however, and in these cases you may find Pad Tie quite helpful. Since it ships with a bunch of built-in profiles, you might find that we already have what you need to start playing. If not, we've built an easy and powerful way to create, view, and modify your own custom layouts.

## Is Pad Tie based on JoyToKey/Joy2Key? ##

No, Pad Tie is wholly original.

## Why don't I just keep using JoyToKey? ##

Because Pad Tie is 250% more awesome! Much more modern interface with visual
views of the controller, much more flexible configuration system allows you to share them and have them work for everyone. Pad Tie lets you map gestures like "tap", "double tap", and "hold" to your actions, not just "pressed". This makes Pad Tie much more capable as to what layout it can present.

## Is Pad Tie portable like JoyToKey? ##

Yes and no.
  * No because Pad Tie needs .NET 4 and SlimDX installed on any computer it is run on. A distribution which is portable amongst any Win7 install would likely be easy, but we need .NET 4 Client Profile, which is not included in earlier versions of Windows.
  * Yes because as of 0.1b2 Pad Tie can detect when it's safe/wise to write to it's own folder (since in Vista and later you cannot write to Program Files) and it will do so for your global configuration and for any custom layouts you create. Note that installing to Program Files on XP will not cause Pad Tie to write into Program Files.

This is the precedence Pad Tie assigns to global configurations:
  1. Try to open globalconfig.xml from the Pad Tie directory
  1. Try to open My Documents\Pad Tie\globalconfig.xml
  1. If wise, try to create in the Pad Tie directory and use that
  1. Create globalconfig in My Documents\Pad Tie.

## I used the ZIP/MSI and cannot launch Pad Tie! ##

If you installed via the Windows ZIP or MSI packages we offer, you should be aware that it does not install the third party components required for Pad Tie to work. The "Full Installer" option includes a full setup program which automatically installs dependencies.

## What does Pad Tie depend upon? ##
  * If you are using Windows XP, Vista, or Server 2003 (not Windows 7) you will also need to install the [.NET 4 Client Profile](http://www.microsoft.com/downloads/details.aspx?FamilyID=5765d7a8-7722-4888-a970-ac39b33fd8ab&displaylang=en).
  * All users will require the [SlimDX End User Runtime](http://slimdx.org/download.php).

## I received the error: Could not find assembly SlimDX.DirectInput ##

This happens because you have opted to use the MSI/ZIP installers and you have not installed the [SlimDX End User Runtime](http://slimdx.org/download.php). You can install it manually and then try to start Pad Tie again, alternatively the "Full Installer" option installs all dependencies for you so you don't need to worry about them. If you **did** install using the "Full Installer", it could be that an error occurred during the SlimDX installation, or it could be a bug in Pad Tie's installer. Please visit http://code.google.com/p/padtie/issues/list for detailed information about bugs and to file new issues.

## I received the error: Framework version not supported ##

This happens because you have opted to use the MSI/ZIP installers and the version of .NET installed on your computer is too old. You will need the [.NET 4 Client Profile](http://www.microsoft.com/downloads/details.aspx?FamilyID=5765d7a8-7722-4888-a970-ac39b33fd8ab&displaylang=en). You will need to install it; alternatively you can download the "Full Installer" from the downloads section which automatically installs the required dependencies.

## My pad views and the mapping wizard show the buttons light up, but in the wrong places! ##

Pad Tie 0.1b1 and earlier had not been tested and debugged in non-96-DPI environments. Some automatic scaling that Windows does for us caused the location of the button components against the picture to be scaled (while the picture stayed the same amount of pixels). At 125% (120 DPI) you might notice the button highlights being larger, and anything bigger you will definitely notice it, as well as buttons going off the edge of the pad view

Pad Tie 0.1b2 however has no such issue. The fix was rather easy, but it took some time to go through and make sure the changes actually fixed the issues. Pad Tie will look better than ever on your hi-res/hi-DPI displays.

## Pad Tie shows 2 pads but I only have one!! ##

Did you install gamepad virtualization software (or software which had it bundled) such as the Jumi Mouse desktop server which allows you to use your smartphone as a mouse, keyboard, and gamepad? Usually these services provide a special gamepad device which can be used like any other gamepad, but the difference is that it's always plugged in. This means it is almost always discovered by Pad Tie before your real gamepad(s), even if you already had the pad plugged in when you started the application.

The reason this is a problem is because Pad Tie identifies your controller using a "Pad Number". By default the first pad plugged in is Pad #1, then the second is Pad #2, etc. You can think of Pad Numbers like player numbers from consoles, where you, the distinguished console owner gets to be player 1, and the chips fall where they may. The profiles (aka layouts) which make your gamepad able to be a well-designed remote contain multiple "layouts" which map to Pad Numbers. So if Jumi Joystick gets to be Pad #1 all the time, you cannot use any "single player" layouts, because your controller is Pad #2 or anything **not #1**.

As of Pad Tie 0.1b2, you can now reassign your controllers arbitarily, which will allow you to force Jumi Joystick or any other special gamepad devices to be higher Pad Numbers so that they don't interfere with the real gamepads you plug in, or you can alternately force your specific, particular, exact gamepad to always be Pad #1. Or any other setup you please.

## My game/application/service doesn't support my gamepad, but still complains about it even though Pad Tie is running! ##

I know, I know. This didn't used to be a problem before the late-alphas. When Pad Tie switched from Managed DirectX to SlimDX, we also made Pad Tie switch to nonexclusive mode. When in this mode, your game/app will be able to use the joystick while Pad Tie is running.

Normally you would want to disable Pad Tie or put it in a blank state since the game can handle your gamepad directly, but still it should remain possible to use Pad Tie's more advanced gesture system to map to additional game actions. However, if your game/app/service is able to use gamepads, just not yours (perhaps because it is not an Xinput device), it will go ahead and complain about it not being compatible.

As of Pad Tie 0.1b2, you can specify whether to use an exclusive or non-exclusive lock for each of your gamepads. Realize that an exclusive lock means that no other application which requires exclusivity will be able to use your pad. Likewise realize that non-exclusive locks mean that **both** Pad Tie and whatever else will interpret input from your pad.

To change the lock settings (0.1b2 and up), go to the tab for your pad, then the Pad tab.

## Pad Tie isn't working for my game/app/service/thing! Oh, forgot to tell you I'm extremely low on available RAM! ##

When you run low on available RAM, the OS begins offloading data (in small chunks) onto your hard drive to free up space so things can continue to run. When it offloads chunks which are required for an application to run (and that application **needs** to run), it has to wait for the data to be copied back from the hard drive. This is normally not a problem for Pad Tie in the background because it has a timer which asks the OS to wake it up to check for input. However, in extremely low memory conditions where Pad Tie is swapped to the disk Windows may opt to ignore that timer, and thus no input will be received by Pad Tie, and no actions will be emitted.

You will notice in these circumstances that almost as soon as Pad Tie leaves the foreground you lose the functionality. But indeed restoring the window will make it work. One who is saavy might note that this is expected behavior if you choose the 'Foreground' mode for DirectInput's SetCooperativeLevel, but Pad Tie never specifies the Foreground mode (ever), and the reasons should be fairly obvious to those who would pose the question.

There's really nothing that can be done from our end. You could close applications or buy more RAM. Possibly you could attempt to elevate the process's priority, but I do not know that it would have any bearing on low-memory situations.