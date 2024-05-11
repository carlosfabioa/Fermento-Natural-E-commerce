$(document).ready(function () {
    $('#searchString').on('input', function () {
        var searchString = $(this).val();
        $.ajax({
            url: '/Pao/Vitrine', // Altere para o caminho correto do seu método Vitrine
            type: 'GET',
            data: { 'searchString': searchString },
            success: function (data) {
                $('#productContainer').html(data);
            }
        });
    });
});
