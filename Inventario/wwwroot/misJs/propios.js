    'use strict';
        //mostrar();
var clientes;
var proveedores;
var details;
        var productos;
        var factura;
        var factUltima;
        var detalles = [[]];
        var datos_g = [[]];
var total = 0;
var sumatoria = [[]];
var xhr = new XMLHttpRequest();
var xhr2 = new XMLHttpRequest();
var xhr3 = new XMLHttpRequest();
var xhr4 = new XMLHttpRequest();
var xhr5 = new XMLHttpRequest();
var xhr6 = new XMLHttpRequest();
var cantProd;
var cantVent;
var cantCl;
var canProv;
var facturita;


        function cargarProductos() {
            xhr.open('GET', 'http://localhost:5913/Producto/ObtenerProducto', 'true');
            xhr.responseType = 'text';
            xhr.send();
        }

function cargarClientes() {
    xhr3.open('GET', 'http://localhost:5913/Cliente/ObtenerCliente', 'true');
    xhr3.responseType = 'text';
    xhr3.send();
}

function cargarProveedores() {
    xhr4.open('GET', 'http://localhost:5913/Proveedor/ObtenerProveedor', 'true');
    xhr4.responseType = 'text';
    xhr4.send();
}

function cargarFact() {
    xhr5.open('GET', 'http://localhost:5913/Factura/ObtenerFactura', 'true');
    xhr5.responseType = 'text';
    xhr5.send();

}

function cargarDet() {
    xhr6.open('GET', 'http://localhost:5913/Detalle/ObtenerDetalle', 'true');
    xhr6.responseType = 'text';
    xhr6.send();
}

xhr6.onload = function () {
    if (xhr6.status === 200) {
        details = JSON.parse(xhr6.responseText);
        console.log(details);
    }
}

xhr5.onload = function () {
    if (xhr5.status === 200) {
        facturita = JSON.parse(xhr5.responseText);
        //console.log(facturita);
        cantVent = facturita.length;
        $('#cantVent').text(cantVent);
    }
}

xhr4.onload = function () {
    if (xhr4.status === 200) {
        proveedores = JSON.parse(xhr4.responseText);
        console.log(proveedores);
        canProv = proveedores.length;
        $('#cantProv').text(canProv);
    }
}

xhr3.onload = function () {
    if (xhr3.status === 200) {
        clientes = JSON.parse(xhr3.responseText);
        console.log(clientes);
        cantCl = clientes.length;
        $('#cantCl').text(cantCl);
    }
}

        xhr.onload = function () {
            if (xhr.status === 200) {
            productos = JSON.parse(xhr.responseText);
                console.log(productos);
                cantProd = productos.length;
            }
            for (var i = 0; i < productos.length; i++) {
                if (productos[i].name === opcion_seleccionada) {
        console.log(productos[i].price);
    if (productos[i].cantidad == 0) {
        $('#Rprecio').val(productos[i].price).text();
    $('#RDescripcion').val(productos[i].shortDescription).text();
                        $('#Rdispon').val('No disponible').text();
                        document.getElementById("RCantidad").readOnly = true;
                    }
                    else {
        $('#Rprecio').val(productos[i].price).text();
    $('#RDescripcion').val(productos[i].shortDescription).text();
                        $('#Rdispon').val(productos[i].cantidad).text();
                        document.getElementById("RCantidad").readOnly = false;
                        filita2();
                        if ($('#Rdispon').val() == 0) {
        document.getElementById("RCantidad").readOnly = true;
    }
                    }
                }
            }
        }

        function cargarFactura() {
            xhr2.open('GET', 'http://localhost:5913/Factura/ObtenerFactura', 'true');
            xhr2.responseType = 'text';
            xhr2.send();

            xhr2.onload = function () {
                if (xhr2.status === 200) {
                    factura = JSON.parse(xhr2.responseText);
                    console.log(factura);
                    factUltima = factura[factura.length - 1];
                    console.log(factUltima);
                    paso3();
                }

            }

        }

$(document).ready(function () {
    $('select').formSelect();
});

$(document).ready(function () {
   $('.sidenav').sidenav();
});

 $(document).ready(function () {
   $('.datepicker').datepicker({
         // Creates a dropdown to control month
         // Creates a dropdown of 15 years to control year
        format: 'yyyy-mm-dd'
   });
});

