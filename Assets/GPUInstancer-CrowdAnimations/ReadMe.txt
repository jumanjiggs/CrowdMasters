GPU Instancer - Crowd Animations v1.0.2
Copyright ©2019 GurBu Technologies
---------------------------------
Thank you for supporting GPU Instancer!

---------------------------------
DOCUMENTATION
---------------------------------
Please read our online documentation for more in-depth explanations and customization options at:
https://wiki.gurbu.com/

---------------------------------
SETUP
---------------------------------
Please make sure that you have imported the latest version of GPU Instancer asset to your project first.
If you import GPU Instancer after you imported Crowd Animations, please reimport the GPUInstancer-CrowdAnimations folder.

1. Add Crowd Manager to your scene
Tools -> GPU Instancer -> Add Crowd Manager

2. In the Inspector window, press the "?" button at the top-right corner to get detailed information about setting up the manager.
Or press the "Wiki" button to read more about the Crowd Manager.

---------------------------------
SUPPORT
---------------------------------
If you have any questions, requests or bug reports, please email us at: support@gurbu.com
Unity Forum Thread: https://forum.unity.com/threads/gpu-instancer-crowd-animations.669724/

---------------------------------
MINIMUM REQUIREMENTS
---------------------------------
- DirectX 11 or DirectX 12 and Shader Model 5.0 GPU (Windows, Windows Store)
- Metal (macOS)
- OpenGL Core 4.3 (Windows, Linux)
- Modern Consoles (PS4, Xbox One)

---------------------------------
DEMO SCENES
---------------------------------
You can find demo scenes that showcase GPU Instancer - Crowd Animations capabilities in the "GPUInstancer-CrowdAnimations/Demos" folder. 
These scenes are only for demonstration and you can safely remove this folder from your builds.

---------------------------------
CHANGE LOG
---------------------------------

v1.0.2

New: Added Cancel button to animation baking progress bar

Changed: Synchronous and asynchronous bone updates now checks for instace counts to not to make unnecessary transform modification

Fixed: Animation event null reference exception on builds when clip reference is lost
Fixed: When increasing buffer size, asynchronous bone updates throws error
Fixed: Optional renderers does not update indexes and matrices when adding/removing instances

v1.0.1

IMPORTANT: Requires GPU Instancer v1.5.2 or later

New: Added Setup function for Amplify Shader Editor
New: Added a unity package to Extras with version of Standard shader that support texture variations

Changed: Added warning when no bone is selected while Bone Updates is enabled

Fixed: Unnecessary reference to prototype prefabObject while re-initializing
Fixed: Changes to "Is Looping" option is not being serialized
Fixed: Synchronous bone updates not taking "Is Looping" option into consideration

v1.0.0

New: Added latency limit to Async Bone Updates
New: Added Synchronous Bone Update system
New: Added Package Importer system which automatically imports required GPUI packages depending on the UPM packages and script defines

Changed: Crowd Animator transition performance improvements
Changed: Crowd Animator Root Motion now runs in Jobs
Changed: Reduced Crowd Animator buffers' SetData calls to improve performance
Changed: Async Bone Updates reads much less data from GPU and works faster
Changed: Reduced overall null checks and cached various variables for better performance
Changed: Renamed NUM_THREADS to GPUI_THREADS because it was causing compile errors on PSSL
Changed: Crowd Manager will now inform user when prototypes needs to be re-baked with the new version
Changed: Reimplemented Optional Renderers feature to use single animation data and only separate instance data

Fixed: GPUICrowdManagerEditor incorrect animationBaker null check
Fixed: Crowd Animator transition not being finished
Fixed: When re-backing prototypes bones, optional renderers and root motion selections resets to default
Fixed: Optinal renderers not working correctly with transitions
Fixed: Bounds size offset is not applied for Crowd prototypes
Fixed: Test Animations feature with prefabs that have LOD groups creates skinnedmeshes of all the LOD renderers on top of each other
Fixed: Bone calculations in compute shader does not calculate fractions for current frame

v0.9.7

New: Added demo override packages that support HDRP 10 and URP 10

Changed: HDRP 10 and URP 10 Crowd Animations shaders are remade with ShaderGraph 10

