$(function () {
    $("#listaModelo").DataTable({
        "oLanguage": {
            "sSearch": "Buscar: ",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ registros",
            "sInfoFiltered": "(filtrados de _MAX_ registros en total)",
            "sInfoEmpty": "Mostrando 0 a 0 de 0 registros",
            "oPaginate": {
                "sFirst": "Primera",
                "sLast": "Última",
                "sPrevious": "Anterior",
                "sNext": "Siguiente"
            },
            "sSearchPlaceholder": "Ingrese busqueda...",
        },

    });
});