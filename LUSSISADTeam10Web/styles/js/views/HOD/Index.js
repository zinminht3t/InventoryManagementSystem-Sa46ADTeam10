 var lbls = [];
        var dt = [];
        var urls = '@Url.Action("GetChartData", "HOD")';
        var ctx = document.getElementById("myChart");
        var myChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: lbls,
                datasets: [{
                    data: dt,
                    backgroundColor: [
                        'rgba(128,201,190, 0.65)',
                        'rgba(242,226,205, 0.65)',
                        'rgba(233,151,144, 0.65)',
                        'rgba(215,210,203, 0.65)',
                        'rgba(72,105,127, 0.65)'
                    ],
                    borderColor: [
                        'rgba(128,201,190,1)',
                        'rgba(242,226,205, 1)',
                        'rgba(233,151,144, 1)',
                        'rgba(215,210,203, 1)',
                        'rgba(72,105,127, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                title: {
                    display: true,
                    text: 'Top 5 Items (Frequently Ordered)'
                },
                legend: {
                    display: false
                },
                tooltips: {
                    callbacks: {
                        label: function (tooltipItem) {
                            return tooltipItem.yLabel;
                        }
                    }
                },
                scales: {
                    xAxes: [{
                        gridLines: {
                            display: false
                        },
                        ticks: {
                            autoSkip: true,
                            maxRotation: 45,
                            minRotation: 45,
                        }
                    }],
                    yAxes: [{
                        gridLines: {
                            borderDash: [2, 5]
                        },
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                },
                animation: {
                    easing: 'easeOutQuart'
                }
            }
        });
        ctx.style.display = "none";
        function loadData() {
            $.ajax({
                type: "POST",
                url: urls,
                contentType: 'application/json; charset=utf-8',
                error: function (err) {
                    alert('Error: ' + err.statusText);
                },
                success: function (result) {
                    myChart.data.labels = result["labels"];
                    myChart.data.datasets[0].data = result["data"];
                    ctx.style.display = "block";
                },
                async: false,
                processData: false,
            });
            myChart.update();
        }
        window.onload = loadData;