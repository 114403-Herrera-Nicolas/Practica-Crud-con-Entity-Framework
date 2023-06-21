$(document).ready(function () {



    $("#btn-consultar").click(function () {
        var id = $("#inputID").val();
        console.log(id)
        $.ajax({
            url: 'https://localhost:7175/api/Socio/GetSocioById/' + id,
            method: 'GET',
            datatype: 'json',
            success: function (response) {
                var fila = `
                <tbody>
                    <tr>
                        <th scope="row">${response.id}</th>
                         <td>${response.nombre}</td>
                         <td>${response.apellido}</td>
                         <td>${response.telefono}</td>
                    </tr>
                <tbody>`;
                $('#miTabla').append(fila);



                console.log(response);
            },
            error: function (error) {

                alert("No existe un Socio con el codigo proporcionado")

            }

        })
    })


})