$(function () {
    /* ChartJS
     * -------
     * Data and config for chartjs
     */

    var countryList = JSON.parse(countCountries);
    var usersList = JSON.parse(countUsers);
    var requetsHistoryData = JSON.parse(requestsHistory);

    var monthsList = []
    var currentDate = new Date();
    var currentMonth = currentDate.getMonth(); // Months are zero based

    //console.log(currentDate);
    //console.log(currentMonth);

    currentDate.setMonth(currentDate.getMonth() - 4); // decrese 4 months only (not 5 months) because months are 0 based
    //console.log(currentDate);

     // currentDate.getMonth(): will return 6 months earlier

    for (var i = currentDate.getMonth(); i <= currentMonth; i++) {
        monthsList.push(i);
    }

    
    //console.log(monthsList)

    'use strict';
    var data = {
        labels: ["5", "6", "7", "8", "9", "10"],
        datasets: [{
            label: '# of Votes',
            data: [10, 19, 3, 5, 2, 3],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1,
            fill: false
        }]
    };
    var ByLeveldata = {
        labels: ["School", "University", "Post grads"],
        datasets: [{
            label: '# of Users',
            data: [230, 950, 1300],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            // borderWidth: 1,
            fill: false
        }]
    };
    var Countrydata = {
        labels: countryList, //here
        datasets: [{
            label: '# of Users',
            data: usersList,
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            // borderWidth: 1,
            fill: false
        }]
    };


    var multiLineData = { // here for Review history details, ==> list of objects

        labels: monthsList,
        datasets: requetsHistoryData,

        //datasets: [{
        //    label: 'CV Reviews',
        //    data: [12, 19, 3, 5, 2, 3],
        //    borderColor: [
        //        '#587ce4'
        //    ],
        //    borderWidth: 2,
        //    fill: false
        //},
        //{
        //    label: 'LinkedIn Reviews',
        //    data: [5, 23, 7, 12, 42, 23],
        //    borderColor: [
        //        '#ede190'
        //    ],
        //    borderWidth: 2,
        //    fill: false
        //},
        //{
        //    label: 'IV Simulations',
        //    data: [15, 10, 21, 32, 12, 33],
        //    borderColor: [
        //        '#f44252'
        //    ],
        //    borderWidth: 2,
        //    fill: false
        //}
        //]
    };
    var options = {
        responsive: true,
        interaction: {
            mode: 'index',
            intersect: true,
        },
        stacked: true,
        plugins: {
            title: {
                display: true,
                text: 'Reviews and Simulations'
            }
        },
    };


    var doughnutPieData = {
        datasets: [{
            data: [30, 40, 30],
            backgroundColor: [
                'rgba(255, 99, 132, 0.5)',
                'rgba(54, 162, 235, 0.5)',
                'rgba(255, 206, 86, 0.5)',
                'rgba(75, 192, 192, 0.5)',
                'rgba(153, 102, 255, 0.5)',
                'rgba(255, 159, 64, 0.5)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
        }],

        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'Pink',
            'Blue',
            'Yellow',
        ]
    };
    var doughnutPieOptions = {
        responsive: true,
        animation: {
            animateScale: true,
            animateRotate: true
        }
    };
    var areaData = {
        labels: ["2013", "2014", "2015", "2016", "2017"],
        datasets: [{
            label: '# of Votes',
            data: [12, 19, 3, 5, 2, 3],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1,
            fill: true, // 3: no fill
        }]
    };

    var areaOptions = {
        plugins: {
            filler: {
                propagate: true
            }
        },
        scales: {
            yAxes: [{
                gridLines: {
                    color: "rgba(204, 204, 204,0.1)"
                }
            }],
            xAxes: [{
                gridLines: {
                    color: "rgba(204, 204, 204,0.1)"
                }
            }]
        }
    }

    var multiAreaData = {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: [{
            label: 'Facebook',
            data: [8, 11, 13, 15, 12, 13, 16, 15, 13, 19, 11, 14],
            borderColor: ['rgba(255, 99, 132, 0.5)'],
            backgroundColor: ['rgba(255, 99, 132, 0.5)'],
            borderWidth: 1,
            fill: true
        },
        {
            label: 'Twitter',
            data: [7, 17, 12, 16, 14, 18, 16, 12, 15, 11, 13, 9],
            borderColor: ['rgba(54, 162, 235, 0.5)'],
            backgroundColor: ['rgba(54, 162, 235, 0.5)'],
            borderWidth: 1,
            fill: true
        },
        {
            label: 'Linkedin',
            data: [6, 14, 16, 20, 12, 18, 15, 12, 17, 19, 15, 11],
            borderColor: ['rgba(255, 206, 86, 0.5)'],
            backgroundColor: ['rgba(255, 206, 86, 0.5)'],
            borderWidth: 1,
            fill: true
        }
        ]
    };

    var multiAreaOptions = {
        plugins: {
            filler: {
                propagate: true
            }
        },
        elements: {
            point: {
                radius: 0
            }
        },
        scales: {
            xAxes: [{
                gridLines: {
                    display: false
                }
            }],
            yAxes: [{
                gridLines: {
                    display: false
                }
            }]
        }
    }

    var scatterChartData = {
        datasets: [{
            label: 'First Dataset',
            data: [{
                x: -10,
                y: 0
            },
            {
                x: 0,
                y: 3
            },
            {
                x: -25,
                y: 5
            },
            {
                x: 40,
                y: 5
            }
            ],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        },
        {
            label: 'Second Dataset',
            data: [{
                x: 10,
                y: 5
            },
            {
                x: 20,
                y: -30
            },
            {
                x: -25,
                y: 15
            },
            {
                x: -10,
                y: 5
            }
            ],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)',
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)',
            ],
            borderWidth: 1
        }
        ]
    }

    var scatterChartOptions = {
        scales: {
            xAxes: [{
                type: 'linear',
                position: 'bottom',
                gridLines: {
                    color: "rgba(204, 204, 204,0.1)"
                }
            }],
            yAxes: [{
                gridLines: {
                    color: "rgba(204, 204, 204,0.1)"
                }
            }]
        }
    }
    // Get context with jQuery - using jQuery's .get() method.
    if ($("#barChart").length) {
        var barChartCanvas = $("#barChart").get(0).getContext("2d");
        // This will get the first returned node in the jQuery collection.
        var barChart = new Chart(barChartCanvas, {
            type: 'pie',
            data: Countrydata,
            options: {}
        });
    }
    if ($("#barChartByLevel").length) {
        var barChartCanvas = $("#barChartByLevel").get(0).getContext("2d");
        // This will get the first returned node in the jQuery collection.
        var barChart = new Chart(barChartCanvas, {
            type: 'pie',
            data: ByLeveldata,
            options: {}
        });
    }

    if ($("#lineChart").length) {
        var lineChartCanvas = $("#lineChart").get(0).getContext("2d");
        var lineChart = new Chart(lineChartCanvas, {
            type: 'line',
            data: data,
            options: options
        });
    }

    if ($("#linechart-multi").length) {
        var multiLineCanvas = $("#linechart-multi").get(0).getContext("2d");
        var lineChart = new Chart(multiLineCanvas, {
            type: 'line',
            data: multiLineData,
            //options: options
            options: {
                responsive: true,
                //plugins: {
                //    legend: {
                //        labels: {
                //            // This more specific font property overrides the global property
                //            font: {
                //                size: 14
                //            }
                //        }
                //    }
                //},
                scales: {
                    xAxes: [{
                        //type: 'time',
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Month'
                        },

                    }],
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: '#Requests'
                        },

                    }]
                }
            }
        });
    }

    if ($("#areachart-multi").length) {
        var multiAreaCanvas = $("#areachart-multi").get(0).getContext("2d");
        var multiAreaChart = new Chart(multiAreaCanvas, {
            type: 'line',
            data: multiAreaData,
            options: multiAreaOptions
        });
    }

    if ($("#doughnutChart").length) {
        var doughnutChartCanvas = $("#doughnutChart").get(0).getContext("2d");
        var doughnutChart = new Chart(doughnutChartCanvas, {
            type: 'doughnut',
            data: doughnutPieData,
            options: doughnutPieOptions
        });
    }

    if ($("#pieChart").length) {
        var pieChartCanvas = $("#pieChart").get(0).getContext("2d");
        var pieChart = new Chart(pieChartCanvas, {
            type: 'pie',
            data: doughnutPieData,
            options: doughnutPieOptions
        });
    }

    if ($("#areaChart").length) {
        var areaChartCanvas = $("#areaChart").get(0).getContext("2d");
        var areaChart = new Chart(areaChartCanvas, {
            type: 'line',
            data: areaData,
            options: areaOptions
        });
    }

    if ($("#scatterChart").length) {
        var scatterChartCanvas = $("#scatterChart").get(0).getContext("2d");
        var scatterChart = new Chart(scatterChartCanvas, {
            type: 'scatter',
            data: scatterChartData,
            options: scatterChartOptions
        });
    }

    if ($("#browserTrafficChart").length) {
        var doughnutChartCanvas = $("#browserTrafficChart").get(0).getContext("2d");
        var doughnutChart = new Chart(doughnutChartCanvas, {
            type: 'doughnut',
            data: browserTrafficData,
            options: doughnutPieOptions
        });
    }
});