  $(document).ready(function () {

            document.getElementById("div1").style.display = "none";


            $("href").click(function () {

                $("#div1").fadeToggle();

            });
        });


          $(function () {
              $("#datepicker1").datepicker({
                  dateFormat: 'yy-mm-dd',
                  showAnim: 'slide',
                  disabled: true,
                 
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
                      $("#datepicker1").datepicker("option", "maxDate");

                  }
              });
              $("#datepicker").datepicker('setDate', 'today');
              
          });