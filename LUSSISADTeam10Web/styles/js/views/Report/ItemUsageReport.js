 $('#printbtn').click(function () {
            window.print();
        });


        $('select').on('change', function (event) {
            var prevValue = $(this).data('previous');
            $('select').not(this).find('option[value="' + prevValue + '"]').show();
            var value = $(this).val();
            $(this).data('previous', value);
            $('select').not(this).find('option[value="' + value + '"]').hide();
        });


        function CallChart() {
            var cv = $("#catselect").val();
            var ct = $("#catselect :selected").text();
            var d1v = $("#d1select").val();
            d1t = $("#d1select :selected").text();
            var d2v = $("#d2select").val();
            d2t = $("#d2select :selected").text();
            var d3v = $("#d3select").val();
            d3t = $("#d3select :selected").text();

            if (cv != "" && d1v != "" && d2v != "" && d3v != "") {

                document.getElementById("reporttitle").style.display = "block";
                var x = document.getElementsByClassName("hideatstart");
                var i;
                for (i = 0; i < x.length; i++) {
                    x[i].style.visibility = 'visible';
                }
                $('#reporttitle').html("Item Usage Report for " + ct + " Category between " + d1t + "," + d2t + " and " + d3t);
                $('#dept1').html(d1t);
                $('#dept2').html(d2t);
                $('#dept3').html(d3t);

                chartData(d1v, d2v, d3v, cv, $.trim(d1t), $.trim(d2t), $.trim(d3t));
            }
        }

            $("#btnGenerate").click(function () {
                chartData(2, 4, 6, 3, 'dept1', 'dept2', 'dept3');
            });

            // to built plain chart
            var datasets = [0, 0, 0];
            var lbls = ['1<sup>st</sup> Department', '2<sup>nd</sup> Department', '3<sup>rd</sup> Department'];

            var months = ['January', 'February', 'March', 'April', 'May', 'June',
                'July', 'August', 'September', 'October', 'November', 'December'];

            var ctx = document.getElementById("myChart");
            var data = {
                labels: lbls,
                datasets: [
                    {
                        label: months[ @DateTime.Today.Month-3 ],
                        backgroundColor: 'rgba(247, 55, 42, 0.45)',
                        borderColor: 'rgba(247, 55, 42, 1)',
                        borderWidth: 1,
                        data: datasets
                    },
                    {
                        label: months[ @DateTime.Today.Month-2 ],
                        backgroundColor: 'rgba(58, 175, 169, 0.45)',
                        borderColor: 'rgba(58, 175, 169, 1)',
                        borderWidth: 1,
                        data: datasets
                    },
                    {
                        label: months[ @DateTime.Today.Month-1 ],
                        backgroundColor: 'rgba(77, 31, 132, 0.45)',
                        borderColor: 'rgba(77, 31, 132, 1)',
                        borderWidth: 1,
                        data: datasets
                    }
                ]
            };

            var myBarChart = new Chart(ctx, {
                type: 'bar',
                data: data,
                options: {
                    barValueSpacing: 20,
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }],
                        xAxes: [{
                            ticks: {
                                minRotation: 0,
                                maxRotation: 0
                            }
                        }]
                    }
                }
            });
            ctx.style.display = "none";



            function chartData (s1, s2, s3, item, deptlbl1, deptlbl2, deptlbl3) {
                var req = { s1: s1, s2: s2, s3: s3, item: item};

                var urls = '@Url.Action("GetItemUsageData", "Reports")';


                $.ajax({
                    type: "POST",
                    url: urls,
                    data: JSON.stringify(req),
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    error: function (err) {
                        alert('Error: ' + err.statusText);
                    },
                    success: function (result) {
                        myBarChart.data.labels = [deptlbl1, deptlbl2, deptlbl3];
                        myBarChart.data.datasets[0].data = result["p2"];
                        myBarChart.data.datasets[1].data = result["p1"];
                        myBarChart.data.datasets[2].data = result["cur"];

                        var tds = "<td>" + "@DateTime.Today.AddMonths(-2).ToString("MMMM")" + "</td>";
                        for (row = 0; row < result["p2"].length; row++) {
                            tds += "<td>" + result["p2"][row] +"</td>"
                        }
                        $('#row1').html(tds);

                        var tds = "<td>" + "@DateTime.Today.AddMonths(-1).ToString("MMMM")" + "</td>";
                        for (row = 0; row < result["p1"].length; row++) {
                            tds += "<td>" + result["p1"][row] +"</td>"
                        }
                        $('#row2').html(tds);

                        var tds = "<td>" + "@DateTime.Today.ToString("MMMM")" + "</td>";
                        for (row = 0; row < result["cur"].length; row++) {
                            tds += "<td>" + result["cur"][row] +"</td>"
                        }
                        $('#row3').html(tds);
                    },
                    async: false,
                    processData: false
                });
                ctx.style.display = "block";
                myBarChart.update();
            };