'use strict';

var xhr6 = new XMLHttpRequest();
var xhr7 = new XMLHttpRequest();
var xhr8 = new XMLHttpRequest();
//
var productos2;
var cantProd;
//
var sumaY = 0;
var sumaP = 0
var sumaB = 0;
var sumaA = 0;
var facto;
//
var sumita1 = 0
var sumita2 = 0
var sumita3 = 0
//
var details;

function cargarDet() {
    xhr6.open('GET', 'http://localhost:5913/Detalle/ObtenerDetalle', 'true');
    xhr6.responseType = 'text';
    xhr6.send();
}
//
function cargarProductos2() {
    xhr.open('GET', 'http://localhost:5913/Producto/ObtenerProducto', 'true');
    xhr.responseType = 'text';
    xhr.send();
}
//
function cargarFacto() {
    xhr8.open('GET', 'http://localhost:5913/Factura/ObtenerFactura', 'true');
    xhr8.responseType = 'text';
    xhr8.send();

}
//
xhr8.onload = function () {
    if (xhr8.status === 200) {
        facto = JSON.parse(xhr8.responseText);
        //console.log(facturita);
        sumas2();
        graph2();
    }
}
//
xhr6.onload = function () {
    if (xhr6.status === 200) {
        details = JSON.parse(xhr6.responseText);
        //console.log(details);
        paso22();
    }
}
//
xhr7.onload = function () {
    if (xhr7.status === 200) {
        productos2 = JSON.parse(xhr7.responseText);
        console.log(productos2);
        cantProd = productos2.length;
        $('#cantPro').text(cantProd);
    }
}
//
function cargarProductos() {
    xhr.open('GET', 'http://localhost:5913/Producto/ObtenerProducto', 'true');
    xhr.responseType = 'text';
    xhr.send();
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
function sumas2() {
    for (var i = 0; i < facturita.length; i++) {
        if (facturita[i].clienteId == 2) {
            //console.log(facturita[i]);
            sumita1 += 1;
        }
    }
    for (var i = 0; i < facturita.length; i++) {
        if (facturita[i].clienteId == 1004) {
            //console.log(facturita[i]);
            sumita2 += 1;
        }
    }
    for (var i = 0; i < facturita.length; i++) {
        if (facturita[i].clienteId == 1005) {
            //console.log(facturita[i]);
            sumita3 += 1;
        }
    }
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

function graph2() {

    var oilCanvas = document.getElementById("myChart2");

    Chart.defaults.global.defaultFontFamily = "Lato";
    Chart.defaults.global.defaultFontSize = 18;

    var oilData = {
        labels: [
            "Paul",
            "Raul",
            "Ronaldino"
        ],
        datasets: [
            {
                data: [sumita1, sumita2, sumita3],
                backgroundColor: [
                    "#B5FFAE",
                    "#A589C1",
                    "#FCA985"

                ]
            }]
    };

    var pieChart = new Chart(oilCanvas, {
        type: 'pie',
        data: oilData
    });
}
//

function paso11() {
    cargarDet();
    cargarFacto();
}
function paso22() {
    sumas();
    sumas2();
}
function paso33() {
    graph();
}

paso11();
cargarDet();
cargarProductos2();
cargarFacto();
