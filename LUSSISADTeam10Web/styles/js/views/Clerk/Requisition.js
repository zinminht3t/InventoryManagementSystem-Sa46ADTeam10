        function ConfirmDelete () {
            $("#myModal").modal('show');
        }


        function selectall(source) {
            checkboxes = document.getElementsByName('reqids');
            for (var i = 0, n = checkboxes.length; i < n; i++) {
                checkboxes[i].checked = source.checked;
            }
            ShowButton();
        }

        function ShowButton() {
            if ($('.theclass:checkbox:checked').length > 0) {
                document.getElementById('btnApproveAll').style.display = "block";
            }
            else {
                document.getElementById('btnApproveAll').style.display = "none";
            }
        }

        function ApproveAll() {
            $("#loaderDiv").show();
            var myArray = new Array();
            $('.theclass:checkbox:checked').each(function () {
                myArray.push($(this).val());
            });

            console.log(myArray);

            var url1 = '@Url.Action("StationaryRetrievalForm", "Clerk")';
                $.ajax({
                    type: "POST",
                    url: "@Url.Action("ApproveAllRequisitons", "Clerk")",
                    data: { reqids: myArray },
                    success: function (ResultSuccess) {
                        $("#loaderDiv").hide();
                        $("#myModal").hide();
                        window.location.href = url1;
                    },
                })
         }