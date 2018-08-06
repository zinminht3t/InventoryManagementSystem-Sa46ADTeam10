   $(function () {
            $("#datepicker").datepicker();
            $("#datepicker").datepicker('option', "showAnim", 'slide');
            $("#datepicker").datepicker('setDate', 'today')
            $("#datepicker1").datepicker();
            $("#datepicker1").datepicker('option', "showAnim", 'slide');
            $("#datepicker1").datepicker('setDate', 'today')

        });

        $(document).ready(function () {

            document.getElementById("div1").style.display = "none";


            $("href").click(function () {

                $("#div1").fadeToggle();

            });
        });