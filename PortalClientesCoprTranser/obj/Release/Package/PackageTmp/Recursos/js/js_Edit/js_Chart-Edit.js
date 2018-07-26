/*global $, document, Chart, LINECHART, data, options, window*/
$(document).ready(function () {
    "use strict";

    // ------------------------------------------------------- //
    // Pie Chart //estado cartera
    // ------------------------------------------------------ //

    $.get("/Clientes/Facturacion/estCarteraChart/").done(function (Data) {
        var _datas = Data[0];
        var PIECHART = $("#pieChart");
        var myLineChart = new Chart(PIECHART, {
            type: "doughnut",
            data: {
                labels: [
                    "Corriente",
                    "Vencida 0-30",
                    "Vencida 31-60",
                    "Vencida 61-90",
                    "Vencida mas de 90"
                ],
                datasets: [{
                    label: "Reporte",
                    data: [
                        _datas.CORRIENTE,
                        _datas.MES1,
                        _datas.MES2,
                        _datas.MES3,
                        _datas.MES4
                    ],
                    backgroundColor: [
                        "#a6ed8e",
                        "#fccf4d",
                        "#ff6107",
                        "#e9290f",
                        "#c40018"
                    ]
                }]
            },
            options: {
                legend: {
                    labels: {
                        //fontColor: "#dcdcdc",
                        fontSize: 12
                    },
                    position: "right"
                },
                tooltips: {
                    enabled: true,
                    backgroundColor: "#f6f6f6",
                    titleFontColor: "black",
                    bodyFontColor: "black",
                    caretSize: 5,
                    callbacks: {
                        label: function (tooltipItem, data) {
                            var labelValue = data["labels"][tooltipItem.index];
                            var s = data["datasets"][0].data[tooltipItem.index];
                            var valueformat = parseInt(s).toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
                            var label = labelValue + ': $ ' + valueformat;
                            return label;
                        }
                    }
                }
            }
        });
    });
    // ------------------------------------------------------- //
    // Bar Chart //cartera vencida
    // ------------------------------------------------------ //
    var _labels = [];
    var _data = [];
    $.get("/Clientes/Facturacion/opeAñoChart/").done(function (Data) {
        Data.forEach(element => {
            _labels.push(element["MES1"]);
            _data.push(element["VALOR"]);
        });
        chartOpeAño(_labels, _data);
    });

    function chartOpeAño(_labels, _data) {
        var barchar = $("#barCarteraUltimoaño");
        var myLineChart = new Chart(barchar, {
            type: "line",
            data: {
                labels: _labels,
                datasets: [{
                    label: "# Facturacion ultimo año",
                    lineTension: 0,
                    data: _data,
                    backgroundColor: ["rgba(255, 99, 132, 0.2)"],
                    borderColor: [
                        "rgba(15, 201, 230, 1)"
                    ],
                    backgroundColor: [
                        "rgba(15, 201, 230, 0.46)"
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                legend: {
                    labels: {
                        //fontColor: "#dcdcdc",
                        fontSize: 12
                    }
                },
                scales: {
                    yAxes: [{
                        stacked: true,
                        ticks: {
                            // Include a dollar sign in the ticks
                            callback: function (value, index, values) {
                                return '$' + value / 1000000 + ' mil';
                            }
                        }
                    }]
                },
                tooltips: {
                    enabled: true,
                    intersect: false,
                    backgroundColor: "#f6f6f6",
                    titleFontColor: "black",
                    bodyFontColor: "black",
                    caretSize: 5,
                    callbacks: {
                        label: function (tooltipItem, data) {
                            var label = tooltipItem.yLabel;
                            var digit = '$' + tooltipItem.yLabel.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
                            label += digit;
                            return digit;
                        }
                    }
                }
            }
        });
    }
});