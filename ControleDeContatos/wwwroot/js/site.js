// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

$('.btn-total-contatos').click(function () {
    var usuarioId = $(this).attr('usuario-id')
    $.ajax({
        type: 'GET',
        url: '/Usuario/ListarContatosPorUsuarioId/' + usuarioId, success: function (result) {
            $("#listaContatosUsuario").html(result);
           // getDatatable('#table-contatos-usuario');
            $('#modalContatosUsuario').modal();
        }
    });
    
});
