        var myArray = new Array();

        function addtoarray(source) {


            var checkboxname = "checkbox-" + source;
            console.log(checkboxname);

            selectedcheckbox = document.getElementById(checkboxname);

            if (selectedcheckbox.checked) {
                if (!myArray.includes(source)) {
                    myArray.push(source);
                }
            }
            else {
                if (myArray.includes(source)) {
                    var index = myArray.indexOf(source);
                    if (index > -1) {
                        myArray.splice(index, 1);
                    }
                }
            }
        }


    function Checked() {
        var url1 = '@Url.Action("Adjustment", "Clerk")';
        if (myArray.length > 0) {
            $.ajax({
                type: "POST",
                url: "@Url.Action("Inventory", "Clerk")",
                data: { Invid: myArray },
                success: function (ResultSuccess) {
                    window.location.href = url1;
                },
            })
        }
        else {
            swal(
                'Adjustment',
                'Please select some items to raise adjustment',
                'error'
            );
        }
    }