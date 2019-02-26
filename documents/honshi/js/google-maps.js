	/*!
 	* GM Google Maps
 	* version: 1.1 (10 April, 2016)
 	* require: jQuery v1.12+
 	*/


        function initMap() {
          

        // Create a map object, and include the MapTypeId to add
        // to the map type control.
        var uluru = {lat: 40.9215131, lng: -73.8554112}; // CHANGE COORDINATES HERE // // CHANGE COORDINATES HERE //        
        var map = new google.maps.Map(document.getElementById('map'), {
          zoom: 15,
          mapTypeControlOptions: {
            mapTypeIds: ['roadmap', 'satellite', 'hybrid', 'terrain',
                    'styled_map']
          },
          scrollwheel: false,
          draggable: true,
          center: uluru
        });

        var marker = new google.maps.Marker({
          position: uluru,
          map: map
        });
        var infowindow = new google.maps.InfoWindow({
               content:"We Are Here"
            });
        
        var marker = new google.maps.Marker({
          position: uluru,
          map: map
        });
        var infowindow = new google.maps.InfoWindow({
               content:"We Are Here"
            });
        
            infowindow.open(map,marker);

      }


