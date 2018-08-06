        var count = 0;
        function generate() {
            $("#myModal").show();
            if (count == 0)
                {
                jQuery('#qrgenerate').qrcode('@Model.Reqid');
                count++;
            }
        }
