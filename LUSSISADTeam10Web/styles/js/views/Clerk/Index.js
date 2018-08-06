        var lbls = [];
        var dt = [];
        @for(int i=0; i<labels.Length; i++){
            <text>
        lbls.push((' @labels[i] ').replace(/&quot;/g, '"') );
            </text>
        }
        @for(int i=0; i< data.GetLength(0); i++){
            <text>
                dt.push( ' @data[i] ' );
            </text>
        }
        window.onload = dataload;
        function dataload() {
            var ctx = document.getElementById("myChart");
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: lbls,
                    datasets: [{
                        data: dt,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.45)',
                            'rgba(54, 162, 235, 0.45)',
                            'rgba(255, 206, 86, 0.45)',
                            'rgba(75, 192, 192, 0.45)',
                            'rgba(153, 102, 255, 0.45)'
                        ],
                        borderColor: [
                            'rgba(255,99,132,1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
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
                                borderDash: [2,5]
                            },
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        }