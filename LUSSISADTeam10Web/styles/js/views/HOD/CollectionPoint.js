  var mapcode;
        var diag;
        var marker;
        var latt = @lat;
        var lngg = @lng;
        var list = [[1, 1]];
            @for(int i=0; i<cplist.Count; i++){

                <text>
                    list.push([@cplist[i][0], @cplist[i][1]]);
                </text>

            }
        function change() {
            var radio = Array.from(document.querySelectorAll('#radio input'));
            var value = radio.length && radio.find(r => r.checked).id;

            latt = list[value][0];
            lngg = list[value][1];

            initMap(16);
        }

        function initMap(z) {
            mapcode = new google.maps.Geocoder();
            var lnt = new google.maps.LatLng(latt, lngg);
            var diagChoice = {
                zoom: z,
                center: lnt,
                diagId: google.maps.MapTypeId.ROADMAP
            }
            diag = new google.maps.Map(document.getElementById('map_populate'), diagChoice);

            mark(lnt);

            function mark(location) {
                marker = new google.maps.Marker({
                    map: diag,
                    draggable: false,
                    position: location
                });
            }
        }
        window.onload = initMap(13);