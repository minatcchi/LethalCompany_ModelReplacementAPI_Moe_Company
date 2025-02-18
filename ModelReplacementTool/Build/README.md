# ModelReplacementTool v0.9.3
### A tool to simplify setting bone offsets for replacement Models
ModelReplacementAPI requires a boneMap.json file that contains a map between player model bones and replacement model bones, with an optional rotation offset. 
Because rotations are represented as quaternions, it is difficult or impossible for the user to guess what their offset should be without extended testing. 
This tool seeks to simplify that process by allowing the user to set those offsets via an in-game UI and freecam. 

For more info on the ModelReplacementAPI, see https://github.com/BunyaPineTree/LethalCompany_ModelReplacementAPI
## Instructions
- Place this mod in your plugins folder with ModelReplacementAPI
- First you need a functional ModelReplacement with associated BoneMap loaded in game. Currently there is no option to select ModelReplacements, so you have to register your model replacement to the default skin. 
- This is an in-game tool, so after starting the game you will need to host a (preferably private) lobby. 
- The tool features a freecam that can be translated with w,a,s,d,space,ctrl, and rotated by holding right mouse. Your player model will be held in place so you can examine bones as you rotate them, but input will still go to your character. 
- You can set replacement bone name and position offsets for held items, and a position offset for your model, however you cannot currently change the root bone, that must be set correctly in your boneMap.json
- You can set replacement bone name and rotation offsets for every bone in the base game model, but everything is optional
- you can save your offsets and bone names to your mod's boneMap.json with the save button

## Notes
- This tool considerably lacks polish, and it will probably stay that way unless a reason shows up that necessitates it to be fixed.
- For some reason unity demands that sliders are moved with "a" and "d" keyboard characters even after you click off the slider. This is partially fixed after your release your mouse, but it sometimes fails.
- I highly recommend that you save your model after each bone is set to the correct rotation, it will also remove focus from the sliders, which prevents your rotation from being ruined when you press "a" and "d".
- I highly recommend that you set all of your model bone names in your boneMap.json before using this tool. Though it supports changing bone names with a dropdown menu, it currently does not reset the rotation of the bone that you changed off of, which can result in unexpected behavior. 
- This tool supports symmetric bone names, and will rotate the symmetric bone mirrored to your original bone. This requires your bone to contain a .L, _L, .R, _R in capitalized or undercase.

## Known Bugs
- An unexpected bug of the symmetric bone support is that only the left side bone works, I have no clue why. If you are trying to slide a slider but it won't move, look for the bone on the other side.  
- If you have asymmetric bones on the left and right side of your body, setting a symmetry option will ruin your progress, do asymmetric bones last, and save frequently. 
- numerous others. 

## Changelog
	- v0.9.3
		- Patch for changing field names in ModelReplacementAPI
	- v0.9.2
		- Added symmetry options, note that not all models benefit from this.
		- Added the ability to remove the helmet/arms (Which are not a part of the character model's renderers)
		- Adjusted the slider widths to make more sense. 
	- v0.9.0
		- Just barely functional release