$(document).ready(function () {
    $('#clTbl').DataTable({
        dom: 'Bfrtip',
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }

        }
    });
});
$(document).ready(function () {
    $('#listPr').DataTable({
        dom: 'Bfrtip',
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }

        }
    });
});
$(document).ready(function () {
    $('#PrTbl').DataTable({
        dom: 'Bfrtip',
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }

        }
    });
});

$(document).ready(function () {
    $('#factTable').DataTable({
        dom: 'Bfrtip',
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
           
        }
    });
   
    //$("select").val('10');
    //$('select').addClass("browser-default");
    //$('select').material_select();
});

        var opcion_seleccionada = "";
        $(document).on('change','#ProductoId', function () {
        opcion_seleccionada = $("#ProductoId option:selected").text();
    console.log(opcion_seleccionada);
            cargarProductos();

        });
        //Tabla

        $(document).ready(function () {
        //obtenemos el valor de los input
        $('#adicionar').click(function () {
            var producto = document.getElementById("ProductoId").value;
            var rdescripcion = document.getElementById("RDescripcion").value;
            var rprecio = document.getElementById("Rprecio").value;
            var rcantidad = document.getElementById("RCantidad").value;
            var rdispon = document.getElementById("Rdispon").value;
            rcantidad = parseInt(rcantidad);
            rdispon = parseInt(rdispon);
            var importe = rcantidad * rprecio;
            var i = document.getElementById("mytable").rows.length; //contador para asignar id al boton que borrara la fila
            var descr = descricion();
            /*if (producto != "" && rdescripcion != "" && rprecio != "" && rcantidad != "" && rdispon != "") {
                if (rdescripcion == descr) {
                    console.log('Iguales');
                    filita();

                }
                else {
                    if (rcantidad > rdispon) {
                        var toastHTML = '<span>Escriba una cantidad disponible</span><button class="btn-flat toast-action">Deshacer</button>';
                        M.toast({ html: toastHTML });
                        //alert("Esciba una cantidad menor");
                        document.getElementById("RCantidad").focus();
                    }
                }
                if ( rcantidad <= rdispon) {
                    var fila = '<tr id="row' + i + '"><td class="prod">' + producto + '</td><td>' + rdescripcion + '</td><td id="pre' + i + '">' + rprecio + '</td><td id="cant' + i + '">' + rcantidad + '</td><td id="imp' + i + '">' + importe + '</td><td><button type="button" name="remove" id="' + i + '" class="btn-floating btn-small waves-effect waves-light red"><i class="material-icons">delete</i></button></td></tr>'; //esto seria lo que contendria la fila
                    $('#mytable tr:last').after(fila);
                    $("#adicionados").text(""); //esta instruccion limpia el div adicioandos para que no se vayan acumulando
                    var nFilas = $("#mytable tr").length;
                    $("#adicionados").append(nFilas - 1);
                    //le resto 1 para no contar la fila del header
                    document.getElementById("ProductoId").value = "";
                    document.getElementById("RDescripcion").value = "";
                    document.getElementById("Rprecio").value = "";
                    document.getElementById("RCantidad").value = "";
                    document.getElementById("Rdispon").value = "";
                    document.getElementById("ProductoId").focus();
                }
            }
            else {
                if (rdispon == 0) {
                    var toastHTML = '<span>Producto agotado</span><button class="btn-flat toast-action">Deshacer</button>';
                    M.toast({ html: toastHTML });
                }*/
            switch (producto != "" && rdescripcion != "" && rprecio != "" && rcantidad != "" && rdispon != "") {
                case rdescripcion == descr:
                    console.log('Iguales');
                    filita();
                    break;

                case document.getElementById("RCantidad").value > document.getElementById("Rdispon").value:
                    var toastHTML = '<span>Escriba una cantidad disponible</span><button class="btn-flat toast-action">Deshacer</button>';
                    M.toast({ html: toastHTML });
                    //alert("Esciba una cantidad menor");
                    document.getElementById("RCantidad").focus();
                    break;

                case rcantidad <= rdispon:
                    var fila = '<tr id="row' + i + '"><td class="prod">' + producto + '</td><td>' + rdescripcion + '</td><td id="pre' + i + '">' + rprecio + '</td><td id="cant' + i + '">' + rcantidad + '</td><td id="imp' + i + '">' + importe + '</td><td><button type="button" name="remove" id="' + i + '" class="btn-floating btn-small waves-effect waves-light red"><i class="material-icons">delete</i></button></td></tr>'; //esto seria lo que contendria la fila
                    $('#mytable tr:last').after(fila);
                    $("#adicionados").text(""); //esta instruccion limpia el div adicioandos para que no se vayan acumulando
                    var nFilas = $("#mytable tr").length;
                    $("#adicionados").append(nFilas - 1);
                    //le resto 1 para no contar la fila del header
                    document.getElementById("ProductoId").value = "";
                    document.getElementById("RDescripcion").value = "";
                    document.getElementById("Rprecio").value = "";
                    document.getElementById("RCantidad").value = "";
                    document.getElementById("Rdispon").value = "";
                    document.getElementById("ProductoId").focus();
                    totalito();
                    break;
                case document.getElementById("RCantidad").value == "" && document.getElementById("Rdispon").value == 0:
                    var toastHTML = '<span>Producto agotado</span><button class="btn-flat toast-action">Deshacer</button>';
                    M.toast({ html: toastHTML });
                    break;

                default:
                    console.log('no jodas');
            }

        });

    });

            $(document).on('click', '.btn-floating', function () {
                var button_id = $(this).attr("id");
                //cuando da click obtenemos el id del boton
               var prueba = $("table thead tr:eq(" + button_id+")").find("td:nth-child(4)").text();
                console.log(prueba);
                console.log(button_id);
             if (prueba <= 1) {
        $('#row' + button_id + '').remove(); //borra la fila
    //limpia el para que vuelva a contar las filas de la tabla
    $("#adicionados").text("");
                    var nFilas = $("#mytable tr").length;
                 $("#adicionados").append(nFilas - 1);
                 totalito();
             } else {
                 var button_id = $(this).attr("id");
                 var cant = $("table thead tr:eq(" + button_id + ")").find("td:nth-child(4)").text();
                 var pre = $("#pre" + button_id + "").text();
                 var imp = $("#imp" + button_id + "").text();
                 imp = parseInt(imp);
                 pre = parseInt(pre);
                 cant = cant - 1;
                 imp = cant * pre;
                 $("#cant" + button_id + "").text(cant);
                 $("#imp" + button_id + "").text(imp);
                 totalito();
               }
            });


        $(document).on('click', '.btn-floating', function () {

    });

        $(document).ready(function () {
        $("#mytable").bind("DOMSubtreeModified", function () {
            var tabla2 = document.getElementById("mytable");
            var tdsTabla2 = tabla2.getElementsByTagName("tr");
            var pp = 1;
            var btn = document.getElementsByName('remove');
            for (var i = 0; i < btn.length; i++) {
                btn[i].attributes.id = pp;
                pp++;
            }
        });

    });

        function descripcion_tabla() {

            var tabla2 = document.getElementById("mytable");
            var tdsTabla2 = tabla2.getElementsByTagName("tr");
            var cant = [];
            for (let i = 0; i < tdsTabla2.length; i++) {
        cant[i] = $("table thead tr:eq(" + i + " )").find("td:nth-child(2)").text();
    //console.log(cant[i]);
    }
            return cant;
        }

        function descricion() {
            var cant = descripcion_tabla();
            let test;
            var rdescripcion = document.getElementById("RDescripcion").value;
            for (let i = 0; i < cant.length; i++) {
                if (rdescripcion == cant[i]) {
        test = cant[i];
    //console.log(test);
    }
            }
            return test;
        }

        function filita() {
            var tabla2 = document.getElementById("mytable");
            var tdsTabla2 = tabla2.getElementsByTagName("tr");
            var cant = [];
            var canto = [];
            var canti, imp, pre;
            var rcantidad = document.getElementById("RCantidad").value;
            rcantidad = parseInt(rcantidad);
            var rdescripcion = document.getElementById("RDescripcion").value;
            for (let i = 0; i < tdsTabla2.length; i++) {
        cant[i] = $("table thead tr:eq(" + i + " )").find("td:nth-child(2)").text();
    canto[i] = $("table thead tr:eq(" + i + ")").find("td:nth-child(4)").text();
                if (rdescripcion == cant[i]) {
        console.log(cant[i]);
    console.log($("#cant" + i + "").text());
                    pre = $("#pre" + i + "").text();
                    imp = $("#imp" + i + "").text();
                    canti = $("#cant" + i + "").text();
                    canti = parseInt(canti) + rcantidad;
                    imp = parseInt(imp);
                    pre = parseInt(pre);
                    imp = canti * pre;
                    $("#cant" + i + "").text(canti);
                    $("#imp" + i + "").text(imp);
                    console.log(imp);
                }
                //console.log(cant[i]);
                //canto = canto + rcantidad;
                //$("#cant" + i + "").text(canto);

            }
            document.getElementById("ProductoId").value = "";
            document.getElementById("RDescripcion").value = "";
            document.getElementById("Rprecio").value = "";
            document.getElementById("RCantidad").value = "";
            document.getElementById("Rdispon").value = "";
            document.getElementById("ProductoId").focus();
            totalito();
        }
        var elim = [];
        $(document).ready(function () {
        $("#elim").click(function () {
            var valores = [];
            var pipo = "";
            $(".prod").parent("tr").find("td").each(function () {
                if ($(this).text() != "delete") {
                    valores += $(this).text() + " ";
                }
            });
            $("td").each(function () {
                pipo = $(this).text();
            });
            valores = valores + "\n";
            elim = valores;
            console.log(valores);
        });
    });

        function facturar () {
        detalles.shift();
    console.log(detalles);

                ///POST
                var i = 0;
                for (i = 0; i < detalles.length; i++) {
                    if (detalles[i] != null) {
        $.ajax({
            type: "POST",
            url: "/Detalle/Create",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(detalles[i]),
            success: function (result) {
                console.log('Data received: ');
                console.log(result);

            },
            failure: function (errMsg) {
                alert(errMsg);
            }
        });
    }
                }
                console.log(detalles);
            datos_generar();

        }
        function cargadetalles() {
            ///DETALLES E ID PRODUCTO
            var tabla2 = document.getElementById("mytable");
            var tdsTabla2 = tabla2.getElementsByTagName("tr");
            var i = 0;
            var f = 0
            var ilo = ['', 'ProductoId', 'Descripcion', 'Precio', 'Cantidad', 'Importe'];
            for (i = 0; i < tdsTabla2.length; i++) {
                for (f = 0; f < 6; f++) {

        detalles[i] = {
            FacturaId: factUltima.facturaId,
            ProductoId: parseInt($("table thead tr:eq(" + i + ")").find("td:nth-child(1)").text()),
            //Descripcion: $("table thead tr:eq(" + i + ")").find("td:nth-child(2)").text(),
            Precio: parseInt($("table thead tr:eq(" + i + ")").find("td:nth-child(3)").text()),
            Cantidad: parseInt($("table thead tr:eq(" + i + ")").find("td:nth-child(4)").text()),
            Importe: parseInt($("table thead tr:eq(" + i + ")").find("td:nth-child(5)").text())
        }
    }
    }
            paso4();
        }
        function paso1() {
        console.log('paso 1');
    var factura = {
        ClienteId: $('#ClienteId').val(),
        Fecha: $('#Fecha').val()
            }
            if (factura != null) {
        $.ajax({
            type: "POST",
            url: "/Factura/Create",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(factura),
            success: function (result) {
                console.log('Data received: ');
                console.log(result);
                paso2();
            },
            failure: function (errMsg) {
                alert(errMsg);
            }
        });
    }
            console.log(factura);
        }
        function paso2() {
        console.log('paso 2');
    cargarFactura();
        }
        function paso3() {
        console.log('paso 3');
    cargadetalles();
        }
        function paso4() {
        console.log('paso 4');
    facturar();
        }

        function paso5() {
        console.log('paso 5');
    ocultaBtn();
        }

