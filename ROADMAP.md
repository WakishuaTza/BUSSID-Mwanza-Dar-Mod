# BUSSID Mwanza-Dar Route Mod - Development Roadmap

## Phase 1: Foundation (Week 1-2) ✅
- [x] Create mod repository structure
- [x] Define waypoints (12 cities)
- [x] Define sections (S01-S10)
- [x] Create spawn/restore point data
- [x] Document setup instructions

## Phase 2: Route Building (Week 3-4)
- [ ] Generate road mesh in Unity Editor
- [ ] Place 2-lane main trunk road (A7 highway)
- [ ] Add road shoulders and drainage
- [ ] Implement sharp curve markers
- [ ] Test road colliders for gameplay

## Phase 3: Scenery & Vegetation (Week 5-6)
- [ ] Scatter ~2,500+ trees per region
- [ ] Region-specific vegetation:
  - Mwanza-Shinyanga: Acacia, Baobab
  - Singida-Dodoma: Miombo woodland, Highland grass
  - Dodoma-Morogoro: Montane forest
  - Morogoro-Dar: Coastal vegetation, Coconut palms
- [ ] Add grass patches and terrain details
- [ ] Optimize vegetation with LOD levels

## Phase 4: Urban Development (Week 7-8)
- [ ] Place 414+ buildings across 12 towns:
  - Bus stations (major hubs): 6
  - Petrol stations: ~40 scattered
  - Markets: ~50 across towns
  - Schools: ~20
  - Police posts: ~12
  - Residential buildings: ~250+
  - Clinics/Hospitals: ~15
- [ ] Add town signs and road markers
- [ ] Create town centers with parking areas

## Phase 5: Traffic & Dynamics (Week 9-10)
- [ ] Implement traffic schedule JSON
- [ ] Rush hour (6-9 AM, 4-7 PM): Heavy density (0.8)
- [ ] Night time (10 PM - 5 AM): Light density (0.1-0.4)
- [ ] Configure traffic paths for AI vehicles
- [ ] Add pedestrian spawns in towns

## Phase 6: Terrain & Special Features (Week 11)
- [ ] Create terrain slopes (S07-S08: Dodoma-Morogoro)
- [ ] Add Morogoro River bridge (bridge_medium)
- [ ] Terrain heights:
  - Mwanza: 1,140m
  - Singida plateau: 1,610m
  - Dodoma: 1,650m (highest point)
  - Morogoro: 520m (descent begins)
  - Dar es Salaam: 55m (sea level)
- [ ] Add water features and drainage ditches

## Phase 7: Testing & Optimization (Week 12)
- [ ] QA Checklist verification:
  - Road colliders integrity
  - No floating objects
  - Spawn/restore testing
  - Traffic path testing
  - Performance on low/mid/high devices
  - Night lighting verification
- [ ] Performance optimization:
  - LOD implementation for vegetation
  - Mesh baking for static geometry
  - Draw call reduction
- [ ] User testing on various Android devices

## Phase 8: Export & Release (Week 13)
- [ ] Final export to .bussidmod format
- [ ] Release notes creation
- [ ] Upload to BUSSID Mod Manager
- [ ] Community feedback collection

## Resource Requirements
- Unity 2019.4 LTS
- BUSSID Mod Editor SDK
- Prefabs required: 21 total
  - Roads: 2
  - Vegetation: 4
  - Buildings: 7
  - Road furniture: 3
  - Other: 5

## Estimated World Size
- Total route distance: 102 km (1:10 scale)
- World dimensions: ~10.2 km x 5 km
- Draw distance: 500m-1km per device tier
- LOD levels: 3 (high, medium, low)

## Known Challenges
1. Large vegetation count optimization
2. Traffic AI pathfinding over varied terrain
3. Performance on mid-tier Android devices
4. Night lighting without destroying performance
5. Accurate elevation profile from real-world data

## Success Criteria
- ✅ All 12 waypoints correctly positioned
- ✅ Continuous road from Mwanza to Dar es Salaam
- ✅ 400+ buildings placed
- ✅ 2,500+ trees scattered
- ✅ Playable on Android 6.0+
- ✅ 30+ FPS on mid-tier devices
- ✅ Zero road gaps or floating objects
