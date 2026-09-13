# MWANZA -> DAR ES SALAAM - BUSSID MAP MOD PROJECT

Imebeba tafsiri ya ramani ya Mwanza hadi Dar es Salaam kwenye muundo
wa Mradi wa BUSSID Mod Editor (Unity). FAILI YA .bussidmod HUSAFISHWA
NDINI YA BUSSID MOD EDITOR - haiwezi kutengenezwa nje ya hapo.

## Hatua za kujenga (Windows)

1. Pakua BUSSID Mod Editor rasmi (inapatikana kupitia tovuti ya
   Maleo / BUSSID - inahitaji akaunti ya msanidi programu).
2. Fungua Mradi huu ndani ya Unity (tumia toleo la Unity linalokubalika
   na Mod Editor, kwa kawaida Unity 2019 LTS).
3. Import BUSSID Mod Editor SDK kwenye mradi.
4. Chagua:  Tools -> MwanzaDar -> Build Route From Waypoints
   (huunda mzunguko wa barabara kati ya miji kutoka waypoints.json)
5. Badilisha LineRenderer kwa prefabs za barabara (main_trunk_2lane)
   ndani ya BUSSID Mod Editor kwa kutumia Road Builder yake.
6. Weka Spawn Points kutoka spawn_restore.json.
7. Jenga sehemu S01-S10 kwa mpangilio ule ule wa sections.json -
   mimea, majengo, alama za barabarani, na trafiki kwa sehemu.
8. Weka Restore Points katika kila mji/mji mdogo.
9. Optimize: tumia LODs, instancing, na mipaka ya mipaka ya simu duni.
10. Export -> .bussidmod kupitia Mod Editor, kisha jaribu kwenye simu.

## Faili zilizopo

- Assets/Map/Data/waypoints.json     - kuratibu za miji (mita, dunia 1:10)
- Assets/Map/Data/sections.json       - mipangilio ya sehemu S01-S10
- Assets/Map/Data/spawn_restore.json  - sehemu za kuanzia na kupona
- Assets/Map/Data/prefab_manifest.json- orodha ya prefabs zinazohitajika
- Assets/Map/Scripts/Editor/RouteBuilder.cs - msaidizi wa kujenga barabara

## Umbo la dunia

- Urefu mzima wa dunia: ~102 km (1:10 kutoka ukweli)
- Miji 12 kutoka Mwanza hadi Dar es Salaam