function ocultaBtn() {

    document.getElementById('adicionar').style.display = 'none';
    document.getElementById('nuevo').style.display = 'none';
    document.getElementById('facturar').style.display = 'none';
    document.getElementById('list').style.display = 'none';
    document.getElementById('print').style.display = '';
    document.getElementById('expdf').style.display = '';
    document.getElementById('expcsv').style.display = '';
    document.getElementById('cancelar').style.display = '';

}

function muestraBtn() {

    document.getElementById('adicionar').style.display = '';
    document.getElementById('nuevo').style.display = '';
    document.getElementById('facturar').style.display = '';
    document.getElementById('list').style.display = '';
    document.getElementById('print').style.display = 'none';
            document.getElementById('expdf').style.display = 'none';
        document.getElementById('expcsv').style.display = 'none';
        document.getElementById('cancelar').style.display = 'none';

}

function limpiaTbl(){
            var tableHeaderRowCount = 1;
            var table = document.getElementById('mytable');
            var rowCount = table.rows.length;
            for (var i = tableHeaderRowCount; i < rowCount; i++) {
        table.deleteRow(tableHeaderRowCount);
    }
            document.getElementById("Rtotal").innerHTML = "";
            $('#Rprecio').val("").text();
            $('#RDescripcion').val('').text();
            $('#Rdispon').val('').text();
            $("RCantidad").val('').text();
}
function limpiaTbl2() {
    var tableHeaderRowCount = 1;
    var table = document.getElementById('mytable');
    var rowCount = table.rows.length;
    for (var i = tableHeaderRowCount; i < rowCount; i++) {
        table.deleteRow(tableHeaderRowCount);
    }
    document.getElementById("Rtotal").innerHTML = "";
    $('#Rprecio').val("").text();
    $('#RDescripcion').val('').text();
    $('#Rdispon').val('').text();
    $("RCantidad").val('').text();
    muestraBtn();
    
}

        function filita2() {
            var tabla2 = document.getElementById("mytable");
            var tdsTabla2 = tabla2.getElementsByTagName("tr");
            var des = [];
            var dad = [];
            var canti, imp, pre;
            var rcantidad = document.getElementById("Rdispon").value;
            rcantidad = parseInt(rcantidad);
            var rdescripcion = document.getElementById("RDescripcion").value;
            for (let i = 0; i < tdsTabla2.length; i++) {
        des[i] = $("table thead tr:eq(" + i + " )").find("td:nth-child(2)").text();
    dad[i] = $("table thead tr:eq(" + i + ")").find("td:nth-child(4)").text();
                if (rdescripcion == des[i]) {
        console.log(des[i]);
    canti = $("#cant" + i + "").text();
                    canti = parseInt(canti);
                    rcantidad = rcantidad - canti;
                    document.getElementById("Rdispon").value = rcantidad;
                }
                //console.log(cant[i]);
                //canto = canto + rcantidad;
                //$("#cant" + i + "").text(canto);

            }
        }

        ///pdf
        function datos_generar() {
            var tabla2 = document.getElementById("mytable");
            var tdsTabla2 = tabla2.getElementsByTagName("tr");
            var i = 0;
            var f = 0
            var ilo = ['', 'ProductoId', 'Descripcion', 'Precio', 'Cantidad', 'Importe'];
            for (i = 0; i < tdsTabla2.length; i++) {
                for (f = 0; f < 6; f++) {

        datos_g[i] = [

            $("table thead tr:eq(" + i + ")").find("td:nth-child(1)").text(),
            $("table thead tr:eq(" + i + ")").find("td:nth-child(2)").text(),
            $("table thead tr:eq(" + i + ")").find("td:nth-child(3)").text(),
            $("table thead tr:eq(" + i + ")").find("td:nth-child(4)").text(),
            $("table thead tr:eq(" + i + ")").find("td:nth-child(5)").text()
        ]
    }
    }
            datos_g.shift();
            paso5();
        }

        function generarDesc() {
            var pdf = new jsPDF();
            pdf.setFontSize(22)
            pdf.text(160, 20, "Factura");
            pdf.setFontSize(12)
            pdf.text(160, 40, "No. Factura: " + factUltima.facturaId + "");
            pdf.text(160, 45, "Fecha: " + document.getElementById("Fecha").value+"");
            pdf.setFontSize(12)
            pdf.text(15, 50, "Nombre Cliente:  " + $("#ClienteId option:selected").text()+ "");

            var columns = ["Codigo", "Descripcion", "Precio", "Cantidad", "Importe"];

            pdf.autoTable(columns, datos_g,
                {margin: {top: 55 } },

            );
            let finalY = pdf.autoTable.previous.finalY+10; // The y position on the page
            pdf.text(155, finalY, "Total: " + total + "")
            //Print
            //pdf.autoPrint();
            //window.open(pdf.output('bloburl'), '_blank');
            //Save
            pdf.save('mipdf.pdf');
            muestraBtn();
            limpiaTbl();

        }

 function generarImpr() {
            var pdf = new jsPDF();
            pdf.setFontSize(22)
            pdf.text(160, 20, "Factura");
            pdf.setFontSize(12)
            pdf.text(160, 40, "No. Factura: " + factUltima.facturaId + "");
            pdf.text(160, 45, "Fecha: " + document.getElementById("Fecha").value + "");
            pdf.setFontSize(12)
            pdf.text(15, 50, "Nombre Cliente:  " + $("#ClienteId option:selected").text() + "");

            var columns = ["Codigo", "Descripcion", "Precio", "Cantidad", "Importe"];

            pdf.autoTable(columns, datos_g,
                {margin: {top: 55 } },

            );
            let finalY = pdf.autoTable.previous.finalY + 10; // The y position on the page
            pdf.text(155, finalY, "Total: " + total + "");
            //Print
            pdf.autoPrint();
            window.open(pdf.output('bloburl'), '_blank');
            //Save
            //pdf.save('mipdf.pdf');
            muestraBtn();
            limpiaTbl();
            var toastHTML = '<span>Si la ventana no abre, desbloquee las ventanas emergentes</span><button class="btn-flat toast-action">Deshacer</button>';
            M.toast({ html: toastHTML });

}
function genenerarCsv(){
 
    var csv = 'Factura\nTotal:' + total+'\nCodigo,Descripcion,Precio,Cantidad,Importe\n';
    datos_g.forEach(function (row) {
            csv += row.join(',');
            csv += "\n";
    });
    console.log(csv);
    var hiddenElement = document.createElement('a');
    hiddenElement.href = 'data:text/csv;charset=utf-8,' + encodeURI(csv);
    hiddenElement.target = '_blank';
    hiddenElement.download = 'people.csv';
    hiddenElement.click();
    muestraBtn();
    limpiaTbl();
}

        $(document).ready(function () {
        $('#nuevo').on('click', function () {
            var tableHeaderRowCount = 1;
            var table = document.getElementById('mytable');
            var rowCount = table.rows.length;
            for (var i = tableHeaderRowCount; i < rowCount; i++) {
                table.deleteRow(tableHeaderRowCount);
            }
            document.getElementById("Rtotal").innerHTML = "";
            $('#Rprecio').val("").text();
            $('#RDescripcion').val('').text();
            $('#Rdispon').val('').text();
            $("RCantidad").val('').text();
        });
    });

        function totalito() {
            var tabla2 = document.getElementById("mytable");
            var tdsTabla2 = tabla2.getElementsByTagName("tr");
            var i = 0;
            var f = 0;
            var ilo = ['', 'ProductoId', 'Descripcion', 'Precio', 'Cantidad', 'Importe'];
            for (i = 0; i < tdsTabla2.length; i++) {
                for (f = 0; f < 6; f++) {

        sumatoria[i] = {

            ProductoId: parseInt($("table thead tr:eq(" + i + ")").find("td:nth-child(1)").text()),
            //Descripcion: $("table thead tr:eq(" + i + ")").find("td:nth-child(2)").text(),
            Precio: parseInt($("table thead tr:eq(" + i + ")").find("td:nth-child(3)").text()),
            Cantidad: parseInt($("table thead tr:eq(" + i + ")").find("td:nth-child(4)").text()),
            Importe: parseInt($("table thead tr:eq(" + i + ")").find("td:nth-child(5)").text())
        }
    }
    }
            sumatoria.shift();
            var n = 0;
            total = 0;
            for (n = 0; n < sumatoria.length; n++) {
        total += sumatoria[n].Importe;
    }
            document.getElementById("Rtotal").innerHTML = total;
        }
        ///fin pdf

