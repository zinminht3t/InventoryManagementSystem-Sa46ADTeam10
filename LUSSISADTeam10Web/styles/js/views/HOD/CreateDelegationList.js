 $(document).ready(function () {
            document.getElementById('btnCreate').disabled = true;
        })

        $(function () {
            $("#datepicker1").datepicker({
                dateFormat: 'yy-mm-dd',
                showAnim: 'slide',
                disabled: true,
                onSelect: function () {
                    document.getElementById('btnCreate').disabled = false;
                }
            });



            $("#datepicker1").datepicker('setDate', null);
            $("#datepicker").datepicker({
                dateFormat: 'yy-mm-dd',
                showAnim: 'slide',
                onSelect: function (date) {
                    $("#datepicker1").datepicker("option", "minDate", date);
                    $('#datepicker1').datepicker("option", "disabled", false);
                    $("#datepicker1").datepicker("option", "minDate", date);
                    $('#datepicker1').datepicker('setDate', date);
                    $("#datepicker1").datepicker("option", "maxDate", '+2y');

                }
            });
            $("#datepicker").datepicker('setDate', 'today');
            $("#datepicker").datepicker("option", { minDate: + 0 });
        });