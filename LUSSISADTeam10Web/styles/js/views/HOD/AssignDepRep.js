        $(function () {
            $("#datepicker").datepicker();

            $("#datepicker").datepicker('option', "showAnim", 'slide');
            $("#datepicker").datepicker('option', { minDate: +0 });
            $("#datepicker").datepicker('setDate', 'today')
            $("#datepicker1").datepicker();
            $("#datepicker1").datepicker('option', "showAnim", 'slide');
            $("#datepicker1").datepicker('option', { minDate: +1 });
            $("#datepicker1").datepicker('setDate', 'today + 1')

        });