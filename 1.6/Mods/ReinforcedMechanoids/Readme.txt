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
1. Sort mod order
2. Load save / start new game
3. Replace Goliath / Artilleron mechs with new ones, so they will get abilities removed
4. Check that the "Swap Weapon" ability button is no longer visible

NOTES:
------
- This patch only activates when Reinforced Mechanoids is loaded
- If you remove Reinforced Mechanoids, weapon swapping will work normally again
- The mechanoids will still be fully functional, just with one weapon type
- This is an XML-only fix and requires no C# modifications
