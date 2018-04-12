'use strict';

var xhr6 = new XMLHttpRequest();
//
var sumaY = 0;
var sumaP = 0
var sumaB = 0;
var sumaA = 0;
//

//
var details;

function cargarDet() {
    xhr6.open('GET', 'http://localhost:5913/Detalle/ObtenerDetalle', 'true');
    xhr6.responseType = 'text';
    xhr6.send();
}

xhr6.onload = function () {
    if (xhr6.status === 200) {
        details = JSON.parse(xhr6.responseText);
        //console.log(details);
        paso22();
    }
}
//
function sumas() {
    for (var i = 0; i < details.length; i++) {
        if (details[i].productoId == 2002) {
            //console.log(details[i]);
            sumaY += details[i].importe;
        }

    }

    for (var i = 0; i < details.length; i++) {
        if (details[i].productoId == 2003) {
            //console.log(details[i]);
            sumaP += details[i].importe;
        }
    }
    for (var i = 0; i < details.length; i++) {
        if (details[i].productoId == 2004) {
            //console.log(details[i]);
            sumaB += details[i].importe;
        }
    }
    for (var i = 0; i < details.length; i++) {
        if (details[i].productoId == 2005) {
            //console.log(details[i]);
            sumaA += details[i].importe;
        }
    }
    paso33();
}
//
///Graph
function graph() {
    var ctx = document.getElementById("myChart");
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ["Platano", "Yuca", "Batata", "Arroz"],
            datasets: [{
                label: '# de Ventas',
                data: [sumaP, sumaY, sumaB, sumaA],
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
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

//

function paso11() {
    cargarDet();
}
function paso22() {
    sumas();
    //sumas2();
}
function paso33() {
    graph();
}

paso11();
cargarDet();

