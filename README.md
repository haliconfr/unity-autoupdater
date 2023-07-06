# unity-autoupdater
automatic unity game updater/installer

installer/updater for video games
(made in unity but will work with any engine)

SETUP INSTRUCTIONS:

to make your game compatible, add a text file in your games "gamename_Data" folder called "ver.txt" and set it to the game's current version number (e.g 1.0.0)

and set these variables in the EventSystem object:
- downloadLink: raw pastebin link of a dropbox/google drive link of the newest version of your game
- currentVersionLink: raw pastebin link with the newest version number (e.g 1.0.0) of your game
- notesLink: raw pastebin link with your latest patch notes
- gameName: name of your game (can be inputted directly into Unity)

when you want to update your game, simply replace the downloadLink pastebin text with the new download link, change the currentVersionLink pastebin text to your new version number and update your notesLink patch notes.

the installer automatically sets the game's directory to the user's documents folder, but this can be easily changed.

FEATURES:

- Customisable randomly selected background images on each startup
- Automatic and seamless updating with minimal effort on the developer and client's side
- Dynamic percentage indicator showing progress of the update or download
- Easy for users to reject updates by changing their games ver.txt file
- Patch notes page for developers to explain their changes
- Customisable game logo
