 var approve = document.getElementById("inline-radio1");
        var checkedApprove = approve.checked;

        var mapcode;
        var loc = [];

        window.onload = mapLoad;
        function mapLoad() {
            loc.push([@ViewBag.OldLat, @ViewBag.OldLng]);
            loc.push([@ViewBag.NewLat, @ViewBag.NewLng]);
            initMap(loc[0][0], loc[0][1],
                loc[1][0], loc[1][1]);
        }

        function initMap(lat1, lng1, lat2, lng2) {
            mapcode = new google.maps.Geocoder();
            var lnt1 = new google.maps.LatLng(lat1, lng1);
            var lnt2 = new google.maps.LatLng(lat2, lng2);
            var marker1;
            var marker2;
            var diagChoice1 = {
                zoom: 15,
                center: lnt1,
                diagId: google.maps.MapTypeId.ROADMAP
            }
            var diagChoice2 = {
                zoom: 15,
                center: lnt2,
                diagId: google.maps.MapTypeId.ROADMAP
            }
            oldM = new google.maps.Map(document.getElementById('mapOld'), diagChoice1);
            newM = new google.maps.Map(document.getElementById('mapNew'), diagChoice2);

            var infowindow1 = new google.maps.InfoWindow();
            var infowindow2 = new google.maps.InfoWindow();

            mark(oldM, lnt1, "Previous <br/> Loaction", marker1, infowindow1);
            mark(newM, lnt2, "Requested <br/> Location", marker2, infowindow2);

            function mark(map, location, text, marker, iw) {
                marker = new google.maps.Marker({
                    map: map,
                    draggable: false,
                    position: location
                });
                marker.setTitle(text);
                infoWin(map, marker, text);
                marker.addListener('click', function () {
                    infoWin(map, marker, marker.getTitle(), iw);
                });
                function infoWin(MAP, MARKER, info, iWin) {
                    iWin = new google.maps.InfoWindow();
                    iWin.setContent(info);
                    iWin.open(MAP, MARKER);
                }
            }


        }