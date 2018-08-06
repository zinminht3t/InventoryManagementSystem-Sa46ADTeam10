    $(document).ready(function () {
                $.ajax({
                    url: '@Url.Action("GetNotifications", "Home")',
                    data: {},
                    type: 'GET',
                    success: function (data) {
                        $(notifications).html(data);
                    }
                });
            setInterval(function () {
                $.ajax({
                    url: '@Url.Action("GetNotifications", "Home")',
                        data: {},
                        type: 'GET',
                        success: function (data) {
                            $(notifications).html(data);
                        }
                    });
                }, 10000);



                    });