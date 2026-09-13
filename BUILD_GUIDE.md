# MWONGOZO WA KUJENGA - HATUA KWA HATUA

## Hatua ya 0: Mazingira
1. Sakinisha Unity 2019.4 LTS kwenye Windows.
2. Pakua BUSSID Mod Editor rasmi (Maleo) na uifungue kama mradi mpya.
3. Nakili folda `Assets/Map` ya mradi huu ndani ya mradi wako wa Mod Editor.

## Hatua ya 1: Weka Prefabs (mara moja tu)
Fungua `Assets/Map/Scripts/Editor/MapBuilder.cs` sehemu ya
`PrefabLibrary` uka-drag prefabs zako za BUSSID kwenye nafasi zake.
Hakuna prefab? Builder ataweka vipengee vya kubuni (cubes) kama alama —
uzibadilishe baadaye.

## Hatua ya 2: Jenga kwa mbofyo moja kwa moja (menyu: Tools -> MwanzaDar)
1. **1. Build Full Route** — barabara nzima Mwanza-Dar, shoulders,
   mabwawa ya maji (drainage), na alama za mapinduko makali.
2. **2. Scatter Scenery** — mimea ~miaka 2,500+ inayotawanyika kando ya
   barabara kwa kila sehemu (acacia nyingi kusini, palm kuelekea Dar).
3. **3. Place Town Buildings & Signs** — majengo 414+ katika miji 12:
   vituo vya mabasi, vituo vya mafuta, masoko, shule, vituo vya polisi.
4. **4. Create Spawn & Restore Points** — spawn 6 na restore kwa kila mji.

## Hatua ya 3: Unda Terrain
- Tumia Terrain Tools ya BUSSID kuunda milima na vilima kati ya S07-S08
  (Dodoma-Morogoro) na tambarare kati ya Singida-Manyoni.
- Mto wa Morogoro: weka daraja moja (bridge_medium) km 6 baada ya Morogoro.

## Hatua ya 4: Trafiki
- Tumia `traffic_schedule.json`: msongamano wa gari unabadilika kwa saa
  (kuchoka saa 6-9 na 4-7 mchana; usiku ni utulivu).
- Weka traffic paths kufuatana na barabara katika Mod Editor.

## Hatua ya 5: Ukaguzi (angalia QA_CHECKLIST.md)
Kisha: **Export .bussidmod** kutoka kwenye Mod Editor window.