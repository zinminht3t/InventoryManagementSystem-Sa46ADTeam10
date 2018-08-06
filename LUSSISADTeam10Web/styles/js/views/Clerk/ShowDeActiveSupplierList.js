        var ConfirmDelete = function (SupId) {

            $("#HiddenDeleid").val(SupId);
                $("#myModal").modal('show');

            }

            var DeleteDelegation = function () {

                $("#loaderDiv").show();

                var id = $("#HiddenDeleid").val();

                $.ajax({
                    type: "GET",
                    url: '@Url.Action("Active", "Clerk")',
                    data: { id },
                    success: function (result) {
                        $("#loaderDiv").hide();
                        location.reload();
                        $("#myModal").hide();

                    }

                })

            }