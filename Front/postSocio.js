$(document).ready(function () {
    $('#Form').submit(function (event) {
        event.preventDefault(); // Evitar que el formulario se envíe y se recargue la página
        console.log({
            "nombre": $("#Nombre").val(),
            "apellido": $("#Apellido").val(),
            "telefono": $("#Telefono").val()
        })


        let Socio = {}
        Socio.nombre = $("#Nombre").val();
        Socio.apellido = $("#Apellido").val();
        Socio.telefono = $("#Telefono").val();
        console.log(JSON.stringify(Socio))
        $.ajax({
            url: 'https://localhost:7175/api/Socio/save',
            method: 'POST',
            datatype: 'json',
            contentType: "application/json",
            data: JSON.stringify(Socio),
            success: function (response) {
                alert("se a creado " + response.nombre + " " + response.apellido)
                $("#Nombre").val("");
                $("#Apellido").val("");
                $("#Telefono").val("");
            },
            error: function (error) {
                console.log(error);

            }


        })
    });









})