google.charts.load('current', { packages: ['corechart', 'bar'] });
google.charts.setOnLoadCallback(drawAxisTickColors);

function drawAxisTickColors() {
    var data = google.visualization.arrayToDataTable([
        ['City', '2010 Population', '2000 Population'],
        ['New York City, NY', 8175000, 8008000],
        ['Los Angeles, CA', 3792000, 3694000],
        ['Chicago, IL', 2695000, 2896000],
        ['Houston, TX', 2099000, 1953000],
        ['Philadelphia, PA', 1526000, 1517000]
    ]);

    var options = {
        title: 'Population of Largest U.S. Cities',
        chartArea: { width: '50%' },
        hAxis: {
            title: 'Total Population',
            minValue: 0,
            textStyle: {
                bold: true,
                fontSize: 12,
                color: '#4d4d4d'
            },
            titleTextStyle: {
                bold: true,
                fontSize: 18,
                color: '#4d4d4d'
            }
        },
        vAxis: {
            title: 'City',
            textStyle: {
                fontSize: 14,
                bold: true,
                color: '#848484'
            },
            titleTextStyle: {
                fontSize: 14,
                bold: true,
                color: '#848484'
            }
        }
    };
    var chart = new google.visualization.BarChart(document.getElementById('chart_div'));
    chart.draw(data, options);
}


cargarFact();
cargarProductos();
cargarClientes();
cargarProveedores();
cargarDet();