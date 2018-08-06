    $('#print').click(function () {
            window.print();
        });

            var ConfirmDelete = function () {
                $("#myModal").modal('show');
            }

        var ItemCollect = function () {
            $("#loaderDiv").show();
              var url1 = '@Url.Action("DisbursementLists", "Clerk")';

                $.ajax({
                    type: "GET",
                    url: '@Url.Action("UpdateToPreparing", "Clerk")',
                    success: function (ResultSuccess) {
                        $("#loaderDiv").hide();
                        $("#myModal").hide();
                        window.location.href = url1;
                    }
                })

            }