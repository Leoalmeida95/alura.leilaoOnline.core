function readPosterURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgPoster').attr('src', e.target.result);
            $('.imagem .card-content').text(input.files[0].name);
            console.log(input.files[0].name);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

(function ($) {
    $(function(){

        $('.sidenav').sidenav();
        $('.parallax').parallax();
        $(".dropdown-trigger").dropdown({
            hover: true,
            constrainWidth: false,
            coverTrigger: false
        });
        $('.carousel.carousel-slider').carousel({
            fullWidth: true,
            indicators: true
        });
        $('.modal').modal();
        $('select').formSelect();
        $('.datepicker').datepicker({
            "format": "dd/mm/yyyy",
            autoClose: true
        });
        $('#ArquivoImagem').change(function () {
            readPosterURL(this);
        });
        $('.tooltiped').tooltip();
        $('input[type=text]:not(.browser-default), textarea').characterCounter();

        $('#btnDarLance').on('click', e => {
            e.preventDefault();

            const lanceOfertado = $('#Valor').val();
            //enviar requisição com o lance
            $.post(
                '/Interessadas/OfertaLance',
                $('#formDarLance').serialize(),
                function () {
                    console.log('lance ofertado!');
                    M.toast({ html: 'Lance ofertado com sucesso!' });

                    const formatter = new Intl.NumberFormat('pt-BR', {
                        style: 'currency',
                        currency: 'BRL',
                        minimumFractionDigits: 2
                    });

                    $("#lanceAtual").text(formatter.format(lanceOfertado));
                }
            );

        });

        $('.seguir').one('click', clickSeguir);
        $('.abandonar').one('click', clickAbandonar);

  }); // end of document ready
})(jQuery); // end of jQuery name space
