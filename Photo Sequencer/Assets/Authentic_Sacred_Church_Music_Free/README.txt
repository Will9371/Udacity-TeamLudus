Authentic Sacred Church Music (FREE): SETUP GUIDE

Dear Unity Developer,
Thank you for downloading this package and supporting my work!

Here are some indications as to how to use this pack.

********************************************************************************************************************************************************************************************************
GENERAL REMARKS:

- DO NOT, under any circumstance, change the folder structure of the "Resources" folder.  The resources folder HAS to be located in your asset folder and the folder structure HAS to remain untouched.
  The reason is that many scrips rely on this folder structure to load the samples into arrays. Many scripts could stop working if you change the folder structure.

- Be sure to add an audio listener to your camera or the game object you attach the script on.  Apparently, this helps with the overall performance of the script.

*********************************************************************************************************************************************************************************************************

How to use the church_music_master_script:
-------------------------------------------------

1) Church Music Master Script Prefab

The Church Music Master Script Prefab can be found in the "Prefabs" folder inside the "Authentic Sacred Church Music".
Simply drag and drop it into your scene to set it up and manipulate the four colored squares, resize them and rotate them to set up the trigger zones.
You can duplicate them as necessary in your scene, test the triggers, and once you're satisfied with their location, disable their "Mesh Renderer" to make them invisible.

The color codes work as follows:
- very light yellow: baroque organ minor
- light yellow: baroque organ major
- yellow: medieval organ minor
- darker yellow: medieval organ major
- very light green: dynamic organ - SOFT
- light green: dynamic organ - MEDIUM
- flashy green: dynamic organ - FORTE
- dark green: dynamic organ - FORTISSIMO
- light blue: gregorian chant
- blue: baroque choir
- purple: gregorian ensemble
- pink: baroque cello major

- The red square stops all the music and resets the script.

WORD OF ADVICE: the soundtracks will play indefinitely once triggered so in order not to "bore" the player, make sure you either "reset" (stop) the script using the red square/trigger from time to time or position triggers for other soundtracks above.

You will see that you can also enter a value for the "Fade_out speed" and "Fade_in speed". This is used to fade out between the first and second intensity levels of the Dynamic Organ music.
If you want the fade_out/fade_in to be faster, simple increase the value. If you want the fade_out/fade_in to be even slower, decrease the value.

The "fade_to_distance" public boolean (if enabled) allows you to set the music's intensity as a function of the Player's distance to a 
gameObject.  Simply drag the "Player" gameobject into the "Player" cell in the script (Prefab) and the reference GameObjects in the "
"reference Object" cell.  If this gameobject is destroyed or no longer needed, you will have to reassign other gameobjects or 
triggers to that cell via script.

WORD OF CAUTION: the "fade to distance" method does not apply to the dynamic organ since it's intensity is managed by the green triggers.

-------------------------------------------------------------------------------------------------------------------------
IMPORTANT THINGS TO REMEMBER:

- Make sure only ONE boolean is set to "true" at all times, otherwise you'll hear a mishmash of two or more tracks!
- Whenever you set a boolean to "false", the script waits until the musical phrase is over and then plays an "end" loop. This can take some time so be patient! :-)

-------------------------------------------------------------------------------------------------------------------------

In the FREE version, you only have 4 samples/loops per track.  The PRO version has 16!
Check it out here: https://www.assetstore.unity3d.com/#!/content/43133

I hope you'll be able to make use of this!
Don't forget to leave a review and suggestions/ideas for how to make this work even better!

Thanks again for your support and don't hesitate to contact me if you have any questions/suggestions! 

sincerely,

Marma

CONTACT: marma.developer@gmail.com
WEBSITE: http://marmadeveloper.wix.com/marmamusic