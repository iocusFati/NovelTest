using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MapUI
    {
        private readonly Transform _marker;
        
        private readonly List<LocationUI> _locations;
        private readonly Button _dungeonButton;
        private readonly Image _dungeonIcon;

        public MapUI(Transform marker, List<LocationUI> locations, Button dungeonButton, Image dungeonIcon)
        {
            _marker = marker;
            _locations = locations;
            _dungeonButton = dungeonButton;
            _dungeonIcon = dungeonIcon;
        }

        public void SetQuestMarkerAbove(string location)
        {
            if (_locations.Any(locationUI => locationUI.LocationName == location))
            {
                _marker.gameObject.SetActive(true);
                PlaceQuestMarkerAbove(location);
            }
            else
            {
                Debug.LogError("There is no location " + location);
            }
        }

        public void OpenDungeon(bool open)
        {
            _dungeonButton.interactable = open;
            _dungeonIcon.raycastTarget = open;
        }

        private void PlaceQuestMarkerAbove(string location) =>
            _marker.position = _locations
                .FirstOrDefault(locationUI => location == locationUI.LocationName)
                .PlaceForMarker.position;
    }
}