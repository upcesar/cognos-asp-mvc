jQuery(document).ready(function ($) {
    $('.dataTable').DataTable({
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });

    $("#filterStatus").on("change", function (e) {

        var urlFilter = "/" + $(this).data("controller") + "/Filter/" + $(this).val();
        window.location.href = urlFilter;

    });

    $(".btn-delete").on("click", function (e) {

        var deleteLink = $(this).attr("href");

        e.preventDefault();
        
        bootbox.confirm({
            buttons: {
                cancel: {
                    label: 'Cancelar',
                    className: 'btn-default'
                },
                confirm: {
                    label: 'OK',
                    className: 'btn-danger'
                },
            },
            message: 'Tem certeza de excluir este registro?',
            callback: function (result) {
                if (result == true) {
                    window.location.href = deleteLink;
                }

            },
            title: "Atenção",
        });
    });

});