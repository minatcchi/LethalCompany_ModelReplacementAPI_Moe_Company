# LethalCompany_ModelReplacementAPI

Allows the user to create model replacement mods in Lethal Company

Features
-
- Basic API commands to assign and remove model replacements
- A skin registry that will model replace all players with a specific skin name. Probably works well with the More Suits mod. 
- Seemingly client side




Requirements of the user
-
- An assetbundle containing a rigged character model with SkinnedMeshRenderer
- A user defined boneMap.json to map bone names from the player model to replacement model, among other things. 

How it works
-
The heart of all things in this mod is boneMap.json, which contains a list of every bone name in the base game player model followed by the corresponding bone name in the replacement model. When a body replacement is instantiated the bone map is used to build a list of pairs of `Transform` between the player model and the replacement model

Players with an active model replacement are given a `BodyReplacement` component derived from `BodyReplacementBase`, which on each call of `Update()` sets the replacement model `Transform`'s rotation to its corresponding player model `Transform`'s rotation. 

The upside of setting rotation and not position is that the replacement model won't become an abomination, but as a result this mod will only work with roughly humanoid replacement models, and especially ones with similar armatures. 

Example workflow
-
See the attached Hatsune Miku model replacement for a more concrete example. It is assumed that the user already has an assetBundle with one or more rigged models.

* Using a modeling program like Blender, for each model go through each bone in your model and enter its name after the corresponding bone in that model's boneMap.json. 

* For each model replacement create some `ExampleBodyReplacement` class deriving from `BodyReplacementBase`

* In those classes define the abstract property `boneMapFileName` which is name of your bone map without path, and define the abstract methods `LoadAssetsAndReturnModel()` and `AddModelScripts()`. If your model has more than one armature with duplicate bone names, override `GetMappedBones(GameObject modelReplacement)` to only include bones in the armature that drives your player model. Note that even if you only have a single armature, this mod does not support armatures that have duplicate bone names.

* Besides those methods and property, everything else is model agnostic and handled in `BodyReplacementBase`. Depending on how your mod functions you can now call the methods `ModelReplacementAPI.SetPlayerModelReplacement(PlayerControllerB player, Type type)` or `ModelReplacementAPI.RemovePlayerModelReplacement(PlayerControllerB player)` as necessary. Note that the type property is `typeof(ExampleBodyReplacement)`.

* If you wish for a certain suit to have a model replacement (such as "Default") call `ModelReplacementAPI.RegisterSuitModelReplacement("{Suitname}", typeof(ExampleBodyReplacement))`

* At this point you should be able to enter the game and see your model replacement at work, but many of the bones likely have incorrect rotations. You can use [ModelReplacementTool](ModelReplacementTool/Build) to manually set rotation offsets for each bone.

* See the Miku example project for a demonstration on how your registered model replacement can make use of bepinex configs. 

Other features
-
* More Company cosmetic support
* The ability to set a bone and offset for held items in the replacement model
* The ability to set a model position offset so your model isn't floating three feet off the ground

Known issues
-
* Ragdoll behaves strangely at times

* Blood decals are not currently visible on the ragdoll replacement.

* Dying at the company may make the dead individual respawn without a model, but it may also return at a later point in time. 


Unknown issues
-
* Probably many, as this has only been lightly player tested

Note
-
Compiling this project requires a publicized Assembly-CSharp

