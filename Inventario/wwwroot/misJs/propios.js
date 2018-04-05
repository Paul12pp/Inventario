$('#colocar').click(function () {
    var url = "/Factura/TellMeDate";
    $.get(url, null, function (data) {
        $("#rData").html(data);
    });
});

$(document).on('change', '#ProductoId', function (event) {
    $('#Rprecio').val($("#ProductoId option:selected").text());
});




var valor = "";
$(document).on('change', '#ProductoId', function (event) {
    valor = $('#Rprecio').val($("#ProductoId option:selected").text());
});

$(document).on('change', '#ProductoId', function () {
    var opcion_seleccionada = $("#ProductoId option:selected").text();
    console.log(opcion_seleccionada);
});


