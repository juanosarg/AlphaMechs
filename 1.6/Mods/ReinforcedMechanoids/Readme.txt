ALPHA MECHS + REINFORCED MECHANOIDS COMPATIBILITY PATCH
========================================================

This compatibility patch automatically loads when both Alpha Mechs and 
Reinforced Mechanoids are active.

WHAT IT FIXES:
--------------
- Prevents the "Pawn got primaryInt equipment while already having primaryInt 
  equipment" error that occurs when trying to swap weapons on mechanoids
- Resolves conflicts between Alpha Mechs' weapon swap ability and Reinforced 
  Mechanoids' Gestalt Engine equipment handling

HOW IT WORKS:
-------------
When Reinforced Mechanoids is detected, this patch:
1. Disables the weapon swap ability on Goliath and Artilleron mechanoids
2. Sets them to use their primary weapon only (Charge Blaster for Goliath, 
   Mortar for Artilleron)

AFFECTED MECHANOIDS:
-------------------
- Goliath: Will only use Charge Blaster (no needle gun swap)
- Artilleron: Will only use Mortar (no mini needle gun swap)

TESTING:
--------
To verify the fix is working:
1. Load a save with both mods active
2. Draft a Goliath or Artilleron mechanoid
3. Check that the "Swap Weapon" ability button is no longer visible
4. Check your log file (press Ctrl+F12) - there should be no "primaryInt 
   equipment" errors when managing mechanoids

NOTES:
------
- This patch only activates when Reinforced Mechanoids is loaded
- If you remove Reinforced Mechanoids, weapon swapping will work normally again
- The mechanoids will still be fully functional, just with one weapon type
- This is an XML-only fix and requires no C# modifications

If you encounter any issues, please report them to the Alpha Mechs mod page.