v0.9.6

New: Added Crowd Animations Setup Nodes for Shader Graph
New: Added bone filter to async bone updates for better performance
New: Added ChangeMaterial API method
New: Added GetDeltaPosition API method

Fixed: Root motion matrix calculation causing scaling

v0.9.5

New: Added Async Bone Updates feature for Crowd Animator workflow 
New: Added Assembly Definition files
New: Added Depth Normals shader to be able to use post processing effects like Ambient Occlusion in Forward Rendering mode

Fixed: Transitions not reaching to the end weights in some cases

v0.9.4

New: Added HDRP and URP versions of Demo scenes
New: Added support for HDRP 7 Lit shader
New: Added animations test shader for HDRP 7
New: Added "Optional Renderers" feature to be able to disable/enable child Skinned Mesh Renderers per instance at runtime
New: Added demo scene showing use of enabling/disabling skinned mesh renderers during runtime
New: Added option to bake animation clip lists for prefabs without an Animator component
New: Added Animation Data ScriptableObject to store the baked animation data which allows to use the same baked data for multiple prototypes
New: Added Bake All/Missing buttons
New: Added option to delete baked data while deleting a prototype
New: Added multi-select feature to Frame Rate slider

Changed: Updated support for URP 7 Lit shader and Animations Test shader (re-export package needed)

v0.9.3

New: Added support for URP 7 Lit shader
New: Added animations test shader for URP 7

Changed: Crowd Manager now uses the GPUI shaders if original material uses URP Lit.

v0.9.2

New: Added support for HDRP 6 Lit shader 
New: Added animations test shader for HDRP 6
New: Added support for LWRP 6 Lit shader 
New: Added animations test shader for LWRP 6

Changed: Crowd Manager now uses the GPUI shaders if original material uses LWRP Lit or HDRP Lit.

Fixed: Auto. Add/Remove functionality errors when there is insufficient buffer size

v0.9.1

New: Option to disable loop for animation clips while using Crowd Animator workflow
New: Custom editor to define animation events from the Crowd Manager
New: Added optional float, int and string parameters to animation event system

Fixed: Insufficient animation data buffer size when adding new instances at runtime
Fixed: Mesh vertex color data being lost
Fixed: Animation events for the first frame not repeating when in loop

v0.9.0

New: Added Animation Event system for Crowd Animator workflow
New: Added a demo scene showcasing animation events
New: Added two new scenes that show the usage of material variation for crowd instances

Fixed: Animations getting stuck after setting speed to 0 once
Fixed: Active clip count calculation error on animation blending
Fixed: Wrong animation time calculation while exiting animation blending with transition
Fixed: CPU - GPU frame index synchronization issues when an animation runs for a long time
Fixed: Adding/removing causing other instances to switch to incorrect animation clip/frame

v0.8.5

Fixed: Animator error with multiple prototypes
Fixed: Default Clip option not showing all the clips when there are multiple clips with the same name

v0.8.4

Changed: Baked texture includes 1 more additional frame to include both first and last frames (requires re-bake)

Fixed: Animation - root motion syncronization problem
Fixed: Speed change causing syncornization problem when blending animations

v0.8.3

Changed: C# and HLSL code refactoring for better multi-platform support

Fixed: Incorrect mesh information on macOS
Fixed: Incorrect skinning when instance is removed with Auto Add/Remove feature
Fixed: Test animations are not visible

v0.8.2

New: Added Get/Set AnimationTime API methods
New: Added transition functionality for the Crowd Animator API methods
New: Added time parameter for animation blending

Fixed: Error when the child skinned mesh renderer is disabled on the original prefab
Fixed: Compatibility issues for PSSL
Fixed: Compatibility issues for Metal
Fixed: Shadows not rendering with Standard shaders when LOD Cross Fade enabled
Fixed: Flickering between animation frames
Fixed: Root motion not calculating animation speed
Fixed: Root motion not calculating instance scale

v0.8.1

Changed: Added comments to demo scene scripts

Fixed: Multiple skinned mesh renderers with different bind pose values for the same bones causing incorrect skinning
Fixed: Test Animations button causing errors when there are scripts with dependencies on the prefab

v0.8.0